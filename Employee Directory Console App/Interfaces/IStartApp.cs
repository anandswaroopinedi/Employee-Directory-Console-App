using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectoryConsoleApp.Interfaces
{
    public interface IStartApp
    {
        public void Run();
        public void DisplayOptionMenu();
        public void Register();
    }
}
