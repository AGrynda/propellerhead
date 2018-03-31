namespace propellerhead.Queries
{
    public class GetCustomersQuery : IQuery
    {
        public string Search { get; set; }
        public string OrderBy { get; set; }
    }
}
