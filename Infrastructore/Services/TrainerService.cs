using System.Net;
using Domain.DTOs.TrainerDTOs;
using Domain.DTOs.WorkoutSessionDTOs;
using Domain.Entities;
using Infrastructore.Data;
using Infrastructore.Interfaces;
using Infrastructore.Responses;
using Microsoft.EntityFrameworkCore;

namespace Infrastructore.Services;

public class TrainerService(DataContext context) : ITrainerService
{
    public async Task<Response<string>> CreateTrainer(AddTrainerDto trainer)
    {
        var trainerDto=new Trainer(){
            Experience = trainer.Experience,
            FirstName = trainer.FirstName,
            LastName = trainer.LastName,
            PhoneNumber= trainer.PhoneNumber,
            Specialization= trainer.Specialization,
            Status= trainer.Status
        };
        await context.Trainers.AddAsync(trainerDto);
        var res= await context.SaveChangesAsync();
        return res==0
        ? new Response<string>(HttpStatusCode.InternalServerError,"Trainer not created!")
        : new Response<string>("Trainer created successfully!");
    }

    public async Task<Response<string>> DeleteTrainer(int id)
    {
       var exist=await context.Trainers.FirstOrDefaultAsync(x=>x.Id==id);
       if(exist==null) return new Response<string>(HttpStatusCode.NotFound,"Trainer not found!");
        context.Trainers.Remove(exist);
        var res=await context.SaveChangesAsync();
        return res==0
        ? new Response<string>(HttpStatusCode.InternalServerError,"Trainer not deleted!")
        : new Response<string>("Trainer deleted successfully!");
    }

    public async Task<Response<List<GetTrainersDto>>> GetAllTrainers()
    {
        var trainer=await context.Trainers.Include(w=>w.WorkoutSessions).ToListAsync();
        var res=trainer.Select(x=> new GetTrainersDto(){
            Experience = x.Experience,
            FirstName = x.FirstName,
            Id = x.Id,
            LastName = x.LastName,
            PhoneNumber = x.PhoneNumber,
            Specialization = x.Specialization,
            Status = x.Status,
            WorkoutSessions=x.WorkoutSessions.Select(w=>new GetWorkoutSessionsDto(){
                ClientId = w.ClientId,
                Comment = w.Comment,
                CreatedAt = w.CreatedAt,
                CurrentParticipants = w.CurrentParticipants,
                EndTime = w.EndTime,
                Id = w.Id,
                MaxCapacity = w.MaxCapacity,
                SessionDate = w.SessionDate,
                SessionStatus = w.SessionStatus,
                StartTime = w.StartTime,
                TrainerId=w.TrainerId,
                WorkoutId = w.WorkoutID
            }).ToList()
        }).ToList();
        return new Response<List<GetTrainersDto>>(res);
    }

    public async Task<Response<Trainer>> GetTrainerById(int id)
    {
       var exist=await context.Trainers.FirstOrDefaultAsync(x=>x.Id==id);
       if(exist==null) return new Response<Trainer>(HttpStatusCode.NotFound,"Trainer not found!");
       return new Response<Trainer>(exist) ;       
    }

    public async Task<Response<string>> UpdateTrainer(int id,UpdateTrainerDto trainer)
    {
      var exist=await context.Trainers.FirstOrDefaultAsync(x=>x.Id==id);
       if(exist==null) return new Response<string>(HttpStatusCode.NotFound,"Trainer not found!");
       exist.Experience = trainer.Experience;
       exist.FirstName = trainer.FirstName;;   
       exist.LastName = trainer.LastName;
       exist.PhoneNumber=trainer.PhoneNumber;
       exist.Status = trainer.Status;
       exist.Specialization = trainer.Specialization;
       var res=await context.SaveChangesAsync();
       return res==0
        ? new Response<string>(HttpStatusCode.InternalServerError,"Trainer not updated!")
        : new Response<string>("Trainer updated successfully!");
    }


}
