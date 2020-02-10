using System.Drawing;

namespace WindowsFormsApp1
{
    abstract class GameObject
    {
        //Класс игрового объекта, содержит только 
        //позицию размещения и является родителем для 
        //классов гидролокаторов и сокровищ
        public GameObject(Point position)
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
