using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TryWeb
{
    public class TextConfigurationSource : IConfigurationSource
    {

        public string FilePath { get; set; }
        public TextConfigurationSource(string path)
        {
            FilePath = path;
        }
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            string filepath = builder.GetFileProvider().GetFileInfo(FilePath).PhysicalPath;
            return new TextConfigurationProvider(filepath);
        }
    }
}
