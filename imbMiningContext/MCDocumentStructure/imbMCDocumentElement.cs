using HtmlAgilityPack;
using imbSCI.Data.collection.graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imbMiningContext.MCDocumentStructure
{

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="imbSCI.Data.collection.graph.graphNodeCustom" />
    public abstract class imbMCDocumentElement:graphNodeCustom {

        protected override bool doAutorenameOnExisting { get { return true; } }

        protected override bool doAutonameFromTypeName { get { return true; } }

        public HtmlNode htmlNode { get; set; }



        /// <summary>
        /// Text content of the element
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        public String content { get; set; }

        /// <summary>
        /// char position at parent string-type document element
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        public Int32 position { get; set; }
    }

}