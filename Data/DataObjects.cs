using LibrandriaMAUI.Models;

namespace LibrandriaMAUI.Data;

public class DataObjects
{
    public static List<Term> TermList = new List<Term>();
    public static List<Course> CourseList = new List<Course>();
    public static List<Assessment> AssessmentList = new List<Assessment>();
    
    public static List<Course> AllCourses = new List<Course>();
    public static List<Assessment> AllAssessments = new List<Assessment>();
    
    public static string? CurrentUser { get; set; }
    public static string? CurrentTerm { get; set; }
    public static string? CurrentCourse { get; set; }
    public static string? CurrentAssessment { get; set; }
}