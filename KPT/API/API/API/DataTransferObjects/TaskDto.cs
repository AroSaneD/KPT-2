namespace API.DataTransferObjects
{
	public class TaskDto
	{
		public int Id { get; set; }
		public string Slug { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string CreatedOn { get; set; }
		public string Estimate { get; set; }
		public string EndDate { get; set; }
		public int ProjectId { get; set; }
		public int MilestoneId { get; set; }
		public int TaskStatusId { get; set; }
		public int TaskPriorityId { get; set; }
	}
}