using Moq;
using Project.Controller;
using Project.ControllerInterface;
using Project.DatabaseInterface;
using Project.Enum;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Tests
{
    public class ArtistControllerTests
    {
       
            [TestMethod]
            public void GetArtists_ReturnsArtistList()
            {
                var date1 = new DateTime(1, 2, 3);
                var date2 = new DateTime(1, 2, 4);
                var artistList = new List<Artist>()
            {
                new Artist(1, "Vaishali Ranjan",date1),
                new Artist(2, "Arijit Singh",date2)
            };
                // Arrange
                var artistDbHandler = new Mock<IArtistDbHandler>();
                IArtistController artistController = new ArtistController(artistDbHandler.Object);
                artistDbHandler.Setup(artist => artist.ListOfArtists).Returns(artistList);

                //Act
                var artists = artistController.GetAll();

                //Assert
                Assert.IsNotNull(artists);
                Assert.AreEqual(artistList.Count, artists.Count);
            }


            [TestMethod]
            public void GetArtists_DoesNotReturnsArtistList()
            {
                List<Artist> artistList = null;

                // Arrange
                var artistDbHandler = new Mock<IArtistDbHandler>();
                IArtistController artistController = new ArtistController(artistDbHandler.Object);
                artistDbHandler.Setup(artist => artist.ListOfArtists).Returns(artistList);

                //Act
                var artists = artistController.GetAll();

                //Assert
                Assert.IsNull(artists);
            }



            [TestMethod]
            public void GetArtist_ById_ReturnsArtist()
            {
                var date1 = new DateTime(1, 2, 3);
                var date2 = new DateTime(1, 2, 4);
                var artistList = new List<Artist>()
            {
                new Artist(1, "Vaishali Ranjan",date1),
                new Artist(2, "Arijit Singh",date2)
            };
                // Arrange
                // Arrange
                var artistDbHandler = new Mock<IArtistDbHandler>();
                IArtistController artistController = new ArtistController(artistDbHandler.Object);
                artistDbHandler.Setup(artist => artist.ListOfArtists).Returns(artistList);

                //Act
                //Act
                var artist = artistController.GetById(1);

                //Assert
                Assert.IsInstanceOfType(artist, typeof(Artist));
                Assert.IsNotNull(artist);
            }
            [TestMethod]
            public void GetArtist_ById_DoesnotReturnArtist()
            {
                var date1 = new DateTime(1, 2, 3);
                var date2 = new DateTime(1, 2, 4);
                var artistList = new List<Artist>()
            {
                new Artist(1, "Vaishali Ranjan",date1),
                new Artist(2, "Arijit Singh",date2)
            };
                // Arrange
                var artistDbHandler = new Mock<IArtistDbHandler>();
                IArtistController artistController = new ArtistController(artistDbHandler.Object);
                artistDbHandler.Setup(artist => artist.ListOfArtists).Returns(artistList);

                //Act
                //Act
                var artist = artistController.GetById(3);

                //Assert
                Assert.IsNull(artist);
            }

            [TestMethod]
            public void AddArtist_AddinArtistList()
            {
                var date1 = new DateTime(1, 2, 3);
                var artist = new Artist(1, "Vaishali Ranjan", date1);
                

                // Arrange
                var artistDbHandler = new Mock<IArtistDbHandler>();
                IArtistController artistController = new ArtistController(artistDbHandler.Object);
                artistDbHandler.Setup(x => x.AddArtist(artist)).Returns(true);
                bool expected = true;
                //Act
               
                bool actual = artistController.Add(artist);

                //Assert
                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void AddArtist_DoesnotAddinArtistList()
            {
                var date1 = new DateTime(1, 2, 3);
                var artist = new Artist(1, "Vaishali Ranjan", date1);


                // Arrange
                var artistDbHandler = new Mock<IArtistDbHandler>();
                IArtistController artistController = new ArtistController(artistDbHandler.Object);
                artistDbHandler.Setup(x => x.AddArtist(artist)).Returns(false);
                bool expected = true;
                //Act

                bool actual = artistController.Add(artist);

                //Assert
                Assert.AreNotEqual(expected, actual);
            }


            [TestMethod]
            public void RemoveArtist_RemoveFromArtistList()
            {
                var date1 = new DateTime(1, 2, 3);
                var artist = new Artist(1, "Vaishali Ranjan", date1);
                var date2 = new DateTime(1, 2, 4);
                var artistList = new List<Artist>()
            {
                new Artist(1, "Vaishali Ranjan",date1),
                new Artist(2, "Arijit Singh",date2)
            };

                // Arrange
                var artistDbHandler = new Mock<IArtistDbHandler>();
                IArtistController artistController = new ArtistController(artistDbHandler.Object);
                artistDbHandler.Setup(artist=> artist.ListOfArtists).Returns(artistList);
                artistDbHandler.Setup(x => x.RemoveArtist(artistList)).Returns(true);
                bool expected = true;
                //Act

                bool actual = artistController.RemoveArtist(artist);

                //Assert
                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void RemoveArtist_DoesnotRemoveFromArtistList()
            {
                var date1 = new DateTime(1, 2, 3);
                var artist = new Artist(4, "Vaishali Ranjan", date1);
                var date2 = new DateTime(1, 2, 4);
                var artistList = new List<Artist>()
            {
                new Artist(1, "Vaishali Ranjan",date1),
                new Artist(2, "Arijit Singh",date2)
            };

                // Arrange
                var artistDbHandler = new Mock<IArtistDbHandler>();
                IArtistController artistController = new ArtistController(artistDbHandler.Object);
                artistDbHandler.Setup(artist => artist.ListOfArtists).Returns(artistList);
                artistDbHandler.Setup(x => x.RemoveArtist(artistList)).Returns(false);
                bool expected = false;
                //Act

                bool actual = artistController.RemoveArtist(artist);

                //Assert
                Assert.AreEqual(expected, actual);
            }
        
    }
}
