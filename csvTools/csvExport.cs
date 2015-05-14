using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Jas.Utils.CSVTools {

    /// <summary>
    /// Trida provadi export dat z DataGridView do souboru ve formatu CSV.
    /// Upozorneni: Pokud zdrojovy text obsahuje znak Quote tak je nahrazen znakem ' (apostrof)
    /// </summary>
    public class CSVExport {

        /// <summary>
        /// Rika zda ze ma nahrazovat quote znak ze zdrojovem textu apostrofem
        /// </summary>
        public bool FilterQuote = true;

        /// <summary>
        /// Pokud je true tak se obsah bunky vzdy obali znakem Quote. V opacnem pripade se obaluje pouze pokud je to potreba.
        /// </summary>
        public bool AlwaysUseQuote = true;

        /// <summary>
        /// Provede export.
        /// </summary>
        /// <param name="filename">Nazev ciloveho souboru</param>
        /// <param name="delimiter">Oddelovac poli</param>
        /// <param name="quote">Oddelovat textu</param>
        /// <param name="skipRows">Prvnich X radku nebude exportovano</param>
        /// <param name="skipHidden">Neviditelne radky nebudou exportovany</param>
        /// <param name="dg">Grid ze ktereho se berou data</param>
        /// <param name="exportHeader">Zapise do souboru u hlavicku gridu</param>
        public void Export( string filename, char delimiter, char quote, int skipRows, bool skipHidden, DataGridView dg, bool exportHeader ) {

            ExportConfig c = new ExportConfig();
            c.FileName = filename;
            c.Delimiter = delimiter;
            c.Quote = quote;
            c.SkipRows = skipRows;
            c.SkipHidden = skipHidden;
            c.ExportHeader = exportHeader;
            c.Encoding = 1250;

            Export( c, dg );
        }

        /// <summary>
        /// Provadi export podle zadane konfigurace
        /// </summary>
        /// <param name="config">Konfigurace exportu</param>
        /// <param name="dg">Grid ze ktereho se berou data</param>
        public void Export( ExportConfig config, DataGridView dg ) {

            Encoding enc = Encoding.GetEncoding( config.Encoding );

            using ( StreamWriter sr = new StreamWriter( config.FileName, false, enc ) ) {

                if ( config.ExportHeader ) {
                    sr.WriteLine( getHeader( dg, config.Delimiter, config.Quote ) );
                }

                int skip = 0;
                foreach ( DataGridViewRow row in dg.Rows ) {
                    if ( skip < config.SkipRows ) {
                        skip++;
                        continue;
                    }
                    if ( config.SkipHidden && !row.Visible ) {
                        continue;
                    }
                    sr.WriteLine( getLine( row, config.Delimiter, config.Quote, config.SkipHidden, dg ) );
                }
                sr.Flush();
            }
        }

        /// <summary>
        /// Provede export se standarnim nastavenim:
        /// Delimiter = ;
        /// Quote = "
        /// SkipRows = 0
        /// SkipHidden = true
        /// ExportHeader = true
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="dg"></param>
        public void ExportDefault( string filename, DataGridView dg ) {
            Export( filename, ';', '"', 0, true, dg, true );
        }

        private string getHeader( DataGridView dg, char delimiter, char quote ) {
            StringBuilder sb = new StringBuilder();

            for ( int i = 0; i < dg.Columns.Count; i++ ) {
                DataGridViewColumn o = dg.Columns[i];

                if ( !o.Visible ) {
                    continue;
                }

                if ( shouldQuote( o.HeaderText ) ) {
                    sb.Append( quote );
                }

                sb.Append( filterText( o.HeaderText, quote ) );

                if ( shouldQuote( o.HeaderText ) ) {
                    sb.Append( quote );
                }

                if ( i < dg.Columns.Count - 1 ) {
                    sb.Append( delimiter );
                }

            }

            return sb.ToString();
        }

        private bool shouldQuote( string text ) {
            if ( AlwaysUseQuote ) {
                return true;
            }

            if ( text == null ) {
                return false;
            }
            else {
                return text.Contains( " " );
            }
        }

        private string getLine( DataGridViewRow row, char delimiter, char quote, bool skipHidden, DataGridView dg ) {
            StringBuilder sb = new StringBuilder();

            for ( int i = 0; i < row.Cells.Count; i++ ) {

                DataGridViewColumn col = dg.Columns[i];

                if ( !col.Visible ) {
                    continue;
                }

                object o = row.Cells[i].Value;

                string s = string.Empty;

                if ( o != null ) {
                    s = o.ToString();
                }

                if ( shouldQuote( s ) ) {
                    sb.Append( quote );
                }

                sb.Append( o != null ? filterText( s, quote ) : "" );

                if ( shouldQuote( s ) ) {
                    sb.Append( quote );
                }

                if ( i < row.Cells.Count - 1 ) {
                    sb.Append( delimiter );
                }

            }

            return sb.ToString();
        }

        /// <summary>
        /// Nahrazuje ve zdrojovem textu quote pomoci znaku ' (apostrof)
        /// </summary>
        /// <param name="text"></param>
        /// <param name="quote"></param>
        /// <returns></returns>
        private string filterText( string text, char quote ) {
            if ( FilterQuote ) {

                if ( text == null ) {
                    return "";
                }

                return text.Replace( quote, '\'' );

            }
            else {
                return text;
            }
        }

    }
}
