using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Domain.DTOs.WorkoutSessionDTOs;

public class AddWorkoutSessionDto
{
    public int TrainerId { get; set; }
    public int WorkoutID { get; set; }
    public int ClientId { get; set; }
    public DateTime SessionDate { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public SessionStatus  SessionStatus  { get; set; }
    public int MaxCapacity { get; set; }
    public int CurrentParticipants { get; set; }
    [MaxLength(200)]
    public string? Comment { get; set; }
    public DateTime CreatedAt { get; set; }
}
