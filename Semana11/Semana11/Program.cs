// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using Microsoft.Extensions.Logging.Abstractions;
using Semana11;
using System.ComponentModel;

using (var contextdb = new ContextDB())
{ 
    bool Continuar = true;
    while (Continuar)
    
    {
        Console.WriteLine("DATOS DE LA TABLA:");
        Console.WriteLine("");

        foreach (var s in contextdb.Estudiante)
        {
            Console.WriteLine($"Nombre: {s.Nombres}, Apellido: {s.Apellidos}, Sexo: {s.Sexo}, Edad: {s.Edad}");
            Console.WriteLine(" ");
        }
        Console.WriteLine("1 Agregar registros");
        Console.WriteLine("2 Actualizar registros");
        Console.WriteLine("3 Eliminar registros");
        Console.WriteLine("");

        int opcion1 = Convert.ToInt32(Console.ReadLine());
        switch (opcion1)
        {
            case 1:

                contextdb.Database.EnsureCreated();

                Student estudiante = new Student();

                Console.WriteLine("Ingresar Nombre:");
                estudiante.Nombres = Console.ReadLine();

                Console.WriteLine("Ingresar Apellido:");
                estudiante.Apellidos = Console.ReadLine();

                Console.WriteLine("Ingresar Sexo:");
                estudiante.Sexo = Console.ReadLine();

                Console.WriteLine("Ingresar Edad:");
                estudiante.Edad = Convert.ToInt32(Console.ReadLine());

                contextdb.Add(estudiante);
                contextdb.SaveChanges();

                Console.WriteLine("Se agrego un nuevo estudiante");

                Console.WriteLine("¿Continuar agregando estudiantes?(S/N): ");
                string Si = Console.ReadLine();
                Continuar = Si.ToLower() == "s";
                break;

            case 2:
                Console.WriteLine("Ingrese el Id del registro que desea modificar");
                var id = Console.ReadLine();
                var persona = contextdb.Estudiante.FirstOrDefault(p => p.Id == Int32.Parse(id));

                if (persona != null)
                {
                    Console.WriteLine("");
                    Console.WriteLine("¿Que atributo desea modificar?");
                    Console.WriteLine("");
                    Console.WriteLine("1 Nombre");
                    Console.WriteLine("2 Apellido");
                    Console.WriteLine("3 Sexo");
                    Console.WriteLine("4 Edad");
                    Console.WriteLine(" ");

                    int op = Convert.ToInt32(Console.ReadLine());
                    switch (op)
                    {

                        case 1:
                            Console.WriteLine("");
                            Console.WriteLine("Ingresar nuevo Nombre: ");
                            persona.Nombres = Console.ReadLine();
                            Console.WriteLine("");
                            Console.WriteLine("Nombre actualizado");
                            break;
                        case 2:
                            Console.Write("");
                            Console.WriteLine("Ingresar nuevo Apellido: ");
                            persona.Apellidos = Console.ReadLine();
                            Console.WriteLine("");
                            Console.WriteLine("Apellido actualizado");
                            break;
                        case 3:
                            Console.WriteLine("");
                            Console.WriteLine("Ingresar nuevo Sexo: ");
                            persona.Sexo = Console.ReadLine();
                            Console.WriteLine("");
                            Console.WriteLine("Dato actualizado");
                            break;
                        case 4:
                            Console.WriteLine("");
                            Console.WriteLine("Ingresar nueva Edad: ");
                            if (int.TryParse(Console.ReadLine(), out int nuevaEdad))
                            {
                                persona.Edad = nuevaEdad;
                            }
                            Console.WriteLine("");
                            Console.WriteLine("Edad actualizada");
                            Console.WriteLine(" ");
                            break;

                    }
                    contextdb.SaveChanges();
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("El Id no se ha encontrado");
                }
                break;

            case 3:
                Console.WriteLine("Ingrese el Id del registro que desea eliminar");
                var Id = Console.ReadLine();
                var Persona = contextdb.Estudiante.SingleOrDefault(x => x.Id == Int32.Parse(Id));
                if (Persona != null)
                {
                    contextdb.Estudiante.Remove(Persona);
                    contextdb.SaveChanges();
                }
                Console.WriteLine("Eliminacion de registro correctamente.");
                break;
        }
        Console.WriteLine("");
        Console.WriteLine("¿Desea continuar? Presione S(Si) o N(No) S/N");
        var cont = Console.ReadLine();
        if (cont.Equals("N"))
        {
            Continuar = false;
        }
    }
           Console.WriteLine("");
    }

        




               