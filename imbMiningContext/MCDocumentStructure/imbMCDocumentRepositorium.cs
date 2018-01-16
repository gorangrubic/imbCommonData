using System;
using System.Linq;
using System.Collections.Generic;
using HtmlAgilityPack;
using imbSCI.Data.collection.graph;
using System.Text;
using imbMiningContext.MCWebSite;
using imbMiningContext.MCRepository;

namespace imbMiningContext.MCDocumentStructure
{

    public class imbMCDocumentRepositorium:imbMCDocumentElement
    {

        public imbMCRepository webRepository { get; set; }


        public imbMCDocumentRepositorium()
        {

        }
    }

}