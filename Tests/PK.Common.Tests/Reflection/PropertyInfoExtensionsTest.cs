using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace PK.Common.Reflection
{
    [TestClass]
    public class PropertyInfoExtensionsTest
    {
        [TestClass]
        public class TheGetCustomAttributeMethod
        {
            [TestMethod]
            public void ShouldReturnTheAttributeOfTheTypeSpecifiedOnTheProperty()//Not same instance = correct?
            {
                PropertyInfo actualProperty;
                DummyTestAttribute actualAttribute;
                DummyTestAttribute expectedAttribute;

                //Arrange
                actualProperty = typeof(DummyTestClass).GetProperty("DummyPropertyWith1Attribute");
                expectedAttribute = System.Reflection.CustomAttributeExtensions.GetCustomAttribute<DummyTestAttribute>(actualProperty, false);
                //Act
                actualAttribute = actualProperty.GetCustomAttribute<DummyTestAttribute>();
                //Assert
                actualAttribute.ShouldBeEquivalentTo(expectedAttribute);
            }
            [TestMethod]
            public void ShouldReturnNullWhenCalledWithAnAbsentCustomAttributeOnTheProperty()
            {
                PropertyInfo actualProperty;
                SerializableAttribute actualAttribute;
                SerializableAttribute expectedAttribute;

                //Arrange
                actualProperty = typeof(DummyTestClass).GetProperty("DummyPropertyWith1Attribute");
                expectedAttribute = System.Reflection.CustomAttributeExtensions.GetCustomAttribute<SerializableAttribute>(actualProperty, false);
                //Act
                actualAttribute = actualProperty.GetCustomAttribute<SerializableAttribute>();
                //Assert
                actualAttribute.ShouldBeEquivalentTo(expectedAttribute);
            }
            [TestClass]
            public class TheGetCustomAttributesMethod
            {
                [TestMethod]
                public void ShouldReturnAllMatchingCustomAttributesSpecifiedOnTheProperty()
                {
                    PropertyInfo actualProperty;
                    IEnumerable<DummyTestAttribute> actualAttributes;
                    IEnumerable<DummyTestAttribute> expectedAttributes;

                    //Arrange
                    actualProperty = typeof(DummyTestClass).GetProperty("DummyPropertyWith2Attributes");
                    expectedAttributes = System.Reflection.CustomAttributeExtensions.GetCustomAttributes<DummyTestAttribute>(actualProperty, false);
                    //Act
                    actualAttributes = actualProperty.GetCustomAttributes<DummyTestAttribute>();
                    //Assert
                    actualAttributes.ShouldBeEquivalentTo(expectedAttributes);
                }
                [TestMethod]
                public void ShouldReturnAnEmptyEnumerableWhenCalledWithAnAbsentCustomAttributesOnTheProperty()
                {
                    PropertyInfo actualProperty;
                    IEnumerable<SerializableAttribute> actualAttributes;
                    IEnumerable<SerializableAttribute> expectedAttributes;

                    //Arrange
                    actualProperty = typeof(DummyTestClass).GetProperty("DummyPropertyWith2Attributes");
                    expectedAttributes = System.Reflection.CustomAttributeExtensions.GetCustomAttributes<SerializableAttribute>(actualProperty, false);
                    //Act
                    actualAttributes = actualProperty.GetCustomAttributes<SerializableAttribute>();
                    //Assert
                    actualAttributes.ShouldBeEquivalentTo(expectedAttributes);
                }
            }
        }
    }
}