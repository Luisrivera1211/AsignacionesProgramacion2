namespace SistemaGestionCitasMedicas.Models
{
    public sealed class Medico : Persona
    {   
        public Especialidad especalidad { get; set; }
        public string exequatur { get; set; }
    }
}
