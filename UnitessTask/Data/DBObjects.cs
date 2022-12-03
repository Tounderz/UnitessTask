using UnitessLibrary.Models;

namespace UnitessTask.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContext context)
        {
            if (!context.Employees.Any())
            {
                context.AddRange(
                    new EmployeeModel
                    {
                        Name = "Bob",
                        LastName = "Marley",
                        PhoneNumber = "375291109876",
                        DateOfBirth= new DateTime(1945, 05, 01).ToShortDateString(),
                    },
                    new EmployeeModel
                    {
                        Name = "Robert",
                        LastName = "Downey Jr",
                        PhoneNumber = "375259992200",
                        DateOfBirth = new DateTime(1965, 04, 04).ToShortDateString(),
                    },
                    new EmployeeModel
                    {
                        Name = "John",
                        LastName = "Depp",
                        PhoneNumber = "375335434400",
                        DateOfBirth = new DateTime(1963, 06, 09).ToShortDateString(),
                    },
                    new EmployeeModel
                    {
                        Name = "James",
                        LastName = "Carrey",
                        PhoneNumber = "375445789087",
                        DateOfBirth = new DateTime(1962, 01, 17).ToShortDateString(),
                    },
                    new EmployeeModel
                    {
                        Name = "William",
                        LastName = "Murray",
                        PhoneNumber = "375259876543",
                        DateOfBirth = new DateTime(1950, 09, 21).ToShortDateString(),
                    }
                );
            }

            context.SaveChanges();
        }
    }
}
