namespace PROYECTO_1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            lblConsulta = new Label();
            textBuscar_Click = new TextBox();
            btnBuscar = new Button();
            txtRespuesta = new TextBox();
            btnLimpiar_Click = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // lblConsulta
            // 
            lblConsulta.AutoSize = true;
            lblConsulta.Location = new Point(396, 68);
            lblConsulta.Name = "lblConsulta";
            lblConsulta.Size = new Size(133, 20);
            lblConsulta.TabIndex = 0;
            lblConsulta.Text = "Escriba su consulta";
            // 
            // textBuscar_Click
            // 
            textBuscar_Click.Location = new Point(311, 114);
            textBuscar_Click.Name = "textBuscar_Click";
            textBuscar_Click.Size = new Size(329, 27);
            textBuscar_Click.TabIndex = 1;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.FromArgb(224, 224, 224);
            btnBuscar.Location = new Point(435, 189);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(94, 29);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Consultar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click_Click;
            // 
            // txtRespuesta
            // 
            txtRespuesta.Location = new Point(107, 239);
            txtRespuesta.Multiline = true;
            txtRespuesta.Name = "txtRespuesta";
            txtRespuesta.Size = new Size(756, 273);
            txtRespuesta.TabIndex = 3;
            // 
            // btnLimpiar_Click
            // 
            btnLimpiar_Click.BackColor = Color.Silver;
            btnLimpiar_Click.Location = new Point(402, 558);
            btnLimpiar_Click.Name = "btnLimpiar_Click";
            btnLimpiar_Click.Size = new Size(190, 29);
            btnLimpiar_Click.TabIndex = 4;
            btnLimpiar_Click.Text = "Consulta Nueva";
            btnLimpiar_Click.UseVisualStyleBackColor = false;
            btnLimpiar_Click.Click += btnLimpiar_Click_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(811, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(225, 225);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(26, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(189, 195);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 192, 255);
            ClientSize = new Size(1048, 627);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(btnLimpiar_Click);
            Controls.Add(txtRespuesta);
            Controls.Add(btnBuscar);
            Controls.Add(textBuscar_Click);
            Controls.Add(lblConsulta);
            ForeColor = SystemColors.ActiveCaptionText;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblConsulta;
        private TextBox textBuscar_Click;
        private Button btnBuscar;
        private TextBox txtRespuesta;
        private Button btnLimpiar_Click;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}