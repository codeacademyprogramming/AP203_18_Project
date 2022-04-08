using Models;
using Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class HumanResourceService : IHumanResourceService
    {
        private List<Department> _departments = new List<Department>();
        public List<Department> Departments { get => _departments; }

        public void AddDepartment(string name, int workerLimit, double salaryLimit)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length < 2)
                throw new ModelDataIsNotValidException("Name deyeri minimum 2 uzunluqda olmalidir!");

            if (_departments.Exists(x => x.Name == name))
                throw new DepartmentAlreadyExistException($"{name} adli departament movcuddur!");

            if (workerLimit < 1)
                throw new ModelDataIsNotValidException($"Worket limit deyeri minimum 1 olmalidir!");

            if (salaryLimit < 250)
                throw new ModelDataIsNotValidException($"Salary limit deyeri minimum 250 olmalidir!");

            Department department = new Department
            {
                Name = name,
                SalaryLimit = salaryLimit,
                WorkerLimit = workerLimit,
            };

            _departments.Add(department);
        }

        public void EditDepartment(string name, string newName, int? workerLimit, double? salaryLimit)
        {
            Department department = _departments.Find(x => x.Name == name);

            if (department == null)
                throw new DataIsNotExistException($"{name} adli department movcud deyil!");

            if (string.IsNullOrWhiteSpace(newName) || newName.Length < 2)
                throw new ModelDataIsNotValidException("Name deyeri minimum 2 uzunluqda olmalidir!");

            if (workerLimit != null && workerLimit < 1)
                throw new ModelDataIsNotValidException($"Worket limit deyeri minimum 1 olmalidir!");

            if (salaryLimit != null && salaryLimit < 250)
                throw new ModelDataIsNotValidException($"Salary limit deyeri minimum 250 olmalidir!");


            department.Name = newName;
            department.WorkerLimit = workerLimit == null ? department.WorkerLimit : (int)workerLimit;
            department.SalaryLimit = salaryLimit == null ? department.SalaryLimit : (double)salaryLimit;
        }

        public List<Department> GetDepartments()
        {
            return _departments;
        }

        public bool IsDepartmentExist(string name)
        {
            return _departments.Exists(x => x.Name == name);
        }
    }
}
