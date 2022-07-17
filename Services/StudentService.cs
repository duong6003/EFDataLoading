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
    public interface IStudentService
    {
        Task<List<Student>> GetAllAsync();
        Task<string?> CreateAsync(AddStudent student);
    }
    public class StudentService : IStudentService
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        private readonly IMapper mapper;

        public StudentService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this.repositoryWrapper = repositoryWrapper;
            this.mapper = mapper;
        }

        public async Task<string?> CreateAsync(AddStudent request)
        {
            Student student = mapper.Map<Student>(request);
            if(await repositoryWrapper.Students.GetByIdAsync(student.Id) != null) return "IdExist";
            await repositoryWrapper.Students.AddAsync(student);
            return null;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await repositoryWrapper.Students.Find()
                .Include(x => x.Prizes!).ThenInclude(x => x.PrizeItems!).ThenInclude(x => x.Gift)
                .Include(x => x.Prizes!).ThenInclude(x => x.PrizeItems!).ThenInclude(x => x.Scholarship)
                .ToListAsync();
        }
    }
}