using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Models;

namespace WebAPIDemo.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class EmployeeController : ControllerBase
    //{
    //    private NorthwindContext _context;
    //    public List<Employee> AllEmployee()
    //    {
    //        return _context.Employees.ToList();
    //    }
    //    public List<Employee> GetAllEmployeeId()
    //    {
    //        List<Employee> result = new List<Employee>();
    //        foreach (Employee employee in _context.Employees)
    //        {
    //            result.Add(employee);
    //        }
    //        return result;
    //    }
    //    public Employee FindEmployeeById(String id)
    //    {
    //        Employee employee = _context.Employees.Find(id);
    //        return employee;
    //    }
    //}

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private RepositoryEmployee _repositoryEmployee;
        public EmployeeController(RepositoryEmployee repository)
        {
            _repositoryEmployee = repository;
        }
        [HttpGet("/ListAllEmployees")]
        public List<Employee> ListAllEmployees()
        {
            List<Employee> employeesList = _repositoryEmployee.AllEmployees();
            return employeesList;
        }
        [HttpPost("/FindEmployee")]
        public Employee FindEmployee(int id)
        {
            Employee employeeById = _repositoryEmployee.FindEmployeeById(id);
            return employeeById;
        }
        [HttpPost("/AddEmployee")]
        public string AddEmployee(Employee newEmployee)
        {
            int employeestatus = _repositoryEmployee.AddEmployee(newEmployee);
            if (employeestatus == 0)
            {
                return "Employee Not Added To Database Since it already exist";
            }
            else
            {
                return "Employee Added To Database";
            }
        }
        //[HttpGet("/ModifyEmployee")]
        //public int ModifyEmployee(int id)
        //{
        //    int employeestatus = _repositoryEmployee.ModifyEmployee(id);
        //    return employeestatus;
        //}
        //[HttpDelete("/DeleteEmployee")]
        //public string DeleteEmployee(int id)
        //{
        //    int employeestatus = _repositoryEmployee.DeleteEmployee(id);
        //    if (employeestatus == 0)
        //    {
        //        return "Employee does not exist in the Database";
        //    }
        //    else
        //    {
        //        return "Employee Successfully Deleted";
        //    }
        //}
    }
}
