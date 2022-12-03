using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitessLibrary.Models;
using UnitessLibrary.Models.Dtos;

namespace UnitessLibrary.Abstracts
{
    public interface IEmployee
    {
        List<EmployeeModel> GetEmployees(ParametersDto model);
    }
}
