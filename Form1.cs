using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        GameRules game = new GameRules();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Загрузка начальных размеров игрового поля и его блокировка
            gameField.RowCount = Config.StartRowCount;
            gameField.ColumnCount = Config.StartColumnCount;
            gameField.Enabled = false;
        }
        //Блок методов настройки параметров игры
        private void Columns_ValueChanged(object sender, EventArgs e)
        {
            //Количество столбцов игрового поля
            gameField.ColumnCount = (int)columns.Value;
            ClearField();
        }

        private void Rows_ValueChanged(object sender, EventArgs e)
        {
            //Количество строк игрового поля
            gameField.RowCount = (int)rows.Value;
            ClearField();
        }

        private void Hydro_ValueChanged(object sender, EventArgs e)
        {
            //Количество гидролокаторов у игрока
            game.Player.HydroCount = (int)hydro.Value;
        }

        private void Treasure_ValueChanged(object sender, EventArgs e)
        {
            //Количество спрятанных сокровищ
            game.Player.TreasureCount = (int)treasure.Value;
        }

        private void Area_ValueChanged(object sender, EventArgs e)
        {
            //Зона действия гидролокатора
            game.AreaOfHydro = (int)area.Value;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            //Начало игры
            StartGame(true);
        }

        private void GameField_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Проверка на возможность установки локатора 
            if (game.HydrolocatorPlaced(gameField))
            {
                //Проверяем находится ли сокровища в зоне действия локатора
                if (game.InArea(gameField))
                {
                    //Рассчитываем длинну пути к ближайшему сокровищу
                    game.CalculateWay(gameField);
                }
                else
                    //Если найденное сокровище не в зоне поиска гидролокатора то помечаем клетку символом 'Х'
                    gameField[game.Hydros[game.Hydros.Count-1].Position.Y, game.Hydros[game.Hydros.Count - 1].Position.X].Value = Config.AreaClear;
                //Обновляем значевния в GUI
                RefreshGUI();
                //Проверяем нет ли условий поражения или победы
                if (game.EndGame(gameField))
                    StartGame(false);
            }
        }

        public void RefreshGUI()
        {
            //Выводим количество локаторов и сокровищ на GUI
            hydroGUI.Text = game.Player.HydroCount.ToString();
            treasureGUI.Text = game.Player.TreasureCount.ToString();
        }

        public void StartGame(bool start)
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
                game.Hydros.Clear();
                game.Treasures.Clear();
                game.Player.HydroCount = (int)hydro.Value;
                game.Player.TreasureCount = (int)treasure.Value;
                ClearField();
            }
            hydroGUI.Text = hydro.Value.ToString();
            treasureGUI.Text = treasure.Value.ToString();
            //Спрятать сокровища
            game.HideTreasure(gameField);
            button1.Enabled = !start;
        }

        public void ClearField()
        {
            //Очистка игрового поля
            for (int i = 0; i < gameField.ColumnCount; i++)
            {
                for (int j = 0; j < gameField.RowCount; j++)
                {
                    gameField[i, j].Value = null;
                }
            }
        }
    }
}
