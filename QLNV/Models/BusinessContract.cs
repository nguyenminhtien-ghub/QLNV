using System.ComponentModel.DataAnnotations.Schema;

namespace QLNV.Models;

[Table("business_contract")]
public class BusinessContract
{
    public int Id { get; set; }
    public string? ContractNumberCode {  get; set; }
    public string? Type {  get; set; }
    public DateTime Begin {  get; set; }
    public DateTime End { get; set; }
    public string? Note { get; set; }

    public virtual ICollection<Employee> Employees { get; set; }
}
