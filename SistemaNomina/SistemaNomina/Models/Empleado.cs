namespace SistemaNomina.Models
{
    public abstract class Empleado
    {
        public string primerNombre { get; set; }
        public string apellidoPaterno { get; set; }
        public string numeroSeguroSocial { get; set; }

        // Cada sublacse implementara el siguiente metodo a su propia manera
        public abstract decimal CalcularPago();

        public override string ToString()
        {
            return $"{primerNombre} {apellidoPaterno} | NSS: {numeroSeguroSocial}";
        }

    }
}