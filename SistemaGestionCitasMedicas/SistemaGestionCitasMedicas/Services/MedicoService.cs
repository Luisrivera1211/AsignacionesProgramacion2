using SistemaGestionCitasMedicas.Models;

namespace SistemaGestionCitasMedicas.Services
{
    public class MedicoService
    {
        private readonly Interfaces.IMedicoRepositorio _medicoRepositorio;

        public MedicoService(Interfaces.IMedicoRepositorio medicoRepositorio)
        {
            _medicoRepositorio = medicoRepositorio;
        }

        public void RegistrarMedico(Models.Medico medico)
        {
            if (medico == null) throw new ArgumentNullException(nameof(medico));

            _medicoRepositorio.RegistrarMedico(medico);
        }

        public List<Models.Medico> ListarMedicos()
        {
            return _medicoRepositorio.ListarMedicos();
        }

        public Models.Medico ObtenerPorExequatur(string exequatur)
        {
            if (exequatur == null) throw new ArgumentNullException(nameof(exequatur));

            return _medicoRepositorio.ObtenerPorExequatur(exequatur);
        }

        public Models.Medico ObtenerMedicoPorNombre(string primerNombre)
        {
            if (primerNombre == null) throw new ArgumentNullException(nameof(primerNombre));

            return _medicoRepositorio.ObtenerMedicoPorNombre(primerNombre);
        }

        public void AsignarEspecialidad(Models.Medico medico, Models.Especialidad especialidad)
        {
            if (medico == null) throw new ArgumentNullException(nameof(medico));

            if (especialidad == null) throw new ArgumentNullException(nameof(especialidad));

            if (medico.especalidad != null && medico.especalidad.nombre == especialidad.nombre) 
                throw new InvalidOperationException("El medico ya tiene esa especialidad");

            _medicoRepositorio.AsignarEspecialidad(medico, especialidad);
        }
    }
}
