using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Localization.Tables;

public static class LocalizationHelper
{
    [CanBeNull] private static StringTable _localizationTable;
    public static bool IsInitialized { get; private set; }    
    
    public static void Initialize(StringTable table)
    {
        _localizationTable = table;
        IsInitialized = true;
    }
    
    private static readonly SmartData SmartData = new SmartData();
    public static void SetFriendFirstName(string name)
    {
        SmartData.FriendFirstName = name;
    }
    
    public static string Get(string key)
    {
        return Get(key, SmartData);
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
            Debug.LogWarning("Localization: Unable to find key " + key + " in " + _localizationTable.name + ".");
            return "{?" + key + "}";
        }

        entry.IsSmart = true;
        return entry.GetLocalizedString(args);
    }
}
[SuppressMessage("ReSharper", "InconsistentNaming")]
public class SmartData
{
    public string FriendFirstName = "FriendFirstName";
}