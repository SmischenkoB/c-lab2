using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Figure ob1 = new Pawn(6, 8);
            Figure ob2 = new Pawn(6, 8);
            Console.WriteLine((Pawn)ob1 == (Pawn)ob2);
            Console.WriteLine(ob1.GetHashCode());
            Console.WriteLine(ob2.GetHashCode());
            int[,] ins = new int[6, 2];
            Console.WriteLine(ins.GetLength(0));
            Console.WriteLine(ins.GetLength(1));
            Desk desk = new Desk();
            desk.Print();
            Console.WriteLine("coordinates of figure to move");

            desk.Move(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));
            desk.Print();
            Console.Read();
            // desk.Move(2, 1);
        }
    }
    abstract class Figure
    {
        protected int direction = 1;
        protected int PosX, PosY;
        public void GetPos()
        {
            Console.WriteLine("" + PosX + " " + PosY);
        }
        public int GetX() => PosX;
        public int GetY() => PosY;
        public int GetDir() => direction;
        public Figure(int x, int y) { PosX = x; PosY = y; }
        public void SetPos(int x, int y) { PosX = x; PosY = y; }
        public void ChangeDirection() { direction *= -1; }
        public abstract void Move(int length);
        public override int GetHashCode()
        {
            int hash = (PosX + PosY);
            hash += direction * 15;
            hash += (int)ToString().ElementAt(0);
            return hash;
        }
        public abstract override bool Equals(object obj);


    }
    class Pawn : Figure
    {
        public override string ToString()
        {
            return "P";
        }
        public Pawn(int x, int y) : base(x, y)
        {
        }

        public override void Move(int length)
        {
            PosX += direction;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            return (this.PosX == ((Figure)obj).GetX() && this.PosY == ((Figure)obj).GetY() && this.direction == ((Figure)obj).GetDir()
                    && this.ToString() == ((Figure)obj).ToString());
        }
        public static bool operator ==(Pawn obj1, Pawn obj2)
        {
            if (obj1.Equals(null) || obj2.Equals(null)) return false;
            return obj1.Equals(obj2);
        }
        public static bool operator !=(Pawn obj1, Pawn obj2)
        {
            if (obj1 == null || obj2 == null) return false;
            return obj1.Equals(obj2);
        }
    }
    class King : Figure
    {
        public override string ToString()
        {
            return "K";
        }
        public King(int x, int y) : base(x, y)
        {
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            return (this.PosX == ((Figure)obj).GetX() && this.PosY == ((Figure)obj).GetY() && this.direction == ((Figure)obj).GetDir()
                    && this.ToString() == ((Figure)obj).ToString());
        }
        public override void Move(int length)
        {
            Console.WriteLine("choose direction from 1 to 8");
            int direction = Convert.ToInt32(Console.ReadLine());
            switch (direction)
            {
                case 1:
                    {
                        PosX += this.direction;
                        break;
                    }
                case 2:
                    {
                        PosX += this.direction;
                        PosY += this.direction;
                        break;
                    }
                case 3:
                    {
                        PosY += this.direction;
                        break;
                    }
                case 4:
                    {
                        PosX -= this.direction;
                        PosY += this.direction;
                        break;
                    }
                case 5:
                    {
                        PosX -= this.direction;
                        break;
                    }
                case 6:
                    {
                        PosX -= this.direction;
                        PosY -= this.direction;
                        break;
                    }
                case 7:
                    {
                        PosY -= this.direction;
                        break;
                    }
                case 8:
                    {
                        PosX += this.direction;
                        PosY -= this.direction;
                        break;
                    }
            }
        }
        public static bool operator ==(King obj1, King obj2)
        {
            if (obj1 == null || obj2 == null) return false;
            return obj1.Equals(obj2);
        }
        public static bool operator !=(King obj1, King obj2)
        {
            if (obj1 == null || obj2 == null) return false;
            return obj1.Equals(obj2);
        }
    }

    class Queen : Figure
    {
        public override string ToString()
        {
            return "Q";
        }
        public Queen(int x, int y) : base(x, y)
        {
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            return (this.PosX == ((Figure)obj).GetX() && this.PosY == ((Figure)obj).GetY() && this.direction == ((Figure)obj).GetDir()
                    && this.ToString() == ((Figure)obj).ToString());
        }
        public override void Move(int length)
        {
            Console.WriteLine("choose direction from 1 to 8");
            int direction = Convert.ToInt32(Console.ReadLine());
            switch (direction)
            {
                case 1:
                    {
                        PosX += this.direction * length;
                        break;
                    }
                case 2:
                    {
                        PosX += this.direction * length;
                        PosY += this.direction * length;
                        break;
                    }
                case 3:
                    {
                        PosY += this.direction * length;
                        break;
                    }
                case 4:
                    {
                        PosX -= this.direction * length;
                        PosY += this.direction * length;
                        break;
                    }
                case 5:
                    {
                        PosX -= this.direction * length;
                        break;
                    }
                case 6:
                    {
                        PosX -= this.direction * length;
                        PosY -= this.direction * length;
                        break;
                    }
                case 7:
                    {
                        PosY -= this.direction * length;
                        break;
                    }
                case 8:
                    {
                        PosX += this.direction * length;
                        PosY -= this.direction * length;
                        break;
                    }
            }
        }
        public static bool operator ==(Queen obj1, Queen obj2)
        {
            if (obj1 == null || obj2 == null) return false;
            return obj1.Equals(obj2);
        }
        public static bool operator !=(Queen obj1, Queen obj2)
        {
            if (obj1 == null || obj2 == null) return false;
            return obj1.Equals(obj2);
        }
    }
    class Knight : Figure
    {
        public override string ToString()
        {
            return "H";
        }
        public Knight(int x, int y) : base(x, y)
        {
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            return (this.PosX == ((Figure)obj).GetX() && this.PosY == ((Figure)obj).GetY() && this.direction == ((Figure)obj).GetDir()
                    && this.ToString() == ((Figure)obj).ToString());
        }
        public override void Move(int length)
        {
            Console.WriteLine("choose direction from 1 to 8");
            int direction = Convert.ToInt32(Console.ReadLine());
            switch (direction)
            {
                case 1:
                    {
                        PosX += this.direction * 3;
                        PosY += this.direction;
                        break;
                    }
                case 2:
                    {
                        PosX += this.direction * 3;
                        PosY -= this.direction;
                        break;
                    }
                case 3:
                    {
                        PosX += this.direction;
                        PosY += this.direction * 3;
                        break;
                    }
                case 4:
                    {
                        PosX += this.direction;
                        PosY -= this.direction * 3;
                        break;
                    }
                case 5:
                    {
                        PosX -= this.direction * 3;
                        PosY += this.direction;
                        break;
                    }
                case 6:
                    {
                        PosX -= this.direction * 3;
                        PosY -= this.direction;
                        break;
                    }
                case 7:
                    {
                        PosX -= this.direction;
                        PosY += this.direction * 3;
                        break;
                    }
                case 8:
                    {
                        PosX -= this.direction;
                        PosY -= this.direction * 3;
                        break;
                    }
            }
        }
        public static bool operator ==(Knight obj1, Knight obj2)
        {
            if (obj1 == null || obj2 == null) return false;
            return obj1.Equals(obj2);
        }
        public static bool operator !=(Knight obj1, Knight obj2)
        {
            if (obj1 == null || obj2 == null) return false;
            return obj1.Equals(obj2);
        }
    }
    class Bishop : Figure
    {
        public override string ToString()
        {
            return "B";
        }
        public Bishop(int x, int y) : base(x, y)
        {
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            return (this.PosX == ((Figure)obj).GetX() && this.PosY == ((Figure)obj).GetY() && this.direction == ((Figure)obj).GetDir()
                    && this.ToString() == ((Figure)obj).ToString());
        }
        public override void Move(int length)
        {
            Console.WriteLine("choose direction from 1 to 4");
            int direction = Convert.ToInt32(Console.ReadLine());
            switch (direction)
            {
                case 1:
                    {
                        PosX += this.direction * length;
                        PosY += this.direction * length;
                        break;
                    }
                case 2:
                    {
                        PosX -= this.direction * length;
                        PosY += this.direction * length;
                        break;
                    }
                case 3:
                    {
                        PosX += this.direction * length;
                        PosY -= this.direction * length;
                        break;
                    }
                case 4:
                    {
                        PosX -= this.direction * length;
                        PosY -= this.direction * length;
                        break;
                    }
            }
        }
        public static bool operator ==(Bishop obj1, Bishop obj2)
        {
            if (obj1 == null || obj2 == null) return false;
            return obj1.Equals(obj2);
        }
        public static bool operator !=(Bishop obj1, Bishop obj2)
        {
            if (obj1 == null || obj2 == null) return false;
            return obj1.Equals(obj2);
        }
    }
    class Rook : Figure
    {
        public override string ToString()
        {
            return "R";
        }
        public Rook(int x, int y) : base(x, y)
        {
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            return (this.PosX == ((Figure)obj).GetX() && this.PosY == ((Figure)obj).GetY() && this.direction == ((Figure)obj).GetDir()
                    && this.ToString() == ((Figure)obj).ToString());
        }
        public override void Move(int length)
        {
            Console.WriteLine("choose direction from 1 to 4");
            int direction = Convert.ToInt32(Console.ReadLine());
            switch (direction)
            {
                case 1:
                    {
                        PosX += this.direction * length;
                        break;
                    }
                case 2:
                    {
                        PosX -= this.direction * length;
                        break;
                    }
                case 3:
                    {
                        PosY += this.direction * length;
                        break;
                    }
                case 4:
                    {
                        PosY -= this.direction * length;
                        break;
                    }
            }
        }
        public static bool operator ==(Rook obj1, Rook obj2)
        {
            if (obj1 == null || obj2 == null) return false;
            return obj1.Equals(obj2);
        }
        public static bool operator !=(Rook obj1, Rook obj2)
        {
            if (obj1 == null || obj2 == null) return false;
            return obj1.Equals(obj2);
        }
    }
    class Desk
    {
        private Figure[] black = new Figure[16];
        private Figure[] white = new Figure[16];
        private Node[,] field = new Node[8, 8];
        public void Print()
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j].IsEmpty()) { Console.Write(" "); }
                    else
                    {
                        Console.Write(field[i, j].GetFigure());
                    }
                }
                Console.WriteLine();
            }

        }
        public Desk()
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = new Node();
                }
            }

            for (int i = 0; i < field.GetLength(1); i++)
            {
                black[i] = new Pawn(1, i);
                field[1, i].SetFigure(black[i]);

                white[i] = new Pawn(6, i);
                white[i].ChangeDirection();
                field[6, i].SetFigure(white[i]);
            }
            black[8] = new Rook(0, 0);
            black[9] = new Knight(0, 1);
            black[10] = new Bishop(0, 2);
            black[11] = new Queen(0, 3);
            black[12] = new King(0, 4);
            black[13] = new Bishop(0, 5);
            black[14] = new Knight(0, 6);
            black[15] = new Rook(0, 7);




            white[8] = new Rook(7, 0);
            white[9] = new Knight(7, 1);
            white[10] = new Bishop(7, 2);
            white[11] = new Queen(7, 4);
            white[12] = new King(7, 3);
            white[13] = new Knight(7, 6);
            white[14] = new Bishop(7, 5);
            white[15] = new Rook(7, 7);

            for (int i = 0; i < field.GetLength(1); i++)
            {
                field[0, i].SetFigure(black[8 + i]);

                //white[i] = new Pawn(6, i);
                white[8 + i].ChangeDirection();
                field[7, i].SetFigure(white[8 + i]);
            }

        }
        public void Move(int x, int y)
        {
            if (field[x, y].IsEmpty())
            {
                Console.WriteLine("нет фигуры в точке " + x + y);
                return;
            }
            int PrevX, PrevY;
            PrevX = field[x, y].GetFigure().GetX();
            PrevY = field[x, y].GetFigure().GetY();
            Console.WriteLine("length of movement");
            field[x, y].GetFigure().Move(Convert.ToInt32(Console.ReadLine()));
            if (field[x, y].GetFigure().GetX() > 7 || field[x, y].GetFigure().GetY() > 7 || field[x, y].GetFigure().GetX() < 0 || field[x, y].GetFigure().GetY() < 0)
            {
                Console.WriteLine("can`t move");
                field[x, y].GetFigure().SetPos(PrevX, PrevY);
                return;
            }
            if (!field[field[x, y].GetFigure().GetX(), field[x, y].GetFigure().GetY()].IsEmpty())
            {// проверка на занятость ячейки, в которую происходит ход
                Console.WriteLine("can`t move");
                field[x, y].GetFigure().SetPos(PrevX, PrevY);
                return;
            }

            Console.WriteLine("moved to" + field[x, y].GetFigure().GetX() + " " + field[x, y].GetFigure().GetY());
            field[field[x, y].GetFigure().GetX(), field[x, y].GetFigure().GetY()].SetFigure(field[x, y].GetFigure());
            field[x, y].ReleaseFigure();

        }
    }
    class Node
    {
        private Figure inside = null;
        public Boolean IsEmpty()
        {
            return inside == null;
        }
        public void SetFigure(Figure ins) => inside = ins;
        public void ReleaseFigure() => inside = null;
        public Figure GetFigure() { return inside; }
    }
}
