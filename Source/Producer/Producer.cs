using System;
using Infrastructure.Contracts;
using System.ComponentModel.Composition;
using System.Collections.Generic;
using Infrastructure.CustomEventArgs;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Producer
{
    [Export(typeof(IProducer))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class Producer : IProducer
    {
        private readonly CancellationTokenSource _cancelTokenSource = new CancellationTokenSource();

        private  Task _publisherTask;

        public event EventHandler<XmlContentEventArgs> Produced;

        private void OnPublish(IList<XmlContent> xmlContents)
        {
            Produced?.Invoke(this, new XmlContentEventArgs(xmlContents));
        }

        public void Produce()
        {
            _publisherTask = Task.Factory.StartNew(() =>
            {
                var dirInfo = new DirectoryInfo(@"../Data/Computers");
                foreach (var file in dirInfo.GetFiles())
                {
                    var fileName = Path.GetFileNameWithoutExtension(file.FullName);
                    var fileContent = File.ReadAllText(file.FullName);
                    XmlContent content = new XmlContent(fileName,fileContent);
                    IList<XmlContent> contents = new List<XmlContent>();
                    contents.Add(content);
                    Console.WriteLine("Produce content from and place it on Queue for " + file.FullName);
                    OnPublish(contents);
                }
                //OnComplete();
            });
           
        }

    }
}
