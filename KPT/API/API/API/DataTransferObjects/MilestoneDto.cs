using System;

namespace API.DataTransferObjects
{
	public class MilestoneDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime EndDate { get; set; }
		public int ProjectId { get; set; }
	}
}
