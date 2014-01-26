using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PK.Common.Reflection
{
    internal class DummyTestClass
    {
#pragma warning disable 0649
        public string dummyField1;
#pragma warning restore 0649
        public string DummyProperty1 { get; set; }
        [DummyTestAttribute(DummyProperty2 = "DummyTestClass.DummyPropertyWith1Attribute.DummyTestAttribute.DummyProperty2")]
        public string DummyPropertyWith1Attribute { get; set; }
        [DummyTestAttribute(DummyProperty2 = "DummyTestClass.DummyPropertyWith2Attributes.DummyTestAttribute.DummyProperty2.1")]
        [DummyTestAttribute(DummyProperty2 = "DummyTestClass.DummyPropertyWith2Attributes.DummyTestAttribute.DummyProperty2.2")]
        public string DummyPropertyWith2Attributes { get; set; }
    }
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    internal class DummyTestAttribute : Attribute
    {

        public string DummyProperty2 { get; set; }
    }
}
