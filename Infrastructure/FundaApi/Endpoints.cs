namespace Infrastructure.FundaApi
{
    public class Endpoints
    {
        private const string Feeds = "feeds";
        public class Aanbod
        {
            private const string AanbodService = "Aanbod.svc";
            public static string GetAll(string key, string SearchParameter, int page, int pageSize) =>
                $"{Feeds}/{AanbodService}/{ResponceType.Json}/{key}/?type=koop&zo=/{SearchParameter}/&page={page}&pagesize={pageSize}&=is: ";
        }
    }
    public enum ResponceType { Json, Xml }
}