namespace SistemaGestionCitasMedicas.Services
{
    public class CitaService
    {
        private readonly Interfaces.ICitaRepositorio _citaRepositorio;

        public CitaService(Interfaces.ICitaRepositorio citaRepositorio)
        {
           _citaRepositorio = citaRepositorio;
        }

        public void AgendarCita(Models.Cita cita)
        {
            if (cita == null) throw new ArgumentNullException(nameof(cita));

            var citaExistente = _citaRepositorio.ObtenerCitasPorMedico(cita.medico)
                .Where(c => c.fecha == cita.fecha).FirstOrDefault();

            if (citaExistente != null) throw new InvalidOperationException("El medico ya tiene una cita en esa fecha");

            _citaRepositorio.AgendarCita(cita);
        }

       
        public void CancelarCita(Models.Cita cita)
        {
            if (cita == null) throw new ArgumentNullException(nameof(cita));
            _citaRepositorio.CancelarCita(cita);

        }

        public void ReprogramarCita(Models.Cita cita, DateTime nuevaFecha)
        {
            if (cita == null) throw new ArgumentNullException(nameof(cita));

            var citaExistente = _citaRepositorio.ObtenerCitasPorMedico(cita.medico).Where(c => c.fecha == nuevaFecha && c != cita).FirstOrDefault();

            if (citaExistente != null) throw new InvalidOperationException("El médico ya tiene una cita en esa fecha");

            _citaRepositorio.ReprogramarCita(cita, nuevaFecha);
        }

        public List<Models.Cita> ObtenerCitasPorPaciente(Models.Paciente paciente)
        {
            if (paciente == null) throw new ArgumentNullException(nameof(paciente));

            return _citaRepositorio.ObtenerCitasPorPaciente(paciente);
               
        }

        public List<Models.Cita> ObtenerCitasPorMedico(Models.Medico medico)
        {
            if (medico == null) throw new ArgumentNullException(nameof(medico));

            return _citaRepositorio.ObtenerCitasPorMedico(medico);

        }

        public List<Models.Cita> ObtenerTodas()
        {

            return _citaRepositorio.ObtenerTodas();

        }
    }
}
