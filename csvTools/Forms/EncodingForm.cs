using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace Jas.Utils.CSVTools.Forms {
    public partial class EncodingForm : Form {

        public int SelectedEncoding { get; set; }

        public EncodingForm() {
            InitializeComponent();

            foreach ( var enc in Encoding.GetEncodings() ) {
                dgv.Rows.Add( enc.CodePage, enc.Name, enc.DisplayName );
            }
        }

        private void tbFilter_TextChanged( object sender, EventArgs e ) {
            string s = tbFilter.Text;

            if ( string.IsNullOrEmpty( s ) ) {
                showAll();
            }
            else {
                doFilter( removeAccent( s.ToLowerInvariant() ) );
            }

        }

        private void doFilter( string txt ) {

            foreach ( DataGridViewRow row in dgv.Rows ) {

                bool show = false;

                foreach ( DataGridViewCell cell in row.Cells ) {

                    string s = removeAccent( cell.Value.ToString().ToLowerInvariant());

                    if ( s.Contains( txt ) ) {
                        show = true;
                        break;
                    }

                }

                row.Visible = show;
            }

        }

        private void showAll() {
            foreach ( DataGridViewRow row in dgv.Rows ) {
                row.Visible = true;
            }
        }

        private void EncodingForm_Load( object sender, EventArgs e ) {
            tbFilter.Select();
        }

        private void tbFilter_KeyUp( object sender, KeyEventArgs e ) {
            if ( e.KeyCode == Keys.Escape ) {
                tbFilter.Text = string.Empty;
            }
        }

        private static string removeAccent( string s ) {
            s = s.Normalize( NormalizationForm.FormD );
            StringBuilder sb = new StringBuilder();

            for ( int i = 0; i < s.Length; i++ ) {
                if ( CharUnicodeInfo.GetUnicodeCategory( s[i] ) != UnicodeCategory.NonSpacingMark ) {
                    sb.Append( s[i] );
                }
            }

            return sb.ToString();
        }

        private void dgv_CellDoubleClick( object sender, DataGridViewCellEventArgs e ) {
            SelectedEncoding = int.Parse( dgv.Rows[e.RowIndex].Cells[0].Value.ToString() );
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

    }
}
