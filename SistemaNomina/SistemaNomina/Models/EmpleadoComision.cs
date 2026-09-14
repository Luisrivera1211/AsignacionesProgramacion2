namespace SistemaNomina.Models
{
    public class EmpleadoComision : Empleado
    {
        public decimal ventasBrutas { get; set; }
        public decimal tarifaComision { get; set; }

        public override decimal CalcularPago()
        {
            return ventasBrutas * tarifaComision;
        }
    }
}
