namespace DemoSession1_MVC.Models;

public class LanguageModel
{
    public List<Language> findAll()
    {
        return new List<Language>()
        {
            new Language() {Id=1, Name="Vietnamese"},
            new Language() {Id=2, Name="Japanese"},
            new Language() {Id=3, Name="French"},
            new Language() {Id=4, Name="Spanish"},
            new Language() {Id=5, Name="Korean"}
        };
    }
}
