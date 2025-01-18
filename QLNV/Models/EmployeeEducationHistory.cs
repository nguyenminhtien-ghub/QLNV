using System.ComponentModel.DataAnnotations.Schema;

namespace QLNV.Models;

[Table("employee_education_history")]
public class EmployeeEducationHistory
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public DateOnly UpdateTime { get; set; }
    public int OldEducationId { get; set; }
    public int NewEducationId { get; set; }

    public virtual Employee Employee { get; set; }
}
