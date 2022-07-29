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

        public virtual DbSet<Airline> Airlines { get; set; }
        public virtual DbSet<Airport> Airports { get; set; }
        public virtual DbSet<Continent> Continents { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<CreditDetail> CreditDetails { get; set; }
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

            modelBuilder.Entity<Airline>(entity =>
            {
                entity.HasKey(e => e.CompanyId)
                    .HasName("PK__Companie__357D4CF85C9E0742");

                entity.ToTable("Airline");

                entity.Property(e => e.CompanyId).HasColumnName("Company_id");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Company_name");
            });

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
                    .HasConstraintName("FK__Airport__Country__18EBB532");
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
                    .HasConstraintName("FK__Country__Contine__160F4887");
            });

            modelBuilder.Entity<CreditDetail>(entity =>
            {
                entity.HasKey(e => e.CreditDedailsId)
                    .HasName("PK__Credit_d__D7E5344CB9D4CC40");

                entity.ToTable("Credit_details");

                entity.Property(e => e.CreditDedailsId).HasColumnName("Credit_dedails_id");

                entity.Property(e => e.CreditNumber)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("Credit_Number");

                entity.Property(e => e.Cvv)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("Owner_id");

                entity.Property(e => e.Validity).HasColumnType("date");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK__Customer__8CB382B193995CE3");

                entity.ToTable("Customer");

                entity.HasIndex(e => e.Id, "UQ__Customer__3214EC06B0C392E6")
                    .IsUnique();

                entity.Property(e => e.CustomerId).HasColumnName("Customer_id");

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
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.ToTable("Flight");

                entity.Property(e => e.FlightId).HasColumnName("Flight_id");

                entity.Property(e => e.CompanyId).HasColumnName("Company_id");

                entity.Property(e => e.CostOneWay).HasColumnType("money");

                entity.Property(e => e.CostTwoWay).HasColumnType("money");

                entity.Property(e => e.DestinationAirportId).HasColumnName("Destination_airport_id");

                entity.Property(e => e.DestinationCountryId).HasColumnName("Destination_country_id");

                entity.Property(e => e.FlightDate)
                    .HasColumnType("date")
                    .HasColumnName("Flight_date");

                entity.Property(e => e.LandingTime).HasColumnName("Landing_time");

                entity.Property(e => e.LeavingTime).HasColumnName("Leaving_time");

                entity.Property(e => e.SourceAirportId).HasColumnName("Source_airport_id");

                entity.Property(e => e.SourceCountryId).HasColumnName("Source_country_id");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Flights)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__Flight__Company___1BC821DD");

                entity.HasOne(d => d.DestinationAirport)
                    .WithMany(p => p.FlightDestinationAirports)
                    .HasForeignKey(d => d.DestinationAirportId)
                    .HasConstraintName("FK__Flight__Destinat__1F98B2C1");

                entity.HasOne(d => d.DestinationCountry)
                    .WithMany(p => p.FlightDestinationCountries)
                    .HasForeignKey(d => d.DestinationCountryId)
                    .HasConstraintName("FK__Flight__Destinat__1EA48E88");

                entity.HasOne(d => d.SourceAirport)
                    .WithMany(p => p.FlightSourceAirports)
                    .HasForeignKey(d => d.SourceAirportId)
                    .HasConstraintName("FK__Flight__Source_a__1DB06A4F");

                entity.HasOne(d => d.SourceCountry)
                    .WithMany(p => p.FlightSourceCountries)
                    .HasForeignKey(d => d.SourceCountryId)
                    .HasConstraintName("FK__Flight__Source_c__1CBC4616");
            });

            modelBuilder.Entity<Passenger>(entity =>
            {
                entity.ToTable("Passenger");

                entity.Property(e => e.PassengerId).HasColumnName("Passenger_id");

                entity.Property(e => e.CreditDedailsId).HasColumnName("Credit_dedails_id");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_id");

                entity.Property(e => e.FlightId).HasColumnName("Flight_id");

                entity.HasOne(d => d.CreditDedails)
                    .WithMany(p => p.Passengers)
                    .HasForeignKey(d => d.CreditDedailsId)
                    .HasConstraintName("FK__Passenger__Credi__503BEA1C");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Passengers)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Passenger__Custo__4E53A1AA");

                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.Passengers)
                    .HasForeignKey(d => d.FlightId)
                    .HasConstraintName("FK__Passenger__Fligh__4F47C5E3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
