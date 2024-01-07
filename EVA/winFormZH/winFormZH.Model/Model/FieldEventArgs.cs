namespace winFormZH.Model.Model
{
    public class FieldEventArgs: EventArgs
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

		private int num;

		public int Num
		{
			get { return num; }
			set { num = value; }
		}


		public FieldEventArgs(int gameStepCount, int x, int y, int num)
        {
            this.gameStepCount = gameStepCount;
			this.x = x;
			this.y = y;
			this.num = num;
        }
    }
}