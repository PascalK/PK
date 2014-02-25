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
    public class PropertySetSettingManagerTest
    {
        static readonly string stringSettingKey = "TestStringSettingKey";
        static readonly string stringSettingValue = "TestStringSettingValue";
        static readonly string stringNotExistingSettingKey = "TestStringSettingKeyNotExist";
        static readonly SettingType<string> stringSettingType = SettingType<string>.Text;

        [TestClass]
        public class TheGetMethod
        {
            private static IPropertySet settingValues;
            PropertySetSettingManager unit;

            [ClassInitialize()]
            public static void MyClassInitialize(TestContext testContext)
            {
                settingValues = new PropertySet();
                settingValues[stringSettingKey] = stringSettingValue;
            }
            [TestInitialize()]
            public void MyTestInitialize()
            {
                unit = new PropertySetSettingManager(settingValues);
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
            [TestMethod, TestCategory("CodeContract")]
            public void ShouldAssertKeyParameterIsNotNull()
            {
                //Arrange
                //Act
                Action action = () =>
                    unit.Get<object>(null);
                //Assert
                action.ShouldThrow<ArgumentNullException>();
            }
        }
        [TestClass]
        public class TheSetMethod
        {
            private static IPropertySet settingValues;
            PropertySetSettingManager unit;

            [TestInitialize()]
            public void MyTestInitialize()
            {
                settingValues = new PropertySet();
                unit = new PropertySetSettingManager(settingValues);
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
            [TestMethod, TestCategory("CodeContract")]
            public void ShouldAssertSettingParameterIsNotNull()
            {
                //Arrange
                //Act
                Action action = () =>
                    unit.Set<object>(null);
                //Assert
                action.ShouldThrow<ArgumentNullException>();
            }
            [TestMethod, TestCategory("CodeContract")]
            public void ShouldAssertKeyParameterIsNotNull()
            {
                //Arrange
                //Act
                Action action = () =>
                    unit.Set<object>(null, null);
                //Assert
                action.ShouldThrow<ArgumentNullException>();
            }
        }
    }
}