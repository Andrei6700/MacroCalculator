using System.Drawing;
using System.Windows.Forms;
using System;

namespace MacroCalculator.MainPage
{
    partial class MainPage
    {
        private System.ComponentModel.IContainer components = null;
        private Panel headerPanel;
        private Label lblTitle;
        private Panel buttonPanel;
        private Button btnBulk;
        private Button btnCut;
        private Button btnMaintain;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.headerPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.btnMaintain = new System.Windows.Forms.Button();
            this.btnCut = new System.Windows.Forms.Button();
            this.btnBulk = new System.Windows.Forms.Button();
            this.headerPanel.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(584, 80);
            this.headerPanel.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Black;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Gold;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(584, 80);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Macro Calculator";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonPanel
            // 
            this.buttonPanel.AutoScroll = true;
            this.buttonPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonPanel.Controls.Add(this.btnMaintain);
            this.buttonPanel.Controls.Add(this.btnCut);
            this.buttonPanel.Controls.Add(this.btnBulk);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPanel.Location = new System.Drawing.Point(0, 80);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Padding = new System.Windows.Forms.Padding(20);
            this.buttonPanel.Size = new System.Drawing.Size(584, 281);
            this.buttonPanel.TabIndex = 0;
            // 
            // btnMaintain
            // 
            this.btnMaintain.BackColor = System.Drawing.Color.Black;
            this.btnMaintain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaintain.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaintain.ForeColor = System.Drawing.Color.Red;
            this.btnMaintain.Location = new System.Drawing.Point(184, 180);
            this.btnMaintain.Margin = new System.Windows.Forms.Padding(10);
            this.btnMaintain.Name = "btnMaintain";
            this.btnMaintain.Size = new System.Drawing.Size(200, 60);
            this.btnMaintain.TabIndex = 0;
            this.btnMaintain.Text = "MAINTAIN";
            this.btnMaintain.UseVisualStyleBackColor = false;
            this.btnMaintain.Click += new System.EventHandler(this.btnMaintain_Click);
            // 
            // btnCut
            // 
            this.btnCut.BackColor = System.Drawing.Color.Black;
            this.btnCut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCut.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCut.ForeColor = System.Drawing.Color.Red;
            this.btnCut.Location = new System.Drawing.Point(184, 100);
            this.btnCut.Margin = new System.Windows.Forms.Padding(10);
            this.btnCut.Name = "btnCut";
            this.btnCut.Size = new System.Drawing.Size(200, 60);
            this.btnCut.TabIndex = 1;
            this.btnCut.Text = "CUT";
            this.btnCut.UseVisualStyleBackColor = false;
            this.btnCut.Click += new System.EventHandler(this.btnCut_Click);
            // 
            // btnBulk
            // 
            this.btnBulk.BackColor = System.Drawing.Color.Black;
            this.btnBulk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBulk.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBulk.ForeColor = System.Drawing.Color.Red;
            this.btnBulk.Location = new System.Drawing.Point(184, 20);
            this.btnBulk.Margin = new System.Windows.Forms.Padding(10);
            this.btnBulk.Name = "btnBulk";
            this.btnBulk.Size = new System.Drawing.Size(200, 60);
            this.btnBulk.TabIndex = 2;
            this.btnBulk.Text = "BULK";
            this.btnBulk.UseVisualStyleBackColor = false;
            this.btnBulk.Click += new System.EventHandler(this.btnBulk_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.buttonPanel);
            this.Controls.Add(this.headerPanel);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "MainPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.headerPanel.ResumeLayout(false);
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
