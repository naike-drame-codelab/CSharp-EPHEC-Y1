namespace JeuLabyrinthe
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.b_SolveMaze = new System.Windows.Forms.Button();
            this.l_NbMvts_T = new System.Windows.Forms.Label();
            this.l_NbMvmts = new System.Windows.Forms.Label();
            this.b_Simplifier = new System.Windows.Forms.Button();
            this.b_GenererLaby = new System.Windows.Forms.Button();
            this.l_Largeur = new System.Windows.Forms.Label();
            this.n_Largeur = new System.Windows.Forms.NumericUpDown();
            this.n_Hauteur = new System.Windows.Forms.NumericUpDown();
            this.l_Hauteur = new System.Windows.Forms.Label();
            this.g_Predef = new System.Windows.Forms.GroupBox();
            this.n_NumLaby = new System.Windows.Forms.NumericUpDown();
            this.rb_Non = new System.Windows.Forms.RadioButton();
            this.rb_Oui = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.n_DelaiAffichage = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.n_Largeur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.n_Hauteur)).BeginInit();
            this.g_Predef.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.n_NumLaby)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.n_DelaiAffichage)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // b_SolveMaze
            // 
            this.b_SolveMaze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_SolveMaze.Location = new System.Drawing.Point(805, 515);
            this.b_SolveMaze.Name = "b_SolveMaze";
            this.b_SolveMaze.Size = new System.Drawing.Size(107, 47);
            this.b_SolveMaze.TabIndex = 5;
            this.b_SolveMaze.Text = "Résoudre";
            this.b_SolveMaze.UseVisualStyleBackColor = true;
            this.b_SolveMaze.Click += new System.EventHandler(this.SolveMaze_Click);
            // 
            // l_NbMvts_T
            // 
            this.l_NbMvts_T.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.l_NbMvts_T.AutoSize = true;
            this.l_NbMvts_T.Location = new System.Drawing.Point(805, 573);
            this.l_NbMvts_T.Name = "l_NbMvts_T";
            this.l_NbMvts_T.Size = new System.Drawing.Size(83, 20);
            this.l_NbMvts_T.TabIndex = 1;
            this.l_NbMvts_T.Text = "Nb mvmts:";
            // 
            // l_NbMvmts
            // 
            this.l_NbMvmts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.l_NbMvmts.AutoSize = true;
            this.l_NbMvmts.Location = new System.Drawing.Point(906, 573);
            this.l_NbMvmts.Name = "l_NbMvmts";
            this.l_NbMvmts.Size = new System.Drawing.Size(0, 20);
            this.l_NbMvmts.TabIndex = 8;
            // 
            // b_Simplifier
            // 
            this.b_Simplifier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_Simplifier.Location = new System.Drawing.Point(805, 606);
            this.b_Simplifier.Name = "b_Simplifier";
            this.b_Simplifier.Size = new System.Drawing.Size(107, 47);
            this.b_Simplifier.TabIndex = 6;
            this.b_Simplifier.Text = "Simplifier";
            this.b_Simplifier.UseVisualStyleBackColor = true;
            this.b_Simplifier.Click += new System.EventHandler(this.b_Simplifier_Click);
            // 
            // b_GenererLaby
            // 
            this.b_GenererLaby.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_GenererLaby.Location = new System.Drawing.Point(805, 270);
            this.b_GenererLaby.Name = "b_GenererLaby";
            this.b_GenererLaby.Size = new System.Drawing.Size(107, 64);
            this.b_GenererLaby.TabIndex = 4;
            this.b_GenererLaby.Text = "Générer labyrinthe";
            this.b_GenererLaby.UseVisualStyleBackColor = true;
            this.b_GenererLaby.Click += new System.EventHandler(this.b_GenererLaby_Click);
            // 
            // l_Largeur
            // 
            this.l_Largeur.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Largeur.AutoSize = true;
            this.l_Largeur.Location = new System.Drawing.Point(780, 16);
            this.l_Largeur.Name = "l_Largeur";
            this.l_Largeur.Size = new System.Drawing.Size(64, 20);
            this.l_Largeur.TabIndex = 5;
            this.l_Largeur.Text = "Largeur";
            // 
            // n_Largeur
            // 
            this.n_Largeur.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.n_Largeur.Location = new System.Drawing.Point(856, 14);
            this.n_Largeur.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.n_Largeur.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.n_Largeur.Name = "n_Largeur";
            this.n_Largeur.Size = new System.Drawing.Size(56, 26);
            this.n_Largeur.TabIndex = 0;
            this.n_Largeur.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // n_Hauteur
            // 
            this.n_Hauteur.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.n_Hauteur.Location = new System.Drawing.Point(856, 53);
            this.n_Hauteur.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.n_Hauteur.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.n_Hauteur.Name = "n_Hauteur";
            this.n_Hauteur.Size = new System.Drawing.Size(56, 26);
            this.n_Hauteur.TabIndex = 1;
            this.n_Hauteur.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // l_Hauteur
            // 
            this.l_Hauteur.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Hauteur.AutoSize = true;
            this.l_Hauteur.Location = new System.Drawing.Point(780, 55);
            this.l_Hauteur.Name = "l_Hauteur";
            this.l_Hauteur.Size = new System.Drawing.Size(67, 20);
            this.l_Hauteur.TabIndex = 8;
            this.l_Hauteur.Text = "Hauteur";
            // 
            // g_Predef
            // 
            this.g_Predef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.g_Predef.Controls.Add(this.n_NumLaby);
            this.g_Predef.Controls.Add(this.rb_Non);
            this.g_Predef.Controls.Add(this.rb_Oui);
            this.g_Predef.Location = new System.Drawing.Point(762, 96);
            this.g_Predef.Name = "g_Predef";
            this.g_Predef.Size = new System.Drawing.Size(188, 100);
            this.g_Predef.TabIndex = 2;
            this.g_Predef.TabStop = false;
            this.g_Predef.Text = "Labyrinthe prédéfini?";
            // 
            // n_NumLaby
            // 
            this.n_NumLaby.Location = new System.Drawing.Point(123, 26);
            this.n_NumLaby.Name = "n_NumLaby";
            this.n_NumLaby.Size = new System.Drawing.Size(55, 26);
            this.n_NumLaby.TabIndex = 2;
            // 
            // rb_Non
            // 
            this.rb_Non.AutoSize = true;
            this.rb_Non.Checked = true;
            this.rb_Non.Location = new System.Drawing.Point(7, 57);
            this.rb_Non.Name = "rb_Non";
            this.rb_Non.Size = new System.Drawing.Size(61, 24);
            this.rb_Non.TabIndex = 1;
            this.rb_Non.TabStop = true;
            this.rb_Non.Text = "non";
            this.rb_Non.UseVisualStyleBackColor = true;
            // 
            // rb_Oui
            // 
            this.rb_Oui.AutoSize = true;
            this.rb_Oui.Location = new System.Drawing.Point(7, 26);
            this.rb_Oui.Name = "rb_Oui";
            this.rb_Oui.Size = new System.Drawing.Size(55, 24);
            this.rb_Oui.TabIndex = 0;
            this.rb_Oui.Text = "oui";
            this.rb_Oui.UseVisualStyleBackColor = true;
            this.rb_Oui.CheckedChanged += new System.EventHandler(this.rb_Oui_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(762, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Délai d\'affichage";
            // 
            // n_DelaiAffichage
            // 
            this.n_DelaiAffichage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.n_DelaiAffichage.Location = new System.Drawing.Point(895, 220);
            this.n_DelaiAffichage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.n_DelaiAffichage.Name = "n_DelaiAffichage";
            this.n_DelaiAffichage.Size = new System.Drawing.Size(55, 26);
            this.n_DelaiAffichage.TabIndex = 3;
            this.n_DelaiAffichage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.n_DelaiAffichage.ValueChanged += new System.EventHandler(this.n_DelaiAffichage_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 686);
            this.Controls.Add(this.n_DelaiAffichage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.g_Predef);
            this.Controls.Add(this.n_Hauteur);
            this.Controls.Add(this.l_Hauteur);
            this.Controls.Add(this.n_Largeur);
            this.Controls.Add(this.l_Largeur);
            this.Controls.Add(this.b_GenererLaby);
            this.Controls.Add(this.b_Simplifier);
            this.Controls.Add(this.l_NbMvmts);
            this.Controls.Add(this.l_NbMvts_T);
            this.Controls.Add(this.b_SolveMaze);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Labyrinthe";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.Form1_Layout);
            ((System.ComponentModel.ISupportInitialize)(this.n_Largeur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.n_Hauteur)).EndInit();
            this.g_Predef.ResumeLayout(false);
            this.g_Predef.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.n_NumLaby)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.n_DelaiAffichage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button b_SolveMaze;
        private System.Windows.Forms.Label l_NbMvts_T;
        private System.Windows.Forms.Label l_NbMvmts;
        private System.Windows.Forms.Button b_Simplifier;
        private System.Windows.Forms.Button b_GenererLaby;
        private System.Windows.Forms.Label l_Largeur;
        private System.Windows.Forms.NumericUpDown n_Largeur;
        private System.Windows.Forms.NumericUpDown n_Hauteur;
        private System.Windows.Forms.Label l_Hauteur;
        private System.Windows.Forms.GroupBox g_Predef;
        private System.Windows.Forms.NumericUpDown n_NumLaby;
        private System.Windows.Forms.RadioButton rb_Non;
        private System.Windows.Forms.RadioButton rb_Oui;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown n_DelaiAffichage;
    }
}

