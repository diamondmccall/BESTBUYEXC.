using System;
using System.Collections.Generic;

namespace BESTBUYEXC
{
    public interface IDepartmentRepository
    {
        public IEnumerable<Department> GetAllDepartments();
        public void InsertDepartment(string newDepartmentName);
    }
}

