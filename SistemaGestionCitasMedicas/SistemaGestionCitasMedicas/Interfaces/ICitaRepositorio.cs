using SistemaGestionCitasMedicas.Models;

namespace SistemaGestionCitasMedicas.Interfaces
{
    public interface ICitaRepositorio
    {

        public void AgendarCita(Cita cita);

        public void CancelarCita(Cita cita);

        public void ReprogramarCita(Cita cita, DateTime nuevaFecha);

        public List<Cita> ObtenerCitasPorPaciente(Paciente paciente);

        public List<Cita> ObtenerCitasPorMedico(Medico medico);

        public List<Cita> ObtenerTodas();
      
    }
}
