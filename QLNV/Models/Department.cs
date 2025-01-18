using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLNV.Models;

[Table("department")]
public class Department
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Nhập mã phòng ban")]
    [RegularExpression(@"[A-Za-z0-9]*$", ErrorMessage = "Mã chứa kí tự đặc biệt")]
    [MaxLength(30, ErrorMessage = "vượt quá số kí tự 30")]
    public string? DepartmentNumberCode { get; set; }

    [Required(ErrorMessage = "Nhập tên phòng ban")]
    [MaxLength(50, ErrorMessage = "vượt quá số kí tự 50")]
    public string? Name { get; set; }
    public string? Location { get; set; }
    public string? Phone { get; set; }

    public virtual ICollection<Employee> Employees { get; set; }

}
