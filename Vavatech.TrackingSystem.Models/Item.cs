namespace Vavatech.TrackingSystem.Models
{
    public abstract class Item : BaseEntity
    {
        public string Name { get; set; }

        public Item(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return $"ID: {Id} Nazwa: {Name}";
        }

        public virtual decimal Calculate()
        {
            return 0;
        }
    }
}
