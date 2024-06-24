using Kolokwium_poprawa.DTO;
namespace Kolokwium_poprawa.Service;

public interface ITaskService
{
    public TaskDTO GetTask();
    public IEnumerable<TaskDTO> GetTask(int id);
    public bool CreateTask(CreateTaskDTO dto);
}