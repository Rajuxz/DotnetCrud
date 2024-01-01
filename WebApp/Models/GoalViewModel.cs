namespace WebApp.Models
{
    public class GoalViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DeadLine { get; set; }
        public Boolean IsAchieved { get; set; } = false;
    }
}
