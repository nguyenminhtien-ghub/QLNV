using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLNV.Models;

[Table("employee_award")]
public class EmployeeAward
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public string? Detail { get; set; }

    [Precision(15, 4)]
    public decimal Prize { get; set; }

    public int EmployeeId { get; set; }
    public virtual Employee? Employee { get; set; }
}
