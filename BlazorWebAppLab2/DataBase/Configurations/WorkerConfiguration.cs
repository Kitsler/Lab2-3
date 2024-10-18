using BlazorWebAppLab2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorWebAppLab2.DataBase.Configurations
{
	public class WorkerConfiguration : IEntityTypeConfiguration<Worker>
	{
		private const string TableName = "cd_workers";

		public void Configure(EntityTypeBuilder<Worker> builder)
		{   //Задаем первичный ключ
			builder
				.HasKey(p => p.WorkerId)
				.HasName($"pk_{TableName}_worker_id");

			//Для целочисленного первичного ключа задаем автогенерацию (к каждой новой записи будет добавлять +1)
			builder.Property(p => p.WorkerId).ValueGeneratedOnAdd();

			builder.Property(p => p.WorkerId)
				.HasColumnName("worker_id")
				.HasComment("Код сотрудника");

			builder.Property(p => p.FirstName)
				.HasColumnName("worker_firstname")
				.HasColumnType(Helper.String).HasMaxLength(100)
				.HasComment("Имя сотрудника");

			builder.Property(p => p.LastName)
				.HasColumnName("worker_lastname")
				.HasColumnType(Helper.String).HasMaxLength(100)
				.HasComment("Фамилия сотрудника");

			builder.Property(p => p.SecondName)
				.HasColumnName("worker_secondname")
				.HasColumnType(Helper.String).HasMaxLength(100)
				.HasComment("Отчество сотрудника");

			builder.Property(p => p.JobTitle)
				.HasColumnName("worker_title")
				.HasColumnType(Helper.String).HasMaxLength(100)
				.HasComment("Должнеость сотрудника");

			builder.Property(p => p.Division)
				.HasColumnName("worker_division")
				.HasColumnType(Helper.String).HasMaxLength(100)
				.HasComment("Подразделение");

			builder.Property(p => p.DateJob)
				.HasColumnName("worker_datejob")
				.HasColumnType(Helper.Date)
				.HasComment("Дата приема на работу");

			builder.ToTable(TableName)
			   .HasMany(p => p.ChildWorkers)
			   .WithOne(p => p.Worker)
			   .HasForeignKey(p => p.WorkerId)
			   .HasConstraintName("fk_f_worker_id")
				.OnDelete(DeleteBehavior.Cascade);

			builder.ToTable(TableName)
				.HasIndex(p => p.WorkerId, $"idx_{TableName}_fk_f_worker_id");

			//Добавим явную автоподгрузку связанной сущности
			builder.Navigation(p => p.ChildWorkers)
				.AutoInclude();
		}
	}
}
