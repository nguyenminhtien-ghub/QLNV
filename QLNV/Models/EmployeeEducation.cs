using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLNV.Models;

[Table("employee_education")]
public class EmployeeEducation
{
    public int Id {  get; set; }
    public string? MajorNumberCode { get; set; }
    public string? MajorName { get; set; }
    public string? EducationStatusCode { get; set; }
    public string? EducationName { get; set; }

    [Precision(15, 4)]
    public decimal Coefficient { get; set; }

    public virtual ICollection<Employee>? Employees { get; set; }


}
