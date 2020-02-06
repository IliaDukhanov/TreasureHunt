using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        //Инициализация основных классов и вспомогательных переменных
        private Player player = new Player(Config.startTreasureCount, Config.startHydroCount);
        private List<Treasure> treasures = new List<Treasure>();
        private List<Hydro> hydros = new List<Hydro>();
        private Point foundedTreasure;
        private int areaOfHydro = Config.startAreaOfHydro;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Загрузка начальных размеров игрового поля и его блокировка
            gameField.RowCount = Config.startRowCount;
            gameField.ColumnCount = Config.startColumnCount;
            gameField.Enabled = false;
        }
        //Блок методов настройки параметров игры
        private void Columns_ValueChanged(object sender, EventArgs e)
        {
            //Количество столбцов игрового поля
            gameField.ColumnCount = (int)columns.Value;
        }

        private void Rows_ValueChanged(object sender, EventArgs e)
        {
            //Количество строк игрового поля
            gameField.RowCount = (int)rows.Value;
        }

        private void Hydro_ValueChanged(object sender, EventArgs e)
        {
            //Количество гидролокаторов у игрока
            player.HydroCount = (int)hydro.Value;
        }

        private void Treasure_ValueChanged(object sender, EventArgs e)
        {
            //Количество спрятанных сокровищ
            player.TreasureCount = (int)treasure.Value;
        }

        private void Area_ValueChanged(object sender, EventArgs e)
        {
            //Зона действия гидролокатора
            areaOfHydro = (int)area.Value;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            //Начало игры
            StartGame(true);
        }

        private void GameField_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Игровые правила
            //Сначала проверяем можем ли мы поставить гидролокатор на выбранные координаты
            if ((player.HydroCount > 0) && (player.TreasureCount > 0) && (gameField[gameField.CurrentCell.ColumnIndex, gameField.CurrentCell.RowIndex].Value == null))
            {
                //Добавляем гидролокатор в коллекцию и ищем сокровища
                hydros.Add(new Hydro(new Point(gameField.CurrentCell.RowIndex, gameField.CurrentCell.ColumnIndex), areaOfHydro));
                foundedTreasure = hydros.Last().FindTreasure(treasures);
                //Теперь проверяем находится ли найденное сокровище в зоне поиска гидролокатора
                if ((foundedTreasure.X < Config.treasureInRange) && (foundedTreasure.Y < Config.treasureInRange))
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
                        for (int i = 0; i < hydros.Count; i++)
                        {
                            foundedTreasure = hydros[i].FindTreasure(treasures);
                            if ((foundedTreasure.X < Config.treasureInRange) && (foundedTreasure.Y < Config.treasureInRange) && !(gameField[hydros[i].Position.Y, hydros[i].Position.X].Value.Equals(0)))
                            {
                                //Делаем пересчет расстояний для всех гидролокаторов
                                if (Math.Abs(foundedTreasure.X - hydros[i].Position.X) > Math.Abs(foundedTreasure.Y - hydros[i].Position.Y))
                                    gameField[hydros[i].Position.Y, hydros[i].Position.X].Value = Math.Abs(foundedTreasure.X - hydros[i].Position.X);
                                else
                                    gameField[hydros[i].Position.Y, hydros[i].Position.X].Value = Math.Abs(foundedTreasure.Y - hydros[i].Position.Y);
                            }
                            else if (!gameField[hydros[i].Position.Y, hydros[i].Position.X].Value.Equals(0))
                                gameField[hydros[i].Position.Y, hydros[i].Position.X].Value = 'X';
                        }
                        //Проверяем условие победы
                        if (player.TreasureCount <= 0)
                        {
                            label9.Text = player.HydroCount.ToString();
                            label11.Text = player.TreasureCount.ToString();
                            //Увеличиваем счетчик победы(для статистики)
                            player.WinCount += 1;
                            MessageBox.Show("Поздравляю!!!\n" + "Статистика:\n" + player.WinCount + "-побед\n" + player.LooseCount + "-поражений", "Победа!");
                            StartGame(false);
                        }
                    }
                    else
                        //Выводим на клетку игрового поля расстояние до найденного сокровища(модуль разницы координат по ординате)
                        gameField[hydros.Last().Position.Y, hydros.Last().Position.X].Value = Math.Abs(foundedTreasure.Y - hydros.Last().Position.Y);
                }
                else
                    //Если найденное сокровище не в зоне поиска гидролокатора то помечаем клетку символом 'Х'
                    gameField[hydros.Last().Position.Y, hydros.Last().Position.X].Value = 'X';
                player.HydroCount -= 1;
                //Проверяем условие поражения
                if ((player.TreasureCount >= 0) && (player.HydroCount <= 0))
                {
                    label9.Text = player.HydroCount.ToString();
                    label11.Text = player.TreasureCount.ToString();
                    //Увеличиваем счетчик поражения(для статистики)
                    player.LooseCount += 1;
                    MessageBox.Show("Сожалею...\n" + "Статистика:\n" + player.WinCount + "-побед\n" + player.LooseCount + "-поражений", "Поражение");
                    for (int i = 0; i < treasures.Count; i++)
                    {
                        //Отмечаем невыловленные сокровища
                        gameField[treasures[i].Position.Y, treasures[i].Position.X].Value = 'T';
                    }
                    StartGame(false);
                }
            }
            //Выводим количество локаторов и сокровищ на GUI
            label9.Text = player.HydroCount.ToString();
            label11.Text = player.TreasureCount.ToString();
        }

        void StartGame(bool start)
        {
            //Начало или конец игры(true - начало, false - конец)
            gameField.Enabled = start;
            columns.Enabled = !start;
            rows.Enabled = !start;
            treasure.Enabled = !start;
            hydro.Enabled = !start;
            area.Enabled = !start;
            if (start)
            {
                //Началась игра, очистка коллекций и поля, а также
                //загрузка выставленных на GUI настроек пользователя
                hydros.Clear();
                player.HydroCount = (int)hydro.Value;
                player.TreasureCount = (int)treasure.Value;
                for (int i = 0; i < gameField.ColumnCount; i++)
                {
                    for (int j = 0; j < gameField.RowCount; j++)
                    {
                        gameField[i, j].Value = null;
                    }
                }
            }
            label9.Text = hydro.Value.ToString();
            label11.Text = treasure.Value.ToString();
            while (treasures.Count < player.TreasureCount)
            {
                //Прячем сокровища
                Point position = new Point(new Random(DateTime.Now.Millisecond).Next(0, gameField.RowCount), new Random(DateTime.Now.Millisecond).Next(0, gameField.ColumnCount));
                if (treasures.FindAll(item => item.Position == position).Count == 0)
                    treasures.Add(new Treasure(position));
            }
            button1.Enabled = !start;
        }
    }
}
