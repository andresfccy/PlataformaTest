using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlataformaTest.Models;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Threading;
using System.Web.Http.Description;

namespace PlataformaTest.Controllers
{
    [Authorize]
    public class TestController : ApiController
    {
        private ContextModel db = new ContextModel();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }

            base.Dispose(disposing);
        }

        // GET api/Trivia
        [ResponseType(typeof(QuestionModel))]
        public async Task<IHttpActionResult> Get()
        {
            var userId = User.Identity.Name;

            QuestionModel nextQuestion = await this.NextQuestionAsync(userId);

            if (nextQuestion == null)
            {
                return this.NotFound();
            }

            return this.Ok(nextQuestion);
        }

        // POST api/Trivia
        [ResponseType(typeof(AnswerModel))]
        public async Task<IHttpActionResult> Post(AnswerModel answer)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            answer.UserId = User.Identity.Name;

            var isCorrect = await this.StoreAsync(answer);
            return this.Ok<bool>(isCorrect);
        }

        // Helpers
        // Método que retorna la siguiente pregunta para un usuario definido.
        private async Task<QuestionModel> NextQuestionAsync(string userId)
        {
            var lastQuestionId = await this.db.TestAnswers
                .Where(a => a.UserId == userId)
                .GroupBy(a => a.QuestionId)
                .Select(g => new { QuestionId = g.Key, Count = g.Count() })
                .OrderByDescending(q => new { q.Count, QuestionId = q.QuestionId })
                .Select(q => q.QuestionId)
                .FirstOrDefaultAsync();

            var questionsCount = await this.db.TestQuestions.CountAsync();

            var nextQuestionId = (lastQuestionId % questionsCount) + 1;
            return await this.db.TestQuestions.FindAsync(CancellationToken.None, nextQuestionId);
        }

        private async Task<bool> StoreAsync(AnswerModel answer)
        {
            this.db.TestAnswers.Add(answer);

            await this.db.SaveChangesAsync();
            var selectedOption = await this.db.TestOptions.FirstOrDefaultAsync(o => o.Id == answer.OptionId
                && o.QuestionId == answer.QuestionId);

            return selectedOption.IsCorrect;
        }
    }
}

