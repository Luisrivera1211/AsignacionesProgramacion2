using SistemaGestionCitasMedicas.Interfaces;

namespace SistemaGestionCitasMedicas.Data
{
    public class PacienteRepositorio : IPacienteRepositorio
    {
        private List<Models.Paciente> pacientes = new List<Models.Paciente>();

        public void RegistrarPaciente(Models.Paciente paciente)
        {
            pacientes.Add(paciente);
        }

        public List<Models.Paciente> ListarPacientes()
        {
            return pacientes;
        }

        public Models.Paciente ObtenerPacientePorCedula(string cedula)
        {
            return pacientes.Where(p => p.cedula == cedula).FirstOrDefault();
        }

        public Models.Paciente ObtenerPacientePorNombre(string primerNombre)
        {
            return pacientes.Where(p => p.primerNombre == primerNombre).FirstOrDefault();
        }

    }
}
