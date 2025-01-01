using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Domain.DTOs.ClientDTOs;

public class UpdateClientDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    [Phone]
    public string PhoneNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
    public MembershipStatus MembershipStatus { get; set; }    
}
