
namespace Git_first
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
            this.UI_lbl_massVal = new System.Windows.Forms.Label();
            this.UI_lbl_mass = new System.Windows.Forms.Label();
            this.UI_tbox_formula = new System.Windows.Forms.TextBox();
            this.UI_lbl_cFor = new System.Windows.Forms.Label();
            this.UI_btn_sortByAtomic = new System.Windows.Forms.Button();
            this.UI_btn_single = new System.Windows.Forms.Button();
            this.UI_btn_sortByName = new System.Windows.Forms.Button();
            this.UI_DataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.UI_DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // UI_lbl_massVal
            // 
            this.UI_lbl_massVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UI_lbl_massVal.Font = new System.Drawing.Font("Gulim", 13F);
            this.UI_lbl_massVal.Location = new System.Drawing.Point(1117, 611);
            this.UI_lbl_massVal.Name = "UI_lbl_massVal";
            this.UI_lbl_massVal.Size = new System.Drawing.Size(310, 46);
            this.UI_lbl_massVal.TabIndex = 15;
            this.UI_lbl_massVal.Text = "label3";
            this.UI_lbl_massVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UI_lbl_mass
            // 
            this.UI_lbl_mass.AutoSize = true;
            this.UI_lbl_mass.Font = new System.Drawing.Font("Gulim", 13F);
            this.UI_lbl_mass.Location = new System.Drawing.Point(813, 621);
            this.UI_lbl_mass.Name = "UI_lbl_mass";
            this.UI_lbl_mass.Size = new System.Drawing.Size(85, 26);
            this.UI_lbl_mass.TabIndex = 14;
            this.UI_lbl_mass.Text = "label2";
            // 
            // UI_tbox_formula
            // 
            this.UI_tbox_formula.Font = new System.Drawing.Font("Gulim", 13F);
            this.UI_tbox_formula.Location = new System.Drawing.Point(297, 609);
            this.UI_tbox_formula.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UI_tbox_formula.MaximumSize = new System.Drawing.Size(450, 45);
            this.UI_tbox_formula.MinimumSize = new System.Drawing.Size(450, 45);
            this.UI_tbox_formula.Multiline = true;
            this.UI_tbox_formula.Name = "UI_tbox_formula";
            this.UI_tbox_formula.Size = new System.Drawing.Size(450, 45);
            this.UI_tbox_formula.TabIndex = 13;
            // 
            // UI_lbl_cFor
            // 
            this.UI_lbl_cFor.AutoSize = true;
            this.UI_lbl_cFor.Font = new System.Drawing.Font("Gulim", 13F);
            this.UI_lbl_cFor.Location = new System.Drawing.Point(66, 619);
            this.UI_lbl_cFor.Name = "UI_lbl_cFor";
            this.UI_lbl_cFor.Size = new System.Drawing.Size(85, 26);
            this.UI_lbl_cFor.TabIndex = 12;
            this.UI_lbl_cFor.Text = "label1";
            // 
            // UI_btn_sortByAtomic
            // 
            this.UI_btn_sortByAtomic.Location = new System.Drawing.Point(1117, 151);
            this.UI_btn_sortByAtomic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UI_btn_sortByAtomic.Name = "UI_btn_sortByAtomic";
            this.UI_btn_sortByAtomic.Size = new System.Drawing.Size(310, 61);
            this.UI_btn_sortByAtomic.TabIndex = 11;
            this.UI_btn_sortByAtomic.Text = "button3";
            this.UI_btn_sortByAtomic.UseVisualStyleBackColor = true;
            // 
            // UI_btn_single
            // 
            this.UI_btn_single.Location = new System.Drawing.Point(1117, 81);
            this.UI_btn_single.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UI_btn_single.Name = "UI_btn_single";
            this.UI_btn_single.Size = new System.Drawing.Size(310, 61);
            this.UI_btn_single.TabIndex = 10;
            this.UI_btn_single.Text = "button2";
            this.UI_btn_single.UseVisualStyleBackColor = true;
            // 
            // UI_btn_sortByName
            // 
            this.UI_btn_sortByName.Location = new System.Drawing.Point(1117, 12);
            this.UI_btn_sortByName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UI_btn_sortByName.Name = "UI_btn_sortByName";
            this.UI_btn_sortByName.Size = new System.Drawing.Size(310, 61);
            this.UI_btn_sortByName.TabIndex = 9;
            this.UI_btn_sortByName.Text = "button1";
            this.UI_btn_sortByName.UseVisualStyleBackColor = true;
            // 
            // UI_DataGridView
            // 
            this.UI_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UI_DataGridView.Location = new System.Drawing.Point(71, 12);
            this.UI_DataGridView.Name = "UI_DataGridView";
            this.UI_DataGridView.RowHeadersWidth = 62;
            this.UI_DataGridView.RowTemplate.Height = 28;
            this.UI_DataGridView.Size = new System.Drawing.Size(1040, 572);
            this.UI_DataGridView.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1457, 668);
            this.Controls.Add(this.UI_lbl_massVal);
            this.Controls.Add(this.UI_lbl_mass);
            this.Controls.Add(this.UI_tbox_formula);
            this.Controls.Add(this.UI_lbl_cFor);
            this.Controls.Add(this.UI_btn_sortByAtomic);
            this.Controls.Add(this.UI_btn_single);
            this.Controls.Add(this.UI_btn_sortByName);
            this.Controls.Add(this.UI_DataGridView);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.UI_DataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UI_lbl_massVal;
        private System.Windows.Forms.Label UI_lbl_mass;
        private System.Windows.Forms.TextBox UI_tbox_formula;
        private System.Windows.Forms.Label UI_lbl_cFor;
        private System.Windows.Forms.Button UI_btn_sortByAtomic;
        private System.Windows.Forms.Button UI_btn_single;
        private System.Windows.Forms.Button UI_btn_sortByName;
        private System.Windows.Forms.DataGridView UI_DataGridView;
    }
}

