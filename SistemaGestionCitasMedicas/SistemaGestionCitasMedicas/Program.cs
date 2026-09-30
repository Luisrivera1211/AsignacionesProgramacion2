namespace SistemaGestionCitasMedicas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Repositorios
            var citaRepositorio = new Data.CitaRepositorio();
            var medicoRepositorio = new Data.MedicoRepositorio();
            var especialidadRepositorio = new Data.EspecialidadRepositorio();
            var pacienteRepositorio = new Data.PacienteRepositorio();

            // Servicios
            var citaService = new Services.CitaService(citaRepositorio);
            var medicoService = new Services.MedicoService(medicoRepositorio);
            var especialidadService = new Services.EspecialidadService(especialidadRepositorio);
            var pacienteService = new Services.PacienteService(pacienteRepositorio);

            bool ejecutando = true;

            while (ejecutando)
            {
                Console.WriteLine("=== Sistema de Gestion de Citas ===");
                Console.WriteLine("1. Registrar Paciente");
                Console.WriteLine("2. Registrar Medico");
                Console.WriteLine("3. Registrar Especialidad");
                Console.WriteLine("4. Asignar Medico a una especialidad");
                Console.WriteLine("5. Agendar cita");
                Console.WriteLine("6. Consultar citas por paciente");
                Console.WriteLine("7. Consultar citas por medico");
                Console.WriteLine("8. Cancelar cita");
                Console.WriteLine("9. Reprogramar cita");
                Console.WriteLine("10. Enviar recordatorio");
                Console.WriteLine("11. Salir\n");

                Console.Write("Seleccione una Opcion: ");
                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        {
                            Console.WriteLine("Ingrese el primer nombre: ");
                            string nombre = Console.ReadLine();
                            Console.WriteLine("Ingrese el apellido paterno: ");
                            string apellido = Console.ReadLine();
                            Console.WriteLine("Ingrese el numero de telefono: ");
                            string telefono = Console.ReadLine();
                            Console.WriteLine("Ingrese el correo electronico: ");
                            string correo = Console.ReadLine();
                            Console.WriteLine("Ingrese la cedula: ");
                            string cedula = Console.ReadLine();

                            var paciente = new Models.Paciente
                            {
                                primerNombre = nombre,
                                apellidoPaterno = apellido,
                                numeroTelefono = telefono,
                                correoElectronico = correo,
                                cedula = cedula,
                            };

                            pacienteService.RegistrarPaciente(paciente);
                            Console.WriteLine("Paciente registrado Existosamente!");

                            break;
                        }

                    case "2":
                        {
                            Console.WriteLine("Ingrese el primer nombre: ");
                            string nombre = Console.ReadLine();
                            Console.WriteLine("Ingrese el apellido paterno: ");
                            string apellido = Console.ReadLine();
                            Console.WriteLine("Ingrese el numero de telefono: ");
                            string telefono = Console.ReadLine();
                            Console.WriteLine("Ingrese el correo electronico: ");
                            string correo = Console.ReadLine();

                            var especialidades = especialidadService.ListarEspecialidades();
                            Console.WriteLine("Especialidades disponibles:");
                            for (int i = 0; i < especialidades.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {especialidades[i].nombre}");
                            }

                            Console.WriteLine("Seleccione el numero de la Especialidad");
                            int indice = int.Parse(Console.ReadLine()) - 1;
                            Models.Especialidad especialidad = especialidades[indice];
                            Console.WriteLine("Ingrese el exequatur: ");
                            string exequatur = Console.ReadLine();

                            var medico = new Models.Medico
                            {
                                primerNombre = nombre,
                                apellidoPaterno = apellido,
                                numeroTelefono = telefono,
                                correoElectronico = correo,
                                especalidad = especialidad,
                                exequatur = exequatur
                            };

                            medicoService.RegistrarMedico(medico);
                            Console.WriteLine("Medico registrado Exitosamente!");

                            break;
                        }

                  case "3":
                    {
                            Console.WriteLine("Nombre de la Especialidad");
                            string especialidad = Console.ReadLine();
                            var nuevaEspecialidad = new Models.Especialidad
                            {
                                nombre = especialidad
                            };
                            especialidadService.RegistrarEspecialidad(nuevaEspecialidad);
                            Console.WriteLine("Especialidad registrada Exitosamente!");
                            break;
                        }

                    case "4":
                        {
                            var medicos = medicoService.ListarMedicos();
                            Console.WriteLine("Medicos Disponibles:");
                            for (int i = 0; i < medicos.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {medicos[i].primerNombre}");
                            }

                            Console.WriteLine("Seleccione el numero del Medico: ");
                            int indiceMedico = int.Parse(Console.ReadLine()) - 1;
                            Models.Medico medicoSeleccionado = medicos[indiceMedico];

                            var especialidades = especialidadService.ListarEspecialidades();
                            Console.WriteLine("Especialidades Disponibles:");
                            for (int i = 0; i < especialidades.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {especialidades[i].nombre}");
                            }
                            Console.WriteLine("Seleccione el numero de la Especialidad:");
                            int indiceEspecialidad = int.Parse(Console.ReadLine()) - 1;
                            Models.Especialidad especialidadSeleccionada = especialidades[indiceEspecialidad];

                            medicoService.AsignarEspecialidad(medicoSeleccionado, especialidadSeleccionada);
                            Console.WriteLine("Especialidad asignada Exitosamente!");
                            break;
                        }

                    case "5":
                        {
                            Console.WriteLine("Seleccione la especialidad de la cita:");
                            var especialidades = especialidadService.ListarEspecialidades();
                            Console.WriteLine("Especialidades diponibles:");
                            for (int i = 0; i < especialidades.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {especialidades[i].nombre}");
                            }
                            int indiceEspecialidad = int.Parse(Console.ReadLine()) - 1;
                            Models.Especialidad especialidadSeleccionada = especialidades[indiceEspecialidad];

                            var medicos = medicoService.ListarMedicos();
                            Console.WriteLine("Medicos Disponibles:");
                            for (int i = 0; i < medicos.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {medicos[i].primerNombre}");
                            }

                            Console.WriteLine("Seleccione el numero del medico: ");
                            int indiceMedico = int.Parse(Console.ReadLine()) - 1;
                            Models.Medico medicoSeleccionado = medicos[indiceMedico];

                            var pacientes = pacienteService.ListarPacientes();
                            Console.WriteLine("Pacientes Disponibles:");
                            for (int i = 0; i < pacientes.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {pacientes[i].primerNombre}");
                            }

                            Console.WriteLine("Seleccione el numero del Paciente: ");
                            int indicePaciente = int.Parse(Console.ReadLine()) - 1;
                            Models.Paciente pacienteSeleccionado = pacientes[indicePaciente];

                            Console.WriteLine("Ingrese la fecha de la cita");
                            DateTime fecha = DateTime.Parse(Console.ReadLine());

                            var cita = new Models.Cita
                            {
                                fecha = fecha,
                                especialidad = especialidadSeleccionada,
                                medico = medicoSeleccionado,
                                paciente = pacienteSeleccionado,
                                estado = Models.EstadoCita.Pendiente
                            };

                            try
                            {
                                citaService.AgendarCita(cita);
                                Console.WriteLine("Cita agendada Exitosamente!");
                            }
                            catch (InvalidOperationException ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;
                        }

                    case "6":
                        {
                            var pacientes = pacienteService.ListarPacientes();
                            Console.WriteLine("Pacientes Disponibles:");
                            for (int i = 0; i < pacientes.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {pacientes[i].primerNombre}");
                            }

                            Console.WriteLine("Seleccione el numero del Paciente:");
                            int indicePaciente = int.Parse(Console.ReadLine()) - 1;
                            Models.Paciente pacienteSeleccionado = pacientes[indicePaciente];

                            var citas = citaService.ObtenerCitasPorPaciente(pacienteSeleccionado);
                            Console.WriteLine("Citas del Paciente:");
                            foreach (var cita in citas)
                            {
                                Console.WriteLine($"Fecha: {cita.fecha} - Médico: {cita.medico.primerNombre} - Estado: {cita.estado}");
                            }
                            break;
                        }

                    case "7":
                        {
                            var medicos = medicoService.ListarMedicos();
                            Console.WriteLine("Médicos disponibles:");
                            for (int i = 0; i < medicos.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {medicos[i].primerNombre}");
                            }
                            Console.WriteLine("Seleccione el número de el medico:");
                            int indiceMedico = int.Parse(Console.ReadLine()) - 1;
                            Models.Medico medicoSeleccionado = medicos[indiceMedico];
                            var citas = citaService.ObtenerCitasPorMedico(medicoSeleccionado);
                            Console.WriteLine("Citas del Medico:");
                            foreach (var cita in citas)
                            {
                                Console.WriteLine($"Fecha: {cita.fecha} - Paciente: {cita.paciente.primerNombre} - Estado: {cita.estado}");
                            }
                            break;
                        }

                    case "8":
                        {
                            var todasLasCitas = citaService.ObtenerTodas();
                            Console.WriteLine("Citas disponibles:");
                            for (int i = 0; i < todasLasCitas.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. Paciente: {todasLasCitas[i].paciente.primerNombre} - Médico: {todasLasCitas[i].medico.primerNombre} - Fecha: {todasLasCitas[i].fecha}");
                            }
                            Console.WriteLine("Seleccione el número de la Cita a cancelar:");
                            int indiceCita = int.Parse(Console.ReadLine()) - 1;
                            Models.Cita citaSeleccionada = todasLasCitas[indiceCita];
                            try
                            {
                                citaService.CancelarCita(citaSeleccionada);
                                Console.WriteLine("Cita cancelada Exitosamente!");
                            }
                            catch (InvalidOperationException ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;
                        }

                    case "9":
                        {
                            var todasLasCitas = citaService.ObtenerTodas();
                            Console.WriteLine("Citas disponibles:");
                            for (int i = 0; i < todasLasCitas.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. Paciente: {todasLasCitas[i].paciente.primerNombre} - Médico: {todasLasCitas[i].medico.primerNombre} - Fecha: {todasLasCitas[i].fecha}");
                            }
                            Console.WriteLine("Seleccione el número de la Cita a reprogramar:");
                            int indiceCita = int.Parse(Console.ReadLine()) - 1;
                            Models.Cita citaSeleccionada = todasLasCitas[indiceCita];
                            Console.WriteLine("Ingrese la nueva Fecha:");
                            DateTime nuevaFecha = DateTime.Parse(Console.ReadLine());
                            try
                            {
                                citaService.ReprogramarCita(citaSeleccionada, nuevaFecha);
                                Console.WriteLine("Cita reprogramada Exitosamente!");
                            }
                            catch (InvalidOperationException ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;
                        }

                    case "10":
                        {
                            var todasLasCitas = citaService.ObtenerTodas();
                            Console.WriteLine("Citas disponibles:");
                            for (int i = 0; i < todasLasCitas.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. Paciente: {todasLasCitas[i].paciente.primerNombre} - Fecha: {todasLasCitas[i].fecha}");
                            }
                            Console.WriteLine("Seleccione el número de cita para enviar recordatorio:");
                            int indiceCita = int.Parse(Console.ReadLine()) - 1;
                            Models.Cita citaSeleccionada = todasLasCitas[indiceCita];
                            var recordatorio = new Services.RecordatorioService();
                            recordatorio.EnviarRecordatorio(citaSeleccionada);
                            break;
                        }

                    case "11":
                        ejecutando = false;
                        break;

                    default:
                        Console.WriteLine("Opción no válida, Intente de nuevo.");
                        break;

                }
            }
        }
    }
}