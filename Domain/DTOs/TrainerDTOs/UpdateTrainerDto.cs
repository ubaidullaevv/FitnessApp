using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Domain.DTOs.TrainerDTOs;

public class UpdateTrainerDto
{
public string FirstName { get; set; }
public string? LastName { get; set; }
[Phone]
public string PhoneNumber { get; set; }
public int Experience { get; set; }
public Status Status { get; set; }
public string? Specialization { get; set; }
}
