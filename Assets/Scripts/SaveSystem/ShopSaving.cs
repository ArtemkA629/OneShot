using UnityEngine;

public static class ShopSaving
{
    public static int GetInt(string intName)
    {
        return PlayerPrefs.GetInt(intName);
    }

    public static string GetString(string stringName)
    {
        return PlayerPrefs.GetString(stringName);
    }

    public static void SaveInt(string intName, int intValue)
    {
        PlayerPrefs.SetInt(intName, intValue); 
    }

    public static void SaveString(string stringName, string stringValue)
    {
        PlayerPrefs.SetString(stringName, stringValue);
    }

    public static bool KeyIsNull(string key)
    {
        return !PlayerPrefs.HasKey(key);
    }
}
