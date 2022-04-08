using System;
using Services;

namespace HR_System
{
    internal class Program
    {
        static IHumanResourceService _service;
        static void Main(string[] args)
        {
            _service = new HumanResourceService();

            string menu;
            do
            {
                ShowMenu();

                menu = Console.ReadLine();

                switch (menu)
                {
                    case "1":
                        DepartmentMenu();
                        break;
                    case "2":
                        EmployeeMenu();
                        break;
                    case "3":
                        Console.WriteLine("Proqramdan cixdiniz!");
                        break;
                    default:
                        Console.WriteLine("Seciminiz 1,2 ve ya 3 ola biler!");
                        break;
                }


            } while (menu!="3");
        }


        static void ShowMenu()
        {
            Console.WriteLine("1. Departamentler uzerinde emeliyyatlar");
            Console.WriteLine("2. Isciler uzerinde emeliyyatlar");
            Console.WriteLine("3. Systemden cix");
        }

        static void DepartmentMenu()
        {
            string subMenu;
            do
            {
                Console.WriteLine("1.1 Departmentler siyahisini goster");
                Console.WriteLine("1.2 Department elave et");
                Console.WriteLine("1.3 Departmenti deyisdir");
                Console.WriteLine("0 Esas menuya qayit");
                subMenu = Console.ReadLine();

                switch (subMenu)
                {
                    case "1.1":

                        foreach (var item in _service.GetDepartments())
                        {
                            Console.WriteLine($"Name: {item.Name} - SalaryLimit: {item.SalaryLimit} - Workerlimit: {item.WorkerLimit} - WorkerCount: 0 ");
                        }
                        break;
                    case "1.2":
                        string departmentName;
                        string workerLimitStr;
                        int workerLimit;
                        double salaryLimit;
                        string salaryLimitStr;


                        do
                        {
                            Console.WriteLine("Departmentin adini daxil et:");
                            departmentName = Console.ReadLine();

                        } while (string.IsNullOrWhiteSpace(departmentName) || departmentName.Length<2 || _service.IsDepartmentExist(departmentName));

                        do
                        {
                            Console.WriteLine("Departmentin isci limitini daxil edin:");
                            workerLimitStr = Console.ReadLine();

                        } while (!int.TryParse(workerLimitStr,out workerLimit) || workerLimit<1);

                        do
                        {
                            Console.WriteLine("Departmentin maas limitini daxil edin:");
                            salaryLimitStr = Console.ReadLine();

                        } while (!double.TryParse(salaryLimitStr, out salaryLimit) || salaryLimit < 250);


                        _service.AddDepartment(departmentName, workerLimit, salaryLimit);

                        break;
                    case "1.3":
                        Console.WriteLine("Editlemek");
                        break;
                    case "0":
                        Console.WriteLine("\n==============Esas Menu==============");
                        break;
                    default:
                        Console.WriteLine("Seciminiz yanlisdir, tekrar secim edin!");
                        break;
                }

            } while ("0" != subMenu);
        }

        static void EmployeeMenu()
        {
            string menu;
            do
            {
                Console.WriteLine("2.1 Iscilerin siyahisini goster");
                Console.WriteLine("2.2 Secilmis departamentdeki iscilerin siyahisi");
                Console.WriteLine("2.3 Yeni isci elave etmek");
                Console.WriteLine("2.4 Isci uzerinde deyisiklik");
                Console.WriteLine("0 Esas menuya qayit");

                menu = Console.ReadLine();

                switch (menu)
                {
                    case "2.1":
                        Console.WriteLine("Butun iscileri goster");
                        break;
                    case "2.2":
                        Console.WriteLine("Secilmis dep iscileri goster");
                        break;
                    case "2.3":
                        Console.WriteLine("Yeni isci elave et");
                        break;
                    case "2.4":
                        Console.WriteLine("Isci editlemek");
                        break;
                    case "0":
                        Console.WriteLine("\n===============Esas Menu================\n");
                        break;
                    default:
                        break;
                }

            } while (menu!="0");
           


        }
    }
}
