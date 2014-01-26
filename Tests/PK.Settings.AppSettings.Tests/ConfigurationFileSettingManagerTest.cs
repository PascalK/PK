using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Globalization;

namespace PK.Settings.AppSettings
{
    [TestClass]
    public class AppSettingsSettingManagerTest
    {
        static readonly DateTime dateSettingValue = new DateTime(2014, 01, 14, 17, 23, 15);
        static readonly string dateSettingKey = "dateSettingKey";
        static readonly string nonExistingSettingKey = "ThereIsNoSettingWithThisKey";
        static readonly SettingType<DateTime> dateTimeSettingType = SettingType<DateTime>.DateTime;

        [TestClass]
        public class TheGetFunction
        {
            private AppSettingsSettingManager unit;

            [ClassInitialize()]
            public static void MyClassInitialize(TestContext testContext)
            {
                ConfigurationManager.AppSettings[dateSettingKey] = dateSettingValue.ToString(CultureInfo.InvariantCulture);
            }
            [TestInitialize()]
            public void MyTestInitialize()
            {
                unit = new AppSettingsSettingManager();
            }

            [TestMethod]
            public void ShouldGetTheConfiguredSettingWithTheRightTypeKeyAndValue()
            {
                //Arrange
                //Act
                var actualSettingValue = unit.Get<DateTime>(dateSettingKey);
                //Assert
                actualSettingValue.Key.Should().Be(dateSettingKey);
                actualSettingValue.Value.Should().Be(dateSettingValue);
                actualSettingValue.Type.Should().BeSameAs(SettingType<DateTime>.Get());
            }
            [TestMethod]
            public void ShouldReturnNullWhenASettingKeyDoesNotExist()
            {
                //Act
                var actualResult = unit.Get<DateTime>(nonExistingSettingKey);
                //Assert
                actualResult.Should().BeNull();
            }
        }
        [TestClass]
        public class TheSetMethod
        {
            private AppSettingsSettingManager unit;

            [TestInitialize()]
            public void MyTestInitialize()
            {
                unit = new AppSettingsSettingManager();
            }

            [TestMethod]
            public void ShouldSaveParsedValueInConfigurationManagerAppSettingsWhenCalledWithAKeyAndValue()
            {
                string expectedSavedSettingValue;
                //Arrange
                expectedSavedSettingValue = dateTimeSettingType.ParseFrom(dateSettingValue);
                //Act
                unit.Set(dateSettingKey, dateSettingValue);
                //Assert
                ConfigurationManager.AppSettings.Keys.Should().Contain(dateSettingKey);
                ConfigurationManager.AppSettings[dateSettingKey].Should().Be(expectedSavedSettingValue);
            }
            [TestMethod]
            public void ShouldSaveParsedValueInConfigurationManagerAppSettingsWhenCalledWithASettingInstance()
            {
                ISetting<DateTime> actualSetting;
                string expectedSavedSettingValue;
                //Arrange
                expectedSavedSettingValue = dateTimeSettingType.ParseFrom(dateSettingValue);
                actualSetting = new Setting<DateTime>(dateSettingKey)
                {
                    Type = dateTimeSettingType,
                    Value = dateSettingValue,
                };
                //Act
                unit.Set(actualSetting);
                //Assert
                ConfigurationManager.AppSettings.Keys.Should().Contain(dateSettingKey);
                ConfigurationManager.AppSettings[dateSettingKey].Should().Be(expectedSavedSettingValue);
            }
        }
    }
}
