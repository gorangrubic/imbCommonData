using HtmlAgilityPack;
using imbCommonModels.contentBlock;
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
    /// <seealso cref="imbMiningContext.MCDocumentStructure.imbMCDocumentElement" />
    public class imbMCBlock: imbMCDocumentElement
    {

        public nodeBlock blockModel { get; set; }

        /// <summary>
        /// Extracted text content from the block
        /// </summary>
        /// <value>
        /// The content of the text.
        /// </value>
        public String textContent { get; set; }
    }


}
