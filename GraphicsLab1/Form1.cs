using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsLab1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(900, 500);
        }

        Graphics g;
        private void Form1_Load(object sender, EventArgs e)
        {
            g = selectedFigure.CreateGraphics();
        }


        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            blink = false;
            floating = false;
            figures.Clear();
            SolidBrush back = new SolidBrush(Color.White);
            g.FillRectangle(back, 0, 0, 675, 500);
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void drawButton_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int figure = figureForm.SelectedIndex;
            int xPos = rnd.Next(0, 475), yPos = rnd.Next(0, 300),  size = rnd.Next(50, 200);
            int colorR = rnd.Next(0, 255), colorG = rnd.Next(0, 255), colorB = rnd.Next(0, 255);

            draw_figure(figure, colorR, colorG, colorB, xPos, 0, size);
        }

        private void draw_figure(int figure, int colorR, int colorG, int colorB,  int xPos, int yPos, int size)
        {

            SolidBrush randColor = new SolidBrush(Color.FromArgb(colorR, colorG, colorB));
            
            switch (figure)
            {
                case 0:
                    g.FillPolygon(randColor, new Point[]
                        {
                            new Point(xPos + size/2, yPos),new Point(xPos, yPos + size),
                            new Point(xPos, yPos + size),new Point(xPos + size, yPos + size),
                            new Point(xPos + size, yPos + size),new Point(xPos + size/2, yPos)
                        });
                    break;
                case 1:
                    g.FillRectangle(randColor, xPos, yPos, size, size);
                    break;
                case 2:
                    g.FillEllipse(randColor, xPos, yPos, size, size);
                    break;
                case 3:
                    break;
            }
        }

        private void draw_border(int figure, int colorR, int colorG, int colorB, int xPos, int yPos, int size, int width)
        {
            Pen randColor = new Pen(Color.FromArgb(colorR, colorG, colorB), width);
            switch (figure)
            {
                case 0:
                    g.DrawPolygon(randColor, new Point[]
                        {
                            new Point(xPos + size/2, yPos),new Point(xPos, yPos + size),
                            new Point(xPos, yPos + size),new Point(xPos + size, yPos + size),
                            new Point(xPos + size, yPos + size),new Point(xPos + size/2, yPos)
                        });
                    break;
                case 1:
                    g.DrawRectangle(randColor, xPos, yPos, size, size);
                    break;
                case 2:
                    g.DrawEllipse(randColor, xPos, yPos, size, size);
                    break;
                case 3:
                    break;
            }
        }

        static Mutex mutex = new Mutex();
        bool blink = false;
        async private void button2_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int size = rnd.Next(50, 200);
            int xPos = rnd.Next(0, 475), yPos = rnd.Next(0, 300);

            int figure = figureForm.SelectedIndex;

            int colorR = rnd.Next(0, 255), colorG = rnd.Next(0, 255), colorB = rnd.Next(0, 255);
            int width = rnd.Next(2, 10);

            blink = true;

            void blinkBorder(int time)
            {
                int borderColorR = colorR, borderColorG = colorG, borderColorB = colorB;
                while (blink)
                {
                    mutex.WaitOne();
                        draw_figure(figure, 255, 255, 255, xPos, yPos, size);
                        draw_border(figure, 255, 255, 255, xPos, yPos, size, width);
                        draw_figure(figure, colorR, colorG, colorB, xPos, yPos, size);
                        draw_border(figure, borderColorR, borderColorG, borderColorB, xPos, yPos, size, width);
                    mutex.ReleaseMutex();

                    borderColorR = rnd.Next(0, 255);
                    borderColorG = rnd.Next(0, 255);
                    borderColorB = rnd.Next(0, 255);
                    Thread.Sleep(time);
                }
                
            }

            int rndTime = rnd.Next(200, 1000);
            async Task DrawAsync()
            {
                Console.WriteLine("Начало метода blinkBorder");
                await Task.Run(() => blinkBorder(rndTime));
                Console.WriteLine("Конец метода blinkBorder");
            }

            await DrawAsync();
           
        }


        List<int> figures = new List<int>();
        bool floating = false;
        async private void floating_button_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int figure = figureForm.SelectedIndex;
            int xPos = rnd.Next(5, 475), yPos = rnd.Next(5, 300), size = rnd.Next(50, 200);
            bool pos = true;
            while(pos)
            {
                int c = 0;
                for(int i = 0; i < figures.Count; i += 5)
                {
                    if (xPos + size >= figures[i] && xPos <= figures[i] + figures[i + 2]) c++;
                    if (yPos + size >= figures[i + 1] && yPos <= figures[i + 1] + figures[i + 2]) c++;
                }
                if (c==0) { pos = false; } else { xPos = rnd.Next(5, 475); yPos = rnd.Next(5, 300); }
            }
            int colorR = rnd.Next(0, 255), colorG = rnd.Next(0, 255), colorB = rnd.Next(0, 255);
            int switchR = rnd.Next(1, 20), switchG = rnd.Next(1, 20), switchB = rnd.Next(1, 20);
            int figId = figures.Count;
            figures.Add(xPos);
            figures.Add(yPos);
            figures.Add(size);
            figures.Add(1);
            figures.Add(1);

            floating = true;

            void floatFigure()
            {
                while (floating)
                {
                    mutex.WaitOne();
                    {
                        draw_figure(figure, 255, 255, 255, xPos, yPos, size);

                        if (xPos <= 0) figures[figId + 3] *= -1;
                        if (xPos + size >= 675) figures[figId + 3] *= -1;
                        if (yPos <= 0) figures[figId + 4] *= -1;
                        if (yPos + size >= 500) figures[figId + 4] *= -1;

                        for(int i = 0; i < figures.Count; i += 5)
                        {
                            if(i != figId)
                            {
                                int x2Pos = figures[i], y2Pos = figures[i + 1], size2 = figures[i + 2];
                                if (xPos + size >= x2Pos && xPos <= x2Pos + size)
                                {
                                    if (yPos + size + 1 * figures[figId + 4] == y2Pos || yPos + 1 * figures[figId + 4] == y2Pos + size2) { figures[figId + 4] *= -1; figures[i + 4] *= -1; }
                                }
                                if (yPos + size >= y2Pos && yPos <= y2Pos + size)
                                {
                                    if (xPos + size + 1 * figures[figId + 3] == x2Pos || xPos + 1 * figures[figId + 3] == x2Pos + size2) {figures[figId + 3] *= -1; figures[i + 3] *= -1; }
                                }
                            }
                            
                        }

                        xPos += 1 * figures[figId + 3];
                        yPos += 1 * figures[figId + 4];

                        figures[figId] = xPos;
                        figures[figId + 1] = yPos;

                        if (colorR + switchR > 255) switchR *= -1;
                        if (colorR + switchR < 0) switchR *= -1;
                        if (colorG + switchG > 255) switchG *= -1;
                        if (colorG + switchG < 0) switchG *= -1;
                        if (colorB + switchB > 255) switchB *= -1;
                        if (colorB + switchB < 0) switchB *= -1;

                        colorR += switchR;
                        colorG += switchG;
                        colorB += switchB;

                        draw_figure(figure, colorR, colorG, colorB, xPos, yPos, size);
                    }
                    mutex.ReleaseMutex();
                    Thread.Sleep(50);
                }

            }

            async Task DrawAsync()
            {
                Console.WriteLine("Начало метода blinkBorder");
                await Task.Run(() => floatFigure());
                Console.WriteLine("Конец метода blinkBorder");
            }

            await DrawAsync();
        }
    }
}
