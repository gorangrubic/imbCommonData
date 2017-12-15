using imbACE.Network.tools;
using imbSCI.Data.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imbCommonModels.webStructure
{
    public class webCrawlerProfile:IObjectWithNameAndDescription
    {
        public String name { get; set; } = "";

        public String description { get; set; } = "";

        public webCrawlerProfile()
        {

        }
    }
 

    public class webSiteProfile:IObjectWithName, IObjectWithNameAndDescription
    {

        public String name { get; set; } = "";

        public String description { get; set; } = "";
        public webSiteProfile()
        {

        }

        public webSiteProfile(String _url)
        {
            domainInfo = new domainAnalysis(_url);
            url = domainInfo.urlProper;
            domain = domainInfo.domainName;
            name = domainInfo.domainRootName;

        }
        public domainAnalysis domainInfo { get; set; }

        public String domain {get;set;}

        public String url { get; set; }
    }
}
