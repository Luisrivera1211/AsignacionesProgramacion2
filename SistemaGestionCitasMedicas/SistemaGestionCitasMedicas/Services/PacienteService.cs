namespace SistemaGestionCitasMedicas.Services
{
    public class PacienteService
    {
        private readonly Interfaces.IPacienteRepositorio _pacienteRepositorio;

        public PacienteService(Interfaces.IPacienteRepositorio pacienteRepositorio)
        {
            _pacienteRepositorio = pacienteRepositorio;
        }

        public void RegistrarPaciente(Models.Paciente paciente)
        {
            if (paciente ==  null) throw new ArgumentNullException(nameof(paciente));

                _pacienteRepositorio.RegistrarPaciente(paciente);
        }

        public List<Models.Paciente> ListarPacientes()
        {
            return _pacienteRepositorio.ListarPacientes(); 
        }

        public Models.Paciente ObtenerPacientePorCedula(string cedula)
        {
            return _pacienteRepositorio.ObtenerPacientePorCedula(cedula);
        }

        public Models.Paciente ObtenerPacientePorNombre(string primerNombre)
        {
            return _pacienteRepositorio.ObtenerPacientePorNombre(primerNombre);
        }

    }
}
