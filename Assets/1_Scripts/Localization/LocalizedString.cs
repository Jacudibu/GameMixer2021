using System;

namespace Localization
{
    public class LocalizedString
    {
        private readonly string _english;
        private readonly string _german;

        public LocalizedString(string english, string german)
        {
            _english = english;
            _german = german;
        }

        public string Get(Language language)
        {
            return language switch
            {
                Language.English => _english,
                Language.German => _german,
                _ => throw new ArgumentOutOfRangeException(nameof(language), language, "Language not implemented!")
            };
        }
    }
}