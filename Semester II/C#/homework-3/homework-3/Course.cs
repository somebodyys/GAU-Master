namespace homework_3;

public class Course
{
    private List<string> subjectList;

    public Course()
    {
        subjectList = new List<string>();
    }

    public void AddSubject(string subject)
    {
        subjectList.Add(subject);
    }

    public void PrintSubjects()
    {
        Console.WriteLine("Subjects in the course:");
        foreach (string subject in subjectList)
        {
            Console.WriteLine(subject);
        }
    }
}