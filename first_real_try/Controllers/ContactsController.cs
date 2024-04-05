using first_real_try.Models;
using Microsoft.AspNetCore.Mvc;

namespace first_real_try.Controllers
{
    public class ContactsController : Controller
    {
		private readonly FeedbacksContext context;

		public ContactsController(FeedbacksContext context)
        {
			this.context = context;
		}

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost] //not via direct link
        public IActionResult Check(Feedback feedback)
        {
            if(ModelState.IsValid)
            {
                context.Feedbacks.Add(feedback);
                context.SaveChanges();
                return Redirect("/contacts/show");
            }

            return View("Index");
        }

        public IActionResult Show()
        {
            var feedbacks = context.Feedbacks.OrderByDescending(x => x.Id).ToList();
            return View(feedbacks);
        }

        public IActionResult Edit(int id)
        {
            var feedback = context.Feedbacks.Find(id);

            if (feedback == null) 
            {
                return RedirectToAction("Show", "Products");
            }

            return View(feedback);
        }

        [HttpPost]
		public IActionResult EditCheck(Feedback feedback, int id)
		{
			if (ModelState.IsValid)
			{
                var fb = context.Feedbacks.Find(id);
                if(fb == null)
                {
                    return Redirect("/contacts/show");
                }
                fb.Name = feedback.Name;
                fb.Surname = feedback.Surname;
                fb.Age = feedback.Age;
                fb.Email = feedback.Email;
                fb.Message = feedback.Message;
                context.SaveChanges();
				return Redirect("/contacts/show");
			}

			return Redirect("/contacts/show");
		}

		public IActionResult Delete(int id)
        {
			var fb = context.Feedbacks.Find(id);
			if (fb == null)
			{
				return Redirect("/contacts/show");
			}
            context.Feedbacks.Remove(fb);
            context.SaveChanges();
            return Redirect("/contacts/show");
		}
    }
}
