// --------------------------------------------------------------------------------------------------------------------
// <copyright file="nodeTree.cs" company="imbVeles" >
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
    using System.Collections.Generic;
    using System.Linq;
    using HtmlAgilityPack;
    using imbSCI.Data.collection.graph;
    using imbSCI.Data;


    /// <summary>
    /// Tree structure tween of the <see cref="HtmlDocument"/> page
    /// </summary>
    /// <seealso cref="imbSCI.Data.collection.graph.graphWrapNode{imbCommonModels.contentBlock.htmlWrapper}" />
    public class nodeTree:graphWrapNode<htmlWrapper>
    {

        public override string forTreeview
        {
            get
            {
                if (item != null)
                {
                    return base.forTreeview + " (" + item.score + ") ";
                } else
                {
                    return base.forTreeview;
                }
            }
        }

        public nodeTree(string __name, HtmlDocument page)
        {
            name = __name;
            
            item = new htmlWrapper(__name);
            //buildTree(page);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="nodeTree"/> class.
        /// </summary>
        /// <param name="__name">The name.</param>
        /// <param name="__parent">The parent.</param>
        public nodeTree(string __name, nodeTree __parent = null)
        {
            name = __name;
            parent = __parent;
            item = new htmlWrapper(__name);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="nodeTree"/> class.
        /// </summary>
        /// <param name="__html">The HTML.</param>
        /// <param name="__parent">The parent.</param>
        public nodeTree(HtmlNode __html, nodeTree __parent = null) : base()
        {
            item = __html;
            parent = __parent;
            name = item.name;
        }

        /// <summary>
        /// Adds the specified name.
        /// </summary>
        /// <param name="__name">The name.</param>
        /// <returns></returns>
        public override graphWrapNode<htmlWrapper> Add(string __name)
        {
            if (!children.Contains(__name))
            {
                var tkng = new nodeTree(__name, this);
                children.Add(__name, tkng);
                return tkng;
            } else
            {
                var chd = this[__name];

                graphWrapNode<htmlWrapper> wchd = chd as graphWrapNode<htmlWrapper>;
                wchd.item.score++;
            }
            return (graphWrapNode<htmlWrapper>)this[__name] as graphWrapNode<htmlWrapper>;
        }

        /// <summary>
        /// Adds new node or nodes to correspond to specified path or name. <c>pathOrName</c> can be path like: path1\\path2\\path3
        /// </summary>
        /// <param name="pathWithName"></param>
        /// <param name="__item"></param>
        /// <returns></returns>
        public override graphWrapNode<htmlWrapper> Add(string pathWithName, htmlWrapper __item)
        {
            List<string> pathParts = pathWithName.SplitSmart(pathSeparator);
            graphWrapNode<htmlWrapper> head = this;

            foreach (string part in pathParts)
            {
                head = head.Add(part);
            }

            head.SetItem(__item);

            return head;
        }

        //public static Int32 compareByScore(nodeTree a, nodeTree b)
        //{
        //    return a.item.score.CompareTo(b.item.score);
        //}


        /// <summary>
        /// Splits the page content into <c>targetBlockCount</c> number of blocks using heuristic algorithm of SM-Crawlers
        /// </summary>
        /// <param name="targetBlockCount">The target block count.</param>
        /// <returns></returns>
        public nodeBlockCollection getBlocks(int targetBlockCount = 3)
        {
            nodeBlockCollection output = new nodeBlockCollection();


            List<graphWrapNode<htmlWrapper>> lst = new List<graphWrapNode<htmlWrapper>>();
            
            foreach (graphWrapNode<htmlWrapper> w in this)
            {
                lst.Add(w);
            }
            
            //children.Values.ToList();
            lst.Sort((x, y) => y.item.score.CompareTo(x.item.score));


            while (output.Count < targetBlockCount)
            {
                List<graphWrapNode<htmlWrapper>> new_lst = new List<graphWrapNode<htmlWrapper>>();

                if (lst.Count >= targetBlockCount)
                {
                    for (int i = 0; i < (targetBlockCount-1); i++)
                    {
                        output.AddNewBlock(lst[0]);
                        lst.Remove(lst[0]);
                    }

                    output.Add(new nodeBlock(lst.ToList()));
                    lst.Clear();
                }

               

                foreach (graphWrapNode<htmlWrapper> ch in lst.ToList())
                {
                    new_lst.AddRange(ch);
                }
                

                lst = new_lst;

                lst.Sort((x, y) => y.item.score.CompareTo(x.item.score));

                if (!lst.Any()) break;
            }


            return output;

        }


        
       
    }
}
