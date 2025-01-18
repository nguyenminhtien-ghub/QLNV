using System.ComponentModel.DataAnnotations.Schema;

namespace QLNV.Models;

[Table("employee_leave")]
public class EmployeeLeave
{
    public int Id { get; set; }
    public virtual Employee? Employee { get; set; }
    public DateTime? LeavingDate { get; set; }



}
