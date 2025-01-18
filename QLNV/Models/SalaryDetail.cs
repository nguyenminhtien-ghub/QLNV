using System.ComponentModel.DataAnnotations.Schema;

namespace QLNV.Models;

[Table("salary_detail")]
public class SalaryDetail
{
    public int Id {  get; set; }
    public int EmployId { get; set; }

    public decimal BaseSalary { get; set; }
    public decimal HealthInsurance { get; set; }
    public decimal SocialInsurance { get; set; }
    public decimal UnemploymentInsurance { get; set; }
    public decimal Allowance { get; set; }
    public decimal IncomeTax { get; set; }

    public decimal AwardPrize { get; set; }
    public decimal Fine { get; set; }
    public DateOnly PaidDate { get; set; }
    public decimal Total { get; set; }

    public virtual Salary Salary { get; set; }
}
