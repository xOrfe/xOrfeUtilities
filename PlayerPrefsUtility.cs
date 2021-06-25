using UnityEngine;

namespace xOrfe.Utilities
{
    public static class PlayerPrefsUtility
    {

        public static void SetString(string key, string value)
        {
            PlayerPrefs.SetString(key, value);
            PlayerPrefs.Save();
        }

        public static void SetInt(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
            PlayerPrefs.Save();
        }

        public static void SetFloat(string key, float value)
        {
            PlayerPrefs.SetFloat(key, value);
            PlayerPrefs.Save();
        }

        public static void SetBool(string key, bool value)
        {
            int intValue = 0;
            if (value) intValue = 1;
            PlayerPrefs.SetInt(key, intValue);
            PlayerPrefs.Save();
        }
        
        public static string getString(string key)
        {
            return PlayerPrefs.GetString(key);
        }

        public static float GetFloat(string key)
        {
            return PlayerPrefs.GetFloat(key);
        }

        public static int GetInt(string key)
        {
            return PlayerPrefs.GetInt(key);
        }

        public static bool GetBool(string key)
        {
            int intValue = PlayerPrefs.GetInt(key);
            if (intValue >= 1) return true;
            return false;
        }

        public static bool HasKey(string key)
        {
            return PlayerPrefs.HasKey(key);
        }


    }
}
