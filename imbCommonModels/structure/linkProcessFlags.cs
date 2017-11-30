// --------------------------------------------------------------------------------------------------------------------
// <copyright file="linkProcessFlags.cs" company="imbVeles" >
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
    using System;

    /// <summary>
    /// Flagovi - linkProcessFlag
    /// </summary>
    [Flags]
    public enum linkProcessFlags
    {
        none = 0,

        /// <summary>
        /// Stalno da vrsi azuriranje recnika
        /// </summary>
        liveUpdateDictionaries = 1,

        /// <summary>
        /// Obradjuje queri elemente linkova i 
        /// </summary>
        processQueries = 2,

        /// <summary>
        /// proglasava main query - sto dalje koristi za odredjivanje scopea
        /// </summary>
        findMainQueryParam=4,


        /// <summary>
        /// Ako je link scope on Page onda je i Inner takodje
        /// </summary>
        scopeOnPageIsInnerToo=8,

        /// <summary>
        /// Processes anchor as parameter with name anchor
        /// </summary>
        anchorAsParam=16,

        mailtoAsParam=32,


        standard = processQueries | scopeOnPageIsInnerToo,
    }
}