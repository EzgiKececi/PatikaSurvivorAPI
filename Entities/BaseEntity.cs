namespace PatikaSurvivor.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            ModifiedDate = DateTime.Now;
            CreatedDate = DateTime.Now;
        }
        public int Id { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
