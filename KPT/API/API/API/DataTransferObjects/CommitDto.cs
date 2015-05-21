using System;

namespace API.DataTransferObjects
{
	public class CommitDto
	{
		public int Id { get; set; }
		public string CommitHash { get; set; }
		public DateTime CommitDateTime { get; set; }
		public int TaskId { get; set; }
	}
}