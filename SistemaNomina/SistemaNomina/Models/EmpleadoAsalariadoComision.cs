namespace SistemaNomina.Models
{
    public class EmpleadoAsalariadoComision : EmpleadoComision
    {
        public decimal salarioBase { get; set; }

        public override decimal CalcularPago()
        {
            return (ventasBrutas * tarifaComision) + salarioBase + (salarioBase * 0.10m);
        }

    }
}