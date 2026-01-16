using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace JocDeSah
{


    class Piesa
    {
        protected int x, y, w, h;
        protected int col = -1;
        protected Image img;

        public int X
        {
            get { return x; }
            set { this.x = value; }
        }
        public int Y
        {
            get { return y; }
            set { this.y = value; }
        }

        public int W
        {
            get { return w; }
            set { this.w = value; }
        }

        public int H
        {
            get { return h; }
            set { this.h = value; }
        }

        public int COL
        {
            get { return col; }
        }

        public bool este_deasupra(int x, int y)
        {
            if (x < this.x) return false;
            if (x > this.x + w) return false;
            if (y < this.y) return false;
            if (y > this.y + h) return false;

            return true;
        }


        public void deseneaza(Graphics g)
        {
            g.DrawImage(img, x, y, w, h);
        }

        public virtual bool mutare_valida(JocSah joc, int linStart, int colStart, int linStop, int colStop, int ocupat)//ocupat: 0 - liber, 1 - alb, 2 - negru
        {
            return true;
        }


        public void afisare_mutari(Graphics g, JocSah joc, int linStart, int colStart)
        {
            int l = joc.LatimePatratel;

            Brush mutareNormala = new SolidBrush(Color.FromArgb(100, Color.Green));
            Brush captura = new SolidBrush(Color.FromArgb(150, Color.Red));

            for (int linStop = 3; linStop <= 10; linStop++)
            {
                for (int colStop = 1; colStop <= 8; colStop++)
                {
                    if (linStop == linStart && colStop == colStart)
                        continue;

                    int x = linStop * l + l / 2;
                    int y = colStop * l + l / 2;

                    Piesa piesaDesub = joc.da_piesa_desub(this, x, y);
                    int ocupat = -1;  // -1 = liber
                    if (piesaDesub != null)
                        ocupat = piesaDesub.COL;

                    if (this.mutare_valida(joc, linStart, colStart, linStop, colStop, ocupat))
                    {
                        int r = l / 6;
                        Brush brush = (ocupat != -1) ? captura : mutareNormala;
                        g.FillEllipse(brush, x - r, y - r, 2 * r, 2 * r);
                    }
                }
            }
        }


    }

    class Rege : Piesa
    {
        public Rege(int col, int x, int y, int w, int h)//col = 0 pt alb, 1 pt negru
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
            this.col = col;
            if (this.col == 0)
            {
                this.img = Image.FromFile("regeN.gif");
            }
            else
            {
                this.img = Image.FromFile("rege.gif");
            }
        }
        public override bool mutare_valida(JocSah joc, int linStart, int colStart, int linStop, int colStop, int ocupat)
        {

            if (linStop > 10 || linStop < 3 || colStop > 8 || colStop < 1) return false;

            if (linStart == linStop && colStart == colStop)
                return false;

            int dx = Math.Abs(linStart - linStop);
            int dy = Math.Abs(colStart - colStop);

            return (dx <= 1 && dy <= 1) && (ocupat != this.COL);
        }


    }

    class Regina : Piesa
    {
        public Regina(int col, int x, int y, int w, int h)//col = 0 pt alb, 1 pt negru
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
            this.col = col;
            if (this.col == 0)
            {
                this.img = Image.FromFile("reginaN.gif");
            }
            else
            {
                this.img = Image.FromFile("regina.gif");
            }
        }

        public override bool mutare_valida(JocSah joc, int linStart, int colStart, int linStop, int colStop, int ocupat)
        {

            if (linStop > 10 || linStop < 3 || colStop > 8 || colStop < 1) return false;
            if (linStart == linStop && colStart == colStop)
                return false;

            if (ocupat == this.COL)
                return false;

            bool diagonala = Math.Abs(linStart - linStop) == Math.Abs(colStart - colStop);
            bool linie = linStart == linStop || colStart == colStop;

            return (diagonala || linie) && joc.drum_liber(this, linStart, colStart, linStop, colStop);
        }
    }

    class Nebun : Piesa
    {
        public Nebun(int col, int x, int y, int w, int h)//col = 0 pt alb, 1 pt negru
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
            this.col = col;
            if (this.col == 0)
            {
                this.img = Image.FromFile("nebunN.gif");
            }
            else
            {
                this.img = Image.FromFile("nebun.gif");
            }
        }

        public override bool mutare_valida(JocSah joc, int linStart, int colStart, int linStop, int colStop, int ocupat)
        {
            if (linStop > 10 || linStop < 3 || colStop > 8 || colStop < 1) return false;
            if (linStart == linStop && colStart == colStop)
                return false;

            if (ocupat == this.COL)
                return false;

            return (Math.Abs(linStart - linStop) == Math.Abs(colStart - colStop)) &&
                   joc.drum_liber(this, linStart, colStart, linStop, colStop);
        }
    }
    class Cal : Piesa
    {
        public Cal(int col, int x, int y, int w, int h)//col = 0 pt alb, 1 pt negru
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
            this.col = col;
            if (this.col == 0)
            {
                this.img = Image.FromFile("CalN.gif");
            }
            else
            {
                this.img = Image.FromFile("Cal.gif");
            }
        }

        public override bool mutare_valida(JocSah joc, int linStart, int colStart, int linStop, int colStop, int ocupat)
        {
            if (linStop > 10 || linStop < 3 || colStop > 8 || colStop < 1) return false;
            if (linStart == linStop && colStart == colStop)
                return false;

            if (ocupat == this.COL)
                return false;

            int dx = Math.Abs(linStart - linStop);
            int dy = Math.Abs(colStart - colStop);

            return (dx == 2 && dy == 1) || (dx == 1 && dy == 2);
        }
    }

    class Turn : Piesa
    {
        public Turn(int col, int x, int y, int w, int h)//col = 0 pt alb, 1 pt negru
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
            this.col = col;
            if (this.col == 0)
            {
                this.img = Image.FromFile("turnN.gif");
            }
            else
            {
                this.img = Image.FromFile("turn.gif");
            }
        }

        public override bool mutare_valida(JocSah joc, int linStart, int colStart, int linStop, int colStop, int ocupat)
        {
            if (linStop > 10 || linStop < 3 || colStop > 8 || colStop < 1) return false;
            if (linStart == linStop && colStart == colStop)
                return false;

            if (ocupat == this.COL)
                return false;

            bool inLinie = linStart == linStop || colStart == colStop;
            return inLinie && joc.drum_liber(this, linStart, colStart, linStop, colStop);
        }
    }
    class Pion : Piesa
    {
        public Pion(int col, int x, int y, int w, int h)//col = 0 negru, 1 pt alb
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
            this.col = col;
            if (this.col == 0)
            {
                this.img = Image.FromFile("pionN.gif");
            }
            else
            {
                this.img = Image.FromFile("pion.gif");
            }
        }

        public override bool mutare_valida(JocSah joc, int linStart, int colStart, int linStop, int colStop, int ocupat)
        {
            if (linStop > 10 || linStop < 3 || colStop > 8 || colStop < 1) return false;
            int dir = (this.COL == 1) ? -1 : 1;

            if (linStart == linStop && ocupat == -1)
            {
                if (colStop - colStart == dir)
                    return true;

                if (colStop - colStart == 2 * dir && ((COL == 1 && colStart == 7) || (COL == 0 && colStart == 2)) && 
                    joc.drum_liber(this,linStart, colStart, linStop, colStop))
                    return true;
            }

            if (Math.Abs(linStop - linStart) == 1 &&
            colStop - colStart == dir &&
            ocupat != -1 && ocupat != this.COL)
                return true;

            return false;
        }

    }

    class JocSah
    {
        int w, h, l;
        int startX;
        int startY;
        List<Piesa> piese;
        List<Piesa> piese_capturate;
        Graphics g;


        public JocSah(int w, int h, Graphics g)
        {

            this.h = h;
            this.g = g;
            this.w = w;
            l = h / 10;
            this.startX = (w - 8 * l) / 2;
            this.startY = (h - 8 * l) / 2;
            
        }

        public int LatimePatratel
        {
            get { return l; }
        }


        void deseneaza_tabla_sah()
        {
            g.Clear(Color.White);


            int startX = (w - 8 * l) / 2;
            int startY = (h - 8 * l) / 2;

            Pen creion = new Pen(Color.Black, 3);
            Pen margine = new Pen(Color.SaddleBrown, 30);
            
            Brush col1 = Brushes.Maroon;
            Brush col2 = Brushes.LightCyan;
            System.Drawing.Font f = new System.Drawing.Font("Times New Roman", 14, FontStyle.Bold);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            g.DrawImage(Image.FromFile("fundal.gif"), 0, 0, w, h);

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    g.FillRectangle((i + j) % 2 == 0 ? col1 : col2, startX + i * l, startY + j * l, l, l);
                }
            }
           
            g.DrawLine(margine, startX-15, startY -15, startX + 8 * l+15, startY -15);
            g.DrawLine(margine, startX -15, startY-30, startX -15, startY + 8 * l+30);
            g.DrawLine(margine, startX - 15, startY + 8 * l + 15, startX + 8 * l + 15, startY + 8 * l + 15);       
            g.DrawLine(margine, startX + 8*l+ 17, startY - 30, startX + 8 * l + 17, startY + 8 * l + 30);

            for (int i = 0; i <= 8; i++)
            {
                g.DrawLine(creion, startX, startY + i * l, startX + 8 * l, startY + i * l);
                g.DrawLine(creion, startX + i * l, startY, startX + i * l, startY + 8 * l);
            }
            for (int i = 0; i < 8; i++)
            {
                g.DrawString((i + 1).ToString(), f, Brushes.Black, new Rectangle(startX - l / 2, startY + i * l, l / 2, l), sf);
                g.DrawString(((char)(i + 'a')).ToString(), f, Brushes.Black, new Rectangle(startX + i * l, startY + 8 * l, l, l / 2), sf);
            }

            g.FillRectangle(Brushes.Black, new Rectangle(620, 0, 247, 25));
            g.DrawString("it's your turn", f, Brushes.White, new Rectangle(695, 0,147, 25), sf);
            

        }

        public bool drum_liber(Piesa p, int linStart, int colStart, int linStop, int colStop)
        {
            int dLin = linStop - linStart;
            int dCol = colStop - colStart;

            int pasLin = Math.Sign(dLin);
            int pasCol = Math.Sign(dCol);

            int lin = linStart + pasLin;
            int col = colStart + pasCol;

            while (lin != linStop || col != colStop)
            {
                foreach (Piesa piesa in piese)
                {

                    int linPiesa = this.daLinie(piesa.X);
                    int colPiesa = this.daColoana(piesa.Y);

                    if (lin == linPiesa && col == colPiesa && piesa != p)
                        return false; // o piesă blochează drumul
                }

                lin += pasLin;
                col += pasCol;
            }

            return true; // nu există nicio piesă pe drum
        }


        public void captureaza_piesa(Piesa p)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer("move-self.wav");
            player.Play();
            if (p != null)
            {
                player = new System.Media.SoundPlayer("capture.wav");
                player.Play();
                piese.Remove(p);
                piese_capturate.Add(p);
                if (p.COL == 0)
                {
                    p.X = (this.piese_albe_capturate() / 9 + 12) * l;
                    p.Y = (this.piese_albe_capturate() % 9) * l;
                }
                if (p.COL == 1)
                {
                    p.X = (this.piese_negre_capturate() / 9) * l;
                    p.Y = (this.piese_negre_capturate() % 9) * l;
                }
            }
        }

        public int piese_albe_capturate()
        {
            int count = 0;
            foreach (Piesa piesa in piese_capturate)
            {
                if (piesa.COL == 0)
                {
                    count++;
                }
            }
            return count;
        }

        public int piese_negre_capturate()
        {
            int count = 0;
            foreach (Piesa piesa in piese_capturate)
            {
                if (piesa.COL == 1)
                {
                    count++;
                }
            }
            return count;
        }

        public void deseneaza()
        {
            

    
            deseneaza_tabla_sah();
            foreach (Piesa piesa in piese)
            {
                piesa.deseneaza(g);
            }
            foreach (Piesa piesa in piese_capturate)
            {
                piesa.deseneaza(g);
            }
        }

        public void jocNou()
        {
            piese = new List<Piesa>();
            piese_capturate = new List<Piesa>();
            for (int i = 0; i < 8; i++) piese.Add(new Pion(0, 0, 0, l / 2, l * 2 / 3));//negru
            for (int i = 0; i < 8; i++) piese.Add(new Pion(1, 0, 0, l / 2, l * 2 / 3));//alb
            for (int i = 0; i < 2; i++) piese.Add(new Turn(0, 0, 0, 3 * l / 4, l * 2 / 3));//negru
            for (int i = 0; i < 2; i++) piese.Add(new Turn(1, 0, 0, 3 * l / 4, l * 2 / 3));//alb
            for (int i = 0; i < 2; i++) piese.Add(new Cal(0, 0, 0, 3 * l / 4, l * 2 / 3));//negru
            for (int i = 0; i < 2; i++) piese.Add(new Cal(1, 0, 0, 3 * l / 4, l * 2 / 3));//alb
            for (int i = 0; i < 2; i++) piese.Add(new Nebun(0, 0, 0, 3 * l / 4, l * 2 / 3));//negru
            for (int i = 0; i < 2; i++) piese.Add(new Nebun(1, 0, 0, 3 * l / 4, l * 2 / 3));//alb
            piese.Add(new Rege(0, 0, 0, l, l * 2 / 3));
            piese.Add(new Rege(1, 0, 0, l, l * 2 / 3));
            piese.Add(new Regina(0, 0, 0, l, l * 2 / 3));
            piese.Add(new Regina(1, 0, 0, l, l * 2 / 3));
            aseaza_piese();
            deseneaza();

        }

        public void aseaza_piese()
        {

            for (int i = 0; i < 8; i++)
                aseaza_piesa(piese[i], (i + 1 + 2) * l, 2 * l);
            for (int i = 0; i < 8; i++)
                aseaza_piesa(piese[i + 8], (i + 1 + 2) * l, 7 * l);
            for (int i = 0; i < 2; i++)
                aseaza_piesa(piese[i + 16], (i * 7 + 1 + 2) * l, 1 * l);
            for (int i = 0; i < 2; i++)
                aseaza_piesa(piese[i + 18], (i * 7 + 1 + 2) * l, 8 * l);
            for (int i = 0; i < 2; i++)
                aseaza_piesa(piese[i + 20], (i * 5 + 1 + 3) * l, 1 * l);
            for (int i = 0; i < 2; i++)
                aseaza_piesa(piese[i + 22], (i * 5 + 1 + 3) * l, 8 * l);
            for (int i = 0; i < 2; i++)
                aseaza_piesa(piese[i + 24], (i * 3 + 1 + 4) * l, 1 * l);
            for (int i = 0; i < 2; i++)
                aseaza_piesa(piese[i + 26], (i * 3 + 1 + 4) * l, 8 * l);
            aseaza_piesa(piese[28], (1 + 5) * l, 1 * l);
            aseaza_piesa(piese[29], (1 + 5) * l, 8 * l);
            aseaza_piesa(piese[30], (1 + 6) * l, 1 * l);
            aseaza_piesa(piese[31], (1 + 6) * l, 8 * l);

        }

        public void aseaza_piesa(Piesa p, int x, int y)
        {
            int lin = y / l;
            int col = x / l;
            p.X = col * l + l / 2 - p.W / 2;
            p.Y = lin * l + l / 2 - p.H / 2;
        }

        public Piesa da_piesa(int x, int y)
        {
            foreach (Piesa piesa in piese)
            {
                if (piesa.este_deasupra(x, y)) return piesa;
            }
            return null;
        }


        public Piesa da_piesa_desub(Piesa p, int x, int y)
        {
            foreach (Piesa piesa in piese)
            {
                if (piesa.este_deasupra(x, y) && (p != piesa)) return piesa;
            }
            return null;
        }

        public void restart()
        {
           this.jocNou();
        }

        public int daLinie(int x)
        {
            return x / l;
        }
        public int daColoana(int y)
        {
            return y / l;
        }

    }

}