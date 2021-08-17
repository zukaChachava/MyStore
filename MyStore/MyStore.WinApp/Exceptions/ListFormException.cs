using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.WinApp.Exceptions
{
    class ListFormException : Exception
    {
        public ListFormException(string errorText) : base(errorText)
        {

        }

        public ListFormException(string errorText, Exception innerException) : base(errorText, innerException)
        {

        }
    }
}
