namespace CR.Interface
{
    partial class frmWelcome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWelcome));
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnPlayNow = new System.Windows.Forms.Button();
            this.btnChangePlayer = new System.Windows.Forms.Button();
            this.btnRules = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(220, 25);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(153, 33);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome ";
            // 
            // btnPlayNow
            // 
            this.btnPlayNow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnPlayNow.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayNow.ForeColor = System.Drawing.Color.White;
            this.btnPlayNow.Location = new System.Drawing.Point(169, 90);
            this.btnPlayNow.Name = "btnPlayNow";
            this.btnPlayNow.Size = new System.Drawing.Size(261, 40);
            this.btnPlayNow.TabIndex = 10;
            this.btnPlayNow.Text = "PLAY NOW";
            this.btnPlayNow.UseVisualStyleBackColor = false;
            this.btnPlayNow.Click += new System.EventHandler(this.BtnPlayNow_Click);
            // 
            // btnChangePlayer
            // 
            this.btnChangePlayer.BackColor = System.Drawing.Color.Red;
            this.btnChangePlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePlayer.ForeColor = System.Drawing.Color.White;
            this.btnChangePlayer.Location = new System.Drawing.Point(169, 155);
            this.btnChangePlayer.Name = "btnChangePlayer";
            this.btnChangePlayer.Size = new System.Drawing.Size(261, 40);
            this.btnChangePlayer.TabIndex = 11;
            this.btnChangePlayer.Text = "CHANGE PLAYER";
            this.btnChangePlayer.UseVisualStyleBackColor = false;
            this.btnChangePlayer.Click += new System.EventHandler(this.BtnChangePlayer_Click);
            // 
            // btnRules
            // 
            this.btnRules.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRules.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRules.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRules.Location = new System.Drawing.Point(169, 230);
            this.btnRules.Margin = new System.Windows.Forms.Padding(2);
            this.btnRules.Name = "btnRules";
            this.btnRules.Size = new System.Drawing.Size(261, 32);
            this.btnRules.TabIndex = 13;
            this.btnRules.Text = "HELP";
            this.btnRules.UseVisualStyleBackColor = false;
            this.btnRules.Click += new System.EventHandler(this.BtnRules_Click);
            // 
            // frmWelcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 301);
            this.Controls.Add(this.btnRules);
            this.Controls.Add(this.btnChangePlayer);
            this.Controls.Add(this.btnPlayNow);
            this.Controls.Add(this.lblWelcome);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmWelcome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome!";
            this.Load += new System.EventHandler(this.FrmWelcome_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnPlayNow;
        private System.Windows.Forms.Button btnChangePlayer;
        private System.Windows.Forms.Button btnRules;
    }
}