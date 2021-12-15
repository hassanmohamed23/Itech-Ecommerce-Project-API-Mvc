using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbayView.Services
{
    public class AzureStorage
    {
        public string ConnectionString { get; set; }
        public string ContainerName { get; set; }
        public string SourceFolder { get; set; }
         
    }
}
