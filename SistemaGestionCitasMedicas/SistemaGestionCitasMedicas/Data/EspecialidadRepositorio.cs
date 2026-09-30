using SistemaGestionCitasMedicas.Interfaces;

namespace SistemaGestionCitasMedicas.Data
{
    public class EspecialidadRepositorio : IEspecialidadRepositorio
    {   

        List<Models.Especialidad> especialidades = new List<Models.Especialidad>();

        public void RegistrarEspecialidad(Models.Especialidad especialidad)
        {
            especialidades.Add(especialidad);
        }

        public List<Models.Especialidad> ListarEspecialidades()
        {
            return especialidades;
        }
    }
}
