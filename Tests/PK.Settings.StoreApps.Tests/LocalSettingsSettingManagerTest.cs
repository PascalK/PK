using System;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Windows.Foundation.Collections;
using Windows.Storage;

namespace PK.Settings.StoreApps
{
    [TestClass]
    public class LocalSettingsSettingManagerTest
    {
        [TestMethod, TestCategory("CodeContract")]
        public void ShouldAssertSettingSourceParameterIsNotNull()
        {
            LocalSettingsSettingManager unit;
            //Arrange
            //Act
            Action action = () =>
                unit = new LocalSettingsSettingManager(null);
            //Assert
            action.ShouldThrow<ArgumentNullException>();
        }
    }
}