using Domain.DTOs.TrainerDTOs;
using Domain.Entities;
using Infrastructore.Responses;

namespace Infrastructore.Interfaces;

public interface ITrainerService
{
    public Task<Response<string>> CreateTrainer(AddTrainerDto trainer);
    public Task<Response<string>> UpdateTrainer(int id,UpdateTrainerDto trainer);
    public Task<Response<string>> DeleteTrainer(int id);
    public Task<Response<List<GetTrainersDto>>> GetAllTrainers();
    public Task<Response<Trainer>> GetTrainerById(int id);
}
