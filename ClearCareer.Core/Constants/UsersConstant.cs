namespace ClearCareer.Core.Constants
{
    public class UsersConstant
    {
        public class Login
        {
            public const string RequiredUsernameOrEmail = "Username or email is required!";

            public const string RequiredPassword = "Password is required!";
        }

        public class Register
        {
            public class Username
            {
                public const string Required = "Username is required and cannot contain empty characters!";

                public const string Length = "Username must be between 5 and 20 characters!";
            }

            public class Email
            {
                public const string Required = "Email is required!";

                public const string Invalid = "Enter valid email address!";
            }

            public class Password
            {
                public const string Required = "Password is required!";

                public const string Length = "Password must be between 8 and 20 characters!";
            }

            public class ConfirmPassword
            {
                public const string Required = "Confirm password is required!";

                public const string NotMatch = "Passwords do not match!";
            }
        }
    }
}
