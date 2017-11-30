// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISpiderLink.cs" company="imbVeles" >
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
namespace imbCommonModels.webStructure
{
    using System.Collections.Generic;
    using imbSCI.Data.interfaces;

    public interface ISpiderLink : IObjectWithNameAndDescription
    {
        /// <summary>
        /// Number of detections on single page
        /// </summary>
        int countOnTheDomain { get; set; }

        /// <summary>
        /// Number of detections on single page
        /// </summary>
        int countOnThePage { get; set; }

        /// <summary> </summary>
        int linkAge { get; set; }

        /// <summary>
        /// Name for this instance
        /// </summary>
        string name { get; set; }

        /// <summary>
        /// Human-readable description of object instance
        /// </summary>
        string description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string domain { get; set; }

        string originHash { get; }

        /// <summary> </summary>
        string targetHash { get; }

        /// <summary>
        /// 
        /// </summary>
        string url { get; set; }

        /// <summary>Contains link/page captions detected from the same page of origin</summary>
        List<string> captions { get; }

        /// <summary> </summary>
        int iterationLoaded { get; }

        /// <summary>
        /// Discovery iteration
        /// </summary>
        int iterationDiscovery { get; }
    }
}