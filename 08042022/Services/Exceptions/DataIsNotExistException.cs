using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Exceptions
{
    public class DataIsNotExistException:Exception
    {
        public DataIsNotExistException(string msg):base(msg)
        {

        }
    }
}
