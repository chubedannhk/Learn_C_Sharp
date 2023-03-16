namespace DemoSession1_MVC.Models;

public class Question
{
    public int Id { get; set; }
    public string Content { get; set; }
    public List<Answer> Answers { get; set; }
}
