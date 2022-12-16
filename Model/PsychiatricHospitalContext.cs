using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PsychiatricHospitalContext : DbContext
    {
        public DbSet<Psycotherapist> Psycotherapists { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        private readonly string _connectionString;

        public PsychiatricHospitalContext()
        {
            _connectionString = "Data Source=localhost;Initial Catalog=PsychiatricHospital;Integrated Security=true; TrustServerCertificate=True";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Psycotherapist>().HasMany(p=>p.Calendar).WithOne(m=>m.Psycotherapist).HasForeignKey(m=>m.PsycotherapistId);

            modelBuilder.Entity<Psycotherapist>().HasData(new List<Psycotherapist>
            {
                new Psycotherapist()
                {
                    Id = 1,
                    Name = "Zach Curtis",
                    Address = "Herentalsebaan 335, 2100 Antwerpen",
                    Password = "1ps",
                },
                new Psycotherapist()
                {
                    Id = 2,
                    Name = "Max Thomson",
                    Address = "Eyendijkstraat 22, 2100 Antwerpen",
                    Password = "2ps",
                },
                new Psycotherapist()
                {
                    Id = 3,
                    Name = "Eva Reyes",
                    Address = "Apollostraat 31, 2140 Antwerpen",
                    Password = "3ps",
                },
                new Psycotherapist()
                {
                    Id = 4,
                    Name = "Farhan Greene",
                    Address = "Lange Beeldekensstraat 267, 2060 Antwerpen",
                    Password = "4ps",
                },
                new Psycotherapist()
                {
                    Id = 5,
                    Name="Lorna Carpenter",
                    Address = "Arenaplein 62 A, 2100 Antwerpen",
                    Password = "5ps",
                },
            });
            modelBuilder.Entity<Meeting>().HasData(new List<Meeting>
            {
                new Meeting()
                {
                    Id = 1,
                    Name = "Ronald E. Tinsley depression",
                    Description = "Nulla sed neque malesuada, faucibus est non, luctus elit. Sed ultrices sem justo, convallis convallis ex sagittis sit amet. Cras at mauris in lectus semper placerat sit amet nec metus.",
                    FirstMeeting = new DateTime(2022, 12, 17, 14, 0, 0),
                    FrequencyTime = 7,
                    PsycotherapistId = 1,
                },
                new Meeting()
                {
                    Id = 2,
                    Name = "Edward J. Reynolds post-traumatic syndrome",
                    Description = "Mauris ac odio dui. ",
                    FirstMeeting = new DateTime(2022, 12, 13, 16, 0, 0),
                    FrequencyTime = 14,
                    PsycotherapistId = 2,
                },
                new Meeting()
                {
                    Id = 3,
                    Name = "Lloyd D. Smith amnesia",
                    Description = "Duis non tellus sed velit imperdiet lacinia. ",
                    FirstMeeting = new DateTime(2022, 12, 15, 13, 20, 0),
                    FrequencyTime = 14,
                    PsycotherapistId = 3,
                },
                new Meeting()
                {
                    Id = 4,
                    Name = "Corine W. Daniels paranoia",
                    Description = "Cras varius tortor a diam pulvinar tempor. Aliquam vel bibendum turpis. ",
                    FirstMeeting = new DateTime(2022, 12, 17, 10, 0, 0),
                    FrequencyTime = 7,
                    PsycotherapistId = 4,
                },
                new Meeting()
                {
                    Id = 5,
                    Name = "Christine R. Carlson addiction",
                    Description = "Quisque nunc quam, lacinia ut efficitur et, dictum eu dui. Aliquam dapibus sem eget nisi pellentesque, non eleifend ipsum bibendum.",
                    FirstMeeting = new DateTime(2022, 12, 16, 14, 30, 0),
                    FrequencyTime = 3,
                    PsycotherapistId = 5,
                },
                new Meeting()
                {
                    Id = 6,
                    Name = "Tricia C. Kirkpatrick depression",
                    Description = "Nulla ut finibus tellus. Donec ultrices sem eros, tincidunt ultrices leo malesuada ut. Vivamus ultricies eros eget enim lobortis eleifend. Mauris consectetur, ipsum at condimentum semper, elit elit egestas nibh, id suscipit sem diam sed neque. ",
                    FirstMeeting = new DateTime(2022, 12, 12, 12, 0, 0),
                    FrequencyTime = 4,
                    PsycotherapistId = 1,
                },
            });
        }

    }
}
