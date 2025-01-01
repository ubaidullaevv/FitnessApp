using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain.Entities;
[Table("Workouts")]
public class Workout
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
    public List<WorkoutSession> WorkoutSessions { get; set; }=[];
}
