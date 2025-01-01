using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain.Entities;
[Table("Trainers")]
public class Trainer
{
public int Id { get; set; }
public string FirstName { get; set; }
public string? LastName { get; set; }
[Phone]
public string PhoneNumber { get; set; }
public int Experience { get; set; }
public Status Status { get; set; }
public string? Specialization { get; set; }
public List<WorkoutSession> WorkoutSessions { get; set; }=[];
}
