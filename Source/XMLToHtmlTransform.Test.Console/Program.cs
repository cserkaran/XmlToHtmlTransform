using Infrastructure.Extensibility;
using System;

namespace XMLToHtmlTransform.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            AppBootStrapper appBootStrapper = new AppBootStrapper();
            appBootStrapper.Run();
            Infrastructure.Services.AppContext.Instance.Host.Queue.Run();
            Console.Read();
        }
    }
}
