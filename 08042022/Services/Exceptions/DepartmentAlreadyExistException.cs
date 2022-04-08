using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Exceptions
{
    public class DepartmentAlreadyExistException:Exception
    {
        public DepartmentAlreadyExistException(string msg):base(msg)
        {

        }
    }
}
