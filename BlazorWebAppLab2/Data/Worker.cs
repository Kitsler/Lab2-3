namespace BlazorWebAppLab2.Data
{
	public class Worker
	{
		public int WorkerId { get; set; }
		public string? LastName { get; set; }
		public string? FirstName { get; set; }
		public string? SecondName { get; set; }
		public string? JobTitle { get; set; }
		public string? Division { get; set; }
		public DateOnly DateJob { get; set; }

		public ICollection<ChildWorker> ChildWorkers { get; set; } = new List<ChildWorker>();
	}
}
