// --------------------------------------------------------------------------------------------------------------------
// <copyright file="imbMCWebPageEntry.cs" company="imbVeles" >
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
namespace imbMiningContext.MCWebPage
{
    using System.ComponentModel;
    using imbCommonModels.webPage;
    using imbSCI.Core.attributes;

    public class imbMCWebPageEntry
    {

        public imbMCWebPageEntry()
        {

        }

        


        /// <summary> MD5 hash created from full resolved URL of the page. Used as directory name for the MCWebPage repository. The hash is same as: <see cref="indexPage.HashCode"/>  </summary>
        [Category("Label")]
        [DisplayName("HashCode")]
        [imb(imbAttributeName.measure_letter, "")]
        [imb(imbAttributeName.measure_setUnit, "-")]
        [Description("MD5 hash created from full resolved URL of the page. Used as directory name for the MCWebPage repository.")] // [imb(imbAttributeName.reporting_escapeoff)]
        [imb(imbAttributeName.collectionPrimaryKey)]
        public string HashCode { get; set; } = default(string);





        /// <summary> Number of clicks required to reach this page </summary>
        [Category("Count")]
        [DisplayName("ClickDepth")]
        [imb(imbAttributeName.measure_letter, "")]
        [imb(imbAttributeName.measure_setUnit, "n")]
        [Description("Number of clicks required to reach this page")] // [imb(imbAttributeName.measure_important)][imb(imbAttributeName.reporting_valueformat, "")]
        public int ClickDepth { get; set; } = default(int);


        /// <summary> resolved URL to this page, without domain host name </summary>
        [Category("Label")]
        [DisplayName("ResolvedRelativeURL")]
        [imb(imbAttributeName.measure_letter, "")]
        [imb(imbAttributeName.measure_setUnit, "-")]
        [Description("resolved URL to this page, without domain host name")] // [imb(imbAttributeName.reporting_escapeoff)]
        public string ResolvedRelativeURL { get; set; } = default(string);



        /// <summary> All distinct anchor texts asociated with this page, separated with comma - comma is removed from the anchor text </summary>
        [Category("Label")]
        [DisplayName("AnchorTextAll")]
        [imb(imbAttributeName.measure_letter, "")]
        [imb(imbAttributeName.measure_setUnit, "-")]
        [Description("All distinct anchor texts asociated with this page, separated with comma - comma is removed from the anchor text")] // [imb(imbAttributeName.reporting_escapeoff)]
        public string AnchorTextAll { get; set; } = default(string);

        /// <summary>
        /// Path leading to MCWebPAge repository, relative to MCRepositoryManager directory
        /// </summary>
        /// <value>
        /// The local path.
        /// </value>
        [Category("Label")]
        [DisplayName("Local Path")]
        [Description("Path leading to MCWebPAge repository, relative to MCRepositoryManager directory")]
        public string localPath { get; set; } = "";





    }

}