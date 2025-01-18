using System.ComponentModel.DataAnnotations.Schema;

namespace QLNV.Models;

[Table("salary_modifi_history")]
public class SalaryModifiHistory
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public decimal OldSalary { get; set; }
    public decimal NewSalary { get; set; }
    public decimal HealthInsurance { get; set; }
    public decimal SocialInsurance { get; set; }
    public decimal UnemploymentInsurance { get; set; }
    public decimal Allowance {  get; set; }
    public decimal IncomeTax {  get; set; }
    public DateOnly ModifiDate { get; set; }
    public decimal Coefficients { get; set; }
    public virtual Salary Salary { get; set; }
}
