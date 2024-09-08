namespace Electro_CleanArchitecture.Routing
{
    public class Router
    {
        public const string SignleRoute = "/{Id}";
        public const string root = "Api";
        public const string version = "V1";
        public const string Rule = root + "/" + version + "/";
        public static class ProductRouting
        {
            public const string Prefix = Rule + "Product";
            public const string List = Prefix + "/List";
            public const string GetByID = Prefix + SignleRoute;
            public const string Create = Prefix + "/Add";
            public const string Edit = Prefix + "/Update";
            public const string Delete = Prefix + "/Delete" + SignleRoute;
            public const string TopSelling = Prefix + "/TopSelling";
            public const string Paginated = Prefix + "/Paginated";
            public const string GetById = Prefix + SignleRoute;

        }
        public static class CartRouting
        {
            public const string Prefix = Rule + "Cart";
            public const string GetAllProducts = Prefix + "/GetAllProductsInCart";
            public const string GetByID = Prefix + SignleRoute;
            public const string AddProduct = Prefix + "/AddProductToCart";
            public const string RemoveProduct = Prefix + "/RemoveProductToCart";
            public const string Clear = Prefix + "/ClearCart";
            public const string InCreaseAmount = Prefix + "/InCreaseAmount";
            public const string DeCreaseAmount = Prefix + "/DeCreaseAmount";


        }
        public static class FavouriteListRouting
        {
            public const string Prefix = Rule + "FavouriteList";
            public const string GetAllProducts = Prefix + "/GetAllProductsInFavourite";
            public const string GetByID = Prefix + SignleRoute;
            public const string AddProduct = Prefix + "/AddProductToFavouriteLsit";
            public const string RemoveProduct = Prefix + "/RemoveProductToFavourtie";
            public const string Clear = Prefix + "/ClearFavouriteList";
   
        }
        public static class CategoryRouting
        {
            public const string Prefix = Rule + "Category";
            public const string List = Prefix + "/List";
            public const string GetByID = Prefix + SignleRoute;
            public const string Create = Prefix + "/Add";
            public const string Edit = Prefix + "/Update";
            public const string Delete = Prefix + "/Delete" + SignleRoute;
            public const string Paginated = Prefix + "/Paginated";
        }
        public static class UserRouting
        {
            public const string Prefix = Rule + "User";
            public const string List = Prefix + "/List";
            public const string Add = Prefix + "/Add";
            public const string Update = Prefix + "/Update";
            public const string GetById = Prefix + SignleRoute;
        }
        public static class ReviewRouting
        {
            public const string Prefix = Rule + "Review";
            public const string List = Prefix + "/List";
            public const string Add = Prefix + "/Add";
            public const string Update = Prefix + "/Update";
            public const string GetById = Prefix + SignleRoute;
            public const string Delete = Prefix + SignleRoute;

        }
    }
}