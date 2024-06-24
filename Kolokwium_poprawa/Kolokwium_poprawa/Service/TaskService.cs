using Kolokwium_poprawa.DTO;
using Kolokwium_poprawa.Repository;

namespace Kolokwium_poprawa.Service;

public class TaskService
{
    private readonly ITaskRepository _taskRepository;
    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public IEnumerable<TaskDTO> GetTasks(int idProject)
    {
        return _taskRepository.GetTasks(idProject);
    }

    public TaskDTO GetTasks()
    {
        return _taskRepository.GetTasks();
    }

    public bool CreateTask(CreateTaskDTO dto)
    {
        return _taskRepository.CreateTask(dto);
    }
}