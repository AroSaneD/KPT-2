using System;

namespace Client.DataTransferObjects
{
	public class TaskLogDto
	{
		public int Id { get; set; }
		public string Event { get; set; }
		public DateTime EntryDate { get; set; }
		public int TaskId { get; set; }
	}
}