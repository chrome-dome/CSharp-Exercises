using System;
using System.Linq;
using Workshop.CSharp.Data;
using Workshop.Common;

namespace Workshop.CSharp.EntityFramework.ExercisesB
{
    [TestClass]
    public class EntityFrameworkExercises
    {
        /// <summary>
        /// Sprobowac przeniesc zapytania LINQ to Objects z 'LinqExercises_.cs' (bez LINQ to XML)
        /// Przejrzec wykonywane zapytania SQL za pomoca 'SQL Server Profiler'
        /// </summary>
        [TestMethod]
        public void Linq()  {  }

        /// <summary>
        /// Zbudowac od podstaw wlasny model skladajacy sie z jednej encji i wygenerowac dla niego baze danych
        /// Napisac kod dodajacy, modyfikujacy oraz usuwajacy dane modelu
        /// </summary>
        [TestMethod]
        public void DatabaseFromModel()  {  }

        public class MyModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }

        public class MyDbContext : DbContext
        {
            public DbSet<MyModel> MyModels { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MyDatabase;Trusted_Connection=True;");
            }

            internal void SaveChanges()
            {
                throw new NotImplementedException();
            }
        }

        public class DatabaseFromModelExample
        {
            public static void Main()
            {
                using (var context = new MyDbContext())
                {
                    context.Database.EnsureCreated();

                    // Add data
                    context.MyModels.Add(new MyModel { Name = "Model 1", Description = "Description 1" });
                    context.SaveChanges();

                    // Modify data
                    var model = context.MyModels.First();
                    model.Name = "Modified Model 1";
                    context.SaveChanges();

                    // Remove data
                    context.MyModels.Remove(model);
                    context.SaveChanges();
                }
            }
        }
    }
}
