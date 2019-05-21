using AngleSharp.Dom.Html;

namespace habra_angelsharp.Core
{
    interface IParser<T> where T : class
    {
        T Parse(IHtmlDocument document);
    }
}
