using Domain.DTOs.WorkoutDTOs;
using Domain.Entities;
using Infrastructore.Responses;

namespace Infrastructore.Interfaces;

public interface IWorkoutService
{
    public Task<Response<string>> CreateWorkout(AddWorkoutDto workout);
    public Task<Response<string>> UpdateWorkout(int id,UpdateWorkoutDto workout);
    public Task<Response<string>> DeleteWorkout(int id);
    public Task<Response<List<GetWorkoutsDto>>> GetAllWorkouts();
    public Task<Response<Workout>> GetWorkoutById(int id);
}
