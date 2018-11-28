namespace Raffle.Api.Helpers
{
    public static class Constants
    {
        public const string StandartRole = "Participant";
        public const string Admin = "Superuser";

        public static class Strings
        {
            public static class JwtClaimIdentifiers
            {
                public const string Rol = "rol", Id = "id";
            }

            public static class JwtClaims
            {
                public const string ApiAccess = "api_access";
            }
        }
    }
}
