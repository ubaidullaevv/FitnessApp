using System.Net;
using Domain.DTOs.WorkoutDTOs;
using Domain.DTOs.WorkoutSessionDTOs;
using Domain.Entities;
using Infrastructore.Data;
using Infrastructore.Interfaces;
using Infrastructore.Responses;
using Microsoft.EntityFrameworkCore;

namespace Infrastructore.Services;

public class WorkoutService(DataContext context) : IWorkoutService
{
    public async Task<Response<string>> CreateWorkout(AddWorkoutDto workout)
    {
        var WorkoutDto=new Workout(){
            Description = workout.Description,
            Difficulty = workout.Difficulty,
            Duration = workout.Duration,
            MaxParticipants= workout.MaxParticipants,
            Name= workout.Name
        };
        await context.Workouts.AddAsync(WorkoutDto);
        var res= await context.SaveChangesAsync();
        return res==0
        ? new Response<string>(HttpStatusCode.InternalServerError,"Workout not created!")
        : new Response<string>("Workout created successfully!");
    }

    public async Task<Response<string>> DeleteWorkout(int id)
    {
       var exist=await context.Workouts.FirstOrDefaultAsync(x=>x.Id==id);
       if(exist==null) return new Response<string>(HttpStatusCode.NotFound,"Workout not found!");
        context.Workouts.Remove(exist);
        var res=await context.SaveChangesAsync();
        return res==0
        ? new Response<string>(HttpStatusCode.InternalServerError,"Workout not deleted!")
        : new Response<string>("Workout deleted successfully!");
    }

    public async Task<Response<List<GetWorkoutsDto>>> GetAllWorkouts()
    {
        var Workout=await context.Workouts.Include(w=>w.WorkoutSessions).ToListAsync();
        var res=Workout.Select(x=> new GetWorkoutsDto(){
            Description = x.Description,
            Difficulty = x.Difficulty,
            Id = x.Id,
            Duration = x.Duration,
            IsActive = x.IsActive,
            MaxParticipants = x.MaxParticipants,
             Name = x.Name,
            WorkoutSessions=x.WorkoutSessions.Select(w=>new GetWorkoutSessionsDto(){
                WorkoutId = w.WorkoutID,
                Comment = w.Comment,
                CreatedAt = w.CreatedAt,
                CurrentParticipants = w.CurrentParticipants,
                EndTime = w.EndTime,
                Id = w.Id,
                MaxCapacity = w.MaxCapacity,
                SessionDate = w.SessionDate,
                SessionStatus = w.SessionStatus,
                StartTime = w.StartTime,
            }).ToList()
        }).ToList();
        return new Response<List<GetWorkoutsDto>>(res);
    }

    public async Task<Response<Workout>> GetWorkoutById(int id)
    {
       var exist=await context.Workouts.FirstOrDefaultAsync(x=>x.Id==id);
       if(exist==null) return new Response<Workout>(HttpStatusCode.NotFound,"Workout not found!");
       return new Response<Workout>(exist) ;       
    }

    public async Task<Response<string>> UpdateWorkout(int id,UpdateWorkoutDto workout)
    {
      var exist=await context.Workouts.FirstOrDefaultAsync(x=>x.Id==id);
       if(exist==null) return new Response<string>(HttpStatusCode.NotFound,"Workout not found!");
       exist.Description = workout.Description;
       exist.Difficulty = workout.Difficulty;;   
       exist.Duration = workout.Duration;
       exist.IsActive=workout.IsActive;
       exist.MaxParticipants = workout.MaxParticipants;
       exist.Name = workout.Name;
       var res=await context.SaveChangesAsync();
       return res==0
        ? new Response<string>(HttpStatusCode.InternalServerError,"Workout not updated!")
        : new Response<string>("Workout updated successfully!");
    }


}
