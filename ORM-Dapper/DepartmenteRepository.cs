using System.Data;
using Dapper;
using ZstdSharp.Unsafe;

namespace ORM_Dapper;


public class DepartmenteRepository : IDepartmentRepository
{
    private readonly IDbConnection _connection;

    public DepartmenteRepository(IDbConnection connection)
    {
        _connection = connection;
    }
    public IEnumerable<Department> GetAllDepartments()
    {
        return _connection.Query<Department>("SELECT * FROM departments;");
    }

    public void AddDepartment(string newDepartmentName)
    {
        _connection.Execute("INSERT INTO departments (Name) VALUES (@newDepartmentName);", new {newDepartmentName});
    }
}