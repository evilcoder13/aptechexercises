using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Oct5thMVCProjectManagement.Models
{
    public class ProjectManagementDBInitilizer: DropCreateDatabaseAlways<ProjectManagementDBContext>
    {
        protected override void Seed(ProjectManagementDBContext context)
        {
            context.Employees.AddRange(new List<Employee>()
            {
                new Employee() { EmpId=1, EmpName="Thang", EmpDepartment="HR"},
                new Employee() { EmpId=2, EmpName="Thanh", EmpDepartment="Design"},
                new Employee() { EmpId=3, EmpName="Thai", EmpDepartment="Code"},
                new Employee() { EmpId=4, EmpName="Huy", EmpDepartment="Design"},
                new Employee() { EmpId=5, EmpName="Dat", EmpDepartment="Code"}
            });

            context.Customers.AddRange(new List<Customer>()
            {
                new Customer() { CustId=1, CustName="Cong ty A", CustEmail="congtya@gmail.com", CustPhone="0123456789"},
                new Customer() { CustId=2, CustName="Cong ty B", CustEmail="congtyb@gmail.com", CustPhone="0123456789"},
                new Customer() { CustId=3, CustName="Cong ty C", CustEmail="congtyc@gmail.com", CustPhone="0123456789"},
                new Customer() { CustId=4, CustName="Cong ty D", CustEmail="congtyd@gmail.com", CustPhone="0123456789"},
                new Customer() { CustId=5, CustName="Cong ty E", CustEmail="congtye@gmail.com", CustPhone="0123456789"}
            });

            context.Projects.AddRange(new List<Project>()
            {
                new Project() { PrjId=1, PrjName="Phan mem 1", PrjStart=DateTime.Now, PrjEnd=DateTime.Now.AddDays(10) },
                new Project() { PrjId=2, PrjName="Phan mem 2", PrjStart=DateTime.Now, PrjEnd=DateTime.Now.AddDays(5) },
                new Project() { PrjId=3, PrjName="Web 1", PrjStart=DateTime.Now, PrjEnd=DateTime.Now.AddDays(0) },
                new Project() { PrjId=4, PrjName="Web 2", PrjStart=DateTime.Now, PrjEnd=DateTime.Now.AddDays(-5) },
                new Project() { PrjId=5, PrjName="Mobile 1", PrjStart=DateTime.Now, PrjEnd=DateTime.Now.AddDays(-10) }
            });

            context.Managements.AddRange(new List<Management>()
            {
                new Management() { CustId=1, EmpId=5, PrjId=2, Note="Note 1"},
                new Management() { CustId=2, EmpId=4, PrjId=3, Note="Note 2"},
                new Management() { CustId=3, EmpId=3, PrjId=4, Note="Note 3"},
                new Management() { CustId=4, EmpId=2, PrjId=5, Note="Note 4"},
                new Management() { CustId=5, EmpId=1, PrjId=4, Note="Note 5"},
                new Management() { CustId=4, EmpId=2, PrjId=3, Note="Note 6"},
                new Management() { CustId=3, EmpId=3, PrjId=2, Note="Note 7"},
                new Management() { CustId=2, EmpId=4, PrjId=1, Note="Note 8"},
                new Management() { CustId=1, EmpId=5, PrjId=1, Note="Note 9"},
                new Management() { CustId=1, EmpId=1, PrjId=2, Note="Note 10"},
            });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}