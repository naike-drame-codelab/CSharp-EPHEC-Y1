using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;
using System.Reflection;

namespace JeuLabyrinthe
{
    public partial class Form1 : Form
    {
        private int SquareSize;
        private int HStart;
        private int VStart;
        private Color CouleurLong = Color.DarkCyan;
        private Color CouleurCourt = Color.DarkRed;
        private Color CouleurCourante;
        private int TimeLapse;
        private System.Drawing.Bitmap MyBitmap;

        private Labyrinthe Laby;
        private int LargeurLaby = 20;
        private int HauteurLaby = 20;
        private Voyageur Voy;
        private Trajet TrajetAutomatique;
        private int NbPas;

        public Form1()
        {
            this.ResizeRedraw = true;
            this.TimeLapse = 50;

            Laby = new Labyrinthe(LargeurLaby, HauteurLaby, 1);
            Voy = new Voyageur(Laby);

            InitializeComponent();

            n_Largeur.Value = 20;
            n_Hauteur.Value = 20;
            n_NumLaby.Value = 1;
            n_DelaiAffichage.Value = 50;
            rb_Oui.Checked = true;
            b_Simplifier.Enabled = false;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(MyBitmap, 0, 0);//, MyBitmap.Width, MyBitmap.Height);
            g.Dispose();
        }
        private void DrawLaby()
        {

            // TODO: pas sûr que ce soit la manière standard de traiter ce cas
            if (this.WindowState == FormWindowState.Minimized)
                return;

            // TODO: dois-je appeler Dispose pour le bitmap qq part (genre la ligne ci-dessous) ?
            if (MyBitmap != null) MyBitmap.Dispose(); // clever or stupid?
            MyBitmap = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            using (Graphics g = Graphics.FromImage(MyBitmap))
            {
                g.Clear(this.BackColor);
                AdjustCellSize();

                using (Pen CrayonNoir = new Pen(Color.Black, 1))
                {
                    for (int PosH = 0; PosH < Laby.Largeur; PosH++)
                        for (int PosV = 0; PosV < Laby.Hauteur; PosV++)
                        {
                            DrawCell(PosH, PosV, g, CrayonNoir);
                        }
                    DrawTraveller(Voy.Pos, true, CouleurLong);
                }
            }
        }

