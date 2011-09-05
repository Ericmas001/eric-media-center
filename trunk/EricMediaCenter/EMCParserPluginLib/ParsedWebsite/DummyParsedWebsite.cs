using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCMasterPluginLib;

namespace EMCParserPluginLib.ParsedWebsite
{
    public class DummyParsedWebsite : AbstractParsedWebsite
    {
        public DummyParsedWebsite(string url)
            : base(url)
        {
        }
    }
}
