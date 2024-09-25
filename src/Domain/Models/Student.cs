using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Student
{

    public int Id { get; set; }  //Key indicates that this ID is going to be a primary Key

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    //navigation property
    public List<Premium> Premiums { get; set; } = new();

}
