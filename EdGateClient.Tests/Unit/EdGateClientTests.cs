using AndcultureCode.EdGateClient.Interfaces;
using AndcultureCode.EdGateClient.Models;
using NUnit.Framework;
using System;

namespace AndcultureCode.EdGateClient.Tests.Unit
{
    [TestFixture]
    public class EdGateClientTests
    {
        #region Private Members

        IEdGateClient _sut;

        #endregion

        #region Setup and Teardown

        [SetUp]
        public void Setup()
        {
            // Nothing to set up at this point
        }

        [TearDown]
        public void Teardown() { }

        #endregion

        #region Constructor

        [Test]
        public void Constructor_Throws_ArgumentNullException_When_Options_Is_Null()
        {
            // Arrange
            EdGateClientOptions options = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _sut = new EdGateClient(options));
        }

        [Test]
        public void Constructor_Throws_Exception_When_EdGatePrivateKey_Is_Null()
        {
            // Arrange
            EdGateClientOptions options = new EdGateClientOptions
            {
                EdGatePrivateKey = null,
                EdGatePublicKey  = "x"
            };

            // Act & Assert
            Assert.Throws<Exception>(() => _sut = new EdGateClient(options));
        }

        [Test]
        public void Constructor_Throws_Exception_When_EdGatePublicKey_Is_Null()
        {
            // Arrange
            EdGateClientOptions options = new EdGateClientOptions
            {
                EdGatePrivateKey = "x",
                EdGatePublicKey  = null
            };

            // Act & Assert
            Assert.Throws<Exception>(() => _sut = new EdGateClient(options));
        }

        #endregion
    }
}
