// --------------------------------------------------------------------------------------------------------------------
// <copyright file="blockRegistry.cs" company="imbVeles" >
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
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String, imbSemanticEngine.contentTree.nodeBlock}}" />
    public class blockRegistry:IEnumerable<KeyValuePair<string, nodeBlock>>
    {

        public IEnumerator<KeyValuePair<string, nodeBlock>> GetEnumerator() => items.GetEnumerator();
        public int Count() => items.Count;
        public nodeBlock Get(string hash)
        {
            if (!items.ContainsKey(hash)) return null;

            return items[hash];
        }

        /// <summary>
        /// Gets the hash list.
        /// </summary>
        /// <returns></returns>
        public List<string> GetHashList(bool onlySerbian=false)
        {
            List<string> output = new List<string>();

            if (onlySerbian)
            {
                foreach (var p in items)
                {
                    if (p.Value.isRelevantContent)
                    {
                        output.AddUnique(p.Key);
                    }
                }
            }
            else
            {
                output.AddRangeUnique(items.Keys);
            }

            return output;
        }

        /// <summary>
        /// Returns block count
        /// </summary>
        /// <param name="onlySerbian">if set to <c>true</c> it will count only serbian blocks</param>
        /// <returns></returns>
        public int Count(bool onlySerbian=false)
        {
            if (onlySerbian)
            {
                return items.Values.Count(x => x.isRelevantContent);
            } else
            {
                return items.Count;
            }
        }

        /// <summary>
        /// Gets the block list.
        /// </summary>
        /// <returns></returns>
        public List<nodeBlock> GetBlockList(bool onlySerbian = false)
        {
            List<nodeBlock> output = new List<nodeBlock>();
            if (onlySerbian)
            {
                output.AddRange(items.Values.Where(x=>x.isRelevantContent));
            } else
            {
                output.AddRange(items.Values);
            }
            

            return output;
        }

        public void Add(nodeBlock item)
        {
            if (!items.ContainsKey(item.textHash)) items.Add(item.textHash, item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<string, nodeBlock>>)items).GetEnumerator();
        }

        /// <summary>
        /// 
        /// </summary>
        protected Dictionary<string, nodeBlock> items { get; set; } = new Dictionary<string, nodeBlock>();
    }

}