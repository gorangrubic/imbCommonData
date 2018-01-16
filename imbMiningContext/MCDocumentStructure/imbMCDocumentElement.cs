// --------------------------------------------------------------------------------------------------------------------
// <copyright file="imbMCDocumentElement.cs" company="imbVeles" >
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
// Project: imbMiningContext
// Author: Goran Grubic
// ------------------------------------------------------------------------------------------------------------------
// Project web site: http://blog.veles.rs
// GitHub: http://github.com/gorangrubic
// Mendeley profile: http://www.mendeley.com/profiles/goran-grubi2/
// ORCID ID: http://orcid.org/0000-0003-2673-9471
// Email: hardy@veles.rs
// </summary>
// ------------------------------------------------------------------------------------------------------------------
using HtmlAgilityPack;
using imbSCI.Data.collection.graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imbMiningContext.MCDocumentStructure
{

    public static class imbMCDocumentElementTools
    {

        /// <summary>
        /// Returns first parent in ansestor line that is of specified type
        /// </summary>
        /// <typeparam name="T">Type that parent has to be</typeparam>
        /// <param name="source">The source node - to start from</param>
        /// <param name="depthLimit">Number of levels allowed for search</param>
        /// <returns>Parent of specified type or null if not found</returns>
        public static List<T> GetParentOfType<T, TSource>(this IEnumerable<TSource> source, Int32 depthLimit = 10)
            where T :  imbMCDocumentElement, IGraphNode
            where TSource :  imbMCDocumentElement, IGraphNode
        {
            List<T> output = new List<T>();

            foreach (TSource ts in source)
            {
                T parent = ts.GetParentOfType<T>(depthLimit);
                if (parent != null)
                {
                    if (!output.Contains(parent))
                    {
                        output.Add(parent);
                    }
                }
            }

            return output;
        }


        /// <summary>
        /// Returns first parent in ansestor line that is of specified type
        /// </summary>
        /// <typeparam name="T">Type that parent has to be</typeparam>
        /// <param name="source">The source node - to start from</param>
        /// <param name="depthLimit">Number of levels allowed for search</param>
        /// <returns>Parent of specified type or null if not found</returns>
        public static T GetParentOfType<T>(this imbMCDocumentElement source, Int32 depthLimit = 10) where T :  imbMCDocumentElement, IGraphNode
        {
            imbMCDocumentElement head = source;

            Int32 i = 0;
            while (i < depthLimit)
            {
                head = head.parent as imbMCDocumentElement;
                if (head is T)
                {
                    return head as T;
                }
                else if (head == null)
                {
                    return null;
                }
                i++;
            }
            return null;
        }
    }

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