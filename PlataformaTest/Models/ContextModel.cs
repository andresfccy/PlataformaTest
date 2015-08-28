using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PlataformaTest.Models
{
    public class ContextModel : DbContext
    {
        public ContextModel()
            : base("name=DefaultConnection") { }

        public DbSet<QuestionModel> TestQuestions { get; set; }
        public DbSet<OptionModel> TestOptions { get; set; }
        public DbSet<AnswerModel> TestAnswers { get; set; }
    }

    public class TestDatabaseInitializer : CreateDatabaseIfNotExists<ContextModel>
    {
        protected override void Seed(ContextModel context)
        {
            base.Seed(context);

            var questions = new List<QuestionModel>();

            questions.Add(new QuestionModel
            {
                Title = "¿Cuándo se lanzó .NET por primera vez?",
                Options = (new OptionModel[]
                 {
                    new OptionModel { Title= "2000", IsCorrect= false },
                    new OptionModel { Title= "2001", IsCorrect= false },
                    new OptionModel { Title= "2002", IsCorrect= true },
                    new OptionModel { Title= "2003", IsCorrect= false }
                 }).ToList()
            });

            questions.ForEach(a => context.TestQuestions.Add(a));

            context.SaveChanges();
        }
    }

    public class TestDatabaseSeed
    {
        public void Seed(ContextModel context)
        {
            var questions = new List<QuestionModel>();

            questions.Add(new QuestionModel
            {
                Title = "¿Cuándo se lanzó .NET por primera vez?",
                Options = (new OptionModel[]
                 {
                    new OptionModel { Title= "2000", IsCorrect= false },
                    new OptionModel { Title= "2001", IsCorrect= false },
                    new OptionModel { Title= "2002", IsCorrect= true },
                    new OptionModel { Title= "2003", IsCorrect= false }
                 }).ToList()
            });

            questions.ForEach(a => context.TestQuestions.Add(a));

            context.SaveChanges();
        }
    }
}