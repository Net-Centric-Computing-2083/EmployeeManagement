using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

app.MapGet("/", () =>
{
    return "Employee Management System";
});

//Get Employee Information
app.MapGet("/employees", () =>
{
    List<Employee> employees = new();

    //1) using SqlConnection
    using SqlConnection con = new(connectionString);
    
    string sql = "Select * from Employee";

    // 2) SqlCommand
    using SqlCommand cmd = new SqlCommand(sql, con);
    con.Open();

    //3) Execute Reader
    using SqlDataReader reader = cmd.ExecuteReader();

    while (reader.Read())
    {
        employees.Add(new Employee
        {
            Id = Convert.ToInt32(reader["Id"]),
            Name = reader["Name"].ToString(),
            DepartmentName = reader["Department_Name"].ToString(),
            Designation = reader["Designation"].ToString(),
            Email = reader["Email"].ToString(),
            Address = reader["Address"].ToString(),
            Gender = reader["Gender"].ToString()
        });
    }

});

app.Run();

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? DepartmentName { get; set; }
    public string Designation { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string Gender { get; set; }
}
