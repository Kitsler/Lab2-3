using BlazorWebAppLab2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorWebAppLab2.DataBase.Configurations
{
	public class ChildConfiguration : IEntityTypeConfiguration<ChildWorker>
	{
		private const string TableName = "cd_childs";

		public void Configure(EntityTypeBuilder<ChildWorker> builder)
		{   //Задаем первичный ключ
			builder
				.HasKey(p => p.ChildWorkerId)
				.HasName($"pk_{TableName}_child_id");

			//Для целочисленного первичного ключа задаем автогенерацию (к каждой новой записи будет добавлять +1)
			builder.Property(p => p.ChildWorkerId).ValueGeneratedOnAdd();

			builder.Property(p => p.ChildWorkerId)
				.HasColumnName("child_id")
				.HasComment("Код ребенка");

			builder.Property(p => p.ChildName)
				.HasColumnName("сhild_name")
				.HasColumnType(Helper.String).HasMaxLength(100)
				.HasComment("Имя ребенка");

			builder.Property(p => p.DateBirth)
				.HasColumnName("child_datebirth")
				.HasColumnType(Helper.Date)
				.HasComment("дата рождения ребенка");

			builder.ToTable(TableName)
			   .HasMany(p=>p.Presents)
			   .WithOne(p=> p.ChildWorker)
			   .HasForeignKey(p=>p.ChildWorkerId)
				.HasConstraintName("fk_f_child_id")
				.OnDelete(DeleteBehavior.Cascade);

			builder.ToTable(TableName)
				.HasIndex(p => p.WorkerId, $"idx_{TableName}_fk_f_child_id");

			//Добавим явную автоподгрузку связанной сущности
			builder.Navigation(p => p.Presents)
				.AutoInclude();
		}
	}
}
