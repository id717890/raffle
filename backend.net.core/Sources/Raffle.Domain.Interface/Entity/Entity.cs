namespace Raffle.Domain.Interface.Entity
{
    public abstract class Entity
    {
        public string Id { get; set; }
        public bool IsDeleted { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var objCast = obj as Entity;

            if (objCast != null)
            {
                return objCast.Id.Equals(Id);
            }

            return ReferenceEquals(obj, this);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
