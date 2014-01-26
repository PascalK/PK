using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PK.Application
{
    [TestClass]
    public class ApplicationBaseTests
    {
        TestApplication unit;

        [TestInitialize()]
        public void MyTestInitialize()
        {
            unit = new TestApplication();
        }

        [TestClass]
        public class TheOnInitializeMethod:ApplicationBaseTests
        {
            [TestMethod]
            public void ShouldDoNothing() //:)
            {
                //Arrange
                //Act
                unit.OnInitialize();
                //Assert
            }
        }
        [TestClass]
        public class TheOnStartMethod : ApplicationBaseTests
        {
            [TestMethod]
            public void ShouldDoNothing() //:)
            {
                //Arrange
                //Act
                unit.OnStart();
                //Assert
            }
        }
        [TestClass]
        public class TheOnEndMethod : ApplicationBaseTests
        {
            [TestMethod]
            public void ShouldDoNothing() //:)
            {
                //Arrange
                //Act
                unit.OnEnd();
                //Assert
            }
        }
        [TestClass]
        public class TheOnErrorMethod : ApplicationBaseTests
        {
            [TestMethod]
            public void ShouldDoNothing() //:)
            {
                //Arrange
                //Act
                unit.OnError();
                //Assert
            }
        }
        private class TestApplication : ApplicationBase
        {

        }

    }
}