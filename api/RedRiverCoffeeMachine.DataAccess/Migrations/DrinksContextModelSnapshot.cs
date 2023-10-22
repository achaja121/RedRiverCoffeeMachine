﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RedRiverCoffeeMachine.Data.DataAccess;

#nullable disable

namespace RedRiverCoffeeMachine.DataAccess.Migrations
{
    [DbContext(typeof(DrinksContext))]
    partial class DrinksContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RedRiverCoffeeMachine.Data.Models.Drink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RecipeStepsOrder")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Drinks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Lemon Tea",
                            RecipeStepsOrder = "1,2,3,4",
                            Type = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Coffee",
                            RecipeStepsOrder = "1,5,3,4",
                            Type = 2
                        },
                        new
                        {
                            Id = 3,
                            Name = "Chocolate",
                            RecipeStepsOrder = "1,6,3",
                            Type = 3
                        });
                });

            modelBuilder.Entity("RedRiverCoffeeMachine.Data.Models.Extra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Extras");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Lemon"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Sugar"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Milk"
                        });
                });

            modelBuilder.Entity("RedRiverCoffeeMachine.Data.Models.RecipeStep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("StepName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("RecipeSteps");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            StepName = "Boil some water"
                        },
                        new
                        {
                            Id = 2,
                            StepName = "Steep the water in the tea"
                        },
                        new
                        {
                            Id = 3,
                            StepName = "Pour {drinkType} in the cup"
                        },
                        new
                        {
                            Id = 4,
                            StepName = "Add {drinkExtras}"
                        },
                        new
                        {
                            Id = 5,
                            StepName = "Brew the coffee grounds"
                        },
                        new
                        {
                            Id = 6,
                            StepName = "Add drinking chocolate powder to the water"
                        });
                });

            modelBuilder.Entity("RedRiverCoffeeMachine.DataAccess.Models.DrinkExtra", b =>
                {
                    b.Property<int>("DrinkId")
                        .HasColumnType("int");

                    b.Property<int>("ExtraId")
                        .HasColumnType("int");

                    b.HasKey("DrinkId", "ExtraId");

                    b.HasIndex("ExtraId");

                    b.ToTable("DrinkExtra");

                    b.HasData(
                        new
                        {
                            DrinkId = 1,
                            ExtraId = 1
                        },
                        new
                        {
                            DrinkId = 1,
                            ExtraId = 2
                        },
                        new
                        {
                            DrinkId = 1,
                            ExtraId = 3
                        },
                        new
                        {
                            DrinkId = 2,
                            ExtraId = 2
                        },
                        new
                        {
                            DrinkId = 2,
                            ExtraId = 3
                        },
                        new
                        {
                            DrinkId = 3,
                            ExtraId = 2
                        });
                });

            modelBuilder.Entity("RedRiverCoffeeMachine.DataAccess.Models.DrinkExtra", b =>
                {
                    b.HasOne("RedRiverCoffeeMachine.Data.Models.Drink", "Drink")
                        .WithMany("DrinkExtras")
                        .HasForeignKey("DrinkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RedRiverCoffeeMachine.Data.Models.Extra", "Extra")
                        .WithMany("DrinkExtras")
                        .HasForeignKey("ExtraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drink");

                    b.Navigation("Extra");
                });

            modelBuilder.Entity("RedRiverCoffeeMachine.Data.Models.Drink", b =>
                {
                    b.Navigation("DrinkExtras");
                });

            modelBuilder.Entity("RedRiverCoffeeMachine.Data.Models.Extra", b =>
                {
                    b.Navigation("DrinkExtras");
                });
#pragma warning restore 612, 618
        }
    }
}