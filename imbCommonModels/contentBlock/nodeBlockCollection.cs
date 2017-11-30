// --------------------------------------------------------------------------------------------------------------------
// <copyright file="nodeBlockCollection.cs" company="imbVeles" >
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
    using imbSCI.Data.collection.graph;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Collection of <see cref="nodeBlock"/> content segment 
    /// </summary>
    /// <seealso cref="System.Collections.Generic.List{imbSemanticEngine.contentTree.nodeBlock}" />
    public class nodeBlockCollection:List<nodeBlock>
    {

        public nodeBlock GetBlockByXPath(string xPath)
        {
            xPath = xPath.Replace("/", "\\");

            foreach (nodeBlock bl in this)
            {
                if (bl.isChild(xPath))
                {
                    return bl;
                }
                if (bl.xPathList.Contains(xPath))
                {
                    return bl;
                }
            }

            return null;
        }

        public void AddNewBlock(graphWrapNode<htmlWrapper> input)
        {
            nodeBlock bl = new nodeBlock(input);
            Add(bl);
        }


        public void CalculateScores()
        {
            if (Count == 0) return;

            int maxLinks = int.MinValue;
            foreach (nodeBlock bl in this)
            {
                maxLinks = Math.Max((int) bl.linkNodeCount, maxLinks);
            }

            foreach (nodeBlock bl in this)
            {
                bl.lbf = ((double)bl.linkNodeCount) / ((double)maxLinks);
            }

            List<nodeBlock> blocks = new List<nodeBlock>();
            blocks.AddRange(this);

            nodeBlock bl_nav = this.MaxItem(x => x.E);
            bl_nav.role = nodeBlockSemanticRoleEnum.navigation;

            blocks.Remove(bl_nav);

            nodeBlock bl_inf = this.MaxItem(x => x.entropy);
            bl_inf.role = nodeBlockSemanticRoleEnum.information;

            blocks.Remove(bl_inf);

            foreach (var bl in blocks)
            {
                bl.role = nodeBlockSemanticRoleEnum.reserve;
            }
        }

        //public void Add(IEnumerable<graphWrapNode<htmlWrapper>> input)
        //{

        //}
    }

}