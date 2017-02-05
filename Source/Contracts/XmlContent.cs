namespace Contracts
{
    public struct XmlContent
    {
        string FileName { get; }

        string Content { get; }

        public XmlContent(string fileName,string content)
        {
            this.FileName = fileName;
            this.Content = content;
        }
    }
}
