# StudentPerformanceAnalyzer

Student:Tomiris Chekalin
Group:IT-2503

Input data
Each student has a name and a score from 0 to 100. The sample dataset contains six students:
Anna - 85
Alex - 45
Maria - 92
John - 60
David - 30
Tom - 50

Business rules

The student's name cannot be empty.

The score must be between 0 and 100.

Only students with scores of 50 or more are included in the report.

The normal policy keeps the original score.

The bonus policy adds 10 points, but the final score cannot be higher than 100.

An empty list returns "No students found."

Invalid data is rejected.

Pipeline stages

FilterStudents
Input: a list of students.
Output: a new list of students with scores of 50 or more.
Example: Alex has 45 points and is excluded. Tom has 50 points and is included.

CalculateScores
Input: a list of selected students and a Func<int, int> policy.
Output: a new list with calculated scores.
Example: John's score changes from 60 to 70 when the bonus policy is used.

CreateReport
Input: a list of students with calculated scores.
Output: a text report with student names and scores.
Example: if the list is empty, the method returns "No students found."

RunPipeline connects these three stages. It validates the input, filters students, calculates scores, and creates the report.

Policies
Normal policy: score => score
Bonus policy: score => Math.Min(score + 10, 100)

Both policies use the same pipeline. The policy is passed to the calculation method as a Func<int, int> delegate.

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

Alex and David are excluded because their scores are below 50.

Empty dataset:
No students found.

Invalid data:
A student with a score of -5 is rejected.

<img width="1221" height="470" alt="image" src="https://github.com/user-attachments/assets/f09f40fc-95ab-4d01-b44c-71c87923845c" />


Tests
The test project has six automated tests:

NormalWorkflowTest checks that the pipeline returns the expected report and excludes students below 50.

EmptyDatasetTest checks that an empty list returns "No students found."

BoundaryValueTest checks that a score of exactly 50 is included.

InvalidInputTest checks that invalid scores are rejected.

TwoPoliciesTest checks that the normal and bonus policies produce different results.

OriginalDataRemainsUnchangedTest checks that the original student scores and list remain unchanged.

Latest test outcome
The six tests passed in the previous test run. Run dotnet test again before submission and update this section if the result changes.
<img width="1525" height="528" alt="image" src="https://github.com/user-attachments/assets/baa25ba8-8a25-4e6a-93ff-5c5e1cd931d6" />

In conclusion, I created a Student Performance Analyzer using C#. The program processes student scores with LINQ and pipelines. I also added different policies and checked how the program handles empty datasets and invalid data. I created unit tests to check the main functions. All 6 tests passed successfully. This project helped me understand functional programming and unit testing better.

