using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using QuestionAndAnswer.Models;

namespace QuestionAndAnswer.Controllers
{
    [Authorize]
    public class QuestionsAndAnswerController : Controller
    {
        private QuestionAndAnswerDB db = new QuestionAndAnswerDB();

        // GET: QuestionsAndAnswer
        public ActionResult Index(int? page)
        {
            var questions = from q in db.Questions
                            select q;
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            questions = questions.OrderByDescending(q => q.QuestionCreateTime);
            return View(questions.ToPagedList(pageNumber, pageSize));
        }

        // GET: QuestionsAndAnswer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        public ActionResult MoreAnswer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return PartialView("AnswerListPartial", question.Answers);

        }

        [HttpPost]
        public ActionResult CreateAnswer([Bind(Include = "AnswerId, AnswerCreator, QuestionId, AnswerContent")] Answer answer)
        {
            if (ModelState.IsValid)
            {
                answer.AnswerTime = DateTime.Now;
                db.Answers.Add(answer);
                db.SaveChanges();
            }
            return RedirectToAction("Details", new { 
                id = answer.QuestionId });
        }

        // GET: QuestionsAndAnswer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuestionsAndAnswer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QuestionId, QuestionCreator, QuestionContent")] Question question)
        {
            ViewBag.Answers = new Answer();
            if (ModelState.IsValid)
            {
                question.QuestionCreateTime = DateTime.Now;
                db.Questions.Add(question);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(question);
        }

        // GET: QuestionsAndAnswer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: QuestionsAndAnswer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QuestionId,QuestionCreator,QuestionContent")] Question question)
        {
            question.QuestionCreateTime = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(question);
        }

        // GET: QuestionsAndAnswer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: QuestionsAndAnswer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Question question = db.Questions.Find(id);
            db.Questions.Remove(question);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
