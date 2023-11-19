using Project.ControllerInterface;
using Moq;
using Project.Models;
using Project.Controller;
using Project.Database;
using NSubstitute;
using Project.DatabaseInterface;

namespace DatabaseTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddArtist_ShouldCallAddEntryInArtistDbHandler()
        {
            // Arrange
            var artistDbHandlerMock = new Mock<ArtistDbHandler>(MockBehavior.Strict, null, null);
            var artistController = new ArtistController(artistDbHandlerMock.Object);

            var artist = new Artist(1, "ArtistName", DateTime.Now);

            // Set up the expectation that AddEntry will be called
            artistDbHandlerMock.Setup(x => x.AddEntry(artist, It.IsAny<List<Artist>>(), It.IsAny<string>())).Returns(true);

            // Act
            var result = artistController.Add(artist);

            // Assert
            Assert.IsTrue(result);

            // Verify that AddEntry was called with the correct arguments
            artistDbHandlerMock.Verify(x => x.AddEntry(artist, It.IsAny<List<Artist>>(), It.IsAny<string>()), Times.Once);
        }
    }
}