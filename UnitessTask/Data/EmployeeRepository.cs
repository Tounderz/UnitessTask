using UnitessLibrary.Abstracts;
using UnitessLibrary.Models;
using UnitessLibrary.Models.Dtos;

namespace UnitessTask.Data
{
    public class EmployeeRepository : IEmployee
    {
        private readonly AppDBContext _context;

        public EmployeeRepository(AppDBContext context)
        {
            _context = context;
        }

        public List<EmployeeModel> GetEmployees(ParametersDto model)
        {
            if (model.Start == 0 && model.End == 0)
            {
                return _context.Employees.ToList();
            }

            if (model.Start > model.End)
            {
                return CreateList(model.End, model.Start);
            }
            else
            {
                return CreateList(model.Start, model.End);
            }
        }

        private List<EmployeeModel> CreateList(int start, int end)
        {
            int count = _context.Employees.Count();
            if (end > count)
            {
                return _context.Employees.Skip(start - 1).Take(count).ToList();
            }

            return _context.Employees.Where(i => i.Id >= start && i.Id <= end).ToList();
        }
    }
}
