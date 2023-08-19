namespace CommonWebAPI.Entities
{
    public class CommonEntitySpeaker
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string MacAddress { get; set; }

        public bool IsUp { get; set; }
    }
}