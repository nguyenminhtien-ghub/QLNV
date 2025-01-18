using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLNV.Models;

[Table("salary_modifi_history")]
public class SalaryModifiHistory
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    [Precision(15, 4)]
    public decimal OldSalary { get; set; }
    [Precision(15, 4)]
    public decimal NewSalary { get; set; }

    [Precision(15, 4)]
    public decimal HealthInsurance { get; set; }

    [Precision(15, 4)]
    public decimal SocialInsurance { get; set; }

    [Precision(15, 4)]
    public decimal UnemploymentInsurance { get; set; }

    [Precision(15, 4)]
    public decimal Allowance {  get; set; }

    [Precision(15, 4)]
    public decimal IncomeTax {  get; set; }
    public DateOnly ModifiDate { get; set; }

    [Precision(15, 4)]
    public decimal Coefficients { get; set; }
    public virtual Salary Salary { get; set; }
}
