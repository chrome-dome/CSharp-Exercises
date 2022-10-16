namespace Workshop.Common
{
    public class TestClassAttribute : Attribute { }
    public class TestMethodAttribute : NUnit.Framework.TestAttribute { }
    public class TestInitializeAttribute : NUnit.Framework.SetUpAttribute { }
}