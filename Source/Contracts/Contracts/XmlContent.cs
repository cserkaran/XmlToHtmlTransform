namespace Infrastructure.Contracts
{
    /// <summary>
    /// Wraps the xml content payload to be placed on the queue.
    /// Contains the xml file name to be transformed and content of the file.
    /// </summary>
    public struct XmlContent
    {
        /// <summary>
        /// Gets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        public string FileName { get; }

        /// <summary>
        /// Gets the content.
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        public string Content { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlContent"/> struct.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="content">The content.</param>
        public XmlContent(string fileName,string content)
        {
            this.FileName = fileName;
            this.Content = content;
        }
    }
}
