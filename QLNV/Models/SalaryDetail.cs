using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLNV.Models;

[Table("salary_detail")]
public class SalaryDetail
{
    public int Id {  get; set; }
    public int EmployeeId { get; set; }

    [Precision(15, 4)]
    public decimal BaseSalary { get; set; }
    [Precision(15, 4)]
    public decimal HealthInsurance { get; set; }
    [Precision(15, 4)]
    public decimal SocialInsurance { get; set; }
    [Precision(15, 4)]
    public decimal UnemploymentInsurance { get; set; }
    [Precision(15, 4)]
    public decimal Allowance { get; set; }
    [Precision(15, 4)]
    public decimal IncomeTax { get; set; }

    [Precision(15, 4)]
    public decimal AwardPrize { get; set; }
    [Precision(15, 4)]
    public decimal Fine { get; set; }
    public DateOnly PaidDate { get; set; }
    [Precision(15, 4)]
    public decimal Total { get; set; }

    public virtual Salary Salary { get; set; }
}
