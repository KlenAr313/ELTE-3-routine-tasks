using Minefield.Model;

namespace MinefieldTest
{
    public class MineTest
    {
        private Mine mine;

        public MineTest()
        {
            mine = new Mine(900);
        }

        [Fact]
        public void InitTest()
        {
            Assert.Equal(0, mine.Y);
            Assert.True(5 <= mine.X && mine.X <= 844);
            Assert.True(2 <= mine.Speed && mine.Speed <= 4);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(26)]
        [InlineData(78)]
        public void MoveTest(int length)
        {
            for (int i = 0; i < length; i++)
            {
                mine.Move();
            }

            Assert.Equal(mine.Speed * length, mine.Y);
        }
    }
}
