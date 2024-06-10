
namespace Goldbergalizer
{
    partial class Golderberg_Alizer_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Golderberg_Alizer_Form));
            this.GameFolder_text_box = new System.Windows.Forms.TextBox();
            this.GameFolder_Text = new System.Windows.Forms.Label();
            this.GameFolder_Btn_Finder = new System.Windows.Forms.Button();
            this.Golberglarize_Btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Update_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GameFolder_text_box
            // 
            this.GameFolder_text_box.Location = new System.Drawing.Point(86, 71);
            this.GameFolder_text_box.Name = "GameFolder_text_box";
            this.GameFolder_text_box.ReadOnly = true;
            this.GameFolder_text_box.Size = new System.Drawing.Size(192, 20);
            this.GameFolder_text_box.TabIndex = 0;
            // 
            // GameFolder_Text
            // 
            this.GameFolder_Text.AutoSize = true;
            this.GameFolder_Text.Location = new System.Drawing.Point(2, 74);
            this.GameFolder_Text.Name = "GameFolder_Text";
            this.GameFolder_Text.Size = new System.Drawing.Size(78, 13);
            this.GameFolder_Text.TabIndex = 1;
            this.GameFolder_Text.Text = "Game Folder(s)";
            // 
            // GameFolder_Btn_Finder
            // 
            this.GameFolder_Btn_Finder.Location = new System.Drawing.Point(284, 69);
            this.GameFolder_Btn_Finder.Name = "GameFolder_Btn_Finder";
            this.GameFolder_Btn_Finder.Size = new System.Drawing.Size(75, 23);
            this.GameFolder_Btn_Finder.TabIndex = 2;
            this.GameFolder_Btn_Finder.Text = "...";
            this.GameFolder_Btn_Finder.UseVisualStyleBackColor = true;
            this.GameFolder_Btn_Finder.Click += new System.EventHandler(this.GameFolder_Btn_Finder_Click);
            // 
            // Golberglarize_Btn
            // 
            this.Golberglarize_Btn.Location = new System.Drawing.Point(130, 165);
            this.Golberglarize_Btn.Name = "Golberglarize_Btn";
            this.Golberglarize_Btn.Size = new System.Drawing.Size(119, 29);
            this.Golberglarize_Btn.TabIndex = 3;
            this.Golberglarize_Btn.Text = "Golberglarize!";
            this.Golberglarize_Btn.UseVisualStyleBackColor = true;
            this.Golberglarize_Btn.Click += new System.EventHandler(this.Goldbergalarize);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(288, 309);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "by @ealtairz2318";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 309);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "V.1";
            // 
            // Update_btn
            // 
            this.Update_btn.Location = new System.Drawing.Point(5, 12);
            this.Update_btn.Name = "Update_btn";
            this.Update_btn.Size = new System.Drawing.Size(115, 23);
            this.Update_btn.TabIndex = 6;
            this.Update_btn.Text = "Update Emulator";
            this.Update_btn.UseVisualStyleBackColor = true;
            this.Update_btn.Click += new System.EventHandler(this.UpdateEmulator);
            // 
            // Golderberg_Alizer_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 331);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Golberglarize_Btn);
            this.Controls.Add(this.GameFolder_Btn_Finder);
            this.Controls.Add(this.GameFolder_Text);
            this.Controls.Add(this.GameFolder_text_box);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Golderberg_Alizer_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Goldberg-Alizer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnExitCaching);
            this.Load += new System.EventHandler(this.Goldberg_Files_Updater);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox GameFolder_text_box;
        private System.Windows.Forms.Label GameFolder_Text;
        private System.Windows.Forms.Button GameFolder_Btn_Finder;
        private System.Windows.Forms.Button Golberglarize_Btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Update_btn;
    }
}

