using System.Collections.Generic;
using EFCore.BulkExtensions;
using FsParser_Library;

namespace FS_CSProject
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            var res = FSParser.getParsedResults();
            
            using (var context = new AppDbContext())
            {
                var listEmployees = new List<Employee>();
                var listEmployeeContactDetails = new List<EmployeeContactDetails>();
                var listEmployeeAddresses = new List<EmployeeAddress>();
                var listEmployments = new List<Employment>();
                int j = 1;

                foreach (var entry in res)
                {
                    foreach (var r in res[entry.Key])
                    {
                        var employee = new Employee
                        {
                            EmpId = r.Item1,
                            FirstName = r.Item2,
                            LastName = r.Item3,
                            Gender = r.Item4,
                            DateOfBirth = r.Item6,
                            ContactDetailsId = j,
                            AddressId = j
                        };

                        var employeeContactDetails = new EmployeeContactDetails
                        {
                            Email = r.Item5,
                            Password = r.Rest.Rest.Item2,
                            PhoneNumber = r.Rest.Item2,
                            Username = r.Rest.Rest.Item1
                        };

                        var employeeAddress = new EmployeeAddress
                        {
                            City = r.Rest.Item5,
                            Country = r.Rest.Item4,
                            PlaceName = r.Rest.Item3,
                            State = r.Rest.Item6,
                            EmploymentId = j
                        };

                        var employment = new Employment
                        {
                            JoinDate = r.Item7,
                            AgeInCompany = r.Rest.Item1
                        };

                        j++;

                        listEmployees.Add(employee);
                        listEmployeeContactDetails.Add(employeeContactDetails);
                        listEmployeeAddresses.Add(employeeAddress);
                        listEmployments.Add(employment);
                    }
                }
                
                context.BulkInsert(listEmployees);
                context.BulkInsert(listEmployeeContactDetails);
                context.BulkInsert(listEmployeeAddresses);
                context.BulkInsert(listEmployments);

                context.SaveChanges();
            }
            
        }
        
    }
}
