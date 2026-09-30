using SistemaGestionCitasMedicas.Interfaces;

namespace SistemaGestionCitasMedicas.Services
{
    public class RecordatorioService : IRecordatorioCita
    {
        public void EnviarRecordatorio(Models.Cita cita)
        {
            Console.WriteLine($"Querido paciente {cita.paciente.primerNombre}, su cita esta programada para {cita.fecha} con el Dr. {cita.medico.primerNombre}");
        }
    }
}
