using System.ComponentModel.DataAnnotations.Schema;

namespace QLNV.Models;

[Table("employee_position_history")]
public class EmployeePositionHistory
{
    public int Id { get; set; }
    public DateOnly ChangeDate {  get; set; }
    public string? Detail {  get; set; }
    public int OldDepartment {  get; set; }
    public int NewDepartment { get; set; }
    public virtual Employee Employee { get; set; }
}
