using SistemaGestionCitasMedicas.Interfaces;

namespace SistemaGestionCitasMedicas.Data
{
    public class MedicoRepositorio : IMedicoRepositorio
    {   

        List<Models.Medico> medicos = new List<Models.Medico>();

        public void RegistrarMedico(Models.Medico medico)
        {
            medicos.Add(medico);
        }

        public List<Models.Medico> ListarMedicos()
        {
            return medicos;
        }

        public Models.Medico ObtenerPorExequatur(string exequatur)
        {
            return medicos.Where(m => m.exequatur == exequatur).FirstOrDefault();
        }

        public Models.Medico ObtenerMedicoPorNombre(string primerNombre)
        {
            return medicos.Where(m => m.primerNombre == primerNombre).FirstOrDefault();
        }

        public void AsignarEspecialidad(Models.Medico medico, Models.Especialidad especialidad)
        {
            medico.especalidad = especialidad;
        }
    }
}
