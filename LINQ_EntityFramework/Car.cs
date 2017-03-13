namespace LINQ_EntityFramework
{
    public class Car
    {
        public int CarId { get; set; }
        public Color Color { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }


        //knows by convention that this is a Foreign Key
        public int? PersonId { get; set; }

        //Navigation Property (by default lazy loads Person on access)..virtual required
        public virtual Person Person { get; set; }
    }
}