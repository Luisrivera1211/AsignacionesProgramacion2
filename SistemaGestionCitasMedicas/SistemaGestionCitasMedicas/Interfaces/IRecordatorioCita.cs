using SistemaGestionCitasMedicas.Models;

namespace SistemaGestionCitasMedicas.Interfaces
{
    public interface IRecordatorioCita
    {
      public void EnviarRecordatorio(Cita cita);

    }
}
