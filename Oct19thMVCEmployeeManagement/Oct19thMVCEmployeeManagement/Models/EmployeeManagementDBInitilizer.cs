using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Oct19thMVCEmployeeManagement.Models
{
    //Nen de DropCreateDatabaseAlways cho den khi chay test form co du lieu init roi moi thay doi lai ve DropCreateDatabaseIfModelChanges
    public class EmployeeManagementDBInitilizer:DropCreateDatabaseIfModelChanges<EmployeeManagementDBContext>
    {
        //Override Seed de khoi tao du lieu ban dau.
        protected override void Seed(EmployeeManagementDBContext context)
        {
            context.Departments.AddRange(new List<Department>(){
                new Department() {  Id=1, Name="HR"},
                new Department() {  Id=2, Name="Code"},
                new Department() {  Id=3, Name="Design"}
                });

            context.Employees.AddRange(new List<Employee>() { 
                new Employee() { Id=1, Name="Thang", DOB=new DateTime(1990,1,1), DepartmentId=1, Avatar=null},
                new Employee() { Id=2, Name="Thanh", DOB=new DateTime(1990,1,1), DepartmentId=2, Avatar=null},
                new Employee() { Id=3, Name="Hai", DOB=new DateTime(1990,1,1), DepartmentId=3, Avatar=null},
                new Employee() { Id=4, Name="Huy", DOB=new DateTime(1990,1,1), DepartmentId=2, Avatar=null},
                new Employee() { Id=5, Name="Huyen", DOB=new DateTime(1990,1,1), DepartmentId=1, Avatar=null},
                new Employee() { Id=6, Name="Trang", DOB=new DateTime(1990,1,1), DepartmentId=2, Avatar=null},
                new Employee() { Id=7, Name="Hong", DOB=new DateTime(1990,1,1), DepartmentId=3, Avatar=null},
                new Employee() { Id=8, Name="Hanh", DOB=new DateTime(1990,1,1), DepartmentId=2, Avatar=null},
                new Employee() { Id=9, Name="Thuy", DOB=new DateTime(1990,1,1), DepartmentId=1, Avatar=null},
                new Employee() { Id=10, Name="Thu", DOB=new DateTime(1990,1,1), DepartmentId=2, Avatar=null}
            });

            context.SaveChanges();

            base.Seed(context);
        }
    }
}