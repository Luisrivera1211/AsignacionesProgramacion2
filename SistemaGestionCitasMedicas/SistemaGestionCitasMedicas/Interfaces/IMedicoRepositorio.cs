namespace SistemaGestionCitasMedicas.Interfaces
{
    public interface IMedicoRepositorio
    {
        public void RegistrarMedico(Models.Medico medico);

        public List<Models.Medico> ListarMedicos();

        public Models.Medico ObtenerPorExequatur(string exequatur);

        public Models.Medico ObtenerMedicoPorNombre(string primerNombre);

        public void AsignarEspecialidad(Models.Medico medico, Models.Especialidad especialidad);
    }
}
