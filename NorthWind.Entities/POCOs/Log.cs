namespace NorthWind.Entities.POCOs
{
    public class Log
    {
        public long Id { get; init; }
        public DateTime CreatedDate { get; init; }
        public string Description { get; init; }

        public Log(DateTime createdDate, string description) =>
            (CreatedDate, Description) = (createdDate, description);
        public Log(string description) : this(DateTime.Now, description) { }
    }
}
