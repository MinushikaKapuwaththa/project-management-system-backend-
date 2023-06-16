//using Microsoft.EntityFrameworkCore;
//using project_management_system_backend.Data;
//using project_management_system_backend.Dtos.TaskDtos;


//namespace project_management_system_backend.Repositories
//{
//    public class TaskRepository : ITaskRepository
//    {
//        private readonly ApiDbContext _context;

//        public TaskRepository(ApiDbContext context)
//        {
//            _context = context ?? throw new ArgumentNullException(nameof(context));
//        }

//        public async Task CreateTaskAsync(Models.Task taskToCreate)
//        {
//            taskToCreate.ProjectId = taskToCreate.ProjectId == 0 ? null : taskToCreate.ProjectId;
//            _context.Tasks.Add(taskToCreate);
//            await _context.SaveChangesAsync();
//        }

//        public async Task<List<TasksDto>> GetAssignedTasksAsync()
//        {
//            //You can uncomment this method to filter by employee id. Make sure to accept empId as parameter and update the database
//            //with the empid foreign key as well.
//            // return await _context.Tasks.Where(t => t.EmployeeId == employeeId).OrderBy(t => t.TaskId).ToListAsync();

//            return await _context.Tasks.OrderBy(p => p.TaskId).Select(p => new TasksDto
//            {
//                TaskId = p.TaskId,
//                TaskName = p.TaskName,
//                EstimatedTime = p.EstimatedTime,
//                Deadline = p.Deadline,
//                ProjectName = p.Project != null ? p.Project.Name : string.Empty,
//                DaysLeft = (p.Deadline - DateTime.Now).Days
//            }).ToListAsync();
//        }
//    }
//}
