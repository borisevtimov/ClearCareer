namespace ClearCareer.Core.Constants
{
    public class OffersConstant
    {
        public class Image
        {
            public const string DefaultImageName = "default_job.png";
        }

        public class Title
        {
            public const string Required = "Title is required!";

            public const string Length = "Title must be between 1 and 80 characters!";
        }

        public class Categories
        {
            public const string Required = "Categories are required!";
        }

        public class Description
        {
            public const string Required = "Description is required!";

            public const string MinLength = "Description must be at least 5 characters!";
        }
    }
}
