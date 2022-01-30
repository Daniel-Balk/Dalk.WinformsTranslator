using Dalk.WinformsTranslator.Stash;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public static Component AddTranslations(this Component p)
        {
            bool add = false;
            try
            {
                if (p.Get<bool>("translating"))
                    add = false;
                else add = true;
            }
            catch (Exception)
            {
                add = true;
            }
            if (add)
            {
                void MenItem(ToolStripItem i)
                {
                    var tu = new EventHandler((s, e) =>
                    {
                        var d = i.Text.Trim().TrimEnd();
                        if (d.StartsWith("#"))
                        {
                            var id = d.Remove(0, 1);
                            i.Set("last_id", id);
                            var text = TranslationManager.Get(id);
                            if (text != null)
                                i.Text = text;
                        }
                    });
                    i.TextChanged += tu;
                    tu?.Invoke(null, EventArgs.Empty);
                    TranslationManager.CurrentLanguageChanged += () =>
                    {
                        try
                        {
                            var id = i.Get<string>("last_id");
                            if (id != null)
                            {
                                var text = TranslationManager.Get(id);
                                if (text != null)
                                    i.Text = text;
                            }
                        }
                        catch (Exception) { }
                    };
                    i.Set("translating", true);

                    p = i;
                }
                if (p is ToolStripItem j)
                {
                    MenItem(j);
                }
                else if(p is ToolStripMenuItem k)
                {
                    MenItem(k);
                }
                else if (p is Control c)
                {
                    if (c is MenuStrip m)
                    {
                        foreach (ToolStripItem v in m.Items)
                        {
                            v.AddTranslations();
                        }
                        m.ItemAdded += (sender, args) => args.Item.AddTranslations();
                    }
                    c.ControlAdded += new ControlEventHandler((s, e) => e.Control.AddTranslations());
                    var tu = new EventHandler((s, e) =>
                    {
                        var d = c.Text.Trim().TrimEnd();
                        if (d.StartsWith("#"))
                        {
                            var id = d.Remove(0, 1);
                            c.Set("last_id", id);
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
                        catch (Exception) { }
                    };
                    c.Set("translating", true);

                    p = c;
                }
            }
            return p;
        }
    }
    
    namespace Stash
    {
        internal static class ControlStash
        {
            private static Dictionary<Component, Dictionary<Type, Dictionary<string, object>>> stash = new Dictionary<Component, Dictionary<Type, Dictionary<string,object>>>();
            public static T Get<T>(this Component c, string name)
            {
                return (T)stash[c][typeof(T)][name];
            }
            public static void Set<T>(this Component c, string name, T t)
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
