﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectoryConsoleApp.Presentation.Interfaces
{
    public  interface ILocationPropertyEntryManager
    {
        public string ChooseLocation();
        public string CreateLocationRef();
    }
}