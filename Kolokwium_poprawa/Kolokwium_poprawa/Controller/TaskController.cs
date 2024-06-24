using Kolokwium_poprawa.DTO;
using Kolokwium_poprawa.Repository;
using Kolokwium_poprawa.Service;
using Microsoft.AspNetCore.Mvc;
namespace Kolokwium_poprawa.Controller;

[Route("/api/task")]
[ApiController]
public class TaskController : ControllerBase
{
    private ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet("/api/task?projectId={5}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetTasks([FromQuery] int idProject)
    {
        var tasks = _taskService.GetTask(idProject);
        return Ok(tasks);
    }
    [HttpGet("/api/task?projectId={5}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetTasks()
    {
        var task = _taskService.GetTask();
        return Ok(task);
    }

    [HttpPost("/api/task")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public IActionResult CreateTask([FromBody] CreateTaskDTO dto)
    {
        var success = _taskService.CreateTask(dto);
        return success ? Created() : Conflict();
    }
}