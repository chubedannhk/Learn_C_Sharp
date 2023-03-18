namespace DemoSession1_MVC.Models;

public class QuestionModel
{
    private List<Question> question;
    public QuestionModel()
    {
        question = new List<Question>()
        {
          new Question()
          {
              Id = 1,
              Content = "Tren long duoi long toi long lam 1, la cai gi?",
              Answers = new List<Answer>()
              {
                  new Answer()
                  {
                      Id = 1,
                      Content = "Long Mi",
                      IsCorrect = true,
                  },
                  new Answer()
                  {
                      Id = 2,
                      Content = "Long may",
                      IsCorrect = false,
                  },
                  new Answer()
                  {
                      Id = 3,
                      Content = "Long co",
                      IsCorrect = false,
                  },
                  new Answer()
                  {
                      Id = 1,
                      Content = "Long chim",
                      IsCorrect = false,
                  },
              }
          },
           new Question()
          {
              Id = 2,
              Content = "con cho co may chan",
              Answers = new List<Answer>()
              {
                  new Answer()
                  {
                      Id = 5,
                      Content = "2 chan",
                      IsCorrect = false,
                  },
                  new Answer()
                  {
                      Id = 6,
                      Content = "4 chan",
                      IsCorrect = true,
                  }
              }
          },
        };
    }
    public List<Question> findAll() { return question; }

    public bool isCorrect(int questionId, int answerId)
    {
        var ques = question.SingleOrDefault(q => q.Id == questionId);
        var answerIdCorrect = ques.Answers.SingleOrDefault(q => q.IsCorrect).Id;
        return answerIdCorrect == answerId;
    }
  
}
