namespace SistemaGestionCitasMedicas.Services
{
    public class EspecialidadService
    {
        private readonly Interfaces.IEspecialidadRepositorio _especialidadRepositorio;

        public EspecialidadService(Interfaces.IEspecialidadRepositorio especialidadRepositorio)
        {
            _especialidadRepositorio = especialidadRepositorio;
        }

        public void RegistrarEspecialidad(Models.Especialidad especialidad)
        {
            if (especialidad == null) throw new ArgumentNullException(nameof(especialidad));

            _especialidadRepositorio.RegistrarEspecialidad(especialidad);
        }

        public List<Models.Especialidad> ListarEspecialidades()
        {
            return _especialidadRepositorio.ListarEspecialidades();
        }
    }
}
