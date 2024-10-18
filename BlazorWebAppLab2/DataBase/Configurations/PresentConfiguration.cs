using BlazorWebAppLab2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BlazorWebAppLab2.DataBase.Configurations
{
	public class PresentConfiguration: IEntityTypeConfiguration<Present>
	{
		private const string TableName = "cd_presents";
		public void Configure(EntityTypeBuilder<Present> builder)
		{   //Задаем первичный ключ
			builder
				.HasKey(p => p.PresentId)
				.HasName($"pk_{TableName}_present_id");

			//Для целочисленного первичного ключа задаем автогенерацию (к каждой новой записи будет добавлять +1)
			builder.Property(p => p.PresentId).ValueGeneratedOnAdd();

			builder.Property(p => p.PresentId)
				.HasColumnName("present_id")
				.HasComment("Код подарка");

			builder.Property(p => p.DatePresent)
				.HasColumnName("date_present")
				.HasColumnType(Helper.Date)
				.HasComment("Дата подарка");

			builder.Property(p => p.Cost)
				.HasColumnName("cost")
				.HasColumnType(Helper.Double)
				.HasComment("Цена");

			builder.Property(p => p.ChildWorkerId)
				.HasColumnName("сhildworker_id")
				.HasColumnType(Helper.Int)
				.HasComment("Код ребенка");

			builder.ToTable(TableName);
		}
	}
}
