using CommonWebAPI.Entities;

namespace CommonWebAPI.Persistence
{
    public class CommonDBContext
    {
        public List<CommonEntity> commonEntities { get; set; }
        public CommonDBContext() { 
        this.commonEntities = new List<CommonEntity>();
        }
    }
}
