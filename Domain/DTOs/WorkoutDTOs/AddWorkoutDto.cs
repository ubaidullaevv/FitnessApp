using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Domain.DTOs.WorkoutDTOs;

public class AddWorkoutDto
{
    [Required,MaxLength(100)]
    public string Name { get; set; }
    [MaxLength(500)]
    public string Description { get; set; }
    public int Duration { get; set; }
    public int MaxParticipants { get; set; }
    public Difficulty Difficulty { get; set; }    
}
