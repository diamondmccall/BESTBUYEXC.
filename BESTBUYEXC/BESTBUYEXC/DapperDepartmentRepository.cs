using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace BESTBUYEXC
{
    public class DapperDepartmentRepository : IDepartmentRepository
    {
        private readonly IDbConnection _connection;

        public DapperDepartmentRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _connection.Query<Department>("SELECT * FROM departments;");
        }

        public void InsertDepartment(string newDepartmentName)
        {
            _connection.Execute("INSERT INTO departments (Name) VALUES (@departmentName);",
               new { departmentName = newDepartmentName });
        }
    }
}
