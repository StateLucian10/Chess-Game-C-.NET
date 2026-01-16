using System.Globalization;
using System.Reflection.Metadata;
using static System.Windows.Forms.AxHost;


namespace JocDeSah
{
    public partial class Form1 : Form
    {

        Image img;
        Graphics g;
        JocSah joc;
        Piesa piesa;
        int dx, dy;
        bool apasat;
        int linStart, colStart;
        int tura = 1; //Alb incepe
        System.Drawing.Font f = new System.Drawing.Font("Times New Roman", 14, FontStyle.Bold);
        StringFormat sf = new StringFormat();



        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            tura = 1;
            joc.restart();
            label2.Text = "White";
            p.Refresh();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            tura = 1;
            panel1.Visible = true;
            joc.restart();
            label2.Text = "White";
            p.Refresh();
        }

        private void p_Click(object sender, EventArgs e)
        {

        }

        private void p_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(img, 0, 0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            img = new Bitmap(p.Width, p.Height);
            g = Graphics.FromImage(img);
            joc = new JocSah(p.Width, p.Height, g);


            button1.FlatStyle = FlatStyle.Flat;
            button1.BackColor = Color.Salmon;
            button1.ForeColor = Color.White;

            button2.FlatStyle = FlatStyle.Flat;
            button2.BackColor = Color.Salmon;
            button2.ForeColor = Color.White;

            button1.MouseEnter += (s, e) => button1.BackColor = Color.OrangeRed;
            button1.MouseLeave += (s, e) => button1.BackColor = Color.Salmon;

            button2.MouseEnter += (s, e) => button2.BackColor = Color.OrangeRed;
            button2.MouseLeave += (s, e) => button2.BackColor = Color.Salmon;




            p.Refresh();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void p_MouseDown(object sender, MouseEventArgs e)
        {
            piesa = joc.da_piesa(e.X, e.Y);
            if (piesa != null && tura == piesa.COL)
            {
                apasat = true;
                dx = e.X - piesa.X;
                dy = e.Y - piesa.Y;
                linStart = joc.daLinie(e.X);
                colStart = joc.daColoana(e.Y);
                Cursor = Cursors.Hand;
                joc.deseneaza();
                piesa.afisare_mutari(g, joc, linStart, colStart);
                p.Refresh();
            }
        }

        private void p_MouseMove(object sender, MouseEventArgs e)
        {
            if (apasat)
            {
                piesa.X = e.X - dx;
                piesa.Y = e.Y - dy;
                joc.deseneaza();
                piesa.afisare_mutari(g, joc, linStart, colStart);
                p.Refresh();
            }
        }

        private void p_MouseUp(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Default;

            if (apasat)
            {
                apasat = false;

                //aici se face testul pentru mutare valida
                int linStop = joc.daLinie(e.X);
                int colStop = joc.daColoana(e.Y);
                Piesa tempPiesa = joc.da_piesa_desub(piesa, e.X, e.Y);//?????????
                int ocupat = -1;
                if (piesa != null)
                {
                    if (tempPiesa != null)
                    {
                        ocupat = tempPiesa.COL;
                    }

                    if (piesa.mutare_valida(joc, linStart, colStart, linStop, colStop, ocupat))
                    {
                        joc.aseaza_piesa(piesa, e.X, e.Y);
                        joc.captureaza_piesa(tempPiesa);
                        tura = (tura == 1) ? 0 : 1;
                        label2.Text = (tura == 1) ? "White" : "Black";


                    }

                    else
                    {
                        joc.aseaza_piesa(piesa, linStart * joc.LatimePatratel, colStart * joc.LatimePatratel);

                    }
                }

                joc.deseneaza();
                p.Refresh();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            joc.jocNou();
            p.Refresh();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iesireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                this.Close();
            }
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                panel1.Visible = false;
                panel2.Visible = true;
                joc.jocNou();
                p.Refresh();
            }
        }
    }
}
