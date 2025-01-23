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

    public int EmployeePositionId { get; set; }

    [ForeignKey(nameof(EmployeePositionId))]
    public virtual EmployeePosition? EmployeePosition { get; set; }
    public bool IsActive { get; set; }

    public int DepartmentId { get; set; }

    [ForeignKey(nameof(DepartmentId))]
    public virtual Department? Department { get; set; }

    public int EmployeeEducatonId {  get; set; }

    [ForeignKey(nameof(EmployeeEducatonId))]
    public virtual EmployeeEducation? EductionStatus {  get; set; }

    public string? CitizenNumber {  get; set; }

    public virtual ICollection<EmployeeEducationHistory>? EducationHistories { get; set; }

    
    public virtual ICollection<EmployeePositionHistory>? PositionHistories { get; set;  }

    public int SalaryId {  get; set; }
    public virtual Salary Salary {  get; set; }
    

}
