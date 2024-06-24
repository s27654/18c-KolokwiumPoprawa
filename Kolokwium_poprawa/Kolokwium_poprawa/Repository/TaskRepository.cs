using System.Data.SqlClient;
using Kolokwium_poprawa.DTO;
namespace Kolokwium_poprawa.Repository;

public interface ITaskRepository
{
    public IEnumerable<TaskDTO> GetTasks(int idProject);
    public TaskDTO GetTasks();
    public bool CreateTask(CreateTaskDTO dto);

}
public class TaskRepository
{
    private IConfiguration _configuration;

    public TaskRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IEnumerable<TaskDTO> GetTasks(int idProject)
    {
        using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnectionString"));
        connection.Open();
        using var command = new SqlCommand("SELECT * FROM TASK, User WHERE IdProject == IdProject ", connection);
        command.Parameters.AddWithValue("idProject", idProject);
        var tasks = new List<TaskDTO>();
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var task = new TaskDTO()
            {
                idTask = reader["IdAnimal"],
                name = reader["Name"],
                description = reader["description"],
                createdAt = reader["CreatedAt"],
                idProject = reader["IdProject"],
                idReporter = reader["IdReporter"],
                reporter = new UserDTO()
                {
                    firstName = reader["FirstName"],
                    lastName = reader["LastName"]
                },
                idAssignee = reader["IdAssignee"],
                assignee = new UserDTO()
                {
                    firstName = reader["FirstName"],
                    lastName = reader["LastName"]
                },
            };
            tasks.Add(task);
        }

        return tasks;
    }
    
    public TaskDTO GetTasks()
    {
        using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnectionString"));
        connection.Open();
        using var command = new SqlCommand("SELECT * FROM TASK, User", connection);
        
        var reader = command.ExecuteReader();
        var task = new TaskDTO()
        {
            idTask = reader["IdAnimal"],
            name = reader["Name"],
            description = reader["description"],
            createdAt = reader["CreatedAt"],
            idProject = reader["IdProject"],
            idReporter = reader["IdReporter"],
            reporter = new UserDTO()
            {
                firstName = reader["FirstName"],
                lastName = reader["LastName"]
            },
            idAssignee = reader["IdAssignee"],
            assignee = new UserDTO()
            {
                firstName = reader["FirstName"],
                lastName = reader["LastName"]
            },
        };
        return task;
    }

    public bool CreateTask(CreateTaskDTO dto)
    {
        using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnectionString"));
        connection.Open();
        using var command = new SqlCommand("INSERT INTO Task (Name, Description, idProject, idReporter, idAssignee) VALUES (@name, @description, @idProject, @idReporter, @idAssignee)", connection);
        command.Parameters.AddWithValue("name", dto.Name);
        command.Parameters.AddWithValue("descrption", dto.Description);
        command.Parameters.AddWithValue("name", dto.IdProject);
        command.Parameters.AddWithValue("name", dto.IdReporter);
        command.Parameters.AddWithValue("name", dto.IdAssignee);
        
        return command.ExecuteNonQuery() == 1;
    }
        
}