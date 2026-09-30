namespace SistemaGestionCitasMedicas.Models
{
    public class Cita
    {
        public Medico medico { get; set; }

        public DateTime fecha { get; set; }

        public Especialidad especialidad { get; set; }

        public Paciente paciente { get; set; }

        public EstadoCita estado { get; set; }

    }
}
