
namespace MamiesModGeckoTest
{
    partial class MamiesModGeckoTestForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.ipText = new System.Windows.Forms.TextBox();
            this.connect = new System.Windows.Forms.Button();
            this.disconnect = new System.Windows.Forms.Button();
            this.xrayPoke = new System.Windows.Forms.CheckBox();
            this.xrayCodeHandler = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ipText
            // 
            this.ipText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipText.Location = new System.Drawing.Point(13, 13);
            this.ipText.Name = "ipText";
            this.ipText.Size = new System.Drawing.Size(100, 22);
            this.ipText.TabIndex = 0;
            this.ipText.Text = "192.168.1.";
            this.ipText.TextChanged += new System.EventHandler(this.ipText_TextChanged);
            // 
            // connect
            // 
            this.connect.Enabled = false;
            this.connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connect.Location = new System.Drawing.Point(119, 12);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(125, 23);
            this.connect.TabIndex = 1;
            this.connect.Text = "Connect";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // disconnect
            // 
            this.disconnect.Enabled = false;
            this.disconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disconnect.Location = new System.Drawing.Point(250, 12);
            this.disconnect.Name = "disconnect";
            this.disconnect.Size = new System.Drawing.Size(125, 23);
            this.disconnect.TabIndex = 2;
            this.disconnect.Text = "Disconnect";
            this.disconnect.UseVisualStyleBackColor = true;
            this.disconnect.Click += new System.EventHandler(this.disconnect_Click);
            // 
            // xrayPoke
            // 
            this.xrayPoke.AutoSize = true;
            this.xrayPoke.Enabled = false;
            this.xrayPoke.Location = new System.Drawing.Point(13, 41);
            this.xrayPoke.Name = "xrayPoke";
            this.xrayPoke.Size = new System.Drawing.Size(183, 17);
            this.xrayPoke.TabIndex = 3;
            this.xrayPoke.Text = "xray (for Minecraft) [poke version]";
            this.xrayPoke.UseVisualStyleBackColor = true;
            this.xrayPoke.CheckedChanged += new System.EventHandler(this.xrayPoke_CheckedChanged);
            // 
            // xrayCodeHandler
            // 
            this.xrayCodeHandler.AutoSize = true;
            this.xrayCodeHandler.Enabled = false;
            this.xrayCodeHandler.Location = new System.Drawing.Point(13, 64);
            this.xrayCodeHandler.Name = "xrayCodeHandler";
            this.xrayCodeHandler.Size = new System.Drawing.Size(221, 17);
            this.xrayCodeHandler.TabIndex = 4;
            this.xrayCodeHandler.Text = "xray (for Minecraft) [code handler version]";
            this.xrayCodeHandler.UseVisualStyleBackColor = true;
            this.xrayCodeHandler.CheckedChanged += new System.EventHandler(this.xrayCodeHandler_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 111);
            this.Controls.Add(this.xrayCodeHandler);
            this.Controls.Add(this.xrayPoke);
            this.Controls.Add(this.disconnect);
            this.Controls.Add(this.connect);
            this.Controls.Add(this.ipText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MamiesModGecko Test";
            this.Load += new System.EventHandler(this.MamiesModGeckoTestForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ipText;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.Button disconnect;
        private System.Windows.Forms.CheckBox xrayPoke;
        private System.Windows.Forms.CheckBox xrayCodeHandler;
    }
}

