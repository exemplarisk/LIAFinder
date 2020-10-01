using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using LiaFinder;
using LiaFinder.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using LiaFinder.Shared;

namespace LiaFinder.Core
{
    public class StudentRepository : IStudentRepository
    {
        private readonly Database _database;

        public StudentRepository(string path)
        {
            _database = new Database(path);
        }

        public async Task<bool> AddStudentAsync(Student student)
        {
            try
            {
                var tracking = await _database.Students.AddAsync(student);

                await _database.SaveChangesAsync();

                var isAdded = tracking.State == EntityState.Added;

                return isAdded;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            try
            {
                var student = await _database.Students.FindAsync(id);

                return student;
            }
            catch(Exception e)
            {
                // RETURN BAD REQUEST SHOULD GO HERE
                return null;
            }
        }

        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            try
            {
                var students = await _database.Students.ToListAsync();

                return students;
            }
            catch(Exception e)
            {
                // TODO Check to return BadRequest <-----
                return null;
            }
        }

        public Task<IEnumerable<Student>> QueryStudentsAsync(Func<Student, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveStudentAsync(int id)
        {
            try
            {
                var student = await _database.Students.FindAsync(id);
                var tracking = _database.Remove(student);

                await _database.SaveChangesAsync();

                var isDeleted = tracking.State == EntityState.Deleted;

                return isDeleted;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateStudentAsync(Student student)
        {
            try
            {
                var tracking = _database.Students.Update(student);

                await _database.SaveChangesAsync();

                var isModified = tracking.State == EntityState.Modified;

                return isModified;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
