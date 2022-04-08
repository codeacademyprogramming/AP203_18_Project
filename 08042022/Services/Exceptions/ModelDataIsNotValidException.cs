using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Exceptions
{
    public class ModelDataIsNotValidException:Exception
    {
        public ModelDataIsNotValidException(string msg):base(msg)
        {

        }
    }
}
