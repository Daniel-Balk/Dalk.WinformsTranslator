using Dalk.WinformsTranslator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tests
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.AddTranslations();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "#title";
            msToolStripMenuItem.AddTranslations();
        }

        private void goGer_Click(object sender, EventArgs e)
        {
            TranslationManager.SetLanguage("de_de");
        }

        private void goEng_Click(object sender, EventArgs e)
        {
            TranslationManager.SetLanguage("en_us");
        }
    }
}