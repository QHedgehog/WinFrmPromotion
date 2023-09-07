
namespace WinFrmPromotion
{
    partial class 阻塞队列
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
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPause1 = new System.Windows.Forms.Button();
            this.btnEnqueue1 = new System.Windows.Forms.Button();
            this.btnContinue1 = new System.Windows.Forms.Button();
            this.btnPause2 = new System.Windows.Forms.Button();
            this.btnEnqueue2 = new System.Windows.Forms.Button();
            this.btnContinue2 = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnDequeue = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnContinue3 = new System.Windows.Forms.Button();
            this.btnPause3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(144, 59);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(78, 29);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "启动队列";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStartQueue_Click);
            // 
            // btnPause1
            // 
            this.btnPause1.Location = new System.Drawing.Point(312, 59);
            this.btnPause1.Name = "btnPause1";
            this.btnPause1.Size = new System.Drawing.Size(46, 29);
            this.btnPause1.TabIndex = 0;
            this.btnPause1.Tag = "1";
            this.btnPause1.Text = "暂停";
            this.btnPause1.UseVisualStyleBackColor = true;
            this.btnPause1.Click += new System.EventHandler(this.btnStopEnqueue_Click);
            // 
            // btnEnqueue1
            // 
            this.btnEnqueue1.Location = new System.Drawing.Point(228, 59);
            this.btnEnqueue1.Name = "btnEnqueue1";
            this.btnEnqueue1.Size = new System.Drawing.Size(78, 29);
            this.btnEnqueue1.TabIndex = 0;
            this.btnEnqueue1.Text = "入队线程1";
            this.btnEnqueue1.UseVisualStyleBackColor = true;
            this.btnEnqueue1.Click += new System.EventHandler(this.btnEnqueue_Click);
            // 
            // btnContinue1
            // 
            this.btnContinue1.Location = new System.Drawing.Point(361, 59);
            this.btnContinue1.Name = "btnContinue1";
            this.btnContinue1.Size = new System.Drawing.Size(46, 29);
            this.btnContinue1.TabIndex = 0;
            this.btnContinue1.Tag = "1";
            this.btnContinue1.Text = "继续";
            this.btnContinue1.UseVisualStyleBackColor = true;
            this.btnContinue1.Click += new System.EventHandler(this.btnContinueEnqueue_Click);
            // 
            // btnPause2
            // 
            this.btnPause2.Location = new System.Drawing.Point(312, 94);
            this.btnPause2.Name = "btnPause2";
            this.btnPause2.Size = new System.Drawing.Size(46, 29);
            this.btnPause2.TabIndex = 0;
            this.btnPause2.Tag = "2";
            this.btnPause2.Text = "暂停";
            this.btnPause2.UseVisualStyleBackColor = true;
            this.btnPause2.Click += new System.EventHandler(this.btnStopEnqueue_Click);
            // 
            // btnEnqueue2
            // 
            this.btnEnqueue2.Location = new System.Drawing.Point(228, 94);
            this.btnEnqueue2.Name = "btnEnqueue2";
            this.btnEnqueue2.Size = new System.Drawing.Size(78, 29);
            this.btnEnqueue2.TabIndex = 0;
            this.btnEnqueue2.Text = "入队线程2";
            this.btnEnqueue2.UseVisualStyleBackColor = true;
            this.btnEnqueue2.Click += new System.EventHandler(this.btnEnqueue2_Click);
            // 
            // btnContinue2
            // 
            this.btnContinue2.Location = new System.Drawing.Point(360, 94);
            this.btnContinue2.Name = "btnContinue2";
            this.btnContinue2.Size = new System.Drawing.Size(46, 29);
            this.btnContinue2.TabIndex = 0;
            this.btnContinue2.Tag = "2";
            this.btnContinue2.Text = "继续";
            this.btnContinue2.UseVisualStyleBackColor = true;
            this.btnContinue2.Click += new System.EventHandler(this.btnContinueEnqueue_Click);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(144, 162);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(263, 337);
            this.txtResult.TabIndex = 1;
            // 
            // btnDequeue
            // 
            this.btnDequeue.Location = new System.Drawing.Point(228, 127);
            this.btnDequeue.Name = "btnDequeue";
            this.btnDequeue.Size = new System.Drawing.Size(78, 29);
            this.btnDequeue.TabIndex = 2;
            this.btnDequeue.Text = "出队线程";
            this.btnDequeue.UseVisualStyleBackColor = true;
            this.btnDequeue.Click += new System.EventHandler(this.btnDequeue_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(144, 94);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 29);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "关闭队列";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnContinue3
            // 
            this.btnContinue3.Location = new System.Drawing.Point(361, 127);
            this.btnContinue3.Name = "btnContinue3";
            this.btnContinue3.Size = new System.Drawing.Size(46, 29);
            this.btnContinue3.TabIndex = 4;
            this.btnContinue3.Tag = "3";
            this.btnContinue3.Text = "继续";
            this.btnContinue3.UseVisualStyleBackColor = true;
            this.btnContinue3.Click += new System.EventHandler(this.btnContinueEnqueue_Click);
            // 
            // btnPause3
            // 
            this.btnPause3.Location = new System.Drawing.Point(312, 127);
            this.btnPause3.Name = "btnPause3";
            this.btnPause3.Size = new System.Drawing.Size(46, 29);
            this.btnPause3.TabIndex = 5;
            this.btnPause3.Tag = "3";
            this.btnPause3.Text = "暂停";
            this.btnPause3.UseVisualStyleBackColor = true;
            this.btnPause3.Click += new System.EventHandler(this.btnStopEnqueue_Click);
            // 
            // 阻塞队列
            // 
            this.ClientSize = new System.Drawing.Size(1156, 691);
            this.Controls.Add(this.btnContinue3);
            this.Controls.Add(this.btnPause3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDequeue);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnContinue2);
            this.Controls.Add(this.btnContinue1);
            this.Controls.Add(this.btnEnqueue2);
            this.Controls.Add(this.btnPause2);
            this.Controls.Add(this.btnEnqueue1);
            this.Controls.Add(this.btnPause1);
            this.Controls.Add(this.btnStart);
            this.Name = "阻塞队列";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion









        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnPause1;
        private System.Windows.Forms.Button btnEnqueue1;
        private System.Windows.Forms.Button btnContinue1;
        private System.Windows.Forms.Button btnPause2;
        private System.Windows.Forms.Button btnEnqueue2;
        private System.Windows.Forms.Button btnContinue2;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnDequeue;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnContinue3;
        private System.Windows.Forms.Button btnPause3;
    }
}