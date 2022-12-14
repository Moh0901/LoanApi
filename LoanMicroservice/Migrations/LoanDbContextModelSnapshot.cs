// <auto-generated />
using LoanMicroservice.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LoanMicroservice.Migrations
{
    [DbContext(typeof(LoanDbContext))]
    partial class LoanDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LoanMicroservice.Model.Loan", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("fname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("lamount")
                        .HasColumnType("bigint");

                    b.Property<string>("lname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("lnum")
                        .HasColumnType("int");

                    b.Property<long>("lterm")
                        .HasColumnType("bigint");

                    b.Property<string>("ltype")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("paddress")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("loan");
                });
#pragma warning restore 612, 618
        }
    }
}
