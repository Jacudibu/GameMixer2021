using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Localization.Tables;

public static class LocalizationHelper
{
    [CanBeNull] private static StringTable _localizationTable;
        
    public static void Initialize(StringTable table)
    {
        _localizationTable = table;
    }
    
    public static string Get(string key)
    {
        return Get(key, new object[0]);
    }
    
    public static string Get(string key, params object[] args)
    {
        if (_localizationTable == null)
        {
            Debug.LogError("LocalizationHelper has not been initialized!");
            return key;
        }
        
        var entry = _localizationTable.GetEntry(key);
        if (entry == null)
        {
            Debug.LogWarning("Localization: Unable to find key " + key + " in localization table.");
            return key;
        }

        return entry.GetLocalizedString(args);
    }
}