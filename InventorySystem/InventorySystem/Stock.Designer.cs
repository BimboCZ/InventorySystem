namespace InventorySystem
{
 partial class Stock
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
   this.components = new System.ComponentModel.Container();
   this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
   this.label1 = new System.Windows.Forms.Label();
   this.label2 = new System.Windows.Forms.Label();
   this.label3 = new System.Windows.Forms.Label();
   this.label4 = new System.Windows.Forms.Label();
   this.label5 = new System.Windows.Forms.Label();
   this.textBox1 = new System.Windows.Forms.TextBox();
   this.textBox2 = new System.Windows.Forms.TextBox();
   this.textBox3 = new System.Windows.Forms.TextBox();
   this.comboBox1 = new System.Windows.Forms.ComboBox();
   this.button1 = new System.Windows.Forms.Button();
   this.button2 = new System.Windows.Forms.Button();
   this.button3 = new System.Windows.Forms.Button();
   this.dataGridView1 = new System.Windows.Forms.DataGridView();
   this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
   this.dgSno = new System.Windows.Forms.DataGridViewTextBoxColumn();
   this.dgProCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
   this.dgProName = new System.Windows.Forms.DataGridViewTextBoxColumn();
   this.dgQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
   this.dgDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
   this.dgStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
   ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
   ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
   this.SuspendLayout();
   // 
   // dateTimePicker1
   // 
   this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
   this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
   this.dateTimePicker1.Location = new System.Drawing.Point(138, 59);
   this.dateTimePicker1.Name = "dateTimePicker1";
   this.dateTimePicker1.Size = new System.Drawing.Size(93, 20);
   this.dateTimePicker1.TabIndex = 0;
   this.dateTimePicker1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DateTimePicker1_KeyDown);
   // 
   // label1
   // 
   this.label1.AutoSize = true;
   this.label1.Location = new System.Drawing.Point(135, 30);
   this.label1.Name = "label1";
   this.label1.Size = new System.Drawing.Size(30, 13);
   this.label1.TabIndex = 1;
   this.label1.Text = "Date";
   // 
   // label2
   // 
   this.label2.AutoSize = true;
   this.label2.Location = new System.Drawing.Point(234, 30);
   this.label2.Name = "label2";
   this.label2.Size = new System.Drawing.Size(72, 13);
   this.label2.TabIndex = 2;
   this.label2.Text = "Product Code";
   // 
   // label3
   // 
   this.label3.AutoSize = true;
   this.label3.Location = new System.Drawing.Point(340, 30);
   this.label3.Name = "label3";
   this.label3.Size = new System.Drawing.Size(75, 13);
   this.label3.TabIndex = 3;
   this.label3.Text = "Product Name";
   // 
   // label4
   // 
   this.label4.AutoSize = true;
   this.label4.Location = new System.Drawing.Point(446, 30);
   this.label4.Name = "label4";
   this.label4.Size = new System.Drawing.Size(46, 13);
   this.label4.TabIndex = 4;
   this.label4.Text = "Quantity";
   // 
   // label5
   // 
   this.label5.AutoSize = true;
   this.label5.Location = new System.Drawing.Point(552, 30);
   this.label5.Name = "label5";
   this.label5.Size = new System.Drawing.Size(37, 13);
   this.label5.TabIndex = 5;
   this.label5.Text = "Status";
   // 
   // textBox1
   // 
   this.textBox1.Location = new System.Drawing.Point(237, 59);
   this.textBox1.Name = "textBox1";
   this.textBox1.Size = new System.Drawing.Size(100, 20);
   this.textBox1.TabIndex = 6;
   this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox1_KeyDown);
   this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox1_KeyPress);
   // 
   // textBox2
   // 
   this.textBox2.Location = new System.Drawing.Point(343, 59);
   this.textBox2.Name = "textBox2";
   this.textBox2.Size = new System.Drawing.Size(100, 20);
   this.textBox2.TabIndex = 7;
   this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox2_KeyDown);
   // 
   // textBox3
   // 
   this.textBox3.Location = new System.Drawing.Point(449, 59);
   this.textBox3.Name = "textBox3";
   this.textBox3.Size = new System.Drawing.Size(100, 20);
   this.textBox3.TabIndex = 8;
   this.textBox3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox3_KeyDown);
   this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox3_KeyPress);
   // 
   // comboBox1
   // 
   this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
   this.comboBox1.FormattingEnabled = true;
   this.comboBox1.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
   this.comboBox1.Location = new System.Drawing.Point(555, 58);
   this.comboBox1.Name = "comboBox1";
   this.comboBox1.Size = new System.Drawing.Size(121, 21);
   this.comboBox1.TabIndex = 9;
   this.comboBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ComboBox1_KeyDown);
   // 
   // button1
   // 
   this.button1.Location = new System.Drawing.Point(253, 127);
   this.button1.Name = "button1";
   this.button1.Size = new System.Drawing.Size(84, 42);
   this.button1.TabIndex = 10;
   this.button1.Text = "Add";
   this.button1.UseVisualStyleBackColor = true;
   this.button1.Click += new System.EventHandler(this.Button1_Click);
   // 
   // button2
   // 
   this.button2.Location = new System.Drawing.Point(343, 127);
   this.button2.Name = "button2";
   this.button2.Size = new System.Drawing.Size(84, 42);
   this.button2.TabIndex = 11;
   this.button2.Text = "Delete";
   this.button2.UseVisualStyleBackColor = true;
   this.button2.Click += new System.EventHandler(this.Button2_Click);
   // 
   // button3
   // 
   this.button3.Location = new System.Drawing.Point(433, 127);
   this.button3.Name = "button3";
   this.button3.Size = new System.Drawing.Size(84, 42);
   this.button3.TabIndex = 12;
   this.button3.Text = "Reset";
   this.button3.UseVisualStyleBackColor = true;
   this.button3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Button3_MouseClick);
   // 
   // dataGridView1
   // 
   this.dataGridView1.AllowUserToAddRows = false;
   this.dataGridView1.AllowUserToDeleteRows = false;
   this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
   this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgSno,
            this.dgProCode,
            this.dgProName,
            this.dgQuantity,
            this.dgDate,
            this.dgStatus});
   this.dataGridView1.Location = new System.Drawing.Point(15, 186);
   this.dataGridView1.Name = "dataGridView1";
   this.dataGridView1.ReadOnly = true;
   this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
   this.dataGridView1.Size = new System.Drawing.Size(848, 287);
   this.dataGridView1.TabIndex = 13;
   this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DataGridView1_MouseDoubleClick);
   // 
   // errorProvider1
   // 
   this.errorProvider1.ContainerControl = this;
   // 
   // dgSno
   // 
   this.dgSno.HeaderText = "S.No";
   this.dgSno.Name = "dgSno";
   // 
   // dgProCode
   // 
   this.dgProCode.HeaderText = "Product Code";
   this.dgProCode.Name = "dgProCode";
   // 
   // dgProName
   // 
   this.dgProName.HeaderText = "Product Name";
   this.dgProName.Name = "dgProName";
   this.dgProName.Width = 300;
   // 
   // dgQuantity
   // 
   this.dgQuantity.HeaderText = "Quantity";
   this.dgQuantity.Name = "dgQuantity";
   // 
   // dgDate
   // 
   this.dgDate.HeaderText = "Date";
   this.dgDate.Name = "dgDate";
   this.dgDate.Width = 105;
   // 
   // dgStatus
   // 
   this.dgStatus.HeaderText = "Status";
   this.dgStatus.Name = "dgStatus";
   // 
   // Stock
   // 
   this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
   this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
   this.ClientSize = new System.Drawing.Size(875, 531);
   this.Controls.Add(this.dataGridView1);
   this.Controls.Add(this.button3);
   this.Controls.Add(this.button2);
   this.Controls.Add(this.button1);
   this.Controls.Add(this.comboBox1);
   this.Controls.Add(this.textBox3);
   this.Controls.Add(this.textBox2);
   this.Controls.Add(this.textBox1);
   this.Controls.Add(this.label5);
   this.Controls.Add(this.label4);
   this.Controls.Add(this.label3);
   this.Controls.Add(this.label2);
   this.Controls.Add(this.label1);
   this.Controls.Add(this.dateTimePicker1);
   this.Name = "Stock";
   this.Text = "Stock";
   this.Load += new System.EventHandler(this.Stock_Load);
   ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
   ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
   this.ResumeLayout(false);
   this.PerformLayout();

  }

  #endregion

  private System.Windows.Forms.DateTimePicker dateTimePicker1;
  private System.Windows.Forms.Label label1;
  private System.Windows.Forms.Label label2;
  private System.Windows.Forms.Label label3;
  private System.Windows.Forms.Label label4;
  private System.Windows.Forms.Label label5;
  private System.Windows.Forms.TextBox textBox1;
  private System.Windows.Forms.TextBox textBox2;
  private System.Windows.Forms.TextBox textBox3;
  private System.Windows.Forms.ComboBox comboBox1;
  private System.Windows.Forms.Button button1;
  private System.Windows.Forms.Button button2;
  private System.Windows.Forms.Button button3;
  private System.Windows.Forms.DataGridView dataGridView1;
  private System.Windows.Forms.ErrorProvider errorProvider1;
  private System.Windows.Forms.DataGridViewTextBoxColumn dgSno;
  private System.Windows.Forms.DataGridViewTextBoxColumn dgProCode;
  private System.Windows.Forms.DataGridViewTextBoxColumn dgProName;
  private System.Windows.Forms.DataGridViewTextBoxColumn dgQuantity;
  private System.Windows.Forms.DataGridViewTextBoxColumn dgDate;
  private System.Windows.Forms.DataGridViewTextBoxColumn dgStatus;
 }
}