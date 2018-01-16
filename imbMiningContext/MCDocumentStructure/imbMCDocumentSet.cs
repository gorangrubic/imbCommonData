using System;
using System.Linq;
using System.Collections.Generic;
using HtmlAgilityPack;
using imbSCI.Data.collection.graph;
using System.Text;
using imbMiningContext.MCWebSite;

namespace imbMiningContext.MCDocumentStructure
{

    public class imbMCDocumentSet:imbMCDocumentElement
    {

        public imbMCWebSite siteRepo { get; set; }


        public imbMCDocumentSet()
        {
            
        }
    }

}