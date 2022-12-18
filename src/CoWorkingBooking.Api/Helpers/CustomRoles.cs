namespace CoWorkingBooking.Api.Helpers
{
    public class CustomRoles
    {
        private const string ADMIN = "Admin";
        private const string USER = "User";

        public const string USER_ROLE = USER + "," + ADMIN_ROLE;
        public const string ADMIN_ROLE = ADMIN;
    }
}
