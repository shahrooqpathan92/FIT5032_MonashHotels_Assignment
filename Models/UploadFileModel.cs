namespace FIT5032_MonashHotels_Assignment.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class UploadFileModel : DbContext
    {
        public UploadFileModel()
            : base("name=UploadFileModel")
        {
        }

        public virtual DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>()
                .Property(e => e.Path)
                .IsUnicode(false);

            modelBuilder.Entity<Image>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
