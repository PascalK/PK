using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Globalization;

namespace PK.Settings.Tests
{
    [TestClass]
    public class SettingTypesTest
    {
        [TestMethod, TestCategory("CodeContract")]
        public void ShouldThrowAnExceptionWhenConstructedWithoutAParseToFunction()
        {
            //Arrange
            //Act
            Action action = () =>
                new SettingType<object>(null, o => o.ToString());
            //Assert
            action.ShouldThrow<ArgumentNullException>();
        }
        [TestMethod, TestCategory("CodeContract")]
        public void ShouldThrowAnExceptionWhenConstructedWithoutAParseFromFunction()
        {
            //Arrange
            //Act
            Action action = () =>
                new SettingType<object>(s => s, null);
            //Assert
            action.ShouldThrow<ArgumentNullException>();
        }
        [TestClass]
        public class TheGetFunction
        {
            [TestMethod]
            public void ShouldReturnCorrectSettingTypeAccordingEqualToTheProvidedType()
            {
                //Arrange
                var expectedNullableDateTime = SettingType<DateTime?>.DateTimeNullable;
                var expectedDateTime = SettingType<DateTime>.DateTime;
                //Act
                var actualNullableDateTimeResult = SettingType<DateTime?>.Get();
                var actualDateTimeResult = SettingType<DateTime>.Get();
                //Assert
                actualNullableDateTimeResult.Should().BeSameAs(expectedNullableDateTime);
                actualDateTimeResult.Should().BeSameAs(expectedDateTime);
            }
        }
        [TestClass]
        public class TheParseFunction
        {
            [TestMethod]
            public void ShouldReturnInitialValueWhenParsedAndUnparsed()
            {
                //Arrange
                TestParse(SettingType<byte[]>.Binary, "TestTextToBeParsedToAndFromBinary");
                TestParse(SettingType<byte[]>.Binary, null);
                TestParse(SettingType<DateTime>.DateTime, new DateTime(2014, 1, 14, 17, 6, 52).ToString(CultureInfo.InvariantCulture));
                TestParse(SettingType<DateTime?>.DateTimeNullable, new DateTime(2014, 1, 14, 17, 6, 52).ToString(CultureInfo.InvariantCulture));
                TestParse(SettingType<DateTime?>.DateTimeNullable, null);
                TestParse(SettingType<int>.Int, "1");
                TestParse(SettingType<int?>.IntNullable, "2");
                TestParse(SettingType<int?>.IntNullable, null);
                TestParse(SettingType<string>.Text, "TestTextToBeParsed");
            }

            private void TestParse<T>(SettingType<T> settingType, string initialSettingValue)
            {
                //Act
                var parsedSetting = settingType.ParseTo(initialSettingValue);
                var actualSetting = settingType.ParseFrom(parsedSetting);
                //Assert
                actualSetting.Should().Be(initialSettingValue);
            }
        }
    }
}