using System;
using System.Collections.Generic;
using System.Text;

namespace Awesome.Proxy
{
    public class ProxyConfiguration
    {
        public string DestinationUrl { get; set; }
        public string[] Rules { get; set; }
    }
}
