namespace Thread_Task_AwaitAsync.Domain.Entities
{
    public class Users
    {
        public int userId { get; set; }
        public int Id { get; set; }
        public string Body { get; set; }
        public string Title { get; set; }
        public override string ToString()
        {
            return $"Id : {Id}, userId : {userId}, Body : {Body}, Title : {Title}";
        }
    }
}
