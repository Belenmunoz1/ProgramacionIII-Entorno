using Entities; 

namespace DAO
{
   
    public static class MockDatabase
    {
        //Ejercicio 1 
    
        public static List<Player> Players { get; set; } = new List<Player>
        {
            new Player { Id = 1, Name = "Pepe pompin", Age = 36, Dni = "4564868", Numero = 01, TeamId = 1 },
            new Player { Id = 2, Name = "Teletubie", Age = 36, Dni = "648645", Numero = 10, TeamId = 1 }
        };

        public static List<Trainer> Trainers { get; set; } = new List<Trainer>
        {
            new Trainer { Id = 1, Name = "Nala", Age = 20, Dni = "18574641685" }
        };

       
        public static List<Team> Teams { get; set; } = new List<Team>
        {
            new Team { Id = 1, Name = "Selección Cordoba", Category = "Super primera" }
        };

        // Ejercicio 2

        public static List<Student> Students { get; set; } = new List<Student>
        {
            new Student { Id = 1, Name = " Topo", Age = 28, Dni = "1651645", File = "707" }
        };

        public static List<Course> Courses { get; set; } = new List<Course>
        {
            new Course { Id = 1, Name = "Curso de Programación" }
        };

        public static List<Activity> Activities { get; set; } = new List<Activity>
        {
            new Activity {
                Id = 1,
                Title = "TP final",
                Description = "Trabajo Anual",
                Date = DateTime.Now,               
                Type = TypeActivity.PracticalWork  
            }
        };
    }
}
