using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class GameRules
    {
        //Инициализация основных классов и вспомогательных переменных
        private Player player = new Player(Config.StartTreasureCount, Config.StartHydroCount);
        private List<Treasure> treasures = new List<Treasure>();
        private List<Hydro> hydros = new List<Hydro>();
        private Point foundedTreasure;
        private int areaOfHydro = Config.StartAreaOfHydro;
        public Player Player
        {
            get => player;
            set => player = value;
        }
        public List<Treasure> Treasures
        {
            get => treasures;
            set => treasures = value;
        }
        public List<Hydro> Hydros
        {
            get => hydros;
            set => hydros = value;
        }
        public Point FoundedTreasure
        {
            get => foundedTreasure;
            set => foundedTreasure = value;
        }
        public int AreaOfHydro
        {
            get => areaOfHydro;
            set => areaOfHydro = value;
        }

        public bool HydrolocatorPlaced(DataGridView gameField)
        {
            //Сначала проверяем можем ли мы поставить гидролокатор на выбранные координаты
            if ((player.HydroCount > 0) && (player.TreasureCount > 0) && (gameField[gameField.CurrentCell.ColumnIndex, gameField.CurrentCell.RowIndex].Value == null))
            {
                //Добавляем гидролокатор в коллекцию
                hydros.Add(new Hydro(new Point(gameField.CurrentCell.RowIndex, gameField.CurrentCell.ColumnIndex), areaOfHydro));              
                player.HydroCount -= 1;
                return true;
            }
            else
                return false;
        }

        public bool InArea(DataGridView gameField)
        {
            foundedTreasure = hydros.Last().FindTreasure(treasures);
            //Теперь проверяем находится ли найденное сокровище в зоне поиска гидролокатора
            if ((foundedTreasure.X < Config.TreasureInRange) && (foundedTreasure.Y < Config.TreasureInRange))
                return true;
            else
                return false;
        }

        public void CalculateWay( DataGridView gameField)
        {
            //Проверяем в каком направлении от гидролокатора находится ближайшее
            //сокровище(для того чтобы понять по чему вести рассчет: по абсциссе или ординате)
            if (Math.Abs(foundedTreasure.X - hydros.Last().Position.X) > Math.Abs(foundedTreasure.Y - hydros.Last().Position.Y))
            //Выводим на клетку игрового поля расстояние до найденного сокровища(модуль разницы координат по абсциссе)
                gameField[hydros.Last().Position.Y, hydros.Last().Position.X].Value = Math.Abs(foundedTreasure.X - hydros.Last().Position.X);
            else if ((foundedTreasure == hydros.Last().Position) && (player.TreasureCount > 0))
            {
                //Случай, когда гидролокатор поставлен на сокровище(в клетке выводится расстояние 0)
                gameField[foundedTreasure.Y, foundedTreasure.X].Value = 0;
                //удаляем из коллекции собранное сокровище
                treasures.Remove(treasures.Find(item => item.Position == foundedTreasure));
                player.TreasureCount -= 1;
                //Делаем пересчет расстояний для всех гидролокаторов
                RecalculateWay(gameField);
            }
            else
            //Выводим на клетку игрового поля расстояние до найденного сокровища(модуль разницы координат по ординате)
                gameField[hydros.Last().Position.Y, hydros.Last().Position.X].Value = Math.Abs(foundedTreasure.Y - hydros.Last().Position.Y);

        }

        public void RecalculateWay(DataGridView gameField)
        {
            //Делаем пересчет расстояний для всех гидролокаторов
            for (int i = 0; i < hydros.Count; i++)
            {
                foundedTreasure = hydros[i].FindTreasure(treasures);
                if ((foundedTreasure.X < Config.TreasureInRange) && (foundedTreasure.Y < Config.TreasureInRange) && !(gameField[hydros[i].Position.Y, hydros[i].Position.X].Value.Equals(0)))
                {
                    if (Math.Abs(foundedTreasure.X - hydros[i].Position.X) > Math.Abs(foundedTreasure.Y - hydros[i].Position.Y))
                        gameField[hydros[i].Position.Y, hydros[i].Position.X].Value = Math.Abs(foundedTreasure.X - hydros[i].Position.X);
                    else
                        gameField[hydros[i].Position.Y, hydros[i].Position.X].Value = Math.Abs(foundedTreasure.Y - hydros[i].Position.Y);
                }
                else if (!gameField[hydros[i].Position.Y, hydros[i].Position.X].Value.Equals(0))
                    gameField[hydros[i].Position.Y, hydros[i].Position.X].Value = 'X';
            }
        }

        public bool EndGame(DataGridView gameField)
        {
            //Проверяем условие победы
            if (player.TreasureCount <= 0)
            {
                //Увеличиваем счетчик победы(для статистики)
                player.WinCount += 1;
                MessageBox.Show("Поздравляю!!!\n" + "Статистика:\n" + player.WinCount + "-побед\n" + player.LooseCount + "-поражений", "Победа!");
                return true;
            }             
            //Проверяем условие поражения
            else if ((player.TreasureCount > 0) && (player.HydroCount <= 0))
            {
                //Увеличиваем счетчик поражения(для статистики)
                player.LooseCount += 1;
                MessageBox.Show("Сожалею...\n" + "Статистика:\n" + player.WinCount + "-побед\n" + player.LooseCount + "-поражений", "Поражение");
                for (int i = 0; i < treasures.Count; i++)
                {
                    //Отмечаем невыловленные сокровища
                    gameField[treasures[i].Position.Y, treasures[i].Position.X].Value = 'T';
                }
                return true;
            }
            return false;
        }

        public void HideTreasure(DataGridView gameField)
        {
            while (treasures.Count < player.TreasureCount)
            {
                //Прячем сокровища
                Point position = new Point(new Random(DateTime.Now.Millisecond).Next(0, gameField.RowCount), new Random(DateTime.Now.Millisecond).Next(0, gameField.ColumnCount));
                if (treasures.FindAll(item => item.Position == position).Count == 0)
                    treasures.Add(new Treasure(position));
            }
        }


    }
}
