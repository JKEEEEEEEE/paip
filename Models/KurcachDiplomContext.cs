using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace kursach_diplom_api.Models;

public partial class KurcachDiplomContext : DbContext
{
    public KurcachDiplomContext()
    {
    }

    public KurcachDiplomContext(DbContextOptions<KurcachDiplomContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Food> Foods { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Photo> Photos { get; set; }

    public virtual DbSet<PlacesVisited> PlacesVisiteds { get; set; }

    public virtual DbSet<Prog> Progrs { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomType> RoomTypes { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Token> Tokens { get; set; }

    public virtual DbSet<Tour> Tours { get; set; }

    public virtual DbSet<TouristRoute> TouristRoutes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.IdCity);

            entity.ToTable("City");

            entity.Property(e => e.IdCity).HasColumnName("Id_City");
            entity.Property(e => e.HotelId).HasColumnName("Hotel_Id");
            entity.Property(e => e.NameCity)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Name_City");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.IdCountry);

            entity.ToTable("Country");

            entity.Property(e => e.IdCountry).HasColumnName("Id_Country");
            entity.Property(e => e.NameCountry)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Name_Country");
            entity.Property(e => e.CityId).HasColumnName("City_Id");
            entity.Property(e => e.TouristRoutesId).HasColumnName("Tourist_Routes_Id");
        });

        modelBuilder.Entity<Food>(entity =>
        {
            entity.HasKey(e => e.IdFood);

            entity.ToTable("Food");

            entity.Property(e => e.IdFood).HasColumnName("Id_Food");
            entity.Property(e => e.DescriptionFood)
                .IsUnicode(false)
                .HasColumnName("Description_Food");
            entity.Property(e => e.DishFood)
                .IsUnicode(false)
                .HasColumnName("Dish_Food");
            entity.Property(e => e.PriceFood)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("Price_Food");
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.IdHotel);

            entity.ToTable("Hotel");

            entity.Property(e => e.IdHotel).HasColumnName("Id_Hotel");
            entity.Property(e => e.CategoryHotel)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Category_Hotel");
            entity.Property(e => e.FoodId).HasColumnName("Food_Id");
            entity.Property(e => e.NameHotel)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Name_Hotel");
            entity.Property(e => e.PhotoId).HasColumnName("Photo_Id");
            entity.Property(e => e.RoomId).HasColumnName("Room_Id");
            entity.Property(e => e.ServicesId).HasColumnName("Services_Id");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.IdPayments);

            entity.Property(e => e.IdPayments).HasColumnName("Id_Payments");
            entity.Property(e => e.DatePayments)
                .HasColumnType("date")
                .HasColumnName("Date_Payments");
            entity.Property(e => e.PricePayments)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Price_Payments");
            entity.Property(e => e.StatusPayments)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Status_Payments");
        });

        modelBuilder.Entity<Photo>(entity =>
        {
            entity.HasKey(e => e.IdPhoto);

            entity.ToTable("Photo");

            entity.Property(e => e.IdPhoto).HasColumnName("Id_Photo");
            entity.Property(e => e.LinkPhoto)
                .IsUnicode(false)
                .HasColumnName("Link_Photo");
            entity.Property(e => e.NamePhoto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Name_Photo");
        });

        modelBuilder.Entity<PlacesVisited>(entity =>
        {
            entity.HasKey(e => e.IdPlacesVisited);

            entity.ToTable("Places_Visited");

            entity.Property(e => e.IdPlacesVisited).HasColumnName("Id_Places_Visited");
            entity.Property(e => e.DescriptionPlacesVisited)
                .IsUnicode(false)
                .HasColumnName("Description_Places_Visited");
            entity.Property(e => e.NamePlacesVisited)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Name_Places_Visited");
        });

        modelBuilder.Entity<Prog>(entity =>
        {
            entity.HasKey(e => e.IdProg);

            entity.Property(e => e.IdProg).HasColumnName("Id_Programs");
            entity.Property(e => e.Tema)
                .IsUnicode(false)
                .HasColumnName("tema");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.IdReviews);

            entity.Property(e => e.IdReviews).HasColumnName("Id_Reviews");
            entity.Property(e => e.DateReviews)
                .HasColumnType("date")
                .HasColumnName("Date_Reviews");
            entity.Property(e => e.DescriptionReviews)
                .IsUnicode(false)
                .HasColumnName("Description_Reviews");
            entity.Property(e => e.EvaluationReviews).HasColumnName("Evaluation_Reviews");
            entity.Property(e => e.UsersId).HasColumnName("Users_Id");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRole);

            entity.ToTable("Role");

            entity.Property(e => e.IdRole).HasColumnName("Id_Role");
            entity.Property(e => e.NameRole)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Name_Role");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.IdRoom);

            entity.ToTable("Room");

            entity.Property(e => e.IdRoom).HasColumnName("Id_Room");
            entity.Property(e => e.NumberAdultsRoom).HasColumnName("Number_Adults_Room");
            entity.Property(e => e.NumberChildrenRoom).HasColumnName("Number_Children_Room");
            entity.Property(e => e.PhotoId).HasColumnName("Photo_Id");
            entity.Property(e => e.RoomTypeId).HasColumnName("Room_Type_Id");
        });

        modelBuilder.Entity<RoomType>(entity =>
        {
            entity.HasKey(e => e.IdRoomType);

            entity.ToTable("Room_Type");

            entity.Property(e => e.IdRoomType).HasColumnName("Id_Room_Type");
            entity.Property(e => e.NameRoomType)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Name_Room_Type");
            entity.Property(e => e.PriceRoomType)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("Price_Room_Type");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.IdServices);

            entity.Property(e => e.IdServices).HasColumnName("Id_Services");
            entity.Property(e => e.Name_Services)
                .IsUnicode(false)
                .HasColumnName("Name_Services");
            entity.Property(e => e.Price_Services)
                .IsUnicode(false)
                .HasColumnName("Price_Services");
        });

        modelBuilder.Entity<Token>(entity =>
        {
            entity.HasKey(e => e.IdToken);

            entity.ToTable("Token");

            entity.Property(e => e.IdToken).HasColumnName("Id_Token");
            entity.Property(e => e.DateTimeToken)
                .HasColumnType("datetime")
                .HasColumnName("Date_Time_Token");
            entity.Property(e => e.NameToken)
                .IsUnicode(false)
                .HasColumnName("Name_Token");
        });

        modelBuilder.Entity<Tour>(entity =>
        {
            entity.HasKey(e => e.IdTours);

            entity.Property(e => e.IdTours).HasColumnName("Id_Tours");
            entity.Property(e => e.BookingDateTours)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Booking_Date_Tours");
            entity.Property(e => e.BookingStatusTours)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Booking_Status_Tours");
            entity.Property(e => e.CountryId).HasColumnName("Country_Id");
            entity.Property(e => e.DescriptionTours)
                .IsUnicode(false)
                .HasColumnName("Description_Tours");
            entity.Property(e => e.EndDateTours)
                .HasColumnType("date")
                .HasColumnName("End_Date_Tours");
            entity.Property(e => e.PaymentsId).HasColumnName("Payments_Id");
            entity.Property(e => e.PhotoId).HasColumnName("Photo_Id");
            entity.Property(e => e.PriceTours)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("Price_Tours");
            entity.Property(e => e.ReservationNumberTours)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Reservation_Number_Tours");
            entity.Property(e => e.ReviewsId).HasColumnName("Reviews_Id");
            entity.Property(e => e.StartDateTours)
                .HasColumnType("date")
                .HasColumnName("Start_Date_Tours");
            entity.Property(e => e.TypeTours)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Type_Tours");
            entity.Property(e => e.UsersId).HasColumnName("Users_Id");
        });

        modelBuilder.Entity<TouristRoute>(entity =>
        {
            entity.HasKey(e => e.IdTouristRoutes);

            entity.ToTable("Tourist_Routes");

            entity.Property(e => e.IdTouristRoutes).HasColumnName("Id_Tourist_Routes");
            entity.Property(e => e.DateTouristRoutes)
                .HasColumnType("date")
                .HasColumnName("Date_Tourist_Routes");
            entity.Property(e => e.DescriptionTouristRoutes)
                .IsUnicode(false)
                .HasColumnName("Description_Tourist_Routes");
            entity.Property(e => e.DurationTouristRoutes)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Duration_Tourist_Routes");
            entity.Property(e => e.MaximumNumberTouristsTouristRoutes).HasColumnName("Maximum_Number_Tourists_Tourist_Routes");
            entity.Property(e => e.NameTouristRoutes)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Name_Tourist_Routes");
            entity.Property(e => e.PhotoId).HasColumnName("Photo_Id");
            entity.Property(e => e.PlacesVisitedId).HasColumnName("Places_Visited_Id");
            entity.Property(e => e.TimeTouristRoutes).HasColumnName("Time_Tourist_Routes");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUsers);

            entity.Property(e => e.IdUsers).HasColumnName("Id_Users");
            entity.Property(e => e.BirthDate)
                .HasColumnType("date")
                .HasColumnName("Birth_Date");
            entity.Property(e => e.CityUser)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("City_User");
            entity.Property(e => e.EmailUser)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("Email_User");
            entity.Property(e => e.LoginUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Login_User");
            entity.Property(e => e.MiddleNameUser)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Middle_Name_User");
            entity.Property(e => e.NameUser)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Name_User");
            entity.Property(e => e.PasswordUser)
                .IsUnicode(false)
                .HasColumnName("Password_User");
            entity.Property(e => e.RoleId).HasColumnName("Role_Id");
            entity.Property(e => e.SaltUser)
                .IsUnicode(false)
                .HasColumnName("Salt_User");
            entity.Property(e => e.SurnameUser)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Surname_User");
            entity.Property(e => e.TokenId).HasColumnName("Token_Id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
