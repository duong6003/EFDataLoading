using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Web.Entities;
using Web.EntitiesDTO;
using Web.Repositories;

namespace Web.Services
{
    public interface IPrizeService
    {
        Task<List<Prize>> GetAllAsync();
        Task<string?> CreateAsync(AddPrize Prize);
        Task<string?> CreateItemAsync(string prizeId ,List<AddPrizeItem> items);
    }
    public class PrizeService : IPrizeService
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        private readonly IMapper mapper;

        public PrizeService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this.repositoryWrapper = repositoryWrapper;
            this.mapper = mapper;
        }

        public async Task<string?> CreateAsync(AddPrize request)
        {
            Prize prize = mapper.Map<Prize>(request);
            if(await repositoryWrapper.Prizes.GetByIdAsync(prize.Id) != null) return "IdExist";
            await repositoryWrapper.Prizes.AddAsync(prize);
            return null;
        }

        public async Task<string?> CreateItemAsync(string prizeId, List<AddPrizeItem> items)
        {
            if(await repositoryWrapper.Prizes.GetByIdAsync(prizeId) == null) return "IdNotFound";
            if(items.Any(x => x.GiftCode == null || x.ScholarshipCode == null)) return "Invalid";
            List<string> giftCodes = items.Select(x => x.GiftCode!).ToList();
            List<string> scholarshipCodes = items.Select(x => x.ScholarshipCode!).ToList();
            if(await repositoryWrapper.Gifts.CountAsync(x => giftCodes.Contains(x.GiftCode)) != giftCodes.Count) return "InValidGiftCode";
            if(await repositoryWrapper.Scholarships.CountAsync(x => scholarshipCodes.Contains(x.ScholarshipCode)) != scholarshipCodes.Count) return "InValidScholarshipCode";
            List<PrizeItem> entities = mapper.Map<List<PrizeItem>>(items);
            entities.ForEach(x => x.PrizeId = prizeId);
            await repositoryWrapper.PrizeItems.AddRangeAsync(entities);
            return null;
        }

        public async Task<List<Prize>> GetAllAsync()
        {
            return await repositoryWrapper.Prizes.Find()
                .Include(x => x.PrizeItems!).ThenInclude(x => x.Gift)
                .Include(x => x.PrizeItems!).ThenInclude(x => x.Scholarship)
                .ToListAsync();
        }
    }
}