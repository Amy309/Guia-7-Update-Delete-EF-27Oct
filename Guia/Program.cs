using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Guia;

class Program
{
    static void Main()
    {
        using (var contextdb = new ContextDB())
        {
            bool Continuar = true;
            while (Continuar)
            {
                Console.WriteLine("Menu\n");
                Console.WriteLine("1 Insertar Datos");
                Console.WriteLine("2 Actualizar Datos");
                Console.WriteLine("3 Eliminar Datos");

                int op1 = Convert.ToInt32(Console.ReadLine());

                switch (op1)
                {
                    case 1:
                        contextdb.Database.EnsureCreated();

                        Student estudiante = new Student();

                        Console.WriteLine("Ingrese el Nombre: ");
                        estudiante.Nombres = Console.ReadLine();

                        Console.WriteLine("");

                        Console.WriteLine("Ingrese el Apellido: ");
                        estudiante.Apellidos = Console.ReadLine();

                        Console.WriteLine("");

                        Console.WriteLine("Ingrese el Sexo: ");
                        estudiante.Sexo = Console.ReadLine();

                        Console.WriteLine("");

                        Console.WriteLine("Ingrese el Edad: ");
                        estudiante.Edad = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("");

                        contextdb.Add(estudiante);
                        contextdb.SaveChanges();

                        Console.WriteLine("Datos Agregados.");
                        break;

                    case 2:
                        Console.WriteLine("Ingrese el Id del registro que desea Actualizar");
                        var id = Console.ReadLine();
                        var persona = contextdb.Estudiante.FirstOrDefault(p => p.Id == Int32.Parse(id));

                        if (persona != null)
                        {
                            Console.WriteLine("Que opción desea modificar");
                            Console.WriteLine("1 Nombre");
                            Console.WriteLine("2 Apellido");
                            Console.WriteLine("3 Sexo");
                            Console.WriteLine("4 Edad");

                            int op = Convert.ToInt32(Console.ReadLine());
                            switch (op)
                            {

                                case 1:
                                    Console.WriteLine("Ingrese el nuevo Nombre: ");
                                    persona.Nombres = Console.ReadLine();
                                    Console.WriteLine("Datos Actualizados.");
                                    break;
                                case 2:
                                    Console.WriteLine("Ingrese el nuevo Apellido: ");
                                    persona.Apellidos = Console.ReadLine();
                                    Console.WriteLine("Datos Actualizados.");
                                    break;
                                case 3:
                                    Console.WriteLine("Ingrese el nuevo Sexo: ");
                                    persona.Sexo = Console.ReadLine();
                                    Console.WriteLine("Datos Actualizados..");
                                    break;
                                case 4:
                                    Console.WriteLine("Ingrese la nueva Edad: ");
                                    if (int.TryParse(Console.ReadLine(), out int nuevaEdad))
                                    {
                                        persona.Edad = nuevaEdad;
                                    }
                                    Console.WriteLine("Datos Actualizados.");
                                    break;

                            }
                            contextdb.SaveChanges();
                        }
                        else
                        {
                            Console.WriteLine("No se encontro ese registro");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Ingrese el ID del registro que desea Eliminar");
                        var Id = Console.ReadLine();
                        var Persona = contextdb.Estudiante.SingleOrDefault(x => x.Id == Int32.Parse(Id));
                        if (Persona != null)
                        {
                            contextdb.Estudiante.Remove(Persona);
                            contextdb.SaveChanges();
                        }
                        Console.WriteLine("Datos Borrados");
                        break;
                }
                Console.WriteLine("¿Desea continuar? Ingresar (S) o (N)");
                var cont = Console.ReadLine();
                if (cont.Equals("N"))
                {
                    Continuar = false;
                }

            }
            Console.WriteLine("Lista\n");

            foreach (var s in contextdb.Estudiante)
            {
                Console.WriteLine($"Nombre: {s.Nombres}, Apellido: {s.Apellidos}, Sexo: {s.Sexo}, Edad: {s.Edad}");
            }

        }
    }
}