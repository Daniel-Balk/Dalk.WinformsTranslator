using Dalk.WinformsTranslator.Stash;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Dalk.WinformsTranslator
{
    public class TranslatedForm : Form
    {
        public TranslatedForm()
        {
        }
        protected override void OnControlAdded(ControlEventArgs e)
        {
            e.Control.AddTranslations();
            base.OnControlAdded(e);
        }
    }

    public static class TranslationHelper
    {
        public static Control AddTranslations(this Control c)
        {
            bool add = false;
            try
            {
                if (c.Get<bool>("translating"))
                    add = false;
                else add = true;
            }
            catch (Exception)
            {
                add = true;
            }
            if (add)
            {
                c.ControlAdded += new ControlEventHandler((s, e) => e.Control.AddTranslations());
                var tu = new EventHandler((s, e) =>
                {
                    var d = c.Text.Trim().TrimEnd();
                    if (d.StartsWith("#"))
                    {
                        var id = d.Remove(0, 1);
                        c.Set("last_id",id);
                        var text = TranslationManager.Get(id);
                        if (text != null)
                            c.Text = text;
                    }
                });
                c.TextChanged += tu;
                tu?.Invoke(null, EventArgs.Empty);
                TranslationManager.CurrentLanguageChanged += () =>
                {
                    try
                    {
                        var id = c.Get<string>("last_id");
                        if (id != null)
                        {
                            var text = TranslationManager.Get(id);
                            if (text != null)
                                c.Text = text;
                        }
                    }
                    catch(Exception) { }
                };
                c.Set("translating", true);
            }
            return c;
        }
    }
    
    namespace Stash
    {
        internal static class ControlStash
        {
            private static Dictionary<Control, Dictionary<Type, Dictionary<string, object>>> stash = new Dictionary<Control, Dictionary<Type, Dictionary<string,object>>>();
            public static T Get<T>(this Control c, string name)
            {
                return (T)stash[c][typeof(T)][name];
            }
            public static void Set<T>(this Control c, string name, T t)
            {
                if (!stash.ContainsKey(c))
                    stash[c] = new Dictionary<Type, Dictionary<string, object>>();
                if (!stash[c].ContainsKey(typeof(T)))
                    stash[c][typeof(T)] = new Dictionary<string, object>();
                stash[c][typeof(T)][name] = t;
            }
        }
    }
}
