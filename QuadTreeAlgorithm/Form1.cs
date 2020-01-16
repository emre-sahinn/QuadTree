using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuadTreeAlgorithm
{
    public partial class Form1 : Form
    {
        QuadTree quadTree;
        List<Point> pixels = new List<Point>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ResetButton_Click(sender, e);
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            //PictureBox_Paint: Resim kutusunun içine çizme işlemlerini yönetir
            Graphics graphics = e.Graphics;
            Pen pen = new Pen(Color.White, 1);
            Pen pen2 = new Pen(Color.Red, 1);
            Pen eraser = new Pen(Color.Black, 1000);
            graphics.DrawLine(eraser, 0, 0, 1000, 1000);//ekranı temizlemek için

            //QuadTree çizdirmek için
            quadTree.getTrees(quadTree);//quadTree.coordinates içine quadtree lerin pozisyonunu atar
            foreach (int[] gelenData in quadTree.coordinates)
            {
                graphics.DrawRectangle(pen2, gelenData[0] - gelenData[2], gelenData[1] - gelenData[3],
                    gelenData[2] * 2, gelenData[3] * 2);//quad tree sınırlarını ekrana çizdirir
            }

            //Noktaları çizdirmek için
            for (int y = 0; y < pixels.Count; y++)
            {
                int xPoint = pixels[y].x * 10;//*10 dememizin sebebi, problemde 50x50 lik resim istemesi fakat
                int yPoint = pixels[y].y * 10;//50x50 çok küçük olduğu için biz onu 500x500 e genişlettik
                graphics.DrawRectangle(pen, xPoint - 10, yPoint - 10, 10, 10);//x ve y noktalarını ekrana çizdirir.
            }

        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            Rectangle boundary = new Rectangle(250, 250, 250, 250);
            pixels.Clear();//liste içindekileri silmek için
            quadTree = new QuadTree(boundary, 1); //her quadtree max 1 noktaya sahip olabilir

            Console.WriteLine("-----------");
            Random random = new Random();//rastgele pixel oluşturmak için
            Point point, quadPoint;

            if (randomPhoto.Checked)
            {
                //pixel listesini içinde x ve y koordinatlarını barındıran dizi var
                for (int y = 0; y < 50; y++) //random resim çizmek için 50 tane nokta oluştur
                {
                    int xPoint = random.Next(51);
                    int yPoint = random.Next(51);

                    //Sınırlarda nokta oluşturursak ekrandan taşıyor
                    if (xPoint == 0)
                        xPoint = 1;
                    if (yPoint == 0)
                        yPoint = 1;
                    point = new Point(xPoint, yPoint);
                    quadPoint = new Point(xPoint * 10, yPoint * 10);//500x500 genişletilmiş hali
                    quadTree.insert(quadPoint);
                    pixels.Add(point);
                }
            }
            if (!randomPhoto.Checked)
            {
                //Ekranı temizlemek için ön adım
                pixels.Clear();//liste içindekileri silmek için
                quadTree.coordinates.Clear();
            }
            pictureBox.Refresh();

        }

        private void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            Point point, quadPoint;
            point = new Point((e.X / 10) + 1, (e.Y / 10) + 1);//mouse un tıkladığı her noktaya yeni bi Point atar
            //bu point i ekrana çizdirmek için pixels listesine, quadtree ye göndermek için ise quadTree.insert()
            //olarak gönderilir
            quadPoint = new Point(e.X, e.Y);//500x500 genişletilmiş hali
            Console.WriteLine(e.X + ", " + e.Y);//ekrana mouse un x ve y koordinatlarını yazdırır
            quadTree.insert(quadPoint);
            pixels.Add(point);
            pictureBox.Refresh();
        }

        private void RandomPhoto_CheckedChanged(object sender, EventArgs e)
        {
            ResetButton_Click(sender, e);
        }
    }

    public class Point
    {
        //ekrandaki koordinatları tutar
        public int x, y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
