using ReportApp.DAL.Entities;

namespace ReportApp.BLL.ServicesContract
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
    }
}
