namespace mauiZH.Model.Model
{
    public class CreatedEventArgs :EventArgs
    {
		private int gameStepCount;

		public int GameStepCount
		{
			get { return gameStepCount; }
			set { gameStepCount = value; }
		}

		private int x;

		public int X
		{
			get { return x; }
			set { x = value; }
		}

		private int y;

		public int Y
		{
			get { return y; }
			set { y = value; }
		}

		private int[,] table;

		public int[,] Table
		{
			get { return table; }
			set { table = value; }
		}

		public CreatedEventArgs(int gameStepCount, int x, int y, int[,] table)
        {
            this.gameStepCount = gameStepCount;
			this.x = x;
			this.y = y;
			this.table = table;
        }
    }
}