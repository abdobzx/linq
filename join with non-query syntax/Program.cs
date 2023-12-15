using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;


namespace LiNKO
{
    class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Note { get; set; }

    }
    class Prof
    {  
        public int Id { get; set; }
    
        public string? Name { get; set; }
       
    }
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7 } ;
            Student[] students =
            {
                new Student { Id = 1,Name="toto",Note=5},
                new Student { Id = 1,Name="toto",Note=5},
                new Student { Id = 1,Name="toto",Note=5},
                new Student { Id = 1,Name="toto",Note=5},
                new Student { Id = 1,Name="toto",Note=5},
                new Student { Id = 2,Name="aymen",Note=10},
                new Student { Id = 3,Name="ta2toh",Note=50},
                new Student { Id = 4,Name="jaafar",Note=60},
                new Student { Id = 5,Name="Imad",Note=100},
            }; 
            Student[] students2 =
            {
                new Student { Id = 1,Name="toto",Note=5},
                new Student { Id = 1,Name="toto",Note=5},
                new Student { Id = 1,Name="toto",Note=5},
                new Student { Id = 1,Name="toto",Note=5},
                new Student { Id = 1,Name="toto",Note=5},
                new Student { Id = 2,Name="aymen",Note=10},
                new Student { Id = 3,Name="ta2toh",Note=50},
                new Student { Id = 4,Name="jaafar",Note=60},
                new Student { Id = 5,Name="Imad",Note=100},
            };
            Prof[] profs =
            {
                new Prof { Id = 1,Name="said"},
                new Prof { Id = 1,Name="said"},
                new Prof { Id = 1,Name="said"},
                new Prof { Id = 1,Name="said"},
                new Prof { Id = 2,Name="oussama"},
                new Prof { Id = 3,Name="abdo"},
                new Prof { Id = 4,Name="Imad"},
                new Prof { Id = 5,Name="aymen"},
            };

            // join wtih query syntax
            var results = from profo in profs join Student in students on profo.Name equals Student.Name select profo;

            foreach(var prof in results)
            {

                Console.WriteLine($"student{prof.Name}");
            }
            Console.WriteLine("---------------------------------");
            // join wtih non-query syntax
            var results1 = profs.Join(students, sname => sname.Name, pname => pname.Name, (sname, pname) => sname);

            foreach(var P in results1 )
            {
                Console.WriteLine(P.Name);
            };
            Console.WriteLine("---------------------------------");


            //group by on query syntax
            var results2 = from Student in students group Student by Student.Name;

            foreach(var prof in results2)
            {
                Console.WriteLine(prof.Key);
                
            }
            Console.WriteLine("---------------------------------");

            //group by on non-query syntax
            var results3 = students.GroupBy(a => a.Name);
            foreach(var prof in results3)
            {
                Console.WriteLine(prof.Key);
            }
            Console.WriteLine("---------------------------------");
            //order by on query

            var restults3 = from Students in students orderby Students.Note select Students;

            foreach (var P in restults3)
            {
                Console.WriteLine(P.Note);
            };
            Console.WriteLine("---------------------------------");
            // order by on non-query syntax

            var results4 = students.OrderBy(a => a.Note);

            foreach(var prof in results4)
            {
                Console.WriteLine(prof.Note);
            }
            Console.WriteLine("---------------------------------");
            // CONCAT and union 
            var results5 = students2.Union(students);


            foreach(var prof in results5)
            {
                Console.WriteLine(prof.Name);
            }
            Console.WriteLine("---------------------------------");
            // last && first && single
            var results6 = students.First();

                Console.WriteLine(results6.Name);


            Console.WriteLine("---------------------------------");

            // count 


            var results7 = profs.Count();
            Console.WriteLine(results7);

            Console.WriteLine("---------------------------------");
            // SUm && Max && Min && AV  
            var results8 = list.Average();
            Console.WriteLine(results8);



        }
    }
}