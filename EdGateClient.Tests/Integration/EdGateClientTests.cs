
using AndcultureCode.EdGateClient.Interfaces;
using AndcultureCode.EdGateClient.Models;
using AndcultureCode.EdGateClient.Models.Profile;
using NUnit.Framework;
using Shouldly;
using System;

namespace AndcultureCode.EdGateClient.Tests.Integration
{
    [TestFixture]
    public class EdGateClientTests
    {
        #region Private Members

        Profile         _profile;
        IEdGateClient   _sut;

        #endregion

        #region Setup and Teardown

        [SetUp]
        public void Setup()
        {
            _sut = new EdGateClient(new EdGateClientOptions
            {
                EdGatePublicKey  = "",
                EdGatePrivateKey = ""
            });

            _profile = _sut.Profile.GetProfile();
        }

        [TearDown]
        public void Teardown() { }

        #endregion

        #region Standards  Tests

        #region ExportStandards

        [Test]
        public void ExportStandards_Returns_List_Of_Standards()
        {
            // Arrange
            var standardsSetId = _profile.StandardsSets[0].SetId;

            // Act
            var result = _sut.Standards.ExportStandards(standardsSetId);

            // Assert
            result.ShouldNotBeNull();
        }

        [Test]
        public void ExportStandards_Throws_Exception_When_Invalid_Credentials_Supplied()
        {
            // Arrange
            _sut = new EdGateClient(new EdGateClientOptions
            {
                EdGatePrivateKey = "private",
                EdGatePublicKey  = "public"
            });

            var standardsSetId = _profile.StandardsSets[0].SetId;

            // Act & Assert
            Assert.Throws<Exception>(() => _sut.Standards.ExportStandards(standardsSetId));

        }

        #endregion ExportStandards

        #region GetStandardsSets

        [Test]
        public void GetStandardsSets_Returns_List_Of_Standards_Sets()
        {
            // Arrange & Act
            var result = _sut.Standards.GetStandardsSets();

            // Assert
            result.ShouldNotBeNull();
        }
        
        #endregion GetStandardsSets


        #region GetStandardsBySet

        [Test]
        public void GetStandardsBySet_Returns_Standards()
        {
            // Arrange
            var standardsSetId = _profile.StandardsSets[0].SetId;
            var subject        = _profile.Subjects[0];
            var grade          = _profile.Grades[0];

            // Act
            var result = _sut.Standards.GetStandardsBySet(standardsSetId, subject, grade, false);

            // Assert
            result.ShouldNotBeNull();
        }


        [Test]
        public void GetStandardsBySet_Throws_Exception_When_Invalid_Credentials_Supplied()
        {
            // Arrange
            _sut = new EdGateClient(new EdGateClientOptions
            {
                EdGatePrivateKey = "private",
                EdGatePublicKey  = "public"
            });

            var standardsSetId   = _profile.StandardsSets[0].SetId;
            var subject          = _profile.Subjects[0];
            var grade            = _profile.Grades[0];

            // Act & Assert
            Assert.Throws<Exception>(() => _sut.Standards.GetStandardsBySet(standardsSetId, subject, grade, false));

        }

        #endregion GetStandardsBySet


        #region GetStandard

        [Test]
        public void GetStandard_Returns_Standard()
        {


            // Act
            var result = _sut.Standards.GetStandard("9.1.M.PK.A1");

            // Assert
            result.ShouldNotBeNull();
        }

        [Test]
        public void GetStandard_Throws_Exception_When_Invalid_Credentials_Supplied()
        {
            // Arrange
            _sut = new EdGateClient(new EdGateClientOptions
            {
                EdGatePrivateKey = "private",
                EdGatePublicKey = "public"
            });

            // Act & Assert
            Assert.Throws<Exception>(() => _sut.Standards.GetStandard("9.1.M.PK.A1"));

        }

        #endregion GetStandard

        #endregion


        #region Profile  Tests

        #region GetProfile

        [Test]
        public void GetProfile_Returns_Profile()
        {
            // Arrange & Act
            var result = _sut.Profile.GetProfile();

            // Assert
            result.ShouldNotBeNull();
        }

        [Test]
        public void GetProfile_Throws_Exception_When_Invalid_Credentials_Supplied()
        {
            // Arrange
            _sut = new EdGateClient(new EdGateClientOptions
            {
                EdGatePrivateKey = "private",
                EdGatePublicKey  = "public"
            });

            // Act & Assert
            Assert.Throws<Exception>(() => _sut.Profile.GetProfile());

        }

        #endregion GetProfile

        #endregion

    }
}
