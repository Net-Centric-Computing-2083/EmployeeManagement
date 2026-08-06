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

    using SqlConnection con = new(connectionString);
    string sql = "Select * from Employee";

    con.Open();

    Console.WriteLine("This is testing");

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
