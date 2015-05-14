using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Jas.Utils.CSVTools.Forms {
    
    public partial class SettingsForm : Form {

        public ParserConfig Config {
            get {
                ParserConfig c = new ParserConfig();

                c.Delimiter = tbDelimiter.Text[0];
                c.Encoding = int.Parse( tbEncoding.Text );
                c.Quote = tbQuote.Text[0];
                c.SkipRows = (int)nudSkipRows.Value;

                return c;
            }
            set {

                tbDelimiter.Text = value.Delimiter.ToString();
                tbEncoding.Text = value.Encoding.ToString();
                tbQuote.Text = value.Quote.ToString();
                nudSkipRows.Value = value.SkipRows;

            }
        }
        
        public SettingsForm() {
            InitializeComponent();
        }

        /// <summary>
        /// Vraci platny config nebo NULL (pokud uzivatel formular nepotvrdi).
        /// </summary>
        /// <returns></returns>
        public static ParserConfig GetConfig() {

            using ( SettingsForm fr = new SettingsForm() ) {

                if ( fr.ShowDialog() == DialogResult.OK ) {
                    return fr.Config;
                }

            }

            return null;
        }

        public static ParserConfig GetConfig(ParserConfig currentConfig) {

            using ( SettingsForm fr = new SettingsForm() ) {

                fr.Config = currentConfig;

                if ( fr.ShowDialog() == DialogResult.OK ) {
                    return fr.Config;
                }

            }

            return null;
        }

        private void bEncodingHelp_Click( object sender, EventArgs e ) {
            
            var fr = new EncodingForm();

            if ( fr.ShowDialog() == System.Windows.Forms.DialogResult.OK ) {
                tbEncoding.Text = fr.SelectedEncoding.ToString();
            }
        }
    }
}
