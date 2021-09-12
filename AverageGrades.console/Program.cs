using System;
using System.Collections.Generic;
using System.Linq;

namespace AverageGrades.console
{
    class Program
    {
        public static void Main(string[] args)
        {
            Classroom classroom = new Classroom();

            int n = 3;

            Console.WriteLine("Ingresar el Nombre de la Clase");
            classroom.Name = Console.ReadLine();

            bool respose = true;
            while (respose)
            {
                classroom.AddStudent(AddStudent(n),n);

                Console.WriteLine("Desea Agregar otro Estudiante (S/n)");
                string res = Console.ReadLine();

                switch (res.ToUpper())
                {
                    case "N":
                        respose = false;
                        break;
                    default:
                        break;
                }                
            }

            PrintResult(classroom);
        }

        private static Student AddStudent(int n)
        {
            Student student = new Student();

            Console.WriteLine("Ingresar el Nombre del Estudiante");
            student.Name = Console.ReadLine();

            for (int i = 0; i < n; i++)
            {
                bool error;
                int garde;
                do
                {
                    error = false;
                    Console.WriteLine($"Inserte Calificación #{i + 1} rango(1 - 20):");
                    string response = Console.ReadLine();

                    // Validar si es un numero
                    if (!int.TryParse(response, out garde))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Error: '{response}' No es un numero valido");
                        error = true;
                    }

                    // Validar rango
                    if (garde < 1 || garde > 20 )
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Error: La calificacion debe estar en el rango 1 - 20");
                        error = true;
                    }

                    Console.ForegroundColor = ConsoleColor.White;

                } while (error);

                student.AddGarde(garde);

            }

            return student;
        }
    
        private static void PrintResult(Classroom classroom)
        {
            Console.WriteLine("---------------------------------------------------------------");

            Console.WriteLine($"Nombre Clase: {classroom.Name}");
            Console.WriteLine($"Promedio {classroom.Averge}");
            Console.WriteLine($"Estudiantes: {classroom.Students.Count}");
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("");

            foreach (var student in classroom.Students)
            {
                Console.WriteLine($"{student.Name} - Promedio {student.Averge}");
            }
            Console.WriteLine("---------------------------------------------------------------");




        }
    }


    public class Classroom
    {
        public string Name { get; set; }
        public decimal Total { get; set; }
        public decimal Averge { get; set; }
        public List<Student> Students { get; set; }

        public Classroom()
        {
            Students = new List<Student>();
        }

        public void AddStudent(Student student, int n)
        {
            Students.Add(student);
            Total = CalculateTotal(Students);
            Averge = Math.Round((Total / Students.Count)/n, 2);
        }

        private decimal CalculateTotal(List<Student> students)
        {
            if (students.Count == 1)
                return students[0].Total;
            else
                return students[0].Total + CalculateTotal(students.GetRange(1, students.Count - 1));
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public List<int> Gardes { get; set; }
        public decimal Total { get; set; }
        public decimal Averge { get; set; }

        public Student()
        {
            Gardes = new List<int>();
        }

        public void AddGarde(int garde)
        {
            Gardes.Add(garde);
            Total = CalculateTotal(Gardes);
            Averge = Math.Round(Total / Gardes.Count, 2);
        }

        private decimal CalculateTotal(List<int> _gardes)
        {
            if (_gardes.Count == 1)
                return _gardes[0];
            else
                return _gardes[0] + CalculateTotal(_gardes.GetRange(1, _gardes.Count - 1));
        }
    }
}
