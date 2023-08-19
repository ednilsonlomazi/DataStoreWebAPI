namespace CommonWebAPI.Entities
{
    public class CommonEntity
    {
        public CommonEntity()
        {
            Speakers = new List<CommonEntitySpeaker> { };
            IsUp = false;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string IpAddress { get; set; }
        public string MacAddress { get; set; }
        public bool IsUp { get; set; }
        public List<CommonEntitySpeaker> Speakers { get; set; }
    
        public void Update(string Name, string IpAddress, string MacAddress, bool IsUp)
        {
            this.Name = Name;
            this.IpAddress = IpAddress;
            this.MacAddress = MacAddress;
            this.IsUp = IsUp;

        }

        public void Delete()
        {
            this.IsUp = false;
        }
    }
}
