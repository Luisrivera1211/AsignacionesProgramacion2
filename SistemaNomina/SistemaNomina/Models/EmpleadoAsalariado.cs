
namespace SistemaNomina.Models
{
    public class EmpleadoAsalariado : Empleado
    {
        public decimal salarioSemanal { get; set; }

        public override decimal CalcularPago()
        {
            return salarioSemanal;
        }
    }
}