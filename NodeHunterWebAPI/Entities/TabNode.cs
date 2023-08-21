namespace NodeHunterWebAPI.Entities
{
    public class TabNode
    {
        public TabNode()
        {
            this.Users = new List<TabUser> { };
            this.IsUp = false;
            this.IsDeleted = false;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string IpAddress { get; set; }
        public string MacAddress { get; set; }
        public bool IsUp { get; set; }
        public bool IsDeleted { get; set; }
        public List<TabUser> Users { get; set; }
    
        public void Update(string Name, string IpAddress, string MacAddress, bool IsUp, bool IsDeleted)
        {
            this.Name = Name;
            this.IpAddress = IpAddress;
            this.MacAddress = MacAddress;
            this.IsUp = IsUp;
            this.IsDeleted = IsDeleted;

        }

        public void Delete()
        {
            this.IsDeleted = true;
        }
    }
}
