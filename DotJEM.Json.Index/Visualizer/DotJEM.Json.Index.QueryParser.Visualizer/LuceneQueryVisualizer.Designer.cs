﻿namespace DotJEM.Json.Index.QueryParser.Visualizer
{
    partial class LuceneQueryVisualizer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrlQuery = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ctrlGraph = new System.Windows.Forms.Panel();
            this.ctrlError = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlQuery
            // 
            this.ctrlQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlQuery.Location = new System.Drawing.Point(0, 0);
            this.ctrlQuery.Multiline = true;
            this.ctrlQuery.Name = "ctrlQuery";
            this.ctrlQuery.Size = new System.Drawing.Size(1033, 167);
            this.ctrlQuery.TabIndex = 0;
            this.ctrlQuery.KeyUp += new System.Windows.Forms.KeyEventHandler(this.QueryChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ctrlQuery);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ctrlError);
            this.splitContainer1.Panel2.Controls.Add(this.ctrlGraph);
            this.splitContainer1.Size = new System.Drawing.Size(1033, 758);
            this.splitContainer1.SplitterDistance = 167;
            this.splitContainer1.TabIndex = 1;
            // 
            // ctrlGraph
            // 
            this.ctrlGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlGraph.Location = new System.Drawing.Point(12, 12);
            this.ctrlGraph.Name = "ctrlGraph";
            this.ctrlGraph.Size = new System.Drawing.Size(1009, 373);
            this.ctrlGraph.TabIndex = 0;
            // 
            // ctrlError
            // 
            this.ctrlError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlError.Location = new System.Drawing.Point(12, 391);
            this.ctrlError.Multiline = true;
            this.ctrlError.Name = "ctrlError";
            this.ctrlError.Size = new System.Drawing.Size(1009, 184);
            this.ctrlError.TabIndex = 1;
            // 
            // LuceneQueryVisualizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 758);
            this.Controls.Add(this.splitContainer1);
            this.Name = "LuceneQueryVisualizer";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.LuceneQueryVisualizer_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox ctrlQuery;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel ctrlGraph;
        private System.Windows.Forms.TextBox ctrlError;
    }
}

