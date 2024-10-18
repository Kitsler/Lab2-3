using System.ComponentModel.DataAnnotations;

namespace BlazorWebAppLab2.Data
{
	public class ChildWorker
	{
		[Display(Name = "ID ребенка")]
		public int ChildWorkerId { get; set; }

        [Display(Name = "Имя ребенка")]
        public string? ChildName { get; set; }

        [Display(Name = "Дата рождения")]
        public DateOnly DateBirth { get; set; }

        [Display(Name = "ID Сотрудника")]
        public int? WorkerId { get; set; }

		public Worker Worker { get; set; } = null!;
		public ICollection<Present> Presents { get; set; } = new List<Present>();
	} 
}
