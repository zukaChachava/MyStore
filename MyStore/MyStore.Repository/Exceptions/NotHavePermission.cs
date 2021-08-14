using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Repository.Exceptions
{
    public class NotHavePermission : Exception
    {
        public NotHavePermission(string errorText) : base(errorText)
        {

        }

        public NotHavePermission(string errorText, Exception innerException) : base(errorText, innerException)
        {

        }
    }
}
