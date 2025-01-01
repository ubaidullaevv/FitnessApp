using System.ComponentModel.DataAnnotations;
using Domain.DTOs.WorkoutSessionDTOs;
using Domain.Entities;
using Domain.Enums;

namespace Domain.DTOs.ClientDTOs;

public class GetClientsDto
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
    public List<GetWorkoutSessionsDto> WorkoutSessions { get; set; }=[];    
}
