using System.ComponentModel.DataAnnotations;
using Domain.DTOs.WorkoutSessionDTOs;
using Domain.Entities;
using Domain.Enums;

namespace Domain.DTOs.WorkoutDTOs;

public class GetWorkoutsDto
{
    [Key]
    public int Id { get; set; }
    [Required,MaxLength(100)]
    public string Name { get; set; }
    [MaxLength(500)]
    public string Description { get; set; }
    public int Duration { get; set; }
    public int MaxParticipants { get; set; }
    public Difficulty Difficulty { get; set; }
    public bool IsActive { get; set; }=true;
    public List<GetWorkoutSessionsDto> WorkoutSessions { get; set; }=[];    
}