        private void DrawCell(int PosH, int PosV, Graphics G, Pen P)
        {
            int H1 = HStart + SquareSize * PosH;
            int H2 = H1 + SquareSize;
            int V1 = VStart + SquareSize * PosV;
            int V2 = V1 + SquareSize;

            if ((PosV == 0) && (Laby.GetCell(PosH, PosV).MurHaut)) G.DrawLine(P, H1, V1, H2, V1);
            if (Laby.GetCell(PosH, PosV).MurBas) G.DrawLine(P, H1, V2, H2, V2);
            if ((PosH == 0) && (Laby.GetCell(PosH, PosV).MurGauche)) G.DrawLine(P, H1, V1, H1, V2);
            if (Laby.GetCell(PosH, PosV).MurDroit) G.DrawLine(P, H2, V1, H2, V2);
        }
        private void DrawTraveller(Position Pos, bool Draw, Color Col)
        // Draw = true pour dessiner, false pour effacer
        {
            using (Graphics G = this.CreateGraphics())
            {
                Color FillCol;
                if (Draw) FillCol = Col;
                else FillCol = this.BackColor;
                using (Brush B = new SolidBrush(FillCol))
                {
                    using (Pen P = new Pen(Col))
                    {
                        int CX = HStart + SquareSize * Pos.PosH + SquareSize / 4;
                        int CY = VStart + SquareSize * Pos.PosV + SquareSize / 4;
                        G.FillEllipse(B, CX, CY, SquareSize / 2, SquareSize / 2);
                        G.DrawEllipse(P, CX, CY, SquareSize / 2, SquareSize / 2);
                    }
                }
            }
        }
        private void AdjustCellSize()
        {
            Size S = this.ClientSize;
            int W = (S.Width - 2 * this.b_SolveMaze.Width) / (Laby.Largeur + 2);
            int H = S.Height / (Laby.Hauteur + 2);
            SquareSize = Min(H, W);       // Je veux des cases carrées
            HStart = (S.Width - SquareSize * Laby.Largeur) / 2 - this.b_SolveMaze.Width / 2;
            VStart = (S.Height - SquareSize * Laby.Hauteur) / 2;
        }
        private static int Min(int a, int b)
        {
            if (a < b) return a;
            else return b;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Up) || (e.KeyCode == Keys.Down) || (e.KeyCode == Keys.Left) || (e.KeyCode == Keys.Right))
            {
                Direction mvt = null;
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        mvt = Direction.Haut;
                        break;
                    case Keys.Down:
                        mvt = Direction.Bas;
                        break;
                    case Keys.Left:
                        mvt = Direction.Gauche;
                        break;
                    case Keys.Right:
                        mvt = Direction.Droite;
                        break;
                }
                MoveTraveller(mvt);
                e.Handled = true;
            }
        }
        private bool MoveTraveller(Direction Mvt)
        {
            DrawTraveller(Voy.Pos, false, CouleurCourante);
            if (Voy.PeutBouger(Mvt))
                Voy.DeplacerImprudemment(Mvt);
            else
                return false;
            DrawTraveller(Voy.Pos, true, CouleurCourante);
            if (Voy.Pos == Laby.PosArrivee) System.Media.SystemSounds.Exclamation.Play();
            return true;
        }

        private void SolveMaze_Click(object sender, EventArgs e)
        {
            this.timer1.Stop();
            ResolveurLabyrinthe Solver = new ResolveurLabyrintheSolEtudiant();
            Voy = new Voyageur(Laby);
            TrajetAutomatique = Solver.Resoudre(this.Laby);
            this.NbPas = 0;
            this.CouleurCourante = CouleurLong;
            this.timer1.Interval = this.TimeLapse;
            this.timer1.Start();
        }

        private void PlayCrashSound()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"..\..\Data\Smashing-Yuri_Santana-1233262689.wav");
            SoundPlayer sound = new SoundPlayer(path);
            sound.Play();

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Direction Dir = TrajetAutomatique.LireProchainMouvement();
            if (Dir != null)
            {
                Graphics G = this.CreateGraphics();
                if (!MoveTraveller(Dir))
                {
                    PlayCrashSound();
                    this.timer1.Stop();
                }
                this.NbPas++;
                this.l_NbMvmts.Text = this.NbPas.ToString();
            }
            else
            {
                this.timer1.Stop();
                b_Simplifier.Enabled = true;
            }

        }

        private void b_Simplifier_Click(object sender, EventArgs e)
        {
            this.timer1.Stop();
            TrajetAutomatique.Simplifier();
            TrajetAutomatique.RelireAuDebut();
            this.DrawTraveller(Voy.Pos, true, CouleurCourante);
            CouleurCourante = CouleurCourt;
            this.NbPas = 0;
            Voy = new Voyageur(Laby);
            this.timer1.Start();
        }

        private void Form1_Layout(object sender, LayoutEventArgs e)
        {
            DrawLaby();
        }

        private void b_GenererLaby_Click(object sender, EventArgs e)
        {
            this.timer1.Stop();
            int Seed;
            LargeurLaby = Decimal.ToInt32(n_Largeur.Value);
            HauteurLaby = Decimal.ToInt32(n_Hauteur.Value);
            if (rb_Oui.Checked)
            {
                Seed = Decimal.ToInt32(n_NumLaby.Value);
                Laby = new Labyrinthe(LargeurLaby, HauteurLaby,Seed);
            }
            else Laby = new Labyrinthe(LargeurLaby, HauteurLaby);
            Voy = new Voyageur(Laby);
            b_Simplifier.Enabled = false;
            this.DrawLaby();
            this.Invalidate();
        }

        private void rb_Oui_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_Oui.Checked)
                n_NumLaby.Enabled = true;
            else
                n_NumLaby.Enabled = false;
        }

        private void n_DelaiAffichage_ValueChanged(object sender, EventArgs e)
        {
            TimeLapse = Decimal.ToInt32(n_DelaiAffichage.Value);
        }
    }
}