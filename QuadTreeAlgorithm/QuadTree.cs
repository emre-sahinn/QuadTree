using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadTreeAlgorithm
{

    class Rectangle
    {
        //quadtree sınırlarını belirlemek için kullanılmıştır
        public int x, y, w, h;

        public Rectangle(int x, int y, int w, int h)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
        }

        //Gelen noktanın dikdörtgenin sınırları içinde olup olmadığını döndüren metot
        public bool Contains(Point point)
        {
            return (
                point.x >= x - w &&
                point.x <= x + w &&
                point.y >= y - h &&
                point.y <= y + h
                );
        }
    }

    class QuadTree
    {
        //Quadtree nin 4 çocuğu
        public QuadTree rightTop;
        public QuadTree leftTop;
        public QuadTree rightBottom;
        public QuadTree leftBottom;

        public Rectangle boundary;//quadtree nin sınırları
        public int capacity;//quadtree nin alabileceği max. pixel sayısı
        public List<Point> points = new List<Point>();//pixel leri tutan liste(capacity kadar tutabilir)
        private bool divided = false;//quadtree nin bölünüp bölünmediğini belirten değer
        public Queue<int[]> coordinates = new Queue<int[]>();//quadtree yi dolaşıp içindeki pixel leri almak için

        public QuadTree(Rectangle boundary, int capacity)
        {
            this.boundary = boundary;
            this.capacity = capacity;
        }
        //quadtree nin ve onun çocuklarının içindeki pixelleri alıp coordinates içine atar
        public void getTrees(QuadTree root)
        {
            if (root != null)
            {
                getTrees(root.rightTop);
                getTrees(root.leftTop);
                getTrees(root.leftBottom);
                getTrees(root.rightBottom);
                int[] data = new int[4];
                data[0] = root.boundary.x;
                data[1] = root.boundary.y;
                data[2] = root.boundary.w;
                data[3] = root.boundary.h;
                coordinates.Enqueue(data);
            }
        }
        //quadtree yi 4 parçaya böler
        public void subdivide()
        {
            divided = true;
            int x = this.boundary.x;
            int y = this.boundary.y;
            int w = this.boundary.w / 2;//2 ye bölmemizin sebebi: yeni oluşacak quadtree, parent ının yarısı kadar genişlik
            int h = this.boundary.h / 2;//ve yüksekliğe sahip olacak
            //4 yeni çocuk oluşur(her biri quadtree)
            Rectangle rightTopR = new Rectangle(x + w, y - h, w, h);
            rightTop = new QuadTree(rightTopR, capacity);
            Rectangle leftTopR = new Rectangle(x - w, y - h, w, h);
            leftTop = new QuadTree(leftTopR, capacity);
            Rectangle rightBottomR = new Rectangle(x + w, y + h, w, h);
            rightBottom = new QuadTree(rightBottomR, capacity);
            Rectangle leftBottomR = new Rectangle(x - w, y + h, w, h);
            leftBottom = new QuadTree(leftBottomR, capacity);
        }
        public bool insert(Point point)
        {
            if (!boundary.Contains(point)) //Eğer gelen pixel quadtree kapsamında değilse hiç ekleme
                return false;
            if (points.Count < capacity) //Eğer kapasite dolu değilse noktayı quadtree ye ekle
            {
                points.Add(point);
                return true;
            }
            else //Eğer kapasite doluysa
            {
                if (!divided) //quadtree bölünmemişse böl
                    subdivide();
                if (rightTop.insert(point)) //Gelen pixel için en uygun quadtree yi bul ve o quadtree ye ekle
                    return true;
                if (leftTop.insert(point))
                    return true;
                if (leftBottom.insert(point))
                    return true;
                if (rightBottom.insert(point))
                    return true;
            }
            return false; //Buraya düşerse, hiç bir quadtree sınırına uygun değil demektir
        }
    }
}
