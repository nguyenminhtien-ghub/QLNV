using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLNV.Models;

[Table("salary")]
public class Salary
{
    public int Id { get; set; }

    [Precision(15, 4)]
    public decimal MinimumSalary { get; set; }

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
    public decimal Coefficients { get; set; }

    public virtual Employee Employee { get; set; }
    public virtual ICollection<SalaryDetail>? SalaryDetails { get; set;}

    public virtual ICollection<SalaryModifiHistory>? SalaryModifiHistorys { get; set; }
}
