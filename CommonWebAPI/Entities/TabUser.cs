namespace CommonWebAPI.Entities
{
    public class TabUser
    {
        public Guid Id { get; set; }
        public Guid NodeId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

    }
}