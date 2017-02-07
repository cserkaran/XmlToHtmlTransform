﻿using Infrastructure.Contracts;
using System;
using System.ComponentModel.Composition;
using System.IO;

namespace Subscriber
{
    [Export(typeof(IConsumer))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class Subscriber : IConsumer
    {
        private string _outputPath = @"../Output";
        string xslt;

        public Subscriber()
        {
            if (Directory.Exists(_outputPath))
            {
                Directory.Delete(_outputPath, true);
            }

            Directory.CreateDirectory(_outputPath);

            xslt = File.ReadAllText(@"../Resources/Computer.xslt");

            File.WriteAllText(_outputPath + "/Style.css",string.Empty);
            File.Copy(@"../Resources/Style.css", _outputPath + "/Style.css",true);

        }

        public void Consume(XmlContent content)
        {
            var html = Utilities.Utils.TransformXMLToHTML(content.Content, xslt);
            var filePath = string.Format("{0}//{1}.html", _outputPath, content.FileName);
            File.WriteAllText(filePath, html);
            FileInfo info = new FileInfo(filePath);
            Console.WriteLine("Consume content from Queue and write to " + info.FullName);
        }
    }
}
