using System;
using System.Linq;
using Test.Entities;
using Test.DAO;

namespace Test
{
    class Program
    {
        static void Main()
        {
            var dao = new StudentDAO();

            // Helper to create and add student
            void CreateAndAdd(string id, string name, string dob, string email, string major, string score, string status)
            {
                if (Student.TryCreate(id, name, dob, email, major, score, status, out var st, out var err))
                {
                    try
                    {
                        dao.Add(st);
                        Console.WriteLine($"Added: {st}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to add {id}: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid student '{id}': {err}");
                }
            }

            // Create valid students
            CreateAndAdd("sv0001", "Nguyen Van A", "2003-05-10", "a@example.com", "Computer Science", "85", "Active");
            CreateAndAdd("sv0002", "Tran Thi B", "2004-07-20", "b@example.com", "Mathematics", "65", "Inactive");
            CreateAndAdd("sv0003", "Le Van C", "2002-01-15", "c@example.com", "Physics", "75", "Active");

            // Attempt to add invalid students
            CreateAndAdd("s100", "nguyen van a", "2003-05-10", "bad-email", "CS", "120", "Active");

            Console.WriteLine();
            Console.WriteLine("All students:");
            foreach (var s in dao.GetAlls()) Console.WriteLine(s);

            Console.WriteLine();
            Console.WriteLine("GetById sv0002:");
            var byId = dao.GetById("sv0002");
            Console.WriteLine(byId != null ? byId.ToString() : "Not found");

            Console.WriteLine();
            Console.WriteLine("GetByName 'Van':");
            var byName = dao.GetByName("Van");
            foreach (var s in byName) Console.WriteLine(s);

            Console.WriteLine();
            Console.WriteLine("Admitted with cutoff 70:");
            var admitted = dao.GetAdmitted(70);
            foreach (var s in admitted) Console.WriteLine(s);

            Console.WriteLine();
            Console.WriteLine("Edit sv0002 (increase score to 72 and change status):");
            if (dao.GetById("sv0002") is Student s2)
            {
                try
                {
                    var edited = new Student(s2.StudentId, s2.FullName, s2.DateOfBirth, s2.Email, s2.Major, 72, StudentStatus.Active);
                    dao.Edit(edited);
                    Console.WriteLine("Edited: " + dao.GetById("sv0002"));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Edit failed: " + ex.Message);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Admitted with cutoff 70 after edit:");
            foreach (var s in dao.GetAdmitted(70)) Console.WriteLine(s);

            Console.WriteLine();
            Console.WriteLine("Delete sv0003:");
            var deleted = dao.Delete("sv0003");
            Console.WriteLine(deleted ? "Deleted sv0003" : "Delete failed");

            Console.WriteLine();
            Console.WriteLine("Final list:");
            foreach (var s in dao.GetAlls()) Console.WriteLine(s);

            Console.WriteLine();
            Console.WriteLine("Demo finished.");
        }
    }
}
