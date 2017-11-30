// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISpiderTargetCollection.cs" company="imbVeles" >
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
    using imbSCI.DataComplex;
    using System.Collections.Generic;
    using System.Data;

    public interface ISpiderTargetCollection:IEnumerable<ISpiderTarget>
    {
        /// <summary>
        /// 
        /// </summary>
        List<string> termSerbian { get;  }

        /// <summary>
        /// 
        /// </summary>
        List<string> termOther { get; }

        /// <summary>
        /// 
        /// </summary>
        List<string> termsAll { get;  }

        /// <summary>
        /// Name for this instance
        /// </summary>
        string name { get; set; }

        /// <summary>
        /// Human-readable description of object instance
        /// </summary>
        string description { get; set; }

        /// <summary> TF-IDF Master table - for Link tokens (TST)</summary>
        IWeightTableSet dlTargetLinkTokens { get; }

        /// <summary> TF-IDF Master table - for Page content tokens of DLC level</summary>
        IWeightTableSet dlTargetPageTokens { get;  }

        /// <summary>
        /// Gets the data table of all targets
        /// </summary>
        /// <returns></returns>
        DataTable GetDataTable();

        int getLinkCount(ISpiderTarget itemX, ISpiderTarget itemY);
        int getLinkCountRotated(ISpiderTarget itemY, ISpiderTarget itemX);

        /// <summary>
        /// Gets a target by URL
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        ISpiderTarget GetByURL(string url);

        /// <summary>
        /// Gets targets loaded in order of load
        /// </summary>
        /// <returns></returns>
        List<ISpiderTarget> GetLoadedInOrderOfLoad();

        imbTargetLinkMatrix GetAceMatrixRotated();

        /// <summary>
        /// Gets targets loaded in the specified iteration
        /// </summary>
        /// <param name="iteration">The iteration.</param>
        /// <returns></returns>
        List<ISpiderTarget> GetLoadedInIteration(int iteration);

        /// <summary>
        /// Returns all loaded targets, in order of target detection
        /// </summary>
        /// <returns></returns>
        List<ISpiderTarget> GetLoaded();

        /// <summary>
        /// Gets <see cref="ISpiderTarget"/> by origin (page) of the linkVector
        /// </summary>
        /// <param name="linkVector">The link vector.</param>
        /// <returns></returns>
        ISpiderTarget GetByOrigin(ISpiderLink linkVector);

        /// <summary>
        /// Gets <see cref="ISpiderTarget"/> by <see cref="ISpiderLink"/> that is targeted
        /// </summary>
        /// <param name="linkVector">The link vector.</param>
        /// <returns></returns>
        ISpiderTarget GetByTarget(ISpiderLink linkVector);

        spiderLinkFlags GetFlags(ISpiderLink linkVector);

        string GetHash(string url);

        string GetKeyForVector(ISpiderLink linkVector);
    }
}