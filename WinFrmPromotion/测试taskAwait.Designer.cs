
namespace WinFrmPromotion
{
    partial class 测试taskAwait
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
            this.txtResult = new System.Windows.Forms.TextBox();
            this.chkAwait = new System.Windows.Forms.CheckBox();
            this.chkConfigureAwait = new System.Windows.Forms.CheckBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(12, 122);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(556, 255);
            this.txtResult.TabIndex = 4;
            // 
            // chkAwait
            // 
            this.chkAwait.AutoSize = true;
            this.chkAwait.Location = new System.Drawing.Point(22, 50);
            this.chkAwait.Name = "chkAwait";
            this.chkAwait.Size = new System.Drawing.Size(54, 16);
            this.chkAwait.TabIndex = 5;
            this.chkAwait.Text = "Await";
            this.chkAwait.UseVisualStyleBackColor = true;
            // 
            // chkConfigureAwait
            // 
            this.chkConfigureAwait.AutoSize = true;
            this.chkConfigureAwait.Location = new System.Drawing.Point(22, 87);
            this.chkConfigureAwait.Name = "chkConfigureAwait";
            this.chkConfigureAwait.Size = new System.Drawing.Size(108, 16);
            this.chkConfigureAwait.TabIndex = 5;
            this.chkConfigureAwait.Text = "ConfigureAwait";
            this.chkConfigureAwait.UseVisualStyleBackColor = true;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(457, 50);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(111, 38);
            this.btnRun.TabIndex = 6;
            this.btnRun.Text = "执行";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // 测试taskAwait
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 535);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.chkConfigureAwait);
            this.Controls.Add(this.chkAwait);
            this.Controls.Add(this.txtResult);
            this.Name = "测试taskAwait";
            this.Text = "测试taskAwait";
            this.Load += new System.EventHandler(this.测试taskAwait_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.CheckBox chkAwait;
        private System.Windows.Forms.CheckBox chkConfigureAwait;
        private System.Windows.Forms.Button btnRun;
    }
}