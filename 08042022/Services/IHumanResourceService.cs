using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IHumanResourceService
    {
        public List<Department> Departments { get; }
        public void AddDepartment(string name, int workerLimit, double salaryLimit);
        public List<Department> GetDepartments();
        public void EditDepartment(string name,string newName,int? workerLimit, double? salaryLimit);
        public bool IsDepartmentExist(string name);
    }
}
