namespace SistemaNomina.Models
{
    public class EmpleadoPorHoras : Empleado
    {
        public decimal sueldoPorHora { get; set; }
        public decimal horasTrabajadas { get; set; }

        public override decimal CalcularPago()
        {

            if (horasTrabajadas <= 40)
            {
                return sueldoPorHora * horasTrabajadas;
            }
            else
            {
                return (sueldoPorHora * 40) + (sueldoPorHora * 1.5m * (horasTrabajadas - 40));
            }
        }

    }
}
