using System.ComponentModel.DataAnnotations;
using Domain.DTOs.WorkoutDTOs;
using Domain.DTOs.WorkoutSessionDTOs;
using Domain.Entities;
using Domain.Enums;

namespace Domain.DTOs.TrainerDTOs;

public class GetTrainersDto
{
public int Id { get; set; }
public string FirstName { get; set; }
public string? LastName { get; set; }
[Phone]
public string PhoneNumber { get; set; }
public int Experience { get; set; }
public Status Status { get; set; }
public string? Specialization { get; set; }
public List<GetWorkoutSessionsDto> WorkoutSessions { get; set; }=[];    
}
