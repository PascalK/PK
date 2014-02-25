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
    public class RoamingSettingsSettingManagerTest
    {
        [TestMethod, TestCategory("CodeContract")]
        public void ShouldAssertSettingSourceParameterIsNotNull()
        {
            RoamingSettingsSettingManager unit;
            //Arrange
            //Act
            Action action = () =>
                unit = new RoamingSettingsSettingManager(null);
            //Assert
            action.ShouldThrow<ArgumentNullException>();
        }
    }
}