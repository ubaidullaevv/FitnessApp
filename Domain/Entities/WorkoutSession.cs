using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain.Entities;

public class WorkoutSession
{
    [Key]
    public int Id { get; set; }
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
    [ForeignKey("TrainerId")]
    public Trainer Trainer { get; set; }
    [ForeignKey("WorkoutId")]
    public Workout Workout { get; set; }
    [ForeignKey("ClientI")]
    public Client Client { get; set; }
}
