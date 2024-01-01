namespace WebApp.Models.Domain
{
    public class GoalModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get;set; }
        public DateTime DeadLine { get; set; }
        public Boolean IsAchieved { get; set; } =  false;
    }
}
