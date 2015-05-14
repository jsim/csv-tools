using System;
using System.Collections.Generic;
using System.Text;

namespace Jas.Utils.CSVTools {
    public class ParserConfig {
        public string FileName { get; set; }
        public char Delimiter { get; set; }
        public char Quote { get; set; }
        public int SkipRows { get; set; }
        public bool Thread { get; set; }
        public int RowsToProcess { get; set; }
        public int Encoding { get; set; }

        public static ParserConfig GetDefault() {
            ParserConfig c = new ParserConfig();

            c.Delimiter = ';';
            c.Quote = '"';
            c.Encoding = 1250;

            return c;
        }
    }

    public class ExportConfig : ParserConfig {
        public bool ExportHeader { get; set; }
        public bool SkipHidden { get; set; }
    }
}
