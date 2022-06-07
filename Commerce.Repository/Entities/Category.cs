namespace Commerce.Repository.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }
        public int ParentId { get; set; }
        public int ManagementId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
