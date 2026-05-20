namespace McClean_Teeth
{
    partial class BookingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookingForm));
            this.pnlCard = new System.Windows.Forms.Panel();
            this.pnlInput2 = new SmoothPanel();
            this.pnlInput = new SmoothPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlCard.SuspendLayout();
            this.pnlInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCard
            // 
            this.pnlCard.Controls.Add(this.pnlInput2);
            this.pnlCard.Controls.Add(this.pnlInput);
            this.pnlCard.Location = new System.Drawing.Point(40, 12);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(1456, 783);
            this.pnlCard.TabIndex = 0;
            // 
            // pnlInput2
            // 
            this.pnlInput2.AutoScroll = true;
            this.pnlInput2.AutoScrollMinSize = new System.Drawing.Size(0, 25);
            this.pnlInput2.BackColor = System.Drawing.Color.Transparent;
            this.pnlInput2.Location = new System.Drawing.Point(784, 6);
            this.pnlInput2.Name = "pnlInput2";
            this.pnlInput2.Size = new System.Drawing.Size(657, 777);
            this.pnlInput2.TabIndex = 7;
            // 
            // pnlInput
            // 
            this.pnlInput.AutoScroll = true;
            this.pnlInput.AutoScrollMinSize = new System.Drawing.Size(0, 96);
            this.pnlInput.BackColor = System.Drawing.Color.Transparent;
            this.pnlInput.Controls.Add(this.lblTitle);
            this.pnlInput.Location = new System.Drawing.Point(3, 3);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Size = new System.Drawing.Size(775, 777);
            this.pnlInput.TabIndex = 6;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("MS Reference Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(15, 11);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(552, 60);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "BOOK APPOINTMENT";
            // 
            // BookingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1520, 807);
            this.Controls.Add(this.pnlCard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "BookingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome to McClean Teeth";
            this.pnlCard.ResumeLayout(false);
            this.pnlInput.ResumeLayout(false);
            this.pnlInput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblTitle;
        private SmoothPanel pnlInput;
        private SmoothPanel pnlInput2;
    }
}

