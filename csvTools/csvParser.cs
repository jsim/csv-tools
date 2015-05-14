 using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Jas.Utils.CSVTools {

    /// <summary>
    /// Trida provadi parsovani CSV souboru.
    /// Pomoci delegata se napoji event ktery se vola pro kazdy uspesne naparsovany radek.
    /// </summary>
    public class CSVParser {
        
        public delegate void IRowComplete( string[] row );

        /// <summary>
        /// Zde se napoji obsluha ktere bude zpracovavat naparsovane radky.
        /// </summary>
        public event IRowComplete OnRowComplete;

        /// <summary>
        /// Ve vlakne otevre souboru a zacne provadet parsovani radku.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="delimiter"></param>
        /// <param name="quote"></param>
        /// <param name="skipRows"></param>
        /// <param name="rowsToProcess"></param>
        public void Parse( string fileName, char delimiter, char quote, int skipRows, int rowsToProcess ) {
            ParserConfig pc = ParserConfig.GetDefault();

            pc.FileName = fileName;
            pc.Delimiter = delimiter;
            pc.Quote = quote;
            pc.SkipRows = skipRows;
            pc.Thread = false;
            pc.RowsToProcess = rowsToProcess;
            
            doParse( pc );
        }

        /// <summary>
        /// Provadi parsovani podle zadaneho nastevni.
        /// </summary>
        /// <param name="config"></param>
        public void Parse( ParserConfig config ) {
            doParse( config );
        }

        /// <summary>
        /// Provadi parsovani s defaultnim nastavenim.
        /// Delimiter = ;
        /// Quote = "
        /// SkipRows = 0
        /// RowsToProcess = 0 (zde ve vyznamu zpracovat VSECHNY radky)
        /// </summary>
        /// <param name="fileName"></param>
        public void ParseDefault( string fileName ) {
            Parse( fileName, ';', '"', 0, 0 );
        }

        private void doParse( object config ) {
            ParserConfig pc = (ParserConfig)config;

            if ( !File.Exists( pc.FileName ) || OnRowComplete == null ) {
                return;
            }

            try {
                int row = -1;
                int wantCount = 10;
                string quoteStr = string.Concat( pc.Quote );
                string s = null;
                char[] separator = new char[] { pc.Delimiter };

                Encoding enc = Encoding.GetEncoding( pc.Encoding );

                using ( StreamReader sr = new StreamReader( pc.FileName, enc ) ) {
                    while ( ( s = sr.ReadLine() ) != null ) {
                        row++;
                        if ( row < pc.SkipRows ) {
                            continue;
                        }

                        if ( pc.RowsToProcess > 0 && row == pc.RowsToProcess ) {
                            break;
                        }

                        string[] buf = s.Split( separator );
                        if ( buf.Length != wantCount ) {
                            buf = deepAnalyze( s, pc.Delimiter, pc.Quote );
                        }

                        cleanBuf( ref buf, quoteStr );

                        OnRowComplete( buf );
                    }
                }
            } catch ( Exception ex ) {
                MessageBox.Show( string.Concat( "CSVParserException : ", ex.Message )  );
            }
        }

        private string[] deepAnalyze( string s, char delimiter, char quote ) {
            bool inQuote = false;
            StringBuilder buf = new StringBuilder();
            List<string> list = new List<string>();
            foreach ( char c in s ) {
                if ( c == quote ) {
                    inQuote = !inQuote;
                }

                // 123,"567",345,"abc,def",ghi
                if ( c == delimiter ) {
                    if ( !inQuote ) {
                        list.Add( buf.ToString() );
                        buf = new StringBuilder();
                    }
                    else {
                        buf.Append( c );
                    }
                }
                else {
                    if ( c != quote ) {
                        buf.Append( c );
                    }
                }
            }

            if ( buf.Length > 0 ) {
                list.Add( buf.ToString() );
            }

            return list.ToArray();
        }

        private void cleanBuf( ref string[] buf, string quote ) {
            for ( int i = 0; i < buf.Length; i++ ) {
                string s = buf[i];
                if ( s.StartsWith( quote ) && s.EndsWith( quote ) ) {
                    if ( s.Length > 2 ) {
                        s = s.Substring( 1, s.Length - 2 );
                    }
                    else {
                        s = "";
                    }
                    buf[i] = s;
                }
            }
        }

        

    }
}
