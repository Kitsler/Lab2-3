namespace BlazorWebAppLab2.Data
{
	public class Present
	{
		public int PresentId { get; set; }
		public DateOnly DatePresent { get; set; }
		public double Cost { get; set; }
		public int? ChildWorkerId { get; set; }

		public ChildWorker ChildWorker { get; set; } = null!;
	}
}
