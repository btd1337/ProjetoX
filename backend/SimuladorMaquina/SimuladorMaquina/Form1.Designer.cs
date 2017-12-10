namespace SimuladorMaquina
{
    partial class Form1
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
            this.Iniciar = new System.Windows.Forms.Button();
            this.Alarme = new System.Windows.Forms.Button();
            this.txtIdAlarme = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Iniciar
            // 
            this.Iniciar.Location = new System.Drawing.Point(185, 55);
            this.Iniciar.Name = "Iniciar";
            this.Iniciar.Size = new System.Drawing.Size(297, 125);
            this.Iniciar.TabIndex = 0;
            this.Iniciar.Text = "Iniciar Processamento";
            this.Iniciar.UseVisualStyleBackColor = true;
            this.Iniciar.Click += new System.EventHandler(this.Iniciar_Click);
            // 
            // Alarme
            // 
            this.Alarme.Location = new System.Drawing.Point(637, 55);
            this.Alarme.Name = "Alarme";
            this.Alarme.Size = new System.Drawing.Size(203, 101);
            this.Alarme.TabIndex = 1;
            this.Alarme.Text = "Gerar Alarme";
            this.Alarme.UseVisualStyleBackColor = true;
            this.Alarme.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtIdAlarme
            // 
            this.txtIdAlarme.Location = new System.Drawing.Point(893, 102);
            this.txtIdAlarme.Name = "txtIdAlarme";
            this.txtIdAlarme.Size = new System.Drawing.Size(100, 31);
            this.txtIdAlarme.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(893, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Id Alarme";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1536, 467);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIdAlarme);
            this.Controls.Add(this.Alarme);
            this.Controls.Add(this.Iniciar);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Iniciar;
        private System.Windows.Forms.Button Alarme;
        private System.Windows.Forms.TextBox txtIdAlarme;
        private System.Windows.Forms.Label label1;
    }
}

