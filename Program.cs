using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public string Name { get; }
    public int Score { get; }

    public Student(string name, int score)
    {
        Name = name;
        Score = score;
    }
}

public class Program
{
    public static List<Student> FilterStudents(
        IReadOnlyList<Student> students)
    {
        if (students == null)
            throw new ArgumentNullException(nameof(students));

        return students
            .Where(student => student.Score >= 50)
            .ToList();
    }

    public static List<Student> CalculateScores(
        IReadOnlyList<Student> students,
        Func<int, int> policy)
    {
        if (students == null)
            throw new ArgumentNullException(nameof(students));

        if (policy == null)
            throw new ArgumentNullException(nameof(policy));

        return students
            .Select(student =>
                new Student(student.Name, policy(student.Score)))
            .ToList();
    }

    public static string CreateReport(
        IReadOnlyList<Student> students)
    {
        if (students == null)
            throw new ArgumentNullException(nameof(students));

        if (students.Count == 0)
            return "No students found.";

        return string.Join(
            Environment.NewLine,
            students.Select(student =>
                $"{student.Name}: {student.Score} points"));
    }

    public static bool IsValid(IReadOnlyList<Student>? students)
    {
        return students != null &&
               students.All(student =>
                   student != null &&
                   !string.IsNullOrWhiteSpace(student.Name) &&
                   student.Score >= 0 &&
                   student.Score <= 100);
    }

    public static string RunPipeline(
        IReadOnlyList<Student> students,
        Func<int, int> policy)
    {
        if (students == null)
            throw new ArgumentNullException(nameof(students));

        if (policy == null)
            throw new ArgumentNullException(nameof(policy));

        if (!IsValid(students))
            throw new ArgumentException("Invalid student data.");

        var filtered = FilterStudents(students);
        var calculated = CalculateScores(filtered, policy);

        return CreateReport(calculated);
    }

    public static void Main()
    {
        var students = new List<Student>
        {
            new Student("Anna", 85),
            new Student("Alex", 45),
            new Student("Maria", 92),
            new Student("John", 60),
            new Student("David", 30),
            new Student("Tom", 50)
        };

        Func<int, int> normalPolicy = score => score;
        Func<int, int> bonusPolicy =
            score => Math.Min(score + 10, 100);

        Console.WriteLine("=== NORMAL POLICY ===");
        Console.WriteLine(RunPipeline(students, normalPolicy));

        Console.WriteLine();
        Console.WriteLine("=== BONUS POLICY ===");
        Console.WriteLine(RunPipeline(students, bonusPolicy));

        Console.WriteLine();
        Console.WriteLine("=== EMPTY DATASET ===");
        Console.WriteLine(
            RunPipeline(new List<Student>(), normalPolicy));

        Console.WriteLine();
        Console.WriteLine("=== INVALID DATA ===");

        var invalidStudents = new List<Student>
        {
            new Student("Invalid", -5)
        };

        Console.WriteLine(
            IsValid(invalidStudents)
                ? "Data is valid."
                : "Invalid student data rejected.");
    }
}