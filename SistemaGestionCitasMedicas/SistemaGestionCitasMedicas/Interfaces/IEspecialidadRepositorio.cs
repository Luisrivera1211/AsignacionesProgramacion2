namespace SistemaGestionCitasMedicas.Interfaces
{
    public interface IEspecialidadRepositorio
    {

        public void RegistrarEspecialidad(Models.Especialidad especialidad);

        public List<Models.Especialidad> ListarEspecialidades();

    }
}
