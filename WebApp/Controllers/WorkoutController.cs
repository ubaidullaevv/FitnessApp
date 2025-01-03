using Domain.DTOs.WorkoutDTOs;
using Domain.Entities;
using Infrastructore.Interfaces;
using Infrastructore.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("api/[controller]")]
public class WorkoutController(IWorkoutService service):ControllerBase
{
    [HttpPost]
    public async Task<Response<string>> Create(AddWorkoutDto workout) => await service.CreateWorkout(workout);
    public async Task<Response<string>> Update(int id,UpdateWorkoutDto workout) => await service.UpdateWorkout(id,workout);
    public async Task<Response<string>> Delete(int id) => await service.DeleteWorkout(id);
    public async Task<Response<Workout>> GetbyId(int id) => await service.GetWorkoutById(id);
    public async Task<Response<List<GetWorkoutsDto>>> GetAll() => await service.GetAllWorkouts();
}
