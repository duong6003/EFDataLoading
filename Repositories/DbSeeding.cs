using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Web.Entities;

namespace Web.Repositories
{
    public class DbSeeding
    {
        private readonly ApplicationDbContext dbContext;

        public DbSeeding(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task Seeding()
        {
            Console.WriteLine("---> Start Seeding");
            dbContext.Database.EnsureCreated();
            if(!await dbContext.Gifts!.AnyAsync())
            {
                await dbContext.Gifts!.AddRangeAsync(new List<Gift>(){
                    new Gift(){ Name = "Gift-1", Value = 10000 },
                    new Gift(){ Name = "Gift-2", Value = 20000 },
                    new Gift(){ Name = "Gift-3", Value = 30000 },
                    new Gift(){ Name = "Gift-4", Value = 40000 },
                    new Gift(){ Name = "Gift-5", Value = 50000 },
                    new Gift(){ Name = "Gift-6", Value = 60000 },
                    new Gift(){ Name = "Gift-7", Value = 70000 },
                    new Gift(){ Name = "Gift-8", Value = 80000 },
                    new Gift(){ Name = "Gift-9", Value = 90000 },
                    new Gift(){ Name = "Gift-10", Value = 100000 }
                });
            }
            if(!await dbContext.Scholarships!.AnyAsync())
            {
                await dbContext.Scholarships!.AddRangeAsync(new List<Scholarship>(){
                    new Scholarship(){ Name = "Scholarship-1", Value = 100000 },
                    new Scholarship(){ Name = "Scholarship-2", Value = 200000 },
                    new Scholarship(){ Name = "Scholarship-3", Value = 300000 },
                    new Scholarship(){ Name = "Scholarship-4", Value = 400000 },
                    new Scholarship(){ Name = "Scholarship-5", Value = 500000 },
                    new Scholarship(){ Name = "Scholarship-6", Value = 600000 },
                    new Scholarship(){ Name = "Scholarship-7", Value = 700000 },
                    new Scholarship(){ Name = "Scholarship-8", Value = 800000 },
                    new Scholarship(){ Name = "Scholarship-9", Value = 900000 },
                    new Scholarship(){ Name = "Scholarship-10", Value = 1000000 }
                });
            }
            if(!await dbContext.Students!.AnyAsync())
            {
                await dbContext.Students!.AddRangeAsync(new List<Student>(){
                    new Student(){ Name = "Student-1" },
                    new Student(){ Name = "Student-2" },
                    new Student(){ Name = "Student-3" },
                    new Student(){ Name = "Student-4" },
                    new Student(){ Name = "Student-5" },
                    new Student(){ Name = "Student-6" },
                    new Student(){ Name = "Student-7" },
                    new Student(){ Name = "Student-8" },
                    new Student(){ Name = "Student-9" },
                    new Student(){ Name = "Student-10" }
                });
            }
            await dbContext.SaveChangesAsync();
            Console.WriteLine("---> Seeding Success");
        }
    }
}