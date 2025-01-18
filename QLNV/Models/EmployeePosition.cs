using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLNV.Models;

[Table("employee_position")]
public class EmployeePosition
{
    public int Id { get; set; }
    public string? PositionNumberCode { get; set; }
    public string? PositionName { get; set; }

    [Precision(15, 4)]
    public decimal Coefficient { get; set; }

    public virtual ICollection<Employee>? Employees { get; set; }

}
