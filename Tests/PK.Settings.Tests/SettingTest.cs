using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PK.Settings
{
    [TestClass]
    public class SettingTest
    {
        [TestMethod, TestCategory("CodeContract")]
        public void ShouldAssertKeyParameterIsNotNull()
        {
            //Arrange
            //Act
            Action action = ()=>
                new Setting<object>(null);
            //Assert
            action.ShouldThrow<ArgumentNullException>();
        }
    }
}
