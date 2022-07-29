using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApiProject.Models
{
    public partial class TravelsAgencyContext : DbContext
    {
        public TravelsAgencyContext()
        {
        }

        public TravelsAgencyContext(DbContextOptions<TravelsAgencyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Airport> Airports { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Continent> Continents { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<Passenger> Passengers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=srv2\\pupils;Database=TravelsAgency;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<Airport>(entity =>
            {
                entity.ToTable("Airport");

                entity.Property(e => e.AirportId).HasColumnName("Airport_id");

                entity.Property(e => e.AirportName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Airport_name");

                entity.Property(e => e.CountryId).HasColumnName("Country_id");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Airports)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__Airport__Country__6FE99F9F");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company");

                entity.Property(e => e.CompanyId).HasColumnName("Company_id");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Company_name");
            });

            modelBuilder.Entity<Continent>(entity =>
            {
                entity.ToTable("Continent");

                entity.Property(e => e.ContinentId).HasColumnName("Continent_id");

                entity.Property(e => e.ContinentName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Continent_name");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.Property(e => e.CountryId).HasColumnName("Country_id");

                entity.Property(e => e.ContinentCode).HasColumnName("Continent_code");

                entity.Property(e => e.CountryName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Country_name");

                entity.Property(e => e.Information)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.ContinentCodeNavigation)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.ContinentCode)
                    .HasConstraintName("FK__Country__Contine__6D0D32F4");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK__Customer__8CB382B1374D7795");

                entity.ToTable("Customer");

                entity.HasIndex(e => e.Id, "UQ__Customer__3214EC064BB5533B")
                    .IsUnique();

                entity.Property(e => e.CustomerId).HasColumnName("Customer_id");

                entity.Property(e => e.CreditNumber)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("Credit_Number");

                entity.Property(e => e.Cvv)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("First_Name");

                entity.Property(e => e.Id)
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Last_Name");

                entity.Property(e => e.Mail)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Validity).HasColumnType("date");
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.ToTable("Flight");

                entity.Property(e => e.FlightId).HasColumnName("Flight_id");

                entity.Property(e => e.CompanyId).HasColumnName("Company_id");

                entity.Property(e => e.CostOneWay).HasColumnType("money");

                entity.Property(e => e.CostTwoWay).HasColumnType("money");

                entity.Property(e => e.DestinationCountry).HasColumnName("Destination_country");

                entity.Property(e => e.FlightDate)
                    .HasColumnType("date")
                    .HasColumnName("Flight_date");

                entity.Property(e => e.LandingTime).HasColumnName("Landing_time");

                entity.Property(e => e.LeavingTime).HasColumnName("Leaving_time");

                entity.Property(e => e.SourceCountry).HasColumnName("Source_country");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Flights)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__Flight__Company___72C60C4A");

                entity.HasOne(d => d.DestinationCountryNavigation)
                    .WithMany(p => p.FlightDestinationCountryNavigations)
                    .HasForeignKey(d => d.DestinationCountry)
                    .HasConstraintName("FK__Flight__Destinat__74AE54BC");

                entity.HasOne(d => d.SourceCountryNavigation)
                    .WithMany(p => p.FlightSourceCountryNavigations)
                    .HasForeignKey(d => d.SourceCountry)
                    .HasConstraintName("FK__Flight__Source_c__73BA3083");
            });

            modelBuilder.Entity<Passenger>(entity =>
            {
                entity.ToTable("Passenger");

                entity.Property(e => e.PassengerId).HasColumnName("Passenger_id");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_id");

                entity.Property(e => e.FlightId).HasColumnName("Flight_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Passengers)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Passenger__Custo__7B5B524B");

                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.Passengers)
                    .HasForeignKey(d => d.FlightId)
                    .HasConstraintName("FK__Passenger__Fligh__7C4F7684");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
