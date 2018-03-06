namespace JsonToClassDefine
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtJson = new System.Windows.Forms.RichTextBox();
            this.txtClass = new System.Windows.Forms.RichTextBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPro = new System.Windows.Forms.TextBox();
            this.btnGetPro = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtJson
            // 
            this.txtJson.Location = new System.Drawing.Point(24, 12);
            this.txtJson.Name = "txtJson";
            this.txtJson.Size = new System.Drawing.Size(368, 382);
            this.txtJson.TabIndex = 0;
            this.txtJson.Text = "";
            // 
            // txtClass
            // 
            this.txtClass.Location = new System.Drawing.Point(590, 12);
            this.txtClass.Name = "txtClass";
            this.txtClass.Size = new System.Drawing.Size(368, 445);
            this.txtClass.TabIndex = 1;
            this.txtClass.Text = "";
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(449, 155);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 2;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // txtClassName
            // 
            this.txtClassName.Location = new System.Drawing.Point(449, 69);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(100, 21);
            this.txtClassName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(449, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "class name:";
            // 
            // txtPro
            // 
            this.txtPro.Location = new System.Drawing.Point(94, 400);
            this.txtPro.Name = "txtPro";
            this.txtPro.Size = new System.Drawing.Size(163, 21);
            this.txtPro.TabIndex = 5;
            // 
            // btnGetPro
            // 
            this.btnGetPro.Location = new System.Drawing.Point(263, 400);
            this.btnGetPro.Name = "btnGetPro";
            this.btnGetPro.Size = new System.Drawing.Size(75, 23);
            this.btnGetPro.TabIndex = 6;
            this.btnGetPro.Text = "抽取";
            this.btnGetPro.UseVisualStyleBackColor = true;
            this.btnGetPro.Click += new System.EventHandler(this.btnGetPro_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 405);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "抽取属性：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 484);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGetPro);
            this.Controls.Add(this.txtPro);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtClassName);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.txtClass);
            this.Controls.Add(this.txtJson);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtJson;
        private System.Windows.Forms.RichTextBox txtClass;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPro;
        private System.Windows.Forms.Button btnGetPro;
        private System.Windows.Forms.Label label2;
    }
}

