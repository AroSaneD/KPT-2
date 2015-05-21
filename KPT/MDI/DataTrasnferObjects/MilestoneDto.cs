using System;

namespace Client.DataTransferObjects
{
	public class MilestoneDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime EndDate { get; set; }
		public int TaskId { get; set; }
	}
}
