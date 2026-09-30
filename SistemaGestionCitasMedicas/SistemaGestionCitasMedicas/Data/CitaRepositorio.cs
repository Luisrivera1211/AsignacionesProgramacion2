using SistemaGestionCitasMedicas.Interfaces;

namespace SistemaGestionCitasMedicas.Data
{
    public class CitaRepositorio : ICitaRepositorio
    {

        private List<Models.Cita> citas = new List<Models.Cita>();

        public void AgendarCita(Models.Cita cita)
        {
            citas.Add(cita);
        }

        public void CancelarCita(Models.Cita cita)
        {
            cita.estado = Models.EstadoCita.Cancelada;
        }

        public void ReprogramarCita(Models.Cita cita, DateTime nuevaFecha)
        {
            cita.fecha = nuevaFecha;
            cita.estado = Models.EstadoCita.Reprogramada;
        }

        public List<Models.Cita> ObtenerCitasPorPaciente(Models.Paciente paciente)
        {
            return citas.Where(c => c.paciente == paciente).ToList();
        }

        public List<Models.Cita> ObtenerCitasPorMedico(Models.Medico medico)
        {
            return citas.Where(c => c.medico == medico).ToList();
        }

        public List<Models.Cita> ObtenerTodas()
        {
            return citas;
        }

    }
}
