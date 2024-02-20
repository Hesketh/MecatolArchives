namespace Hesketh.MecatolArchives.Website.Helpers
{
    public static class ColourStyleHelper
    {
        public static string GetUnderlineStyle(string hex)
        {
            return $"text-decoration: underline; text-decoration-color: {hex}; text-underline-offset: 5px;";
        }

        public static string GetBackgroundStyle(string hex)
        {
            return $"background: {hex};";
        }
    }
}
