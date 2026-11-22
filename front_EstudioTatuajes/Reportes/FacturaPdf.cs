using Aplicaciones_libreria.entidades;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace front_EstudioTatuajes.Reportes
{
    public class FacturaPdf
    {
        public static byte[] Generar(Facturas factura, List<DetallesFacturas> detalles)
        {
            QuestPDF.Settings.License = LicenseType.Community;
            var subtotal = detalles.Sum(d => d.Subtotal);
            var iva = subtotal * factura.IVA / 100;

            var documento = Document.Create(contenedor =>
            {
                contenedor.Page(pagina =>
                {
                    pagina.Size(PageSizes.A4);
                    pagina.Margin(40);
                    pagina.DefaultTextStyle(x => x.FontSize(11));

                    pagina.Header().Column(col =>
                    {
                        col.Item().Text("Estudio de Tatuajes").FontSize(22).Bold();
                        col.Item().Text("Factura No. " + factura.Id).FontSize(14);
                        col.Item().Text("Fecha: " + factura.Fecha.ToString("dd/MM/yyyy") +
                                        "   Hora: " + factura.Hora.ToString("HH:mm"));
                        col.Item().Text("Pago: " + (factura._Pago?.MetodoPago ?? "") +
                                        " - Ref. " + (factura._Pago?.Referencia ?? ""));
                    });

                    pagina.Content().PaddingVertical(15).Column(col =>
                    {
                        col.Item().Table(tabla =>
                        {
                            tabla.ColumnsDefinition(c =>
                            {
                                c.RelativeColumn(4);
                                c.RelativeColumn(1);
                                c.RelativeColumn(2);
                                c.RelativeColumn(2);
                            });

                            tabla.Header(h =>
                            {
                                h.Cell().Element(Celda).Text("Producto").Bold();
                                h.Cell().Element(Celda).Text("Cant.").Bold();
                                h.Cell().Element(Celda).Text("Precio").Bold();
                                h.Cell().Element(Celda).Text("Subtotal").Bold();
                            });

                            foreach (var d in detalles)
                            {
                                tabla.Cell().Element(Celda).Text(d._Producto?.Nombre ?? "");
                                tabla.Cell().Element(Celda).Text(d.Cantidad.ToString());
                                tabla.Cell().Element(Celda).Text(d.PrecioUnitario.ToString("N0"));
                                tabla.Cell().Element(Celda).Text(d.Subtotal.ToString("N0"));
                            }
                        });

                        col.Item().PaddingTop(15).AlignRight()
                            .Text("Subtotal: " + subtotal.ToString("N0"));
                        col.Item().AlignRight()
                            .Text("IVA (" + factura.IVA.ToString("0.##") + "%): " + iva.ToString("N0"));
                        col.Item().AlignRight()
                            .Text("Total: " + (subtotal + iva).ToString("N0")).Bold().FontSize(14);
                    });

                    pagina.Footer().AlignCenter().Text(x =>
                    {
                        x.Span("Gracias por su visita - Página ");
                        x.CurrentPageNumber();
                    });
                });
            });

            return documento.GeneratePdf();
        }

        private static IContainer Celda(IContainer contenedor)
        {
            return contenedor
                .BorderBottom(1)
                .BorderColor(Colors.Grey.Lighten2)
                .Padding(4);
        }
    }
}