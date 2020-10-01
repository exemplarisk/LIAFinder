using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LiaFinder.Shared;

namespace LiaFinder.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudentsAsync();
        Task<Student> GetStudentByIdAsync(int id);
        Task<bool> AddStudentAsync(Student student);
        Task<bool> UpdateStudentAsync(Student student);
        Task<bool> RemoveStudentAsync(int id);

        Task<IEnumerable<Student>> QueryStudentsAsync(Func<Student, bool> predicate);
    }
}
