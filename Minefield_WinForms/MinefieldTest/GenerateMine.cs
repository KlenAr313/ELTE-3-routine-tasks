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
    public class GenerateMine: IDisposable
    {
        private bool wasClled;

        private MinefieldGameModel gameModel;
        private GameData gameData;
        private Mock<DataAccess> mock;

        private Submarine submarine;
        List<Mine> mines;

        public GenerateMine()
        {
            wasClled = false;

            submarine = new Submarine(600, 900);
            submarine.X = 300;
            submarine.Y = 600;

            mines = new List<Mine>();

            gameData = new(mines, submarine, 20, 0, 200);

            mock = new Mock<DataAccess>();
            mock.Setup(m => m.Load()).Returns(gameData);

            gameModel = new MinefieldGameModel(600, 900, mock.Object);
            gameModel.Refresh += Refresh;
        }

        [Fact]
        public void GenerateMineTest()
        {
            gameModel.StartGame();
            gameModel.OnFrame();
            Assert.True(wasClled);
        }

        private void Refresh(object? sender, MinefieldEventArgs e)
        {
            Assert.Single(e.Mines);
            wasClled = true;
        }

        public void Dispose()
        {
            gameModel.Dispose();
        }
    }
}
