namespace Tacton
{
    partial class ParametreTacton
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
            this.colorbox = new System.Windows.Forms.ColorDialog();
            this.tactal = new System.Windows.Forms.TextBox();
            this.tactb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.taille = new System.Windows.Forms.MaskedTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tactet = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tactal
            // 
            this.tactal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tactal.Location = new System.Drawing.Point(73, 69);
            this.tactal.Name = "tactal";
            this.tactal.ReadOnly = true;
            this.tactal.Size = new System.Drawing.Size(111, 24);
            this.tactal.TabIndex = 1;
            this.tactal.Text = "Tacton allumé";
            this.tactal.Click += new System.EventHandler(this.textBox1_Click);
            // 
            // tactb
            // 
            this.tactb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tactb.Location = new System.Drawing.Point(73, 17);
            this.tactb.Name = "tactb";
            this.tactb.ReadOnly = true;
            this.tactb.Size = new System.Drawing.Size(111, 24);
            this.tactb.TabIndex = 2;
            this.tactb.Text = "Bordure";
            this.tactb.Click += new System.EventHandler(this.textBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Taille d\'un clou :";
            // 
            // taille
            // 
            this.taille.Location = new System.Drawing.Point(176, 103);
            this.taille.Mask = "000";
            this.taille.Name = "taille";
            this.taille.Size = new System.Drawing.Size(25, 20);
            this.taille.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(32, 152);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Valider";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(144, 152);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Annuler";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tactet
            // 
            this.tactet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tactet.Location = new System.Drawing.Point(73, 41);
            this.tactet.Name = "tactet";
            this.tactet.ReadOnly = true;
            this.tactet.Size = new System.Drawing.Size(111, 24);
            this.tactet.TabIndex = 7;
            this.tactet.Text = "Tacton éteint";
            this.tactet.Click += new System.EventHandler(this.textBox1_Click);
            // 
            // ParametreTacton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 205);
            this.Controls.Add(this.tactet);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.taille);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tactb);
            this.Controls.Add(this.tactal);
            this.Name = "ParametreTacton";
            this.Text = "Paramètres Tacton";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorbox;
        private System.Windows.Forms.TextBox tactal;
        private System.Windows.Forms.TextBox tactb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox taille;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tactet;
    }
}