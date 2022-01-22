using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dalk.WinformsTranslator
{
    public static class TranslationManager
    {
        internal static Dictionary<string, Dictionary<string,string>> Translations { get; set; } = new Dictionary<string, Dictionary<string, string>>();
        internal static string CurrentLanguage { get; set; } = "en_us";
        internal static event Action CurrentLanguageChanged;
        public static string Get(string id)
        {
            if(!Translations.ContainsKey(CurrentLanguage))
                return null;
            else if (!Translations[CurrentLanguage].ContainsKey(id))
                return null;
            return Translations[CurrentLanguage][id];
        } 

        public static void Set(string culture, Dictionary<string, string> translation)
        {
            Translations[culture] = translation;
        }

        public static void SetLanguage(string culture)
        {
            CurrentLanguage = culture;
            CurrentLanguageChanged?.Invoke();
        }
    }
}
