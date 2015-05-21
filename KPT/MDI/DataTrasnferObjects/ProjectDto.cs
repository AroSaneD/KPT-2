using System.Collections.Generic;

namespace Client.DataTransferObjects
{
	public class ProjectDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
        public string Description { get; set; }
		public string CreatedOn { get; set; }
		public string ProjectManager { get; set; }
		public int ProjectStatusId { get; set; }
		public int ClientId { get; set; }
		public int TeamIds { get; set; } 
	}
}