namespace SistemaGestionCitasMedicas.Interfaces
{
    public interface IPacienteRepositorio
    {
        public void RegistrarPaciente(Models.Paciente paciente);

        public List<Models.Paciente> ListarPacientes();

        public Models.Paciente ObtenerPacientePorCedula(string cedula);

        public Models.Paciente ObtenerPacientePorNombre(string primerNombre);
    }
}
