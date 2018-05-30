using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwapiChallenge;
using SwapiUtility;

namespace SwapiTests {
    [TestClass]
    public class SwapiTests {
        [TestMethod]
        public void Run_ValidInput_ValidOutput() {
            // Arrange
            const string expectedOutput = "foo";
            // Act
            var actualOutput = new FilmsUtility().GetFilms("Luke Skywalker");
            // Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}