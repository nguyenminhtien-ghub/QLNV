using System.ComponentModel.DataAnnotations.Schema;

namespace QLNV.Models;

[Table("employee_award")]
public class EmployeeAward
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public string? Detail { get; set; }
    public decimal Prize { get; set; }
    public virtual Employee? Employee { get; set; }
}
