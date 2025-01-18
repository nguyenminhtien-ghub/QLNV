using System.ComponentModel.DataAnnotations.Schema;

namespace QLNV.Models;

public enum Gender
{
    Female = 0,
    Male = 1
}

[Table("employee")]
public class Employee
{
    public int Id { get; set; }
    public string? NumberCode { get; set; }
    public string Name { get; set; }

    public DateOnly DOB { get; set; }
    public string? Country { get; set; }
    public string? AvatarImagePath { get; set; }
    public Gender Gender { get; set; }
    
    public string? Ethnic {  get; set; }
    public string? Phone { get; set; }
    public virtual EmployeePosition? EmployeePosition { get; set; }
    public string? Status { get; set; }

    public virtual Department? Department { get; set; }

    public virtual BusinessContract? BusinessContract { get; set; }

    public virtual EmployeeEducation? EductionStatus {  get; set; }

    public string? CitizenNumber {  get; set; }

    public virtual ICollection<EmployeeEducationHistory>? EducationHistories { get; set; }

    
    public virtual ICollection<EmployeePositionHistory>? PositionHistories { get; set;  }

    public int SalaryId {  get; set; }
    public virtual Salary Salary {  get; set; }
    

}
