using System;
using System.Collections.Generic;
using Xunit;

namespace StudentPerformanceAnalyzer.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void NormalWorkflowTest()
        {
            var students = new List<Student>
            {
                new Student("Anna", 85),
                new Student("Alex", 45),
                new Student("Maria", 92)
            };

            string result = Program.RunPipeline(students, score => score);

            Assert.Contains("Anna: 85 points", result);
            Assert.Contains("Maria: 92 points", result);
            Assert.DoesNotContain("Alex", result);
        }

        [Fact]
        public void EmptyDatasetTest()
        {
            var students = new List<Student>();

            string result = Program.RunPipeline(students, score => score);

            Assert.Equal("No students found.", result);
        }

        [Fact]
        public void BoundaryValueTest()
        {
            var students = new List<Student>
            {
                new Student("Tom", 50)
            };

            string result = Program.RunPipeline(students, score => score);

            Assert.Contains("Tom: 50 points", result);
        }

        [Fact]
        public void InvalidInputTest()
        {
            var students = new List<Student>
            {
                new Student("Invalid", -5)
            };

            Assert.False(Program.IsValid(students));

            Assert.Throws<ArgumentException>(() =>
                Program.RunPipeline(students, score => score));
        }

        [Fact]
        public void TwoPoliciesTest()
        {
            var students = new List<Student>
            {
                new Student("John", 60)
            };

            string normal = Program.RunPipeline(students, score => score);

            string bonus = Program.RunPipeline(
                students, score => Math.Min(score + 10, 100));

            Assert.Contains("John: 60 points", normal);
            Assert.Contains("John: 70 points", bonus);
            Assert.NotEqual(normal, bonus);
        }

        [Fact]
        public void OriginalDataRemainsUnchangedTest()
        {
            var students = new List<Student>
            {
                new Student("Anna", 85),
                new Student("John", 60)
            };

            Program.RunPipeline(students, score => score + 10);

            Assert.Equal(85, students[0].Score);
            Assert.Equal(60, students[1].Score);
            Assert.Equal(2, students.Count);
        }
    }
}