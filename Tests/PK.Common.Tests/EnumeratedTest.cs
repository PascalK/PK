using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using FluentAssertions;
using System.IO;
using System.Runtime.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.Serialization.Formatters.Binary;

namespace PK.Common
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class EnumeratedTest
    {
        [TestMethod]
        public void ShouldBeBinarySerializable()
        {
            ClosedTestEnumerated unit;
            //Arrange
            unit = ClosedTestEnumerated.TestEnum1;
            //Act
            //Assert
            unit.Should().BeBinarySerializable();
        }
        [TestMethod]
        public void ShouldResultInSameInstanceWhenDeserialized()
        {
            ClosedTestEnumerated unit;
            //Arrange
            unit = ClosedTestEnumerated.TestEnum1;
            //Act
            var actualResult = CreateCloneUsingBinarySerializer(unit);
            //Assert
            actualResult.Should().BeSameAs(unit);
        }
        private static T CreateCloneUsingBinarySerializer<T>(T subject)
        {
            using (var stream = new MemoryStream())
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(stream, subject);

                stream.Position = 0;
                return (T)binaryFormatter.Deserialize(stream);
            }
        }
        [TestClass]
        public class TheGetMethod
        {
            [TestMethod]
            public void ShouldReturnTheSameInstanceWhenCalledTwice()
            {
                //Arrange
                string actualValue = "ClosedTestEnum1Value";
                //Act
                var actual1 = ClosedTestEnumerated.Get(actualValue);
                var actual2 = ClosedTestEnumerated.Get(actualValue);
                //Assert
                actual1.Should().BeSameAs(actual2);
            }
            [TestMethod]
            public void ShouldThrowAnExceptionWhenEnumeratedWithRequestedValueDoesNotExist()
            {
                //Arrange
                string actualValue = "NonExistentValue";
                //Act
                this.Invoking(t =>
                    ClosedTestEnumerated.Get(actualValue)).ShouldThrow<InvalidOperationException>();
                this.Invoking(t =>
                    ClosedTestEnumerated.Get(null)).ShouldThrow<InvalidOperationException>();
            }
            [TestMethod]
            public void ShouldReturnCorrectInstanceWhenEnumeratedValueEqualsNull()
            {
                //Arrange
                string actualValue = null;
                //Act
                var actual = NullTestEnumerated.Get(actualValue);
                //Assert
                actual.Should().BeSameAs(NullTestEnumerated.Null);
            }
        }
        [TestClass]
        public class TheGetAllFunction
        {
            [TestMethod]
            public void ShouldReturnAllExistingStaticTypes()
            {
                //Arrange
                //Act
                var actualResult = ClosedTestEnumerated.GetAll();
                //Assert
                actualResult.Count().Should().Be(2);
                actualResult.Should().Contain(ClosedTestEnumerated.TestEnum1);
                actualResult.Should().Contain(ClosedTestEnumerated.TestEnum2);
            }
        }
        [DataContract]
        [Serializable]
        private class ClosedTestEnumerated : Enumerated<ClosedTestEnumerated, string>, ISerializable
        {
            private ClosedTestEnumerated(string value)
                : base(value)
            {
            }
            public static ClosedTestEnumerated TestEnum1 = new ClosedTestEnumerated("ClosedTestEnum1Value");
            public static ClosedTestEnumerated TestEnum2 = new ClosedTestEnumerated("ClosedTestEnum2Value");

            #region Serialization
            /// <summary>
            /// Populates a System.Runtime.Serialization.SerializationInfo with the data needed to serialize the target object.
            /// </summary>
            /// <param name="info">The System.Runtime.Serialization.SerializationInfo to populate with data</param>
            /// <param name="context">The destination (see System.Runtime.Serialization.StreamingContext) for this serialization.</param>
            /// <exception cref="System.Security.SecurityException">The caller does not have the required permission</exception>
            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.SetType(typeof(EnumeratedSerializationHelper<ClosedTestEnumerated, string>));
                info.AddValue("Value", this.Value);
            }
            [Serializable]
            private class EnumeratedSerializationHelper<TEnumerated, TValue> : IObjectReference
                where TEnumerated : class, IEnumerated<TEnumerated, TValue>
            {
                private TValue Value;
                public EnumeratedSerializationHelper(SerializationInfo info, StreamingContext context)
                {
                    Value = (TValue)info.GetValue("Value", typeof(TValue));
                }
                public object GetRealObject(StreamingContext context)
                {
                    return Enumerated<TEnumerated, TValue>.Get(Value);
                }

                public void GetObjectData(SerializationInfo info, StreamingContext context)
                {
                    throw new InvalidOperationException("Object of type EnumeratedSerializationHelper<TEnumerated, TValue> should not be serialized directly");
                }
            }

            #endregion
        }
        private class NullTestEnumerated : Enumerated<NullTestEnumerated, string>
        {
            public NullTestEnumerated(string value)
                : base(value)
            {
            }

            public static NullTestEnumerated Null = new NullTestEnumerated(null);
        }
    }
}