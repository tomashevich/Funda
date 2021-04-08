namespace Infrastructure.FundaApi
{
    public class Endpoints
    {
        private enum ResponceType { Json, Xml }

       // private const string BaseUrl = "http://partnerapi.funda.nl";

        private const string Feeds = "feeds";
        public class Aanbod
        {
            private const string AanbodService = "Aanbod.svc";
            public static string GetAll(string key, string City, int page, int pageSize) =>
                $"{Feeds}/{AanbodService}/{ResponceType.Json}/{key}/?type=koop&zo=/{City}/&page={page}&pagesize={pageSize}&=is: ";
           // public static string CreatePost => PostsPath;
           // public static string GetPostById(int postId) => $"{PostsPath}/{postId}";
            //public static string GetCommentsForPost(int postId) => $"{PostsPath}/{postId}/comments";
        }
    }
}