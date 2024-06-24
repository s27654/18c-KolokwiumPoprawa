using System.ComponentModel.DataAnnotations;

namespace Kolokwium_poprawa.DTO;

public class TaskDTO
{
    public int idTask { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public DateTime createdAt { get; set; }
    public int idProject { get; set; }
    public int idReporter { get; set; }
    public IEnumerable<UserDTO> reporter{ get; set;
    }
    public int idAssignee { get; set; }
    public IEnumerable<UserDTO> assignee { get; set; }
}

public class CreateTaskDTO
{
    [Required] public string Name { get; set; }
    [Required] public string Description { get; set; }
    [Required] public int IdProject { get; set; }
    [Required] public int IdReporter { get; set; }
    [Required] public int IdAssignee { get; set; }
}