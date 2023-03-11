namespace DemoSession1_MVC.Models;

public class CertModel
{
    public List<Cert> findAll()
    {
        return new List<Cert>()
        {
            new Cert() {Id=1, Name="Cert 1"},
            new Cert() {Id=2, Name="Cert 2"},
            new Cert() {Id=3, Name="Cert 3"},
            new Cert() {Id=4, Name="Cert 4"},
            new Cert() {Id=5, Name="Cert 5"}
        };
    }
}
