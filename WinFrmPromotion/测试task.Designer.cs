
namespace WinFrmPromotion
{
    partial class 测试task
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
            this.btnSynch = new System.Windows.Forms.Button();
            this.btnAsynch = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnconcurrenceAsync = new System.Windows.Forms.Button();
            this.btnAsyncCallBack = new System.Windows.Forms.Button();
            this.btnEvent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSynch
            // 
            this.btnSynch.Location = new System.Drawing.Point(12, 47);
            this.btnSynch.Name = "btnSynch";
            this.btnSynch.Size = new System.Drawing.Size(128, 50);
            this.btnSynch.TabIndex = 1;
            this.btnSynch.Text = "同步";
            this.btnSynch.UseVisualStyleBackColor = true;
            this.btnSynch.Click += new System.EventHandler(this.btnSynch_Click);
            // 
            // btnAsynch
            // 
            this.btnAsynch.Location = new System.Drawing.Point(166, 47);
            this.btnAsynch.Name = "btnAsynch";
            this.btnAsynch.Size = new System.Drawing.Size(128, 50);
            this.btnAsynch.TabIndex = 1;
            this.btnAsynch.Text = "异步";
            this.btnAsynch.UseVisualStyleBackColor = true;
            this.btnAsynch.Click += new System.EventHandler(this.BtnAsynch_Click);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(12, 116);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(787, 332);
            this.txtResult.TabIndex = 2;
            // 
            // btnconcurrenceAsync
            // 
            this.btnconcurrenceAsync.Location = new System.Drawing.Point(320, 47);
            this.btnconcurrenceAsync.Name = "btnconcurrenceAsync";
            this.btnconcurrenceAsync.Size = new System.Drawing.Size(128, 50);
            this.btnconcurrenceAsync.TabIndex = 1;
            this.btnconcurrenceAsync.Text = "并发";
            this.btnconcurrenceAsync.UseVisualStyleBackColor = true;
            this.btnconcurrenceAsync.Click += new System.EventHandler(this.btnconcurrenceAsync_Click);
            // 
            // btnAsyncCallBack
            // 
            this.btnAsyncCallBack.Location = new System.Drawing.Point(474, 47);
            this.btnAsyncCallBack.Name = "btnAsyncCallBack";
            this.btnAsyncCallBack.Size = new System.Drawing.Size(128, 50);
            this.btnAsyncCallBack.TabIndex = 1;
            this.btnAsyncCallBack.Text = "异步回调";
            this.btnAsyncCallBack.UseVisualStyleBackColor = true;
            this.btnAsyncCallBack.Click += new System.EventHandler(this.btnAsyncCallBack_ClickAsync);
            // 
            // btnEvent
            // 
            this.btnEvent.Location = new System.Drawing.Point(626, 47);
            this.btnEvent.Name = "btnEvent";
            this.btnEvent.Size = new System.Drawing.Size(128, 50);
            this.btnEvent.TabIndex = 1;
            this.btnEvent.Text = "事件";
            this.btnEvent.UseVisualStyleBackColor = true;
            this.btnEvent.Click += new System.EventHandler(this.btnEvent_Click);
            // 
            // 测试task
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 553);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnconcurrenceAsync);
            this.Controls.Add(this.btnEvent);
            this.Controls.Add(this.btnAsyncCallBack);
            this.Controls.Add(this.btnAsynch);
            this.Controls.Add(this.btnSynch);
            this.Name = "测试task";
            this.Text = "测试task";
            this.Load += new System.EventHandler(this.测试task_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSynch;
        private System.Windows.Forms.Button btnAsynch;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnconcurrenceAsync;
        private System.Windows.Forms.Button btnAsyncCallBack;
        private System.Windows.Forms.Button btnEvent;
    }
}