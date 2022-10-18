using System;
using Domains;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BL
{
    public partial class MadmounDbContext : IdentityDbContext<ApplicationUser>
    {
        public MadmounDbContext()
        {
        }

        public MadmounDbContext(DbContextOptions<MadmounDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbArea> TbAreas { get; set; }
        public virtual DbSet<TbChatSrOffSrReq> TbChatSrOffSrReqs { get; set; }
        public virtual DbSet<TbChatSrRepSroff> TbChatSrRepSroffs { get; set; }
        public virtual DbSet<TbCity> TbCities { get; set; }
        public virtual DbSet<TbComplain> TbComplains { get; set; }
        public virtual DbSet<TbLoginHistory> TbLoginHistories { get; set; }
        public virtual DbSet<TbService> TbServices { get; set; }
        public virtual DbSet<TbServiceApprovedImage> TbServiceApprovedImages { get; set; }
        public virtual DbSet<TbServiceApprovedMilstone> TbServiceApprovedMilstones { get; set; }
        public virtual DbSet<TbServiceCategory> TbServiceCategories { get; set; }
        public virtual DbSet<TbServicesApproved> TbServicesApproveds { get; set; }
        public virtual DbSet<TbServicesRequired> TbServicesRequireds { get; set; }
        public virtual DbSet<TbSrOffCity> TbSrOffCities { get; set; }
        public virtual DbSet<TbSrOffService> TbSrOffServices { get; set; }
        public virtual DbSet<TbSrRepCity> TbSrRepCities { get; set; }
        public virtual DbSet<TbSrRepService> TbSrRepServices { get; set; }

        public virtual DbSet<TbClientImages> TbClientImages { get; set; }

        public virtual DbSet<TbClients> TbClients { get; set; }

        public virtual DbSet<TbAdvertisements> Advertisementss { get; set; }

        public virtual DbSet<TbAdvices> TbAdvicess { get; set; }


        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //                optionsBuilder.UseSqlServer("Server=DESKTOP-ABVI0A5;Database=MadmounDb;Trusted_Connection=True;");
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TbArea>(entity =>
            {
                entity.HasKey(e => e.AreaId);

                entity.Property(e => e.AreaId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AreaName).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.TbAreas)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_TbAreas_TbCities");
            });






            modelBuilder.Entity<TbClientImages>(entity =>
            {
                entity.HasKey(e => e.ClientImageId);

                entity.Property(e => e.ClientImageId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ClientImage).HasMaxLength(200);

                entity.Property(e => e.ImageState).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.client)
                    .WithMany(p => p.TbClientImagess)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_TbClientImages_TbClients");
            });

            modelBuilder.Entity<TbChatSrOffSrReq>(entity =>
            {
                entity.HasKey(e => e.MessagesId);

                entity.ToTable("TbChatSrOffSrReq");

                entity.Property(e => e.MessagesId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MemberId).HasMaxLength(450);

                entity.Property(e => e.MessageText).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.ToSendId).HasMaxLength(450);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.TbChatSrOffSrReqs)
                    .HasForeignKey(d => d.AreaId)
                    .HasConstraintName("FK_TbChatSrOffSrReq_TbAreas");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.TbChatSrOffSrReqs)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_TbChatSrOffSrReq_TbCities");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.TbChatSrOffSrReqs)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK_TbChatSrOffSrReq_TbServices");
            });

            modelBuilder.Entity<TbChatSrRepSroff>(entity =>
            {
                entity.HasKey(e => e.MessagesId);

                entity.ToTable("TbChatSrRepSroff");

                entity.Property(e => e.MessagesId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MemberId).HasMaxLength(450);

                entity.Property(e => e.MessageText).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.ToSendId).HasMaxLength(450);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.TbChatSrRepSroffs)
                    .HasForeignKey(d => d.AreaId)
                    .HasConstraintName("FK_TbChatSrRepSroff_TbAreas");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.TbChatSrRepSroffs)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_TbChatSrRepSroff_TbCities");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.TbChatSrRepSroffs)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK_TbChatSrRepSroff_TbServices");
            });

            modelBuilder.Entity<TbCity>(entity =>
            {
                entity.HasKey(e => e.CityId);

                entity.Property(e => e.CityId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CityName).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });




            modelBuilder.Entity<TbClients>(entity =>
            {
                entity.HasKey(e => e.ClientId);

                entity.Property(e => e.ClientId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ClientName).HasMaxLength(200);

                entity.Property(e => e.ClientDescription).HasMaxLength(200);

                entity.Property(e => e.ClientLogo).HasMaxLength(200);

                entity.Property(e => e.ClientVideo).HasMaxLength(200);


                entity.Property(e => e.ClientLocation).HasMaxLength(200);

                entity.Property(e => e.CityId).HasColumnType("guid");

                entity.Property(e => e.CityName).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });






            modelBuilder.Entity<TbComplain>(entity =>
            {
                entity.HasKey(e => e.ComplainId);

                entity.Property(e => e.ComplainId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Id).HasMaxLength(450);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbLoginHistory>(entity =>
            {
                entity.HasKey(e => e.LogInId);

                entity.ToTable("TbLoginHistory");

                entity.Property(e => e.LogInId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Id).HasMaxLength(450);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbService>(entity =>
            {
                entity.HasKey(e => e.ServiceId);

                entity.Property(e => e.ServiceId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.ServiceDescription).HasMaxLength(200);

                entity.Property(e => e.ServiceName).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.ServiceCategory)
                    .WithMany(p => p.TbServices)
                    .HasForeignKey(d => d.ServiceCategoryId)
                    .HasConstraintName("FK_TbServices_TbServiceCategories");
            });






            modelBuilder.Entity<TbAdvertisements>(entity =>
            {
                entity.HasKey(e => e.AdvertisementId);

                entity.Property(e => e.AdvertisementId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AdvertisementDescription).HasMaxLength(200);

                entity.Property(e => e.AdvertisementImage).HasMaxLength(200);

                entity.Property(e => e.AdvertisementName).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                
            });












            modelBuilder.Entity<TbAdvices>(entity =>
            {
                entity.HasKey(e => e.AdvicetId);

                entity.Property(e => e.AdvicetId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AdviceName).HasMaxLength(200);

                entity.Property(e => e.AdviceDescription).HasMaxLength(200);

                entity.Property(e => e.AdvertisementImage).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");


            });
            modelBuilder.Entity<TbServiceApprovedImage>(entity =>
            {
                entity.HasKey(e => e.ServiceApprovedImageId);

                entity.Property(e => e.ServiceApprovedImageId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ImagePath).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.ServiceApproved)
                    .WithMany(p => p.TbServiceApprovedImages)
                    .HasForeignKey(d => d.ServiceApprovedId)
                    .HasConstraintName("FK_TbServiceApprovedImages_TbServicesApproved");
            });

            modelBuilder.Entity<TbServiceApprovedMilstone>(entity =>
            {
                entity.HasKey(e => e.ServiceApprovedMilstoneId);

                entity.ToTable("TbServiceApprovedMilstone");

                entity.Property(e => e.ServiceApprovedMilstoneId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.ServiceApprovedMilstoneDesc).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.ServiceApproved)
                    .WithMany(p => p.TbServiceApprovedMilstones)
                    .HasForeignKey(d => d.ServiceApprovedId)
                    .HasConstraintName("FK_TbServiceApprovedMilstone_TbServicesApproved");
            });

            modelBuilder.Entity<TbServiceCategory>(entity =>
            {
                entity.HasKey(e => e.ServiceCategoryId);

                entity.Property(e => e.ServiceCategoryId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.ServiceCategoryName).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbServicesApproved>(entity =>
            {
                entity.HasKey(e => e.ServiceApprovedId)
                    .HasName("PK_TbServicesRequested");

                entity.ToTable("TbServicesApproved");

                entity.Property(e => e.ServiceApprovedId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ContractPdf).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.ServiceSyntax).HasMaxLength(200);

                entity.Property(e => e.SrApprovedDescription).HasMaxLength(200);

                entity.Property(e => e.SrOffId).HasMaxLength(450);

                entity.Property(e => e.SrRepId).HasMaxLength(450);

                entity.Property(e => e.SrReqId).HasMaxLength(450);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.TbServicesApproveds)
                    .HasForeignKey(d => d.AreaId)
                    .HasConstraintName("FK_TbServicesApproved_TbAreas");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.TbServicesApproveds)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_TbServicesApproved_TbCities");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.TbServicesApproveds)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK_TbServicesApproved_TbServices");
            });

            modelBuilder.Entity<TbServicesRequired>(entity =>
            {
                entity.HasKey(e => e.ServicesRequiredId);

                entity.ToTable("TbServicesRequired");

                entity.Property(e => e.ServicesRequiredId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.ServiceSyntax).HasMaxLength(200);

                entity.Property(e => e.SrRepId).HasMaxLength(450);

                entity.Property(e => e.SrReqId).HasMaxLength(450);

                entity.Property(e => e.SrRequiredDescription).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.TbServicesRequireds)
                    .HasForeignKey(d => d.AreaId)
                    .HasConstraintName("FK_TbServicesRequired_TbAreas");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.TbServicesRequireds)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_TbServicesRequired_TbCities");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.TbServicesRequireds)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK_TbServicesRequired_TbServices");
            });

            modelBuilder.Entity<TbSrOffCity>(entity =>
            {
                entity.HasKey(e => e.SrOffCityId);

                entity.ToTable("TbSrOffCity");

                entity.Property(e => e.SrOffCityId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Id).HasMaxLength(450);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.TbSrOffCities)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_TbSrOffCity_TbAreas");

                entity.HasOne(d => d.CityNavigation)
                    .WithMany(p => p.TbSrOffCities)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_TbSrOffCity_TbCities");
            });

            modelBuilder.Entity<TbSrOffService>(entity =>
            {
                entity.HasKey(e => e.SrOffServiceId);

                entity.ToTable("TbSrOffService");

                entity.Property(e => e.SrOffServiceId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Id).HasMaxLength(450);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.ServiceCategory)
                    .WithMany(p => p.TbSrOffServices)
                    .HasForeignKey(d => d.ServiceCategoryId)
                    .HasConstraintName("FK_TbSrOffService_TbServiceCategories");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.TbSrOffServices)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK_TbSrOffService_TbServices");
            });

            modelBuilder.Entity<TbSrRepCity>(entity =>
            {
                entity.HasKey(e => e.SrRepCityId)
                    .HasName("PK_TbUserCity");

                entity.ToTable("TbSrRepCity");

                entity.Property(e => e.SrRepCityId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Id).HasMaxLength(450);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.TbSrRepCities)
                    .HasForeignKey(d => d.AreaId)
                    .HasConstraintName("FK_TbSrRepCity_TbAreas");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.TbSrRepCities)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_TbSrRepCity_TbCities");
            });

            modelBuilder.Entity<TbSrRepService>(entity =>
            {
                entity.HasKey(e => e.SrRepServiceId);

                entity.ToTable("TbSrRepService");

                entity.Property(e => e.SrRepServiceId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Id).HasMaxLength(450);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.ServiceCategory)
                    .WithMany(p => p.TbSrRepServices)
                    .HasForeignKey(d => d.ServiceCategoryId)
                    .HasConstraintName("FK_TbSrRepService_TbServiceCategories");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.TbSrRepServices)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK_TbSrRepService_TbServices");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
