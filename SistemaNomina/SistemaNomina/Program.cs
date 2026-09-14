using SistemaNomina.Models;

namespace SistemaNomina
{
    public class Program
    {   
        public static void Main(string[] args)
        {
            List<Empleado> empleados = new List<Empleado>();
            int opcion;

            do
            {
                Console.WriteLine("\n==== SISTEMA DE NOMINA ====");
                Console.WriteLine("1. Agregar Empleados");
                Console.WriteLine("2. Ver Empleados");
                Console.WriteLine("3. Reporte Semanal");
                Console.WriteLine("4. Actualizar Empleado");
                Console.WriteLine("5. Salir");
                Console.Write("Opcion: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        AgregarEmpleado();
                        break;
                    case 2:
                        VerEmpleados();
                        break;
                    case 3:
                        ReporteSemanal();
                        break;
                    case 4:
                        ActualizarEmpleado();
                        break;
                }

            } while (opcion != 5);

            // Metodos que se utilizan en el Switch-case

            void AgregarEmpleado()
            { 
                  Console.WriteLine("\nQue tipo de empleado desea añadir?");
                  Console.WriteLine("1. Empleado Asalariado");
                  Console.WriteLine("2. Empleado Por Horas");
                  Console.WriteLine("3. Empleado Por Comision");
                  Console.WriteLine("4. Empleado Asalariado por Comision");
                  Console.Write("Opcion: ");
                  int opcion = int.Parse(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            {

                                Console.Write("Primer Nombre: ");
                                string nombre = Console.ReadLine();
                                Console.Write("Apellido Paterno: ");
                                string apellido = Console.ReadLine();
                                Console.Write("Numero de seguro social: ");
                                string nss = Console.ReadLine();
                                Console.Write("Salario Semanal: ");
                                decimal salarioSemanal = decimal.Parse(Console.ReadLine());

                                empleados.Add(new EmpleadoAsalariado
                                {
                                    primerNombre = nombre,
                                    apellidoPaterno = apellido,
                                    numeroSeguroSocial = nss,
                                    salarioSemanal = salarioSemanal
                                });

                            }
                            break;

                        case 2:
                            {

                                Console.Write("Apellido Paterno: ");
                                string apellido = Console.ReadLine();
                                Console.Write("Numero de seguro social: ");
                                string nss = Console.ReadLine();
                                Console.Write("Sueldo Por Hora: ");
                                decimal sueldoPorHora = decimal.Parse(Console.ReadLine());
                                Console.Write("Horas Trabajadas: ");
                                decimal horasTrabajadas = decimal.Parse(Console.ReadLine());

                                empleados.Add(new EmpleadoPorHoras
                                {
                                    apellidoPaterno = apellido,
                                    numeroSeguroSocial = nss,
                                    sueldoPorHora = sueldoPorHora,
                                    horasTrabajadas = horasTrabajadas

                                });
                            }
                            break;

                        case 3:
                            {
                                Console.Write("Primer Nombre: ");
                                string nombre = Console.ReadLine();
                                Console.Write("Apellido Paterno: ");
                                string apellido = Console.ReadLine();
                                Console.Write("Numero de seguro social: ");
                                string nss = Console.ReadLine();
                                Console.Write("Ventas Brutas: ");
                                decimal ventasBrutas = decimal.Parse(Console.ReadLine());
                                Console.Write("Tarifa por Comision: ");
                                decimal tarifaComision = decimal.Parse(Console.ReadLine());

                                empleados.Add(new EmpleadoComision
                                {
                                    primerNombre = nombre,
                                    apellidoPaterno = apellido,
                                    numeroSeguroSocial = nss,
                                    ventasBrutas = ventasBrutas,
                                    tarifaComision = tarifaComision

                                });
                            }
                            break;

                        case 4:
                            {
                                Console.Write("Primer Nombre: ");
                                string nombre = Console.ReadLine();
                                Console.Write("Apellido Paterno: ");
                                string apellido = Console.ReadLine();
                                Console.Write("Numero de seguro social: ");
                                string nss = Console.ReadLine();
                                Console.Write("Ventas Brutas: ");
                                decimal ventasBrutas = decimal.Parse(Console.ReadLine());
                                Console.Write("Tarifa por Comision: ");
                                decimal tarifaComision = decimal.Parse(Console.ReadLine());
                                Console.Write("Salario Base: ");
                                decimal salarioBase = decimal.Parse(Console.ReadLine());

                                empleados.Add(new EmpleadoAsalariadoComision
                                {
                                    primerNombre = nombre,
                                    apellidoPaterno = apellido,
                                    numeroSeguroSocial = nss,
                                    ventasBrutas = ventasBrutas,
                                    tarifaComision = tarifaComision,
                                    salarioBase = salarioBase
                                });
                            }
                            break;
                    }

                    Console.WriteLine("Empleado agregado correctamente");
            }

            void VerEmpleados()
            {
                if (empleados.Count() == 0)
                {
                    Console.WriteLine("\nNo se encontraron empleados :(");
                    return;
                }


                Console.WriteLine("\n=== EMPLEADOS ===");
                foreach (Empleado emp in empleados)
                {
                    Console.WriteLine(emp);
                }

            }

            void ReporteSemanal()
            {

                decimal totalNomina = 0;

                if (empleados.Count() == 0)
                {
                    Console.WriteLine("\nNo se encontraron empleados :(");
                    return;
                }

                Console.WriteLine("\n=== REPORTE SEMANAL ===");
                foreach (Empleado emp in empleados)
                {
                    decimal pago = emp.CalcularPago();
                    Console.WriteLine($"{emp} -- Pago: {pago}");
                    totalNomina += pago;
                }

                Console.WriteLine($"\nTotal nomina: {totalNomina}");
            }

            void ActualizarEmpleado()
            {
                if (empleados.Count() == 0)
                {
                    Console.WriteLine("\nNo se encontraron empleados :(");
                    return;
                }

                Console.WriteLine("\n=== SELECIONA EMPLEADO ===");
                for (int i = 0; i < empleados.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {empleados[i]}");
                }

                Console.Write("Numero de empleado a actualizar: ");
                int indice = int.Parse(Console.ReadLine()) - 1;

                Empleado emp = empleados[indice];

                if (emp is EmpleadoAsalariado a)
                {
                    Console.Write("Nuevo Salario Semanal");
                    a.salarioSemanal = decimal.Parse(Console.ReadLine());
                }
                else if (emp is EmpleadoPorHoras h)
                {
                    Console.Write("Nuevo sueldo por hora: ");
                    h.sueldoPorHora = decimal.Parse(Console.ReadLine());
                    Console.Write("Nuevas horas trabajadas: ");
                    h.horasTrabajadas = decimal.Parse(Console.ReadLine());
                }
                else if (emp is EmpleadoComision c)
                {
                    Console.Write("Nuevas ventas brutas: ");
                    c.ventasBrutas = decimal.Parse(Console.ReadLine());
                    Console.Write("Nueva tarifa de comision: ");
                    c.tarifaComision = decimal.Parse(Console.ReadLine());
                }
                else if (emp is EmpleadoAsalariadoComision m)
                {
                    Console.Write("Nuevas ventas brutas: ");
                    m.ventasBrutas = decimal.Parse(Console.ReadLine());
                    Console.Write("Nueva tarifa de comision: ");
                    m.tarifaComision = decimal.Parse(Console.ReadLine());
                    Console.Write("Nuevo salario base: ");
                    m.salarioBase = decimal.Parse(Console.ReadLine());
                }

                Console.WriteLine("Empleado actualizado. Nuevo Pago: " + emp.CalcularPago().ToString());
            }
        }
    }
}