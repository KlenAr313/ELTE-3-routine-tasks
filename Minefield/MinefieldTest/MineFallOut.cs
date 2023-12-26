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
    public class MineFallOut: IDisposable
    {
        private bool wasClled;

        private MinefieldGameModel gameModel;
        private GameData gameData;
        private Mock<DataAccess> mock;

        private Submarine submarine;
        List<Mine> mines;

        public MineFallOut()
        {
            wasClled = false;

            submarine = new Submarine(600, 900);
            submarine.X = 300;
            submarine.Y = 600;

            Mine mine1 = new Mine(900);
            mine1.X = 100;
            mine1.Y = 970;
            mines = new List<Mine>();
            mines.Add(mine1);

            gameData = new(mines, submarine, 20, 90, 200, 600, 900);

            mock = new Mock<DataAccess>();
            mock.Setup(m => m.Load()).Returns(gameData);

            gameModel = new MinefieldGameModel(600, 900, mock.Object);
            gameModel.Refresh += Refresh;
        }

        [Fact]
        public void FallOutTest()
        {
            gameModel.StartGame();
            gameModel.OnFrame();
            Assert.True(wasClled);
        }

        private void Refresh(object? sender, MinefieldEventArgs e)
        {
            Assert.Empty(e.Mines);
            wasClled = true;
        }

        public void Dispose()
        {
            gameModel.Dispose();
        }
    }
}
