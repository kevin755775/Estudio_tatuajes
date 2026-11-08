namespace presentacion_consola.interfaces
{
    public interface IComunicaciones
    {
        Task<T> Ejecutar<T>(string url, object entidad);
    }
}
