using Application.Contracts;
using Application.Dtos;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Contracts;
using Infrastructure.Core;
using Infrastructure.SearchParams;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Concretes
{
    public class VisitService : IVisitService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VisitService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateAsync(VisitDTO model)
        {
            var entity = _mapper.Map<Visit>(model);

            _unitOfWork.Visits.Add(entity);

            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var visit = await _unitOfWork.Visits.GetAsync(id);

            _unitOfWork.Visits.Remove(visit);

            await _unitOfWork.CompleteAsync();
        }

        public async Task<Pagination<VisitDTO>> GetAllAsync(VisitSearchParams visitSearchParams)
        {
            var data = await _unitOfWork.Visits.GetAllWithUserAndAccountAsync(visitSearchParams);

            var count = await _unitOfWork.Visits.CountAsync(visitSearchParams);

            return new Pagination<VisitDTO>
                (visitSearchParams.Skip, visitSearchParams.Take, count, _mapper.Map<List<VisitDTO>>(data));
        }

        public async Task<VisitDTO> GetAsync(int id)
        {
            var entity = await _unitOfWork.Visits.GetVisitWithAccountAsync(id);

            var output = _mapper.Map<VisitDTO>(entity);

            return output;
        }

        public async Task UpdateAsync(VisitDTO model)
        {
            var entity = await _unitOfWork.Visits.GetAsync(x => x.Id == model.Id);

            _mapper.Map(model, entity);

            await _unitOfWork.CompleteAsync();
        }
    }
}
