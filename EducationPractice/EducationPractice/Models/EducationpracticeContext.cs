using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EducationPractice.Models;

public partial class EducationpracticeContext : DbContext
{
    public EducationpracticeContext()
    {
    }

    public EducationpracticeContext(DbContextOptions<EducationpracticeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ActivitiesList> ActivitiesLists { get; set; }

    public virtual DbSet<Activity> Activities { get; set; }

    public virtual DbSet<Arranger> Arrangers { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Direction> Directions { get; set; }

    public virtual DbSet<EventsPlan> EventsPlans { get; set; }

    public virtual DbSet<Expert> Experts { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<Moderator> Moderators { get; set; }

    public virtual DbSet<ModeratorEvent> ModeratorEvents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=educationpractice;Username=postgres;Password=");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActivitiesList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("activities_list_pkey");

            entity.ToTable("activities_list");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NameActivity)
                .HasMaxLength(150)
                .HasColumnName("name_activity");
        });

        modelBuilder.Entity<Activity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("activities_pkey");

            entity.ToTable("activities");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Activity1).HasColumnName("activity");
            entity.Property(e => e.Activityday).HasColumnName("activityday");
            entity.Property(e => e.Countdays).HasColumnName("countdays");
            entity.Property(e => e.Expert1).HasColumnName("expert1");
            entity.Property(e => e.Expert2).HasColumnName("expert2");
            entity.Property(e => e.Expert3).HasColumnName("expert3");
            entity.Property(e => e.Expert4).HasColumnName("expert4");
            entity.Property(e => e.Expert5).HasColumnName("expert5");
            entity.Property(e => e.Moderator).HasColumnName("moderator");
            entity.Property(e => e.NameEvent).HasColumnName("name_event");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.Starttime).HasColumnName("starttime");
            entity.Property(e => e.Winner).HasColumnName("winner");

            entity.HasOne(d => d.Activity1Navigation).WithMany(p => p.Activities)
                .HasForeignKey(d => d.Activity1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("activities_activity_fkey");

            entity.HasOne(d => d.Expert1Navigation).WithMany(p => p.ActivityExpert1Navigations)
                .HasForeignKey(d => d.Expert1)
                .HasConstraintName("activities_expert1_fkey");

            entity.HasOne(d => d.Expert2Navigation).WithMany(p => p.ActivityExpert2Navigations)
                .HasForeignKey(d => d.Expert2)
                .HasConstraintName("activities_expert2_fkey");

            entity.HasOne(d => d.Expert3Navigation).WithMany(p => p.ActivityExpert3Navigations)
                .HasForeignKey(d => d.Expert3)
                .HasConstraintName("activities_expert3_fkey");

            entity.HasOne(d => d.Expert4Navigation).WithMany(p => p.ActivityExpert4Navigations)
                .HasForeignKey(d => d.Expert4)
                .HasConstraintName("activities_expert4_fkey");

            entity.HasOne(d => d.Expert5Navigation).WithMany(p => p.ActivityExpert5Navigations)
                .HasForeignKey(d => d.Expert5)
                .HasConstraintName("activities_expert5_fkey");

            entity.HasOne(d => d.ModeratorNavigation).WithMany(p => p.Activities)
                .HasForeignKey(d => d.Moderator)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("activities_moderator_fkey");

            entity.HasOne(d => d.NameEventNavigation).WithMany(p => p.Activities)
                .HasForeignKey(d => d.NameEvent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("activities_name_event_fkey");

            entity.HasOne(d => d.WinnerNavigation).WithMany(p => p.Activities)
                .HasForeignKey(d => d.Winner)
                .HasConstraintName("activities_winner_fkey");
        });

        modelBuilder.Entity<Arranger>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("arrangers_pkey");

            entity.ToTable("arrangers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Birthdate).HasColumnName("birthdate");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.Fcs)
                .HasMaxLength(150)
                .HasColumnName("fcs");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.IdCountry).HasColumnName("id_country");
            entity.Property(e => e.Image)
                .HasMaxLength(20)
                .HasColumnName("image");
            entity.Property(e => e.Passwd)
                .HasMaxLength(50)
                .HasColumnName("passwd");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .HasColumnName("phone_number");

            entity.HasOne(d => d.GenderNavigation).WithMany(p => p.Arrangers)
                .HasForeignKey(d => d.Gender)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("arrangers_gender_fkey");

            entity.HasOne(d => d.IdCountryNavigation).WithMany(p => p.Arrangers)
                .HasForeignKey(d => d.IdCountry)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("arrangers_id_country_fkey");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cities_pkey");

            entity.ToTable("cities");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CityName)
                .HasMaxLength(150)
                .HasColumnName("city_name");
            entity.Property(e => e.Image)
                .HasMaxLength(50)
                .HasColumnName("image");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("countries_pkey");

            entity.ToTable("countries");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(5)
                .HasColumnName("code");
            entity.Property(e => e.CodeTwo).HasColumnName("code_two");
            entity.Property(e => e.NameEnglish)
                .HasMaxLength(150)
                .HasColumnName("name_english");
            entity.Property(e => e.NameRussian)
                .HasMaxLength(150)
                .HasColumnName("name_russian");
        });

        modelBuilder.Entity<Direction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("directions_pkey");

            entity.ToTable("directions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NameDirection)
                .HasMaxLength(150)
                .HasColumnName("name_direction");
        });

        modelBuilder.Entity<EventsPlan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("events_plan_pkey");

            entity.ToTable("events_plan");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Contestday).HasColumnName("contestday");
            entity.Property(e => e.Countdays).HasColumnName("countdays");
            entity.Property(e => e.EventName)
                .HasMaxLength(250)
                .HasColumnName("event_name");
            entity.Property(e => e.Idcity).HasColumnName("idcity");
            entity.Property(e => e.Image)
                .HasMaxLength(20)
                .HasColumnName("image");

            entity.HasOne(d => d.IdcityNavigation).WithMany(p => p.EventsPlans)
                .HasForeignKey(d => d.Idcity)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("events_plan_idcity_fkey");
        });

        modelBuilder.Entity<Expert>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("experts_pkey");

            entity.ToTable("experts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Birthdate).HasColumnName("birthdate");
            entity.Property(e => e.Direction).HasColumnName("direction");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.Fcs)
                .HasMaxLength(150)
                .HasColumnName("fcs");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.IdCountry).HasColumnName("id_country");
            entity.Property(e => e.Image)
                .HasMaxLength(20)
                .HasColumnName("image");
            entity.Property(e => e.Passwd)
                .HasMaxLength(50)
                .HasColumnName("passwd");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .HasColumnName("phone_number");

            entity.HasOne(d => d.DirectionNavigation).WithMany(p => p.Experts)
                .HasForeignKey(d => d.Direction)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("experts_direction_fkey");

            entity.HasOne(d => d.GenderNavigation).WithMany(p => p.Experts)
                .HasForeignKey(d => d.Gender)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("experts_gender_fkey");

            entity.HasOne(d => d.IdCountryNavigation).WithMany(p => p.Experts)
                .HasForeignKey(d => d.IdCountry)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("experts_id_country_fkey");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("genders_pkey");

            entity.ToTable("genders");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Gender1)
                .HasMaxLength(20)
                .HasColumnName("gender");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("members_pkey");

            entity.ToTable("members");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Birthdate).HasColumnName("birthdate");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.Fcs)
                .HasMaxLength(150)
                .HasColumnName("fcs");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.IdCountry).HasColumnName("id_country");
            entity.Property(e => e.Image)
                .HasMaxLength(20)
                .HasColumnName("image");
            entity.Property(e => e.Passwd)
                .HasMaxLength(50)
                .HasColumnName("passwd");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .HasColumnName("phone_number");

            entity.HasOne(d => d.GenderNavigation).WithMany(p => p.Members)
                .HasForeignKey(d => d.Gender)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("members_gender_fkey");

            entity.HasOne(d => d.IdCountryNavigation).WithMany(p => p.Members)
                .HasForeignKey(d => d.IdCountry)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("members_id_country_fkey");
        });

        modelBuilder.Entity<Moderator>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("moderators_pkey");

            entity.ToTable("moderators");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Birthdate).HasColumnName("birthdate");
            entity.Property(e => e.Direction).HasColumnName("direction");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.Events).HasColumnName("events");
            entity.Property(e => e.Fcs)
                .HasMaxLength(150)
                .HasColumnName("fcs");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.IdCountry).HasColumnName("id_country");
            entity.Property(e => e.Image)
                .HasMaxLength(20)
                .HasColumnName("image");
            entity.Property(e => e.Passwd)
                .HasMaxLength(50)
                .HasColumnName("passwd");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .HasColumnName("phone_number");

            entity.HasOne(d => d.DirectionNavigation).WithMany(p => p.Moderators)
                .HasForeignKey(d => d.Direction)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("moderators_direction_fkey");

            entity.HasOne(d => d.EventsNavigation).WithMany(p => p.Moderators)
                .HasForeignKey(d => d.Events)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("moderators_events_fkey");

            entity.HasOne(d => d.GenderNavigation).WithMany(p => p.Moderators)
                .HasForeignKey(d => d.Gender)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("moderators_gender_fkey");

            entity.HasOne(d => d.IdCountryNavigation).WithMany(p => p.Moderators)
                .HasForeignKey(d => d.IdCountry)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("moderators_id_country_fkey");
        });

        modelBuilder.Entity<ModeratorEvent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("moderator_events_pkey");

            entity.ToTable("moderator_events");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NameEvent)
                .HasMaxLength(100)
                .HasColumnName("name_event");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
