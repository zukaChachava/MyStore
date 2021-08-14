using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Repository.Exceptions
{
    public class UserDoesNotExist : Exception
    {
        public UserDoesNotExist(string errorText) : base(errorText)
        {

        }

        public UserDoesNotExist(string errorText, Exception innerException) : base (errorText, innerException)
        {

        }
    }
}
