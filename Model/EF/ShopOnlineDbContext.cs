namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ShopOnlineDbContext : DbContext
    {
        public ShopOnlineDbContext()
            : base("name=ShopOnlineDbContext")
        {
        }

        public virtual DbSet<ABOUT> ABOUT { get; set; }
        public virtual DbSet<CATEGORY> CATEGORY { get; set; }
        public virtual DbSet<CONTACT> CONTACT { get; set; }
        public virtual DbSet<CONTENT> CONTENT { get; set; }
        public virtual DbSet<CONTENTTAG> CONTENTTAG { get; set; }
        public virtual DbSet<CREDENTIAL> CREDENTIAL { get; set; }
        public virtual DbSet<FEEDBACK> FEEDBACK { get; set; }
        public virtual DbSet<FOOTER> FOOTER { get; set; }
        public virtual DbSet<MENU> MENU { get; set; }
        public virtual DbSet<MENUTYPE> MENUTYPE { get; set; }
        public virtual DbSet<ORDER> ORDER { get; set; }
        public virtual DbSet<ORDERDETAIL> ORDERDETAIL { get; set; }
        public virtual DbSet<PRODUCT> PRODUCT { get; set; }
        public virtual DbSet<PRODUCTCATEGORY> PRODUCTCATEGORY { get; set; }
        public virtual DbSet<ROLE> ROLE { get; set; }
        public virtual DbSet<SLIDE> SLIDE { get; set; }
        public virtual DbSet<SYSTEMCONFIG> SYSTEMCONFIG { get; set; }
        public virtual DbSet<TAG> TAG { get; set; }
        public virtual DbSet<USER> USER { get; set; }
        public virtual DbSet<USERGROUP> USERGROUP { get; set; }
        public virtual DbSet<LOGO> LOGO { get; set; }
        public virtual DbSet<SLIDEGROUP> SLIDEGROUP { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ABOUT>()
            //    .Property(e => e.Metatitle)
            //    .IsUnicode(false);

            //modelBuilder.Entity<ABOUT>()
            //    .Property(e => e.CreateBy)
            //    .IsUnicode(false);

            //modelBuilder.Entity<ABOUT>()
            //    .Property(e => e.ModifiedBy)
            //    .IsUnicode(false);

            //modelBuilder.Entity<ABOUT>()
            //    .Property(e => e.MetaDescriptions)
            //    .IsFixedLength();

            //modelBuilder.Entity<CATEGORY>()
            //    .Property(e => e.MetaTitle)
            //    .IsUnicode(false);

            //modelBuilder.Entity<CATEGORY>()
            //    .Property(e => e.CreateBy)
            //    .IsUnicode(false);

            //modelBuilder.Entity<CATEGORY>()
            //    .Property(e => e.ModefiedBy)
            //    .IsUnicode(false);

            //modelBuilder.Entity<CATEGORY>()
            //    .Property(e => e.MetaDescriptions)
            //    .IsFixedLength();

            //modelBuilder.Entity<CONTENT>()
            //    .Property(e => e.Metatitle)
            //    .IsUnicode(false);

            //modelBuilder.Entity<CONTENT>()
            //    .Property(e => e.CreatedBy)
            //    .IsUnicode(false);

            //modelBuilder.Entity<CONTENT>()
            //    .Property(e => e.ModifielBy)
            //    .IsUnicode(false);

            //modelBuilder.Entity<CONTENT>()
            //    .Property(e => e.MetaDescriptions)
            //    .IsFixedLength();

            //modelBuilder.Entity<CONTENTTAG>()
            //    .Property(e => e.TagID)
            //    .IsUnicode(false);

            //modelBuilder.Entity<CREDENTIAL>()
            //    .Property(e => e.RoleID)
            //    .IsUnicode(false);

            //modelBuilder.Entity<FEEDBACK>()
            //    .Property(e => e.Phone)
            //    .IsUnicode(false);

            //modelBuilder.Entity<FOOTER>()
            //    .Property(e => e.ID)
            //    .IsUnicode(false);

            //modelBuilder.Entity<ORDER>()
            //    .Property(e => e.ShipMobile)
            //    .IsUnicode(false);

            //modelBuilder.Entity<ORDERDETAIL>()
            //    .Property(e => e.Price)
            //    .HasPrecision(18, 0);

            //modelBuilder.Entity<PRODUCT>()
            //    .Property(e => e.Code)
            //    .IsUnicode(false);

            //modelBuilder.Entity<PRODUCT>()
            //    .Property(e => e.Metatitle)
            //    .IsUnicode(false);

            //modelBuilder.Entity<PRODUCT>()
            //    .Property(e => e.Price)
            //    .HasPrecision(18, 0);

            //modelBuilder.Entity<PRODUCT>()
            //    .Property(e => e.PromotionPrice)
            //    .HasPrecision(18, 0);

            //modelBuilder.Entity<PRODUCT>()
            //    .Property(e => e.CreatedBy)
            //    .IsUnicode(false);

            //modelBuilder.Entity<PRODUCT>()
            //    .Property(e => e.ModifiedBy)
            //    .IsUnicode(false);

            //modelBuilder.Entity<PRODUCT>()
            //    .Property(e => e.MetaDescriptions)
            //    .IsFixedLength();

            //modelBuilder.Entity<PRODUCTCATEGORY>()
            //    .Property(e => e.Metatitle)
            //    .IsUnicode(false);

            //modelBuilder.Entity<PRODUCTCATEGORY>()
            //    .Property(e => e.CreatedBy)
            //    .IsUnicode(false);

            //modelBuilder.Entity<PRODUCTCATEGORY>()
            //    .Property(e => e.ModifiedBy)
            //    .IsUnicode(false);

            //modelBuilder.Entity<PRODUCTCATEGORY>()
            //    .Property(e => e.MetaDescriptions)
            //    .IsFixedLength();

            //modelBuilder.Entity<ROLE>()
            //    .Property(e => e.ID)
            //    .IsUnicode(false);

            //modelBuilder.Entity<SLIDE>()
            //    .Property(e => e.Created_By)
            //    .IsUnicode(false);

            //modelBuilder.Entity<SLIDE>()
            //    .Property(e => e.Modified_By)
            //    .IsUnicode(false);

            //modelBuilder.Entity<SYSTEMCONFIG>()
            //    .Property(e => e.ID)
            //    .IsUnicode(false);

            //modelBuilder.Entity<SYSTEMCONFIG>()
            //    .Property(e => e.Type)
            //    .IsUnicode(false);

            //modelBuilder.Entity<TAG>()
            //    .Property(e => e.ID)
            //    .IsUnicode(false);

            //modelBuilder.Entity<USER>()
            //    .Property(e => e.UserName)
            //    .IsUnicode(false);

            //modelBuilder.Entity<USER>()
            //    .Property(e => e.Password)
            //    .IsUnicode(false);

            //modelBuilder.Entity<USER>()
            //    .Property(e => e.CreatedBy)
            //    .IsUnicode(false);

            //modelBuilder.Entity<USER>()
            //    .Property(e => e.ModifiedBy)
            //    .IsUnicode(false);
            //modelBuilder.Entity<USER>()
            //    .Property(e => e.GroupID)
            //    .IsConcurrencyToken();

            //modelBuilder.Entity<LOGO>()
            //    .Property(e => e.Created_By)
            //    .IsUnicode(false);

            //modelBuilder.Entity<LOGO>()
            //    .Property(e => e.Modified_By)
            //    .IsUnicode(false);
        }
    }
}
