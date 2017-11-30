// --------------------------------------------------------------------------------------------------------------------
// <copyright file="crawlerAgentFlag.cs" company="imbVeles" >
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
namespace imbCommonModels.pageAnalytics.core
{
    using System;

    /// <summary>
    /// Flagovi - crawlerAgentFlag
    /// </summary>
    [Flags]
    public enum crawlerAgentFlag
    {
        none = 0,

        /// <summary>
        /// Da li da izvrsava SpiderDiscovery pod proceduruy
        /// </summary>
        runSpiderDiscoveryBlock =1,

        runSaveContentBlock=2,


        /// <summary>
        /// Poziva pred obradu učitanih nodova
        /// </summary>
        preprocessNodes=4,

        detectAndProcessLinkNodes=8,

        detectAndProcessMetaNodes=16,


        tokenizeAsHtml = 32,

        tokenizeAsText = 64,

        tokenizedContentDetectGenericTypes = 128,

        tokenizedContentMakeReport = 256,

        /// <summary>
        /// Pravi zapis o XPath strukturi
        /// </summary>
        cacheXPathStructure = 512,


        /// <summary>
        /// nece dozvoliti da se Home Page nadje na listi detektovanih Key Page-a
        /// </summary>
        skipHomePageInLinksDetection = 1024,
    }
}