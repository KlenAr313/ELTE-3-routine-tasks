using ELTE.DocuStat.Model;
using ELTE.DocuStat.Persistence;
using Moq;

namespace xTest
{
    public class UnitTest1: IDisposable
    {
        Mock<IFileManager> mockFileManagger;
        IDocumentStatistics documentStatistics;


        public UnitTest1() 
        {
            mockFileManagger = new Mock<IFileManager>();
            documentStatistics = new DocumentStatistics(mockFileManagger.Object);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        [Theory]
        [InlineData("")]
        [InlineData("ejnye")]
        [InlineData("nolacikám")]
        public void Test1(string jaj)
        {
            mockFileManagger.Setup(m => m.Load()).Returns(jaj);

            documentStatistics.Load();
            Assert.Equal(jaj, documentStatistics.FileContent);
        }
    }
}