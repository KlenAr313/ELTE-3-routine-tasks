using ELTE.DocuStat.Model;
using ELTE.DocuStat.Persistence;
using Moq;
using static ELTE.DocuStat.Persistence.TextFileManager;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        Mock<IFileManager> mockFileManagger;
        IDocumentStatistics documentStatistics;


        [TestInitialize]
        public void TestInit()
        {
            mockFileManagger = new Mock<IFileManager>();
            documentStatistics = new DocumentStatistics(mockFileManagger.Object);
        }

        [TestMethod]
        public void TestEmptyString()
        {
            mockFileManagger.Setup(m => m.Load()).Returns("");

            documentStatistics.Load();
            Assert.AreEqual("", documentStatistics.FileContent);
        }

        [ExpectedException(typeof(FileManagerException))]
        public void TestClean()
        {

        }
        
    }
}