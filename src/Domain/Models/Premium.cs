using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Premium
{

    public int Id { get; set; }  

    public string Name { get; set; } = string.Empty;

    public DateTime StartDate { get; set; }

    public DateTime EndtDate { get; set; }

    public int StudentId { get; set; }

    //navigation property
    public Student? Student { get; set; }

}
