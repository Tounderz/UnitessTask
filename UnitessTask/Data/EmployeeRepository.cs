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
            int count = _context.Employees.Count();
            if (model.Start > count && model.End > count)
            {
                return null;
            }
            
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
                count -= start;
                if (count <= 0)
                {
                    return null;
                }

                end = _context.Employees.Count();
            }

            return _context.Employees.Where(i => i.Id >= start && i.Id <= end).ToList();
        }
    }
}
