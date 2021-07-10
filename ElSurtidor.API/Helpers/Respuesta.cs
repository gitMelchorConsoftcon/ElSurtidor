namespace ElSurtidor.API.Helpers
{
    public class Respuesta
    {

        public bool Estado { get; set; }
        public string Mensaje { get; set; }
        public object Data { get; set; }

        public Respuesta()
        {
            Estado = true;
            Mensaje = "Sin errores";
            Data = null;
        }
        public Respuesta(bool estado , string mensaje , object data= null)
        {
            Estado = estado;
            Mensaje = mensaje;
            Data = data;
        }
    }
}
