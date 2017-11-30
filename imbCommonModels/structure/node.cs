// --------------------------------------------------------------------------------------------------------------------
// <copyright file="node.cs" company="imbVeles" >
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
    using imbSCI.Core.attributes;
    using imbSCI.Core.reporting;
    #region imbVeles using

    using System.ComponentModel;

    #endregion

    /// <summary>
    /// 2014c> Collection item: node, part of nodeCollection
    /// </summary>
    [imb(imbAttributeName.collectionPrimaryKey, "name")]
    public class node : link
    {
        public node()
        {
        }

        public node(string __url, int __depth) : base(__url)
        {
            clickDepth = __depth;
        }

        #region --- clickDepth ------- U kojoj iteraciji je crawler pronašao ovu stranicu

        private int _clickDepth;

        /// <summary>
        /// U kojoj iteraciji je crawler pronašao ovu stranicu
        /// </summary>
        [Category("Page")]
        [DisplayName("Click Depth")]
        [Description("Kada je crawler primetio stranicu")]
        public int clickDepth
        {
            get { return _clickDepth; }
            set
            {
                _clickDepth = value;
                OnPropertyChanged("clickDepth");
            }
        }

        #endregion

        #region -----------  links  -------  [Kolekcija linkova detektovana u node-u]

        private linkCollection _links = new linkCollection();

        /// <summary>
        /// Kolekcija linkova detektovana u node-u
        /// </summary>
        // [XmlIgnore]
        [Category("node")]
        [DisplayName("links")]
        [Description("Kolekcija linkova detektovana u node-u")]
        public linkCollection links
        {
            get { return _links; }
            set
            {
                // Boolean chg = (_links != value);
                _links = value;
                OnPropertyChanged("links");
                // if (chg) {}
            }
        }

        #endregion

        public virtual void report(ILogBuilder output)
        {
            output.AppendLine("Node - click depth[" + clickDepth + "] - links[" + links.Count + "]");

            reportLink(output);

            links.reportCollection(output);
        }
    }
}