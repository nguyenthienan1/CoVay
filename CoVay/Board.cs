using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CoVay
{
    public class Board
    {
        public Matrix matrix;
        public int StoneNum;

        public Board()
        {
            StoneNum = 0;
            matrix = new Matrix();
        }
        public void DrawBoard(Graphics gr)
        {
            //Vẽ background bàn cờ
            RectangleF rectF = new RectangleF(0, 0, (ConstNumber.linenum + 1) * ConstNumber.cellSize, (ConstNumber.linenum + 1) * ConstNumber.cellSize);
            gr.FillRectangle(Brushes.SaddleBrown, rectF);

            //Vẽ đường kẻ dọc
            for (int i = 1; i <= ConstNumber.linenum; i++)
            {
                Point start = new Point(ConstNumber.cellSize, i * ConstNumber.cellSize);
                Point end = new Point(ConstNumber.linenum * ConstNumber.cellSize, i * ConstNumber.cellSize);
                gr.DrawLine(Pens.Black, start, end);
            }
            //Vẽ đường kẻ ngang
            for (int i = 1; i <= ConstNumber.linenum; i++)
            {
                Point start = new Point(i * ConstNumber.cellSize, ConstNumber.cellSize);
                Point end = new Point(i * ConstNumber.cellSize, ConstNumber.linenum * ConstNumber.cellSize);
                gr.DrawLine(Pens.Black, start, end);
            }
            //Vẽ số hàng ngang
            for (int i = 1; i <= ConstNumber.linenum; i++)
            {
                string drawstr = i.ToString();
                Font drawfont = new Font("Arial", 10);
                SolidBrush drawbrush = new SolidBrush(Color.Black);
                PointF drawpointf = new PointF((float)(i * ConstNumber.cellSize) - 10, 5);
                gr.DrawString(drawstr, drawfont, drawbrush, drawpointf);
            }
            //Vẽ số hàng dọc
            for (int i = 1; i <= ConstNumber.linenum; i++)
            {
                string drawstr = i.ToString();
                Font drawfont = new Font("Arial", 10);
                SolidBrush drawbrush = new SolidBrush(Color.Black);
                PointF drawpointf = new PointF(5, (float)(i * ConstNumber.cellSize) - 10);
                gr.DrawString(drawstr, drawfont, drawbrush, drawpointf);
            }
        }

        protected void DrawStone(Graphics gr, bool isblack, int x, int y)
        {
            int r = ConstNumber.cellSize / 2;
            Color color = isblack == true ? Color.Black : Color.White;
            Brush mybrush = new SolidBrush(color);

            int rectX = x * 2 * r - r;
            int rectY = y * 2 * r - r;

            gr.FillEllipse(mybrush, rectX, rectY, 2 * r, 2 * r);
            gr.DrawEllipse(Pens.Black, rectX, rectY, 2 * r, 2 * r);
        }

        public void DrawStones(Graphics gr)
        {
            int n = ConstNumber.linenum + 1;
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        bool isblack = true;
                        if (matrix[i, j] < 0)
                        {
                            isblack = false;
                        }
                        DrawStone(gr, isblack, i, j);
                        if (Math.Abs(matrix[i, j]) == StoneNum)
                        {
                            DrawNewFlag(gr, i, j);
                        }
                    }
                }
            }
        }

        protected void DrawNewFlag(Graphics gr, int x, int y)
        {
            int r = ConstNumber.cellSize / 2;
            int rectX = x * 2 * r - r / 2;
            int rectY = y * 2 * r - r / 2;
            gr.FillEllipse(Brushes.Green, rectX, rectY, r - 2, r - 2);
        }

        public bool SetStone(bool isblack, int x, int y)
        {

            if (matrix[x, y] != 0)
            {
                return false;
            }

            Matrix m = matrix.Copy();
            int flag = 1;
            if (isblack == false)
            {
                flag = -1;
            }
            m[x, y] = flag * (StoneNum + 1);

            if (StoneNum - 1 >= 0 && m.EqualSituationWith(matrix))
            {
                return false;
            }
            StoneNum++;
            matrix = m;
            return true;
        }
    }
}
