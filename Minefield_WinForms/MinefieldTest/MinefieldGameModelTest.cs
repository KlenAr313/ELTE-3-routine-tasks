using Minefield.Model;
using Minefield.Persistence;
using Moq;
using System.Reflection.Metadata.Ecma335;

namespace MinefieldTest
{
    public class MinefieldGameModelTest
    {
        private MinefieldGameModel gameModel;
        private GameData gameData;
        private Mock<DataAccess> mock;

        private Submarine submarine;
        List<Mine> mines;

        public MinefieldGameModelTest() 
        {
            submarine = new Submarine(600, 900);
            submarine.X = 300;
            submarine.Y = 600;

            Mine mine1 = new Mine(900);
            mine1.X = 100;
            mine1.Y = 122;
            mines = new List<Mine>();
            mines.Add(mine1);

            gameData = new(mines, submarine, 20, 90, 200);

            mock = new Mock<DataAccess>();
            mock.Setup(m => m.Load()).Returns(gameData);

            gameModel = new MinefieldGameModel(600, 900, mock.Object);
            gameModel.End += GameOver;
            gameModel.Refresh += Refresh;
        }

        [Fact]
        public void NewGameTest()
        {
            gameModel = new MinefieldGameModel(600, 900);

            Assert.Equal(0, gameModel.GameTime);

            gameModel.StartGame();

            Assert.True(gameModel.OneSecTick.Enabled);

            Thread.Sleep(1100);

            Assert.Equal(1, gameModel.GameTime);
        }

        [Fact]
        public void OnFrameTest()
        {
            Directions.Down = true;
            Directions.Right = true;
            gameModel.OnFrame();
            Assert.Equal(20, gameModel.GameTime);
        }

        [Fact]
        public void LoadGameTest()
        {
            gameModel = new(600, 900);
            gameModel.StartGame();
            gameModel.Pause();

            gameModel = new(600, 900, mock.Object);

            Assert.Equal(20, gameModel.GameTime);

            gameModel.OnFrame();

            mock.Verify(mock => mock.Load(), Times.Exactly(2));

        }


        private void Refresh(object? sender, MinefieldEventArgs e)
        {
            Assert.True(gameModel.GameTime >= 0);
            Assert.Single(e.Mines);
            Assert.Equal(122 + e.Mines[0].Speed, e.Mines[0].Y);
            Assert.Equal(100, e.Mines[0].X);
            Assert.Equal(302, e.Submarine.X);
            Assert.Equal(602, e.Submarine.Y);
        }

        private void GameOver(object? sender, EventArgs e)
        {
            Assert.True(false);
        }
    }
}
