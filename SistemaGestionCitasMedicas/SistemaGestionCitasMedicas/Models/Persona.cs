namespace SistemaGestionCitasMedicas.Models
{
    public abstract class Persona
    {
        public string primerNombre { get; set; }

        public string apellidoPaterno { get; set; }

        public string correoElectronico { get; set; }

        public string numeroTelefono { get; set; }

    }
}
