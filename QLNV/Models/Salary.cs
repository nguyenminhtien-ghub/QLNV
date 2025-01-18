using System.ComponentModel.DataAnnotations.Schema;

namespace QLNV.Models;

[Table("salary")]
public class Salary
{
    public int Id { get; set; }
    public decimal MinimumSalary { get; set; }

    public decimal HealthInsurance { get; set; }
    public decimal SocialInsurance { get; set; }
    public decimal UnemploymentInsurance { get; set; }
    public decimal Allowance { get; set; }
    public decimal IncomeTax { get; set; }

    public decimal Coefficients { get; set; }

    public virtual Employee Employee { get; set; }
    public virtual ICollection<SalaryDetail> SalaryDetails { get; set;}

    public virtual ICollection<SalaryModifiHistory> SalaryModifiHistorys { get; set; }
}
