using System.Text.Json.Serialization;

namespace PatikaSurvivor.Entities
{
    public class CategoryEntity : BaseEntity
    {
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<CompetitorEntity> Competitors { get; set; }
    }
}
