# StudentPerformanceAnalyzer
# StudentPerformanceAnalyzer
Student:Tomiris Chekalin
Group:IT-2503

#Project topic
This project processes student scores using a C# console application. It is designed for teachers or students who need to check scores and create a simple report.

Input data
Each student has a name and a score from 0 to 100. The sample data contains Anna (85), Alex (45), Maria (92), John (60), David (30), and Tom (50).

Business rules

The student's name cannot be empty.

The score must be between 0 and 100.

Only students with scores of 50 or more are included in the report.

The normal policy keeps the original score.

The bonus policy adds 10 points, but the score cannot be higher than 100.

An empty list returns the message "No students found."

Invalid data is rejected.

Pipeline stages
FilterStudents selects students with scores of 50 or more. For example, Alex is not included because his score is 45, while Tom is included because his score is 50.

CalculateScores applies the selected policy to each student's score. With the bonus policy, John's score changes from 60 to 70.

CreateReport creates a text report with student names and scores. If the list is empty, it returns "No students found."

RunPipeline connects the three stages and runs them in order.

Two policies
Normal policy: score => score
Bonus policy: score => Math.Min(score + 10, 100)

Both policies use the same pipeline. The policy is passed as a Func<int, int> argument.

Expected results
Normal policy:
Anna: 85 points
Maria: 92 points
John: 60 points
Tom: 50 points

Bonus policy:
Anna: 95 points
Maria: 100 points
John: 70 points
Tom: 60 points



Alex and David are not included because their scores are below 50.

For an empty list, the program displays "No students found."

Tests
The test project is StudentPerformanceAnalyzer.Tests. It contains six automated tests:

Normal workflow.

Empty dataset.

Boundary value of 50.

Invalid input.

Comparison of the two policies.
