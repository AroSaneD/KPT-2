
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace API.Models
{

using System;
    using System.Collections.Generic;
    
public partial class Task
{

    public Task()
    {

        this.TaskLog = new HashSet<TaskLog>();

    }


    public int Id { get; set; }

    public string Slug { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string CreatedOn { get; set; }

    public string Estimate { get; set; }

    public string EndDate { get; set; }



    public virtual Project Project { get; set; }

    public virtual Milestone Milestone { get; set; }

    public virtual TaskStatus TaskStatus { get; set; }

    public virtual TaskPriority TaskPriority { get; set; }

    public virtual ICollection<TaskLog> TaskLog { get; set; }

}

}
