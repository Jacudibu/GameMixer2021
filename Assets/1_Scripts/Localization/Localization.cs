using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using RedScarf.EasyCSV;
using UnityEngine;

namespace Localization
{
    public static class Localization
    {
        public static bool IsInitialized { get; private set; }

        private static readonly Dictionary<string, LocalizedString> Data = new Dictionary<string, LocalizedString>();
        private static string _friendFirstName = "FriendFirstName";

        public static Language SelectedLanguage { get; private set; } = Language.English;

        private static void Initialize()
        {
            var csvFile = Resources.LoadAll<TextAsset>("LatestLocalizationDump").Single();
            var test = CsvHelper.Create("Localization", csvFile.text);
        
            foreach (var row in test.RawDataList)
            {
                if (string.IsNullOrEmpty(row[0]))
                {
                    continue;
                }
            
                Data[row[0]] = new LocalizedString(row[1], row[2]);
            }

            IsInitialized = true;
        }

        [NotNull]
        public static string Get([NotNull] string key)
        {
            if (!Data.TryGetValue(key, out var result))
            {
                return key;
            }

            return result.Get(SelectedLanguage)
                .Replace("{FriendFirstName}", _friendFirstName);
        }

        public static void Initialize(string friendName)
        {
            if (!IsInitialized)
            {
                Initialize();
            }
            
            _friendFirstName = friendName;
        }

        public static void SetLanguage(Language language)
        {
            SelectedLanguage = language;
        }
    }
}