using System;
using System.Text.RegularExpressions;

namespace Test.Entities
{
    public class Student
    {
        public string StudentId { get; private set; }
        public string FullName { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string Email { get; private set; }
        public string Major { get; private set; }
        public double Score { get; private set; }
        public StudentStatus Status { get; private set; }

        public Student() { }

        public Student(string studentId, string fullName, DateTime dateOfBirth, string email, string major, double score, StudentStatus status)
        {
            StudentId = studentId;
            FullName = fullName;
            DateOfBirth = dateOfBirth;
            Email = email;
            Major = major;
            Score = score;
            Status = status;
            Validate();
        }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(StudentId)) throw new ArgumentException("StudentId is required.", nameof(StudentId));
            if (string.IsNullOrWhiteSpace(FullName)) throw new ArgumentException("FullName is required.", nameof(FullName));
            if (DateOfBirth > DateTime.Today) throw new ArgumentException("DateOfBirth cannot be in the future.", nameof(DateOfBirth));
            var age = GetAge();
            if (age < 0 || age > 150) throw new ArgumentOutOfRangeException(nameof(DateOfBirth), "DateOfBirth results in invalid age.");
            if (string.IsNullOrWhiteSpace(Email) || !IsValidEmail(Email)) throw new ArgumentException("Invalid email.", nameof(Email));
            if (string.IsNullOrWhiteSpace(Major)) throw new ArgumentException("Major is required.", nameof(Major));
            if (Score < 0.0 || Score > 100.0) throw new ArgumentOutOfRangeException(nameof(Score), "Score must be between 0 and 100.");
        }

        public int GetAge()
        {
            var today = DateTime.Today;
            var age = today.Year - DateOfBirth.Year;
            if (DateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        }

        private static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            try
            {
                // Simple regex for email validation
                var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);
                return regex.IsMatch(email);
            }
            catch
            {
                return false;
            }
        }

        public static bool TryCreate(string studentId, string fullName, string dateOfBirthInput, string email, string major, string scoreInput, string statusInput, out Student student, out string error)
        {
            student = null;
            error = null;
            try
            {
                if (string.IsNullOrWhiteSpace(studentId)) throw new ArgumentException("StudentId is required.");
                if (string.IsNullOrWhiteSpace(fullName)) throw new ArgumentException("FullName is required.");

                if (!DateTime.TryParse(dateOfBirthInput, out var dob)) throw new ArgumentException("Invalid DateOfBirth format.");

                if (!double.TryParse(scoreInput, out var score)) throw new ArgumentException("Invalid score format.");

                if (!Enum.TryParse<StudentStatus>(statusInput, true, out var status))
                {
                    // allow "1"/"0" for Active/Inactive
                    if (statusInput == "1") status = StudentStatus.Active;
                    else if (statusInput == "0") status = StudentStatus.Inactive;
                    else throw new ArgumentException("Invalid status.");
                }

                var s = new Student(studentId.Trim(), fullName.Trim(), dob.Date, email?.Trim(), major?.Trim(), score, status);
                // Validate will be called in constructor
                student = s;
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public override string ToString()
        {
            return $"{StudentId} | {FullName} | {DateOfBirth:yyyy-MM-dd} | {Email} | {Major} | {Score} | {Status}";
        }
    }

    public enum StudentStatus
    {
        Active = 1,
        Inactive = 0
    }
}
