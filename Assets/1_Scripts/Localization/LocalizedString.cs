namespace Localization
{
    public class LocalizedString
    {
        public readonly string english;
        public readonly string german;

        public LocalizedString(string english, string german)
        {
            this.english = english;
            this.german = german;
        }
    }
}