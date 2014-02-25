using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PK.Application.Web
{
    [TestClass]
    public class WebApplicationBaseTests
    {
        [TestClass]
        public class TheInitializeApplicationMethod
        {
            [TestMethod]
            public void ShouldBeCalledByConstructorAndResultShouldBeApplicationProperty()
            {
                TestWebApplication unit;
                //Arrange
                //Act
                unit = new TestWebApplication();
                //Assert
                unit.Application.Should().NotBeNull();
            }
        }
        [TestClass]
        public class TheApplication_InitializeMethod
        {
            [TestMethod]
            public void ShouldCallOnInitializeMethodOnApplication()
            {
                TestWebApplication unit;
                EventArgs actualEventArgs;
                object actualSender;
                //Arrange
                actualSender = new object();
                actualEventArgs = new EventArgs();
                unit = new TestWebApplication();
                unit.Application.MonitorEvents();
                //Act
                unit.TestApplication_Init();
                //Assert
                unit.Application.ShouldRaise("OnInitializeCalled");
            }
        }
        [TestClass]
        public class TheApplication_StartMethod
        {
            [TestMethod]
            public void ShouldCallOnStartMethodOnApplication()
            {
                TestWebApplication unit;
                EventArgs actualEventArgs;
                object actualSender;
                //Arrange
                actualSender = new object();
                actualEventArgs = new EventArgs();
                unit = new TestWebApplication();
                unit.Application.MonitorEvents();
                //Act
                unit.TestApplication_Start(actualSender, actualEventArgs);
                //Assert
                unit.Application.ShouldRaise("OnStartCalled");
            }
        }
        [TestClass]
        public class TheApplication_EndMethod
        {
            [TestMethod]
            public void ShouldCallOnEndMethodOnApplication()
            {
                TestWebApplication unit;
                EventArgs actualEventArgs;
                object actualSender;
                //Arrange
                actualSender = new object();
                actualEventArgs = new EventArgs();
                unit = new TestWebApplication();
                unit.Application.MonitorEvents();
                //Act
                unit.TestApplication_End(actualSender, actualEventArgs);
                //Assert
                unit.Application.ShouldRaise("OnEndCalled");
            }
        }
        [TestClass]
        public class TheApplication_ErrorMethod
        {
            [TestMethod]
            public void ShouldCallOnErrorMethodOnApplication()
            {
                TestWebApplication unit;
                EventArgs actualEventArgs;
                object actualSender;
                //Arrange
                actualSender = new object();
                actualEventArgs = new EventArgs();
                unit = new TestWebApplication();
                unit.Application.MonitorEvents();
                //Act
                unit.TestApplication_Error(actualSender, actualEventArgs);
                //Assert
                unit.Application.ShouldRaise("OnErrorCalled");
            }
        }
        private class TestWebApplication : WebApplicationBase<TestApplication>
        {
            public void TestApplication_Init()
            {
                base.Init();
            }
            public void TestApplication_Start(object sender, EventArgs e)
            {
                base.Application_Start(sender, e);
            }
            public void TestApplication_End(object sender, EventArgs e)
            {
                base.Application_End(sender, e);
            }
            public void TestApplication_Error(object sender, EventArgs e)
            {
                base.Application_Error(sender, e);
            }
        }
        private class TestApplication : ApplicationBase 
        {
            public event EventHandler OnInitializeCalled;
            public event EventHandler OnStartCalled;
            public event EventHandler OnEndCalled;
            public event EventHandler OnErrorCalled;
            public override void OnInitialize()
            {
                base.OnInitialize();
                if (OnInitializeCalled != null) OnInitializeCalled(this, EventArgs.Empty);
            }
            public override void OnStart()
            {
                base.OnStart();
                if (OnStartCalled != null) OnStartCalled(this, EventArgs.Empty);
            }
            public override void OnEnd()
            {
                base.OnEnd();
                if (OnEndCalled != null) OnEndCalled(this, EventArgs.Empty);

            }
            public override void OnError()
            {
                base.OnError();
                if (OnErrorCalled != null) OnErrorCalled(this, EventArgs.Empty);
            }
        }
    }
}
