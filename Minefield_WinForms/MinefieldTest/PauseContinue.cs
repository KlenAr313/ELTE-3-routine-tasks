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
    public class PauseContinue: IDisposable
    {
        private bool wasClled;

        private MinefieldGameModel gameModel;
        private GameData gameData;
        private Mock<DataAccess> mock;

        private Submarine submarine;
        List<Mine> mines;

        public PauseContinue()
        {
            wasClled = false;

            submarine = new Submarine(600, 900);
            submarine.X = 400;
            submarine.Y = 600;

            Mine mine1 = new Mine(900);
            mine1.X = 100;
            mine1.Y = 700;
            mines = new List<Mine>();
            mines.Add(mine1);

            gameData = new(mines, submarine, 20, 90, 200);

            mock = new Mock<DataAccess>();
            mock.Setup(m => m.Load()).Returns(gameData);

            gameModel = new MinefieldGameModel(600, 900, mock.Object);
        }

        [Fact]
        public void PauseTest()
        {
            gameModel.Refresh += RefreshForPauseTest;
            gameModel.StartGame();
            gameModel.Pause();

            for (int i = 0; i < 20; i++)
            {
                gameModel.OnFrame();
            }

            Assert.False(wasClled);
        }

        [Fact]
        public void ContinueTest()
        {
            gameModel.Refresh += RefreshForContinueTest;
            Directions.Up = true;
            gameModel.StartGame();
            gameModel.Pause();
            gameModel.Restrume();
            gameModel.OnFrame();   
        }

        private void RefreshForContinueTest(object? sender, MinefieldEventArgs e)
        {
            Assert.True(e.Mines[0].Y >= 702 && e.Mines[0].Y <= 704);
            Assert.Equal(598, e.Submarine.Y);
            wasClled = true;
        }

        private void RefreshForPauseTest(object? sender, MinefieldEventArgs e)
        {
            wasClled = true;
        }

        public void Dispose() { gameModel.Dispose(); }
    }
}
