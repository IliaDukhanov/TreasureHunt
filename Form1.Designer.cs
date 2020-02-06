namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.columns = new System.Windows.Forms.NumericUpDown();
            this.rows = new System.Windows.Forms.NumericUpDown();
            this.hydro = new System.Windows.Forms.NumericUpDown();
            this.treasure = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gameField = new System.Windows.Forms.DataGridView();
            this.area = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.columns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hydro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treasure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.area)).BeginInit();
            this.SuspendLayout();
            // 
            // columns
            // 
            this.columns.Location = new System.Drawing.Point(655, 260);
            this.columns.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.columns.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.columns.Name = "columns";
            this.columns.Size = new System.Drawing.Size(75, 20);
            this.columns.TabIndex = 1;
            this.columns.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.columns.ValueChanged += new System.EventHandler(this.Columns_ValueChanged);
            // 
            // rows
            // 
            this.rows.Location = new System.Drawing.Point(742, 260);
            this.rows.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.rows.Name = "rows";
            this.rows.Size = new System.Drawing.Size(75, 20);
            this.rows.TabIndex = 2;
            this.rows.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.rows.ValueChanged += new System.EventHandler(this.Rows_ValueChanged);
            // 
            // hydro
            // 
            this.hydro.Location = new System.Drawing.Point(655, 312);
            this.hydro.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.hydro.Name = "hydro";
            this.hydro.Size = new System.Drawing.Size(75, 20);
            this.hydro.TabIndex = 3;
            this.hydro.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.hydro.ValueChanged += new System.EventHandler(this.Hydro_ValueChanged);
            // 
            // treasure
            // 
            this.treasure.Location = new System.Drawing.Point(742, 312);
            this.treasure.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.treasure.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.treasure.Name = "treasure";
            this.treasure.Size = new System.Drawing.Size(75, 20);
            this.treasure.TabIndex = 4;
            this.treasure.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.treasure.ValueChanged += new System.EventHandler(this.Treasure_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(666, 244);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Столбцы";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(751, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Строки";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(649, 296);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Гидролокаторы";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(744, 296);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Сокровища";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(701, 221);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Настройки";
            // 
            // gameField
            // 
            this.gameField.AllowUserToAddRows = false;
            this.gameField.AllowUserToDeleteRows = false;
            this.gameField.AllowUserToResizeColumns = false;
            this.gameField.AllowUserToResizeRows = false;
            this.gameField.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gameField.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gameField.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gameField.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gameField.ColumnHeadersVisible = false;
            this.gameField.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gameField.Location = new System.Drawing.Point(12, 12);
            this.gameField.MultiSelect = false;
            this.gameField.Name = "gameField";
            this.gameField.RowHeadersVisible = false;
            this.gameField.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gameField.Size = new System.Drawing.Size(628, 403);
            this.gameField.TabIndex = 10;
            this.gameField.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GameField_CellClick);
            // 
            // area
            // 
            this.area.Location = new System.Drawing.Point(698, 360);
            this.area.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.area.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.area.Name = "area";
            this.area.Size = new System.Drawing.Size(75, 20);
            this.area.TabIndex = 11;
            this.area.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.area.ValueChanged += new System.EventHandler(this.Area_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(666, 344);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Радиус гидролокаторов";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(649, 392);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "StartButton";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(768, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "20";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(684, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Гидролокаторы:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(760, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(13, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "3";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(697, 35);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "Сокровища:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Mistral", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(646, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(179, 33);
            this.label7.TabIndex = 20;
            this.label7.Text = "Поиск Сокровищ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 429);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.area);
            this.Controls.Add(this.gameField);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treasure);
            this.Controls.Add(this.hydro);
            this.Controls.Add(this.rows);
            this.Controls.Add(this.columns);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.columns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hydro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treasure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.area)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown columns;
        private System.Windows.Forms.NumericUpDown rows;
        private System.Windows.Forms.NumericUpDown hydro;
        private System.Windows.Forms.NumericUpDown treasure;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView gameField;
        private System.Windows.Forms.NumericUpDown area;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
    }
}

