using MyStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.WinApp.LocalData
{
    public static class LocalStorage
    {
        public static User User { get; set; }

        public static IEnumerable<int> Permissions;
    }
}
