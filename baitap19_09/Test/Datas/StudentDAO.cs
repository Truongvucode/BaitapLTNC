using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.Entities;

namespace Test.Datas
{
    public class StudentDAO
    {
        private readonly List<Student> students = new List<Student>();

        public void Add(Student student)
        {
            try
            {
                if (student == null) throw new ArgumentNullException(nameof(student));
                student.Validate();
                if (string.IsNullOrWhiteSpace(student.StudentId)) throw new ArgumentException("StudentId is required.", nameof(student.StudentId));
                if (students.Any(s => s.StudentId == student.StudentId)) throw new InvalidOperationException($"Student with id '{student.StudentId}' already exists.");
                students.Add(student);
            }
            catch (Exception)
            {
                // bubble up for caller to handle; could log here
                throw;
            }
        }

        public void Edit(Student student)
        {
            try
            {
                if (student == null) throw new ArgumentNullException(nameof(student));
                student.Validate();
                var idx = students.FindIndex(s => s.StudentId == student.StudentId);
                if (idx == -1) throw new KeyNotFoundException($"Student with id '{student.StudentId}' not found.");
                students[idx] = student;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id)) return false;
                var existing = students.FirstOrDefault(s => s.StudentId == id);
                if (existing == null) return false;
                return students.Remove(existing);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Student> GetAlls()
        {
            try
            {
                return new List<Student>(students);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // lowercase alias as requested
        public List<Student> getAlls() => GetAlls();

        public Student GetById(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id)) return null;
                return students.FirstOrDefault(s => s.StudentId == id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // lowercase alias
        public Student getById(string id) => GetById(id);

        public List<Student> GetByName(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name)) return new List<Student>();
                return students.Where(s => !string.IsNullOrWhiteSpace(s.FullName) && s.FullName.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // lowercase alias
        public List<Student> getByName(string name) => GetByName(name);
    }
}
