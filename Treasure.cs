using System.Drawing;

namespace WindowsFormsApp1
{
    class Treasure
    {
        //Класс сокровищ, имеет одно поле - координаты
        public Treasure(Point position)
        {
            this.position = position;
        }

        private Point position;
        public Point Position
        {
            get => position;
            set => position = value; 
        }
    }
}
