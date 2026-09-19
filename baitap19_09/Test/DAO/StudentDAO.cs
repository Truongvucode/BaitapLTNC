using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Test.Entities;

namespace Test.DAO
{
    public class StudentDAO
    {
        private readonly List<Student> students = new List<Student>();

        public void Add(Student student)
        {
            if (student == null) throw new ArgumentNullException(nameof(student));
            student.Validate();

            if (!IsValidStudentId(student.StudentId)) throw new ArgumentException("StudentId has invalid format.", nameof(student.StudentId));
            if (!IsValidFullName(student.FullName)) throw new ArgumentException("FullName has invalid characters.", nameof(student.FullName));

            if (students.Any(s => s.StudentId == student.StudentId)) throw new InvalidOperationException($"A student with Id '{student.StudentId}' already exists.");
            students.Add(student);
        }

        public void Edit(Student student)
        {
            if (student == null) throw new ArgumentNullException(nameof(student));
            if (!IsValidStudentId(student.StudentId)) throw new ArgumentException("StudentId has invalid format.", nameof(student.StudentId));
            if (!IsValidFullName(student.FullName)) throw new ArgumentException("FullName has invalid characters.", nameof(student.FullName));

            var idx = students.FindIndex(s => s.StudentId == student.StudentId);
            if (idx == -1) throw new KeyNotFoundException($"Student with Id '{student.StudentId}' not found.");
            students[idx] = student;
        }

        public bool Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return false;
            var existing = students.FirstOrDefault(s => s.StudentId == id);
            if (existing == null) return false;
            return students.Remove(existing);
        }

        public List<Student> GetAlls()
        {
            return new List<Student>(students);
        }

        public Student GetById(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return null;
            return students.FirstOrDefault(s => s.StudentId == id);
        }

        public List<Student> GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return new List<Student>();
            return students
                .Where(s => !string.IsNullOrEmpty(s.FullName) && s.FullName.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();
        }

        public List<Student> GetAdmitted(double cutoff)
        {
            if (cutoff < 0) throw new ArgumentOutOfRangeException(nameof(cutoff), "Cutoff must be non-negative.");
            return students.Where(s => s.Score >= cutoff).ToList();
        }

        public List<Student> getAdmitted(double cutoff) => GetAdmitted(cutoff);

        private static readonly Regex StudentIdRegex = new Regex("^sv\\d{4}$", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
        private static readonly Regex FullNameRegex = new Regex(@"^\p{Lu}\p{Ll}*(?:\s\p{Lu}\p{Ll}*)+$", RegexOptions.Compiled | RegexOptions.CultureInvariant);

        private static bool IsValidStudentId(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return false;
            return StudentIdRegex.IsMatch(id.Trim());
        }

        private static bool IsValidFullName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return false;
            return FullNameRegex.IsMatch(name.Trim());
        }
    }
}
