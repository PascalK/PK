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
        static readonly string stringSettingKey = "TestStringSettingKey";
        static readonly string stringSettingValue = "TestStringSettingValue";
        static readonly string stringNotExistingSettingKey = "TestStringSettingKeyNotExist";
        static readonly SettingType<string> stringSettingType = SettingType<string>.Text;

        [TestClass]
        public class TheGetMethod
        {
            private static IPropertySet settingValues;
            LocalSettingsSettingManager unit;

            [ClassInitialize()]
            public static void MyClassInitialize(TestContext testContext)
            {
                settingValues = ApplicationData.Current.LocalSettings.Values;
                settingValues[stringSettingKey] = stringSettingValue;
            }
            [TestInitialize()]
            public void MyTestInitialize()
            {
                unit = new LocalSettingsSettingManager(settingValues);
            }

            [TestMethod]
            public void ShouldGetTheConfiguredSettingWithTheRightTypeKeyAndValue()
            {
                //Arrange
                //Act
                var actualSetting = unit.Get<string>(stringSettingKey);
                //Assert
                actualSetting.Key.Should().Be(stringSettingKey);
                actualSetting.Type.Should().BeSameAs(SettingType<string>.Get());
                actualSetting.Value.Should().Be(stringSettingValue);
            }
            [TestMethod]
            public void ShouldReturnNullWhenASettingKeyDoesNotExist()
            {
                //Arrange
                //Act
                var actualSetting = unit.Get<string>(stringNotExistingSettingKey);
                //Assert
                actualSetting.Should().BeNull();
            }
        }
        [TestClass]
        public class TheSetMethod
        {
            private static IPropertySet settingValues;
            LocalSettingsSettingManager unit;

            [TestInitialize()]
            public void MyTestInitialize()
            {
                settingValues = ApplicationData.Current.LocalSettings.Values;
                settingValues.Clear();
                unit = new LocalSettingsSettingManager(settingValues);
            }

            [TestMethod]
            public void ShouldSaveParsedValueInConfigurationManagerAppSettingsWhenCalledWithAKeyAndValue()
            {
                //Arrange
                //Act
                unit.Set(stringSettingKey, stringSettingValue);
                //Assert
                settingValues[stringSettingKey].Should().Be(stringSettingValue);
            }
            [TestMethod]
            public void ShouldSaveParsedValueInConfigurationManagerAppSettingsWhenCalledWithASettingInstance()
            {
                ISetting<string> actualSetting;
                //Arrange
                actualSetting = new Setting<string>(stringSettingKey)
                {
                    Type = stringSettingType,
                    Value = stringSettingValue,
                };
                //Act
                unit.Set(stringSettingKey, stringSettingValue);
                //Assert
                settingValues[stringSettingKey].Should().Be(stringSettingValue);
            }
        }
    }
}