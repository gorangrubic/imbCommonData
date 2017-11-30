// --------------------------------------------------------------------------------------------------------------------
// <copyright file="linkQueryPairs.cs" company="imbVeles" >
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
namespace imbCommonModels.structure
{
    using imbSCI.Data.data.maps.datamap;
    using System;
    using System.Linq;

    /// <summary>
    /// Niz vrednosnih parova sa dodeljenim vrednostima -- moze da konstruise query line i da se popuni iz njega
    /// </summary>
    public class linkQueryPairs : propertyValuePairs
    {
        public linkQueryPairs()
        {
        }

        public linkQueryPairs(string __query, linkProcessFlags __flags = linkProcessFlags.none)
        {
            setQueryLine(__query, __flags);
        }

        /// <summary>
        /// Vraca Query line prema podesavanjima
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="__flags"></param>
        /// <returns></returns>
        public string getQueryLine(string prefix = "?", linkProcessFlags __flags = linkProcessFlags.standard)
        {
           

            if (Count == 0) return "";

            string output = "";
            bool anchorAsParam = __flags.HasFlag(linkProcessFlags.anchorAsParam);
            if (anchorAsParam)
            {
                if (ContainsKey(link._anchor_name))
                {
                    output += link._anchor_symbol + this[link._anchor_name];
                }
            }

            bool prefixSet = false;


            for (int i = 0; i < Count; i++)
            {
                if (anchorAsParam && (this[i]== link._anchor_name))
                {
                    //       output += Keys[i] + "" + Values[i];
                }
                else
                {
                    if (prefixSet == false)
                    {
                        output += prefix;
                        prefixSet = true;
                    }

                    output += this[i] + "=" + this[i]; //Values[i];
                    if (i < Count - 1)
                    {
                        output += "&";
                    }
                }
            }
            return output;
        }

        /// <summary>
        /// Podesava pairs preko query linije
        /// </summary>
        /// <param name="__query"></param>
        /// <param name="__flags"></param>
        public void setQueryLine(string __query, linkProcessFlags __flag)
        {
            //if (__flags == null) __flags = linkProcessFlags.getDefaultFlags();

            if (string.IsNullOrEmpty(__query)) return;

            __query = __query.Replace("?", "&");

            if (__flag.HasFlag(linkProcessFlags.anchorAsParam))
            {
                if (__query.Contains(link._anchor_symbol))
                {
                    __query = __query.Replace(link._anchor_symbol, "&" + link._anchor_name + "=");
                }
            }

            string[] qps = __query.Split("&".ToArray(), StringSplitOptions.RemoveEmptyEntries);
            if (qps.Length == 0 && !string.IsNullOrEmpty(__query))
            {
                qps = new string[] {__query};
            }


            foreach (string qp in qps)
            {
                if (!string.IsNullOrEmpty(qp))
                {
                    string[] pr = qp.Split("=".ToArray());
                    if (pr.Count() > 1)
                    {
                        Add(pr[0], pr[1]);
                    }
                }
            }
        }
    }
}