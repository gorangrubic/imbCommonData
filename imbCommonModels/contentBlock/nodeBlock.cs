// --------------------------------------------------------------------------------------------------------------------
// <copyright file="nodeBlock.cs" company="imbVeles" >
//
// Copyright (C) 2017 imbVeles
//
// This program is free software: you can redistribute it and/or modify
// it under the +terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see http://www.gnu.org/licenses/. 
// </copyright>
// <summary>
// Project: imbCommonModels
// Author: Goran Grubic
// ------------------------------------------------------------------------------------------------------------------
// Project web site: http://blog.veles.rs
// GitHub: http://github.com/gorangrubic
// Mendeley profile: http://www.mendeley.com/profiles/goran-grubi2/
// ORCID ID: http://orcid.org/0000-0003-2673-9471
// Email: hardy@veles.rs
// </summary>
// ------------------------------------------------------------------------------------------------------------------
namespace imbCommonModels.contentBlock
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using imbSCI.Data;
    using imbSCI.Data.interfaces;
    using imbSCI.Data.collection.graph;
    using imbSCI.DataComplex.special;
    using imbSCI.Core.extensions.text;
    using imbSCI.Core.math;
    using imbSCI.Core.extensions.data;

    /// <summary>
    /// One block of content nodes
    /// </summary>
    /// <seealso cref="System.Collections.Generic.List{imbCommonModels.contentBlock.htmlWrapper}" />
    public class nodeBlock:List<htmlWrapper>
    {

        public nodeBlock()
        {

        }

        public nodeBlock(graphWrapNode<htmlWrapper> input)
        {
            Add(input);

            deploy();
        }

        public nodeBlock(List<graphWrapNode<htmlWrapper>> inputs)
        {
            foreach (var input in inputs)
            {
                Add(input);
            }
            deploy();
        }

        /// <summary>
        /// 
        /// </summary>
        public nodeBlockSemanticRoleEnum role { get; set; } = nodeBlockSemanticRoleEnum.reserve;


        /// <summary>
        /// Links in block - normalized frequency
        /// </summary>
        public double lbf { get; set; }


        /// <summary>
        /// Number of nodes that are links actually
        /// </summary>
        /// <value>
        /// The link node count.
        /// </value>
        public int linkNodeCount
        {
            get {

                return xPathList.Count(x => x.Contains("\\a"));
            }
        }


        private double _entropy = double.MaxValue;
        /// <summary>
        /// 
        /// </summary>
        public double entropy
        {
            get {
                if (_entropy == double.MaxValue) _entropy = CalculateEntropy();
                return _entropy; }
            set { _entropy = value; }
        }

        public double E
        {
            get
            {
                return Math.Abs(entropy) * lbf;
            }
        }

        /// <summary>
        /// Calculates the entropy.
        /// </summary>
        /// <returns></returns>
        public double CalculateEntropy()
        {
            instanceCountCollection<string> textStats = GetTextTokenStats();
            textStats.reCalculate();

            return textStats.entropyFreq; 
        }



        private string _textContent;
        /// <summary>
        /// Textual content of the block
        /// </summary>
        public string textContent
        {
            get {
                if (_textContent.isNullOrEmpty())
                {
                    _textContent = getContent(nodeBlockOutputEnum.text);
                }
                return _textContent; }
            set { _textContent = value; }
        }


        private string _textHash; // = "";
        /// <summary>
        /// Block text hash
        /// </summary>
        public string textHash
        {
            get {
                if (_textHash.isNullOrEmpty()) _textHash = md5.GetMd5Hash(textContent, false);
                return _textHash;
            }
        }

        ///// <summary>
        ///// Gets the link nodes.
        ///// </summary>
        ///// <returns></returns>
        //public List<HtmlNode> GetLinkNodes()
        //{
        //    List<HtmlNode> output = new List<HtmlNode>();

        //    foreach (htmlWrapper wrap in this)
        //    {
        //        var xnav = wrap.html.CreateNavigator();
        //        var links = xnav.Select("//a");

        //        foreach (XPathItem child in links)
        //        {
        //            HtmlNode node = child.TypedValue as HtmlNode;
        //            output.Add(node);
        //        }
        //    }
        //    return output;
        //}


        private List<string> _xPathList = new List<string>();
        /// <summary>
        /// 
        /// </summary>
        public List<string> xPathList
        {
            get {
                if (_xPathList == null)
                {
                    _xPathList = new List<string>();
                    
                    foreach (htmlWrapper wr in this)
                    {
                        _xPathList.Add(wr.xPath);
                    }
                    
                }
                return _xPathList; }
            set { _xPathList = value; }
        }




        private instanceCountCollection<string> _tokenStats;
        /// <summary>
        /// 
        /// </summary>
        [XmlIgnore]
        public instanceCountCollection<string> tokenStats
        {
            get {
                if (_tokenStats == null)
                {
                    _tokenStats = GetTextTokenStats(); 
                }
                return _tokenStats; }
            set { _tokenStats = value; }
        }


        /// <summary>
        /// Gets the text token stats.
        /// </summary>
        /// <returns></returns>
        public instanceCountCollection<string> GetTextTokenStats()
        {
            instanceCountCollection<string> output = new instanceCountCollection<string>();
            
            output.AddInstanceRange((IEnumerable<string>) textContent.getTokens(true, true, true));

            return output;
        }



        /// <summary>
        /// Extracting text from leaf nodes in the block
        /// </summary>
        /// <param name="mode">The mode.</param>
        /// <returns></returns>
        public string getContent(nodeBlockOutputEnum mode)
        {
            StringBuilder sb = new StringBuilder();

            foreach (htmlWrapper wrap in this)
            {
                sb.AppendLine(wrap.GetContent(mode));
            }

            return sb.ToString();
        }


        /// <summary>
        /// 
        /// </summary>
        public List<string> xPathRoots { get; set; } = new List<string>();

        /// <summary>
        /// Determines whether the specified xPath points to node within this block
        /// </summary>
        /// <param name="xPath">The xPath of node queried for</param>
        /// <returns>
        ///   <c>true</c> if the specified x path is child; otherwise, <c>false</c>.
        /// </returns>
        public bool isChild(string xPath)
        {
            xPath = xPath.Replace("/", "\\");
            foreach (string root in xPathRoots)
            {
                string __root = root.Replace("/", "\\");

                if (xPath.StartsWith(root, StringComparison.CurrentCultureIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// TRUE if the block content is confirmed to be on Serbian
        /// </summary>
        public bool isRelevantContent { get; set; }

        private void deploy()
        {
            List<string> sorted = tokenStats.getSorted();
           // isSerbianContent = sorted.languageTestSample(5, imbLanguageFramework.imbLanguageFrameworkManager.serbian.basic, 0.6, true);
        }

       

        public void Add(graphWrapNode<htmlWrapper> input)
        {
            IObjectWithName rni = input.root as IObjectWithName;
            string xp = input.path.removeStartsWith(rni.name).Replace("/", "\\");
            xPathRoots.AddUnique(xp);

            foreach (var lf in input.getAllLeafs()) 
            {
                graphWrapNode<htmlWrapper> ch = lf as graphWrapNode<htmlWrapper>;
                Add(ch.item);
            }
        }
    }

}