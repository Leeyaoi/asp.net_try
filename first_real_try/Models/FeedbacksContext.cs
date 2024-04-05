using Microsoft.EntityFrameworkCore;

namespace first_real_try.Models
{
	public class FeedbacksContext : DbContext
	{
        public DbSet<Feedback> Feedbacks { get; set; }

        public FeedbacksContext(DbContextOptions options) : base(options) { }

    }
}
