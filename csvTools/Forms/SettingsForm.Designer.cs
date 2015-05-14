namespace Jas.Utils.CSVTools.Forms {
    partial class SettingsForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
            if ( disposing && ( components != null ) ) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.tbDelimiter = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbQuote = new System.Windows.Forms.TextBox();
            this.nudSkipRows = new System.Windows.Forms.NumericUpDown();
            this.tbEncoding = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bOk = new System.Windows.Forms.Button();
            this.bEncodingHelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudSkipRows)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Delimiter";
            // 
            // tbDelimiter
            // 
            this.tbDelimiter.Location = new System.Drawing.Point(125, 27);
            this.tbDelimiter.MaxLength = 1;
            this.tbDelimiter.Name = "tbDelimiter";
            this.tbDelimiter.Size = new System.Drawing.Size(61, 20);
            this.tbDelimiter.TabIndex = 1;
            this.tbDelimiter.Text = ",";
            this.tbDelimiter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Quote";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Skip First Rows";
            // 
            // tbQuote
            // 
            this.tbQuote.Location = new System.Drawing.Point(125, 65);
            this.tbQuote.MaxLength = 1;
            this.tbQuote.Name = "tbQuote";
            this.tbQuote.Size = new System.Drawing.Size(61, 20);
            this.tbQuote.TabIndex = 4;
            this.tbQuote.Text = "\"";
            this.tbQuote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nudSkipRows
            // 
            this.nudSkipRows.Location = new System.Drawing.Point(125, 103);
            this.nudSkipRows.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudSkipRows.Name = "nudSkipRows";
            this.nudSkipRows.Size = new System.Drawing.Size(75, 20);
            this.nudSkipRows.TabIndex = 5;
            this.nudSkipRows.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbEncoding
            // 
            this.tbEncoding.Location = new System.Drawing.Point(125, 141);
            this.tbEncoding.Name = "tbEncoding";
            this.tbEncoding.Size = new System.Drawing.Size(61, 20);
            this.tbEncoding.TabIndex = 6;
            this.tbEncoding.Text = "1250";
            this.tbEncoding.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Encoding";
            // 
            // bOk
            // 
            this.bOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bOk.Location = new System.Drawing.Point(78, 201);
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(75, 23);
            this.bOk.TabIndex = 8;
            this.bOk.Text = "OK";
            this.bOk.UseVisualStyleBackColor = true;
            // 
            // bEncodingHelp
            // 
            this.bEncodingHelp.Location = new System.Drawing.Point(192, 140);
            this.bEncodingHelp.Name = "bEncodingHelp";
            this.bEncodingHelp.Size = new System.Drawing.Size(25, 21);
            this.bEncodingHelp.TabIndex = 9;
            this.bEncodingHelp.Text = "?";
            this.bEncodingHelp.UseVisualStyleBackColor = true;
            this.bEncodingHelp.Click += new System.EventHandler(this.bEncodingHelp_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(231, 236);
            this.Controls.Add(this.bEncodingHelp);
            this.Controls.Add(this.bOk);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbEncoding);
            this.Controls.Add(this.nudSkipRows);
            this.Controls.Add(this.tbQuote);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbDelimiter);
            this.Controls.Add(this.label1);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSV Settings";
            ((System.ComponentModel.ISupportInitialize)(this.nudSkipRows)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDelimiter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbQuote;
        private System.Windows.Forms.NumericUpDown nudSkipRows;
        private System.Windows.Forms.TextBox tbEncoding;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bOk;
        private System.Windows.Forms.Button bEncodingHelp;
    }
}