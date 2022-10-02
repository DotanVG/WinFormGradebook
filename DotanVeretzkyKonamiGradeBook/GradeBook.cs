/*
*  
*  Thank you for viewing this code !
*  This is my first C# Windows Forms Project.
*  I've learned a lot and really enjoyed working on both the design and logic of this assignment.
*
*
*  "Take-Home-Assignment" Details:
* 
*  " We need an electronic grade book to read the scores of an individual student and then compute simple statistics from the scores.
*    The grades are entered as floating point numbers from 0 to 100, and the statistics should show us the highest grade,
*    the lowest grade, and the average grade. "
*   - The Project Manager
*   
*/




namespace DotanVeretzkyKonamiGradeBook
{
    public partial class GradeBook : Form
    {
        public GradeBook()
        {
            InitializeComponent();
        }

        // Actions upon clicking "Go" button

        private void goButton_Click(object sender, EventArgs e)
        {
// Save user grades input

            float mathScore = (float)mathScoreBox.Value;
            float scienceScore = (float)scienceScoreBox.Value;
            float englishScore = (float)englishScoreBox.Value;
            float historyScore = (float)historyScoreBox.Value;
            float geographyScore = (float)geographyScoreBox.Value;

// Calculate highest, lowest and average grade
            
            float[] gradesArray = {mathScore, scienceScore, englishScore, historyScore, geographyScore};
            string[] subjectsArray = {mathLabel.Text, scienceLabel.Text, englishLabel.Text, historyLabel.Text, geographyLabel.Text};
            float highestGrade = gradesArray[0];
            float lowestGrade = highestGrade;
            float averageGrade = 0;
            int highestGradeSubjectNumberInArrayPlaceholder = 0;
            int lowestGradeSubjectNumberInArrayPlaceholder = 0;

            for (int i = 0; i < gradesArray.Length; i++)
            {
                if (gradesArray[i] > highestGrade)
                {
                    highestGrade = gradesArray[i];
                    highestGradeSubjectNumberInArrayPlaceholder = i;
                }
                if (gradesArray[i] < lowestGrade)
                {
                    lowestGrade = gradesArray[i];
                    lowestGradeSubjectNumberInArrayPlaceholder = i;
                }
                averageGrade += gradesArray[i];

            }

            averageGrade = averageGrade / gradesArray.Length;
            string averageGradeString = averageGrade.ToString("0.00");

// Handle no input exception

            if (averageGrade != 0)
            {
// Print grades to read-only grade boxes

                highestGradeBox.Text = subjectsArray[highestGradeSubjectNumberInArrayPlaceholder] + " - " + highestGrade;
                lowestGradeBox.Text = subjectsArray[lowestGradeSubjectNumberInArrayPlaceholder] + " - " + lowestGrade;
                averageGradeBox.Text = "x̄ = " + averageGradeString;
            
// Add last registry to the list on the chalkboard

                string studentName = studentNamesList.Text;
                if (studentName != "")
                {
                    studentRecordsList.Items.Add(studentName + " | x̄ = " + averageGradeString);
                }
            }

            else
            {
                highestGradeBox.Text = "Please";
                lowestGradeBox.Text = "Enter";
                averageGradeBox.Text = "Grades";
            }
        }

// Clear all values in boxes when clicking the "Clear"/"Brush" button

        private void clearButton_Click(object sender, EventArgs e)
        {
            mathScoreBox.Value = 0;
            scienceScoreBox.Value = 0;
            englishScoreBox.Value = 0;
            historyScoreBox.Value = 0;
            geographyScoreBox.Value = 0;
            highestGradeBox.Text = null;
            lowestGradeBox.Text = null;
            averageGradeBox.Text = null;
        }

// Delete selected student record from the list

        private void deleteSelectedButton_Click(object sender, EventArgs e)
        {
            object selectedRecord = studentRecordsList.SelectedItem;
            studentRecordsList.Items.Remove(selectedRecord);
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            studentRecordsList.Items.Clear();
            clearButton_Click(sender, e);
            studentNamesList.Text = null;
        }

        private void addStudentButton_Click(object sender, EventArgs e)
        {
            if (addStudentBox.Text != "")
            {
                studentNamesList.Items.Add(addStudentBox.Text);
                addStudentBox.Text = "";
            }
        }

        private void deleteStudentButton_Click(object sender, EventArgs e)
        {
            object selectedStudent = studentNamesList.SelectedItem;
            studentNamesList.Items.Remove(selectedStudent);            
        }
    }
}