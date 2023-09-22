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
        //[HttpGet("/ListAllEmployee")]
        //public IEnumerable<EmpViewModel> ListAllEmployee()
        //{
        //    List<Employee> employees = _repositoryEmployee.AllEmployees();
        //    var empList = (
        //        from emp in employees
        //        select new EmpViewModel()
        //        {
        //            EmpId = emp.EmployeeId,
        //            FirstName = emp.FirstName,
        //            LastName = emp.LastName, 
        //            BirthDate = emp.BirthDate,
        //            HireDate = emp.HireDate,
        //            Title = emp.Title,
        //            City = emp.City,
        //            ReportsTo = emp.ReportsTo

        //        }
        //        ).ToList();
        //    return empList;
        //}

        [HttpGet("/ListAllEmployees")]
        public List<Employee> ListAllEmployees()
        {
            List<Employee> employeesList = _repositoryEmployee.AllEmployees();
            return employeesList;
        }
        [HttpGet("/FindEmployee")]
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
        [HttpPut]
        public Employee EditEmployee(int id, [FromBody] Employee updatedEmployee)
        {
            updatedEmployee.EmployeeId = id;
            Employee savedEmployee = _repositoryEmployee.UpdateEmployee(updatedEmployee);
            return savedEmployee;
        }


        [HttpDelete("/DeleteEmployee")]
        public string DeleteEmployee(int id)
        {
            int employeestatus = _repositoryEmployee.DeleteEmployee(id);
            if (employeestatus == 0)
            {
                return "Employee does not exist in the Database";
            }
            else
            {
                return "Employee Successfully Deleted";
            }
        }
    }
}
