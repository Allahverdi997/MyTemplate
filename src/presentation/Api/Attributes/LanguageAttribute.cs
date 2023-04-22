namespace Api.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    public class LanguageAttribute:Attribute
    {
    }
}
