using System.ComponentModel.DataAnnotations;

namespace first_real_try.Models
{
	public class Feedback
	{
        public int Id { get; set; }

		[Display(Name = "Your name:")]
		[Required(ErrorMessage = "Your name is required")]
		public string Name { get; set; } = "";

		[Display(Name = "Your surname:")]
		[Required(ErrorMessage = "Your surname is required")]
		public string Surname { get; set; } = "";

		[Display(Name = "Your age:")]
		[Required(ErrorMessage = "Your age is required")]
		public int Age { get; set; }

		[Display(Name = "Your email:")]
		[Required(ErrorMessage = "Your email is required")]
		public string Email { get; set; } = "";

		[Display(Name = "Your message:")]
		[Required(ErrorMessage = "Your message is required")]
		[StringLength(30, ErrorMessage = "Your message is too big (30 symbols max)")]
		public string Message { get; set; } = "";
	}
}
