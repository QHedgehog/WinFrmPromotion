
namespace WinFrmPromotion
{
    partial class 测试TaskWait
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
            this.btnWait = new System.Windows.Forms.Button();
            this.btnWaitAll = new System.Windows.Forms.Button();
            this.btnWaitAny = new System.Windows.Forms.Button();
            this.btnDeadLock = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(12, 75);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(893, 349);
            this.txtResult.TabIndex = 3;
            // 
            // btnWait
            // 
            this.btnWait.Location = new System.Drawing.Point(12, 24);
            this.btnWait.Name = "btnWait";
            this.btnWait.Size = new System.Drawing.Size(100, 34);
            this.btnWait.TabIndex = 4;
            this.btnWait.Text = "Wait";
            this.btnWait.UseVisualStyleBackColor = true;
            this.btnWait.Click += new System.EventHandler(this.btnWait_Click);
            // 
            // btnWaitAll
            // 
            this.btnWaitAll.Location = new System.Drawing.Point(138, 24);
            this.btnWaitAll.Name = "btnWaitAll";
            this.btnWaitAll.Size = new System.Drawing.Size(100, 34);
            this.btnWaitAll.TabIndex = 4;
            this.btnWaitAll.Text = "WaitAll";
            this.btnWaitAll.UseVisualStyleBackColor = true;
            this.btnWaitAll.Click += new System.EventHandler(this.btnWaitAll_Click);
            // 
            // btnWaitAny
            // 
            this.btnWaitAny.Location = new System.Drawing.Point(260, 24);
            this.btnWaitAny.Name = "btnWaitAny";
            this.btnWaitAny.Size = new System.Drawing.Size(100, 34);
            this.btnWaitAny.TabIndex = 4;
            this.btnWaitAny.Text = "WaitAny";
            this.btnWaitAny.UseVisualStyleBackColor = true;
            this.btnWaitAny.Click += new System.EventHandler(this.btnWaitAny_Click);
            // 
            // btnDeadLock
            // 
            this.btnDeadLock.Location = new System.Drawing.Point(393, 24);
            this.btnDeadLock.Name = "btnDeadLock";
            this.btnDeadLock.Size = new System.Drawing.Size(100, 34);
            this.btnDeadLock.TabIndex = 4;
            this.btnDeadLock.Text = "DeadLock";
            this.btnDeadLock.UseVisualStyleBackColor = true;
            this.btnDeadLock.Click += new System.EventHandler(this.btnDeadLock_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(534, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 34);
            this.button1.TabIndex = 4;
            this.button1.Text = "WhenAll和WaitAll的区别";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_ClickAsync);
            // 
            // 测试TaskWait
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 500);
            this.Controls.Add(this.btnDeadLock);
            this.Controls.Add(this.btnWaitAny);
            this.Controls.Add(this.btnWaitAll);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnWait);
            this.Controls.Add(this.txtResult);
            this.Name = "测试TaskWait";
            this.Text = "测试TaskAwait";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnWait;
        private System.Windows.Forms.Button btnWaitAll;
        private System.Windows.Forms.Button btnWaitAny;
        private System.Windows.Forms.Button btnDeadLock;
        private System.Windows.Forms.Button button1;
    }
}