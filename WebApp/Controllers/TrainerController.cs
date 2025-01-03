using Domain.DTOs.TrainerDTOs;
using Domain.Entities;
using Infrastructore.Interfaces;
using Infrastructore.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TrainerController(ITrainerService service):ControllerBase
{
    [HttpPost]
    public async Task<Response<string>> Create(AddTrainerDto trainer) => await service.CreateTrainer(trainer);
    public async Task<Response<string>> Update(int id,UpdateTrainerDto trainer) => await service.UpdateTrainer(id,trainer);
    public async Task<Response<string>> Delete(int id) => await service.DeleteTrainer(id);
    public async Task<Response<Trainer>> GetbyId(int id) => await service.GetTrainerById(id);
    public async Task<Response<List<GetTrainersDto>>> GetAll() => await service.GetAllTrainers();
}
