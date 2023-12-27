using Minefield.Model;

namespace MinefieldTest
{
    public class SubmarineTest
    {
        private Submarine submarine;
        
        public SubmarineTest()
        {
            submarine = new Submarine(600, 900);
        }

        [Fact]
        public void InitTest()
        {
            Assert.Equal(472, submarine.MaxX);
            Assert.Equal(710, submarine.MaxY);
        }

        [Fact]
        public void MoveUpTest()
        {
            submarine.MoveUp();

            Assert.Equal(246, submarine.Y);
            Assert.Equal(250, submarine.X);
        }

        [Fact]
        public void MoveDownTest()
        {
            submarine.MoveDown();

            Assert.Equal(254, submarine.Y);
            Assert.Equal(250, submarine.X);
        }

        [Fact]
        public void MoveLeftTest()
        {
            submarine.MoveLeft();

            Assert.Equal(246, submarine.X);
            Assert.Equal(250, submarine.Y);
        }

        [Fact]
        public void MoveRightTest()
        {
            submarine.MoveRight();

            Assert.Equal(254, submarine.X);
            Assert.Equal(250, submarine.Y);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(5)]
        [InlineData(20)]
        public void BottomEdge(int length)
        {
            for (int i = 0; i < length; i++)
            {
                submarine.MoveDown();
            }

            Assert.True(submarine.Y <= submarine.MaxY);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(50)]
        [InlineData(200)]
        [InlineData(400)]
        public void TopEdge(int length)
        {
            for (int i = 0; i < length; i++)
            {
                submarine.MoveUp();
            }

            Assert.True(submarine.Y >= 20);
        }
        
        [Theory]
        [InlineData(2)]
        [InlineData(50)]
        [InlineData(200)]
        public void LeftEdge(int length)
        {
            for (int i = 0; i < length; i++)
            {
                submarine.MoveLeft();
            }

            Assert.True(submarine.X >= 2);
        }
        
        [Theory]
        [InlineData(2)]
        [InlineData(50)]
        [InlineData(200)]
        public void RightEdge(int length)
        {
            for (int i = 0; i < length; i++)
            {
                submarine.MoveLeft();
            }

            Assert.True(submarine.X <= submarine.MaxX);
        }
    }
}