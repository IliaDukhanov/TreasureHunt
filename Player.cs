namespace WindowsFormsApp1
{
    public class Player
    {
        //Класс игрока хранит в себе переменные
        //количества гидролокаторов, сокровищ, побед и поражений
        public Player(int treasureCount, int hydroCount)
        {
            this.treasureCount = treasureCount;
            this.hydroCount = hydroCount;
        }

        private int treasureCount;
        private int hydroCount;
        private int winCount = 0;
        private int looseCount = 0;

        public int TreasureCount
        {
            get => treasureCount;
            set => treasureCount = value;
        }
        public int HydroCount
        {
            get => hydroCount; 
            set => hydroCount = value; 
        }
        public int WinCount
        {
            get => winCount;
            set => winCount = value; 
        }
        public int LooseCount
        {
            get => looseCount; 
            set => looseCount = value; 
        }
    }
}
