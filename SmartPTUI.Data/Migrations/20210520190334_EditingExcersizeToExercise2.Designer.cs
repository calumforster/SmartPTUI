﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartPTUI.Data;

namespace SmartPTUI.Migrations
{
    [DbContext(typeof(SmartPTUIContext))]
    [Migration("20210520190334_EditingExcersizeToExercise2")]
    partial class EditingExcersizeToExercise2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SmartPTUI.Areas.Identity.Data.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("SmartPTUI.Data.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CurrentHealth")
                        .HasColumnType("int");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PersonalTrainerId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("isDisabled")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("PersonalTrainerId");

                    b.HasIndex("UserId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("SmartPTUI.Data.DomainModels.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CoreArea")
                        .HasColumnType("int");

                    b.Property<int>("Difficulty")
                        .HasColumnType("int");

                    b.Property<int>("TimePerRep")
                        .HasColumnType("int");

                    b.Property<string>("WorkoutDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkoutName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ExerciseStore");
                });

            modelBuilder.Entity("SmartPTUI.Data.DomainModels.ExerciseMeta", b =>
                {
                    b.Property<int>("ExerciseMetaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ExerciseFeedbackRating")
                        .HasColumnType("int");

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<string>("FurtherNotes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RepsGoal")
                        .HasColumnType("int");

                    b.Property<int>("SetsGoal")
                        .HasColumnType("int");

                    b.Property<int>("WeightGoal")
                        .HasColumnType("int");

                    b.Property<int?>("WorkoutSessionId")
                        .HasColumnType("int");

                    b.Property<bool>("isCompletedExerciseMeta")
                        .HasColumnType("bit");

                    b.HasKey("ExerciseMetaId");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("WorkoutSessionId");

                    b.ToTable("ExerciseMetas");
                });

            modelBuilder.Entity("SmartPTUI.Data.DomainModels.ExerciseSet", b =>
                {
                    b.Property<int>("ExerciseSetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ExerciseMetaId")
                        .HasColumnType("int");

                    b.Property<int>("RepsAchieved")
                        .HasColumnType("int");

                    b.Property<int>("RepsInReserve")
                        .HasColumnType("int");

                    b.Property<string>("SetName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WeightAchieved")
                        .HasColumnType("int");

                    b.HasKey("ExerciseSetId");

                    b.HasIndex("ExerciseMetaId");

                    b.ToTable("ExerciseSets");
                });

            modelBuilder.Entity("SmartPTUI.Data.DomainModels.WorkoutPlan", b =>
                {
                    b.Property<int>("WorkoutPlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int?>("WorkoutQuestionId")
                        .HasColumnType("int");

                    b.Property<bool>("isCompletedWorkoutPlan")
                        .HasColumnType("bit");

                    b.HasKey("WorkoutPlanId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("WorkoutQuestionId");

                    b.ToTable("WorkoutPlans");
                });

            modelBuilder.Entity("SmartPTUI.Data.DomainModels.WorkoutQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DaysPerWeek")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("EndWeight")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("Goal")
                        .HasColumnType("int");

                    b.Property<int?>("NumberOfWeeks")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("StartWeight")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("TimePerWorkout")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("WorkoutName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WorkoutQuestions");
                });

            modelBuilder.Entity("SmartPTUI.Data.DomainModels.WorkoutSession", b =>
                {
                    b.Property<int>("WorkoutSessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("WorkoutWeekId")
                        .HasColumnType("int");

                    b.Property<bool>("isCompletedWorkoutSession")
                        .HasColumnType("bit");

                    b.HasKey("WorkoutSessionId");

                    b.HasIndex("WorkoutWeekId");

                    b.ToTable("WorkoutSessions");
                });

            modelBuilder.Entity("SmartPTUI.Data.DomainModels.WorkoutWeek", b =>
                {
                    b.Property<int>("WorkoutWeekId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CaloriesConsumed")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("EndWeight")
                        .HasColumnType("int");

                    b.Property<int>("StartWeight")
                        .HasColumnType("int");

                    b.Property<int?>("WorkoutPlanId")
                        .HasColumnType("int");

                    b.Property<bool>("isCompletedWorkoutWeek")
                        .HasColumnType("bit");

                    b.HasKey("WorkoutWeekId");

                    b.HasIndex("WorkoutPlanId");

                    b.ToTable("WorkoutWeeks");
                });

            modelBuilder.Entity("SmartPTUI.Data.PersonalTrainer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BackgorundColour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiteName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TextColour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleColour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TopBarColour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("WelcomeMessage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PersonalTrainer");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SmartPTUI.Areas.Identity.Data.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SmartPTUI.Areas.Identity.Data.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartPTUI.Areas.Identity.Data.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SmartPTUI.Areas.Identity.Data.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SmartPTUI.Data.Customer", b =>
                {
                    b.HasOne("SmartPTUI.Data.PersonalTrainer", "PersonalTrainer")
                        .WithMany("Customers")
                        .HasForeignKey("PersonalTrainerId");

                    b.HasOne("SmartPTUI.Areas.Identity.Data.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("PersonalTrainer");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SmartPTUI.Data.DomainModels.ExerciseMeta", b =>
                {
                    b.HasOne("SmartPTUI.Data.DomainModels.Exercise", "ExerciseType")
                        .WithMany()
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartPTUI.Data.DomainModels.WorkoutSession", "Workout")
                        .WithMany("Exercises")
                        .HasForeignKey("WorkoutSessionId");

                    b.Navigation("ExerciseType");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("SmartPTUI.Data.DomainModels.ExerciseSet", b =>
                {
                    b.HasOne("SmartPTUI.Data.DomainModels.ExerciseMeta", null)
                        .WithMany("ExerciseSet")
                        .HasForeignKey("ExerciseMetaId");
                });

            modelBuilder.Entity("SmartPTUI.Data.DomainModels.WorkoutPlan", b =>
                {
                    b.HasOne("SmartPTUI.Data.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("SmartPTUI.Data.DomainModels.WorkoutQuestion", "WorkoutQuestion")
                        .WithMany()
                        .HasForeignKey("WorkoutQuestionId");

                    b.Navigation("Customer");

                    b.Navigation("WorkoutQuestion");
                });

            modelBuilder.Entity("SmartPTUI.Data.DomainModels.WorkoutSession", b =>
                {
                    b.HasOne("SmartPTUI.Data.DomainModels.WorkoutWeek", "WorkoutWeek")
                        .WithMany("Workout")
                        .HasForeignKey("WorkoutWeekId");

                    b.Navigation("WorkoutWeek");
                });

            modelBuilder.Entity("SmartPTUI.Data.DomainModels.WorkoutWeek", b =>
                {
                    b.HasOne("SmartPTUI.Data.DomainModels.WorkoutPlan", "WorkoutPlan")
                        .WithMany("WorkoutWeek")
                        .HasForeignKey("WorkoutPlanId");

                    b.Navigation("WorkoutPlan");
                });

            modelBuilder.Entity("SmartPTUI.Data.PersonalTrainer", b =>
                {
                    b.HasOne("SmartPTUI.Areas.Identity.Data.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SmartPTUI.Data.DomainModels.ExerciseMeta", b =>
                {
                    b.Navigation("ExerciseSet");
                });

            modelBuilder.Entity("SmartPTUI.Data.DomainModels.WorkoutPlan", b =>
                {
                    b.Navigation("WorkoutWeek");
                });

            modelBuilder.Entity("SmartPTUI.Data.DomainModels.WorkoutSession", b =>
                {
                    b.Navigation("Exercises");
                });

            modelBuilder.Entity("SmartPTUI.Data.DomainModels.WorkoutWeek", b =>
                {
                    b.Navigation("Workout");
                });

            modelBuilder.Entity("SmartPTUI.Data.PersonalTrainer", b =>
                {
                    b.Navigation("Customers");
                });
#pragma warning restore 612, 618
        }
    }
}
