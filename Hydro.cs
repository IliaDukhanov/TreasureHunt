using System;
using System.Collections.Generic;
using System.Drawing;

namespace WindowsFormsApp1
{
    class Hydro:Treasure
    {
        //Класс гидролокатора хранит переменную зоны
        //поиска, координат и метод поиска ближайшего сокровища
        public Hydro(Point position, int area):base(position)
        {
            this.area = area;
        }
        private int area;

        public Point FindTreasure(List<Treasure> treasures)
        {
            Point foundedTreasure = new Point(Config.TreasureOutOfRange, Config.TreasureOutOfRange);
            for (int i = 0; i < treasures.Count; i++)
            {
                //Проверка входит ли очередное сокровище из коллекции в зону поиска
                //(модуль разницы между абсциссой и ординатой сокровища и локатора 
                //должен быть меньше чем значеение зоны поиска)
                if ((Math.Abs(treasures[i].Position.X - Position.X) <= area) && (Math.Abs(treasures[i].Position.Y - Position.Y) <= area))
                {
                    //выборка ближайшего сокровища(минимального значения расстояния) из находящихся в зоне поиска
                    if ((Math.Abs(treasures[i].Position.X - Position.X) <= Math.Abs(foundedTreasure.X - Position.X)) && 
                        (Math.Abs(treasures[i].Position.Y - Position.Y) <= Math.Abs(foundedTreasure.Y - Position.Y)))
                        foundedTreasure = treasures[i].Position;
                }
            }
            return foundedTreasure;
        }
    }
}
