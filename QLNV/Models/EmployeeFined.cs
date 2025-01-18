using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLNV.Models;

[Table("employee_fined")]
public class EmployeeFined
{
    public int Id { get; set; }
    public string? Detail { get; set; }
    public DateOnly Date { get; set; }

    [Precision(15, 4)]
    public decimal Fine { get; set; }
    public virtual Employee? Employee { get; set; }
}
