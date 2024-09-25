using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Data.Repositories
{
    public class StudentRepository : IStudentRepository //essa é a classe concreta (onde de fato as coisas acontecem, onde existem os métodos e onde os comportamentos são executados)
    {

        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> OnGetAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        { 
           return await _context.Students.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task DeleteAsync(Student student)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }
    }
}
