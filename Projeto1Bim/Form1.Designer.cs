namespace Projeto1Bim
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            xInicial = new TextBox();
            yInicial = new TextBox();
            mAngular = new TextBox();
            bLinear = new TextBox();
            xFinal = new TextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            button1 = new Button();
            BLable = new Label();
            x1Lable = new Label();
            MLable = new Label();
            y0Lable = new Label();
            x0Lable = new Label();
            equacao = new Label();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // xInicial
            // 
            xInicial.Dock = DockStyle.Fill;
            xInicial.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            xInicial.Location = new Point(3, 46);
            xInicial.Name = "xInicial";
            xInicial.Size = new Size(166, 39);
            xInicial.TabIndex = 1;
            // 
            // yInicial
            // 
            yInicial.Dock = DockStyle.Fill;
            yInicial.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            yInicial.Location = new Point(175, 46);
            yInicial.Name = "yInicial";
            yInicial.Size = new Size(166, 39);
            yInicial.TabIndex = 2;
            // 
            // mAngular
            // 
            mAngular.Dock = DockStyle.Fill;
            mAngular.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            mAngular.Location = new Point(347, 46);
            mAngular.Name = "mAngular";
            mAngular.Size = new Size(166, 39);
            mAngular.TabIndex = 3;
            // 
            // bLinear
            // 
            bLinear.Dock = DockStyle.Fill;
            bLinear.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            bLinear.Location = new Point(691, 46);
            bLinear.Name = "bLinear";
            bLinear.Size = new Size(166, 39);
            bLinear.TabIndex = 4;
            // 
            // xFinal
            // 
            xFinal.Dock = DockStyle.Fill;
            xFinal.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            xFinal.Location = new Point(519, 46);
            xFinal.Name = "xFinal";
            xFinal.Size = new Size(166, 39);
            xFinal.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 6;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.Controls.Add(button1, 5, 1);
            tableLayoutPanel1.Controls.Add(BLable, 4, 0);
            tableLayoutPanel1.Controls.Add(x1Lable, 3, 0);
            tableLayoutPanel1.Controls.Add(MLable, 2, 0);
            tableLayoutPanel1.Controls.Add(y0Lable, 1, 0);
            tableLayoutPanel1.Controls.Add(x0Lable, 0, 0);
            tableLayoutPanel1.Controls.Add(xInicial, 0, 1);
            tableLayoutPanel1.Controls.Add(yInicial, 1, 1);
            tableLayoutPanel1.Controls.Add(mAngular, 2, 1);
            tableLayoutPanel1.Controls.Add(xFinal, 3, 1);
            tableLayoutPanel1.Controls.Add(bLinear, 4, 1);
            tableLayoutPanel1.Controls.Add(equacao, 5, 0);
            tableLayoutPanel1.Dock = DockStyle.Bottom;
            tableLayoutPanel1.Location = new Point(0, 527);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1034, 87);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Fill;
            button1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(863, 46);
            button1.Name = "button1";
            button1.Size = new Size(168, 38);
            button1.TabIndex = 2;
            button1.Text = "Desenhar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // BLable
            // 
            BLable.AutoSize = true;
            BLable.Dock = DockStyle.Bottom;
            BLable.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            BLable.Location = new Point(691, 23);
            BLable.Name = "BLable";
            BLable.Size = new Size(166, 20);
            BLable.TabIndex = 9;
            BLable.Text = "Coeficiente linear";
            // 
            // x1Lable
            // 
            x1Lable.AutoSize = true;
            x1Lable.Dock = DockStyle.Bottom;
            x1Lable.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            x1Lable.Location = new Point(519, 23);
            x1Lable.Name = "x1Lable";
            x1Lable.Size = new Size(166, 20);
            x1Lable.TabIndex = 8;
            x1Lable.Text = "X Final";
            // 
            // MLable
            // 
            MLable.AutoSize = true;
            MLable.Dock = DockStyle.Bottom;
            MLable.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            MLable.Location = new Point(347, 23);
            MLable.Name = "MLable";
            MLable.Size = new Size(166, 20);
            MLable.TabIndex = 7;
            MLable.Text = "Coeficiente angular";
            // 
            // y0Lable
            // 
            y0Lable.AutoSize = true;
            y0Lable.Dock = DockStyle.Bottom;
            y0Lable.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            y0Lable.Location = new Point(175, 23);
            y0Lable.Name = "y0Lable";
            y0Lable.Size = new Size(166, 20);
            y0Lable.TabIndex = 6;
            y0Lable.Text = "Y Inicial";
            // 
            // x0Lable
            // 
            x0Lable.AutoSize = true;
            x0Lable.Dock = DockStyle.Bottom;
            x0Lable.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            x0Lable.Location = new Point(3, 23);
            x0Lable.Name = "x0Lable";
            x0Lable.Size = new Size(166, 20);
            x0Lable.TabIndex = 2;
            x0Lable.Text = "X Inicial";
            // 
            // equacao
            // 
            equacao.AutoSize = true;
            equacao.Dock = DockStyle.Bottom;
            equacao.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            equacao.Location = new Point(863, 23);
            equacao.Name = "equacao";
            equacao.Size = new Size(168, 20);
            equacao.TabIndex = 10;
            equacao.Text = "...";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            ClientSize = new Size(1034, 614);
            Controls.Add(tableLayoutPanel1);
            MaximumSize = new Size(1050, 650);
            MinimumSize = new Size(1050, 650);
            Name = "Form1";
            Text = "Form1";
            Paint += Form1_Paint;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox xInicial;
        private TextBox yInicial;
        private TextBox mAngular;
        private TextBox bLinear;
        private TextBox xFinal;
        private TableLayoutPanel tableLayoutPanel1;
        private Label BLable;
        private Label x1Lable;
        private Label MLable;
        private Label y0Lable;
        private Label x0Lable;
        private Button button1;
        private Label equacao;
    }
}