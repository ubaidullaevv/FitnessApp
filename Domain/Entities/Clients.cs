using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain.Entities;
[Table("Clients")]
public class Client
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    [Phone]
    public string PhoneNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
    public MembershipStatus MembershipStatus { get; set; }
    public List<WorkoutSession> WorkoutSessions { get; set; }=[];
}
