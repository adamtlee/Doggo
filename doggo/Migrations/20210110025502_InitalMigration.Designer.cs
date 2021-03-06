﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using doggo.Contexts;

namespace doggo.Migrations
{
    [DbContext(typeof(ClientInfoContext))]
    [Migration("20210110025502_InitalMigration")]
    partial class InitalMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("doggo.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "321 Nuna St. Denver Colorado",
                            Email = "bobross@mail.com",
                            FirstName = "Bob",
                            LastName = "Ross",
                            Phone = "303-000-0001"
                        },
                        new
                        {
                            Id = 2,
                            Address = "234 Nuna St. Arvada Colorado",
                            Email = "batman@mail.com",
                            FirstName = "Bat",
                            LastName = "Man",
                            Phone = "303-000-0101"
                        },
                        new
                        {
                            Id = 3,
                            Address = "333 Nuna St. Arvada Colorado",
                            Email = "superman@mail.com",
                            FirstName = "Super",
                            LastName = "Man",
                            Phone = "303-100-0101"
                        },
                        new
                        {
                            Id = 4,
                            Address = "111 Nuna St. Arvada Colorado",
                            Email = "catwoman@mail.com",
                            FirstName = "Cat",
                            LastName = "Woman",
                            Phone = "303-101-0101"
                        },
                        new
                        {
                            Id = 5,
                            Address = "112 Nuna St. Arvada Colorado",
                            Email = "wonderwoman@mail.com",
                            FirstName = "Wonder",
                            LastName = "Woman",
                            Phone = "303-111-0101"
                        });
                });

            modelBuilder.Entity("doggo.Entities.Dog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Birth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Breed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Dogs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Birth = "Jul 10th 2001",
                            Breed = "Pitbull",
                            ClientId = 1,
                            Name = "Tyco",
                            ShortName = "T"
                        },
                        new
                        {
                            Id = 2,
                            Birth = "Jul 11th 2021",
                            Breed = "Poodle",
                            ClientId = 3,
                            Name = "Maxxie",
                            ShortName = "M"
                        },
                        new
                        {
                            Id = 3,
                            Birth = "Jul 7th 2001",
                            Breed = "Pitbull",
                            ClientId = 2,
                            Name = "Bo",
                            ShortName = "B"
                        },
                        new
                        {
                            Id = 4,
                            Birth = "Aug 10th 2001",
                            Breed = "Boxer",
                            ClientId = 4,
                            Name = "Bennie",
                            ShortName = "B"
                        },
                        new
                        {
                            Id = 5,
                            Birth = "Dec 11th 2001",
                            Breed = "Mutt",
                            ClientId = 3,
                            Name = "Jax",
                            ShortName = "J"
                        },
                        new
                        {
                            Id = 6,
                            Birth = "Nov 15th 2001",
                            Breed = "Husky",
                            ClientId = 1,
                            Name = "Dyco",
                            ShortName = "D"
                        },
                        new
                        {
                            Id = 7,
                            Birth = "Aug 4th 2001",
                            Breed = "Pug",
                            ClientId = 5,
                            Name = "Dunkin",
                            ShortName = "D"
                        });
                });

            modelBuilder.Entity("doggo.Entities.Dog", b =>
                {
                    b.HasOne("doggo.Entities.Client", "Client")
                        .WithMany("Dogs")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("doggo.Entities.Client", b =>
                {
                    b.Navigation("Dogs");
                });
#pragma warning restore 612, 618
        }
    }
}
