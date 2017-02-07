namespace Infrastructure.Contracts
{
    public struct XmlContent
    {
        public string FileName { get; }

        public string Content { get; }

        public XmlContent(string fileName,string content)
        {
            this.FileName = fileName;
            this.Content = content;
        }
    }
}
