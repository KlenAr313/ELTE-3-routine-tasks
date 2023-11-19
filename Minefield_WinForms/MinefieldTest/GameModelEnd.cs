using Minefield.Model;
using Minefield.Persistence;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinefieldTest
{
    public class GameModelEnd: IDisposable
    {
        private bool wasCalled;

        private MinefieldGameModel gameModel;
        private GameData gameData;
        private Mock<DataAccess> mock;

        private Submarine submarine;
        List<Mine> mines;

        public GameModelEnd()
        {
            wasCalled = false;
            submarine = new Submarine(600, 900);
            submarine.X = 200;
            submarine.Y = 200;

            Mine mine1 = new Mine(900);
            mine1.X = 200;
            mine1.Y = 200;
            mines = new List<Mine>();
            mines.Add(mine1);

            gameData = new(mines, submarine, 20, 90, 200);

            mock = new Mock<DataAccess>();
            mock.Setup(m => m.Load()).Returns(gameData);

            gameModel = new MinefieldGameModel(600, 900, mock.Object);
            gameModel.End += GameOver;
        }

        [Fact]
        public void EndTest()
        {
            gameModel.StartGame();
            gameModel.OnFrame();
            Assert.True(wasCalled);
        }

        private void GameOver(object? sender, EventArgs e)
        {
            wasCalled = true;
        }

        public void Dispose()
        {
            gameModel.Dispose();
        }
    }
}
