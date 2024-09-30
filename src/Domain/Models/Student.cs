using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Student : BaseEntity
{

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    //navigation property
    public List<Premium> Premiums { get; set; } = new();

}
