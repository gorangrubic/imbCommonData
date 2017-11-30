// --------------------------------------------------------------------------------------------------------------------
// <copyright file="linkNature.cs" company="imbVeles" >
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
namespace imbCommonModels.enums
{
    using System;

    /// <summary>
    /// Priroda linka - tj. kom lejeru strukture pripada
    /// </summary>
    [Flags]
    public enum linkNature
    {
        /// <summary>
        /// Nedefinisana priroda linka
        /// </summary>
        none = 0,

        /// <summary>
        /// Nije u pitanju pronadjen link vec direktno instanciran URL
        /// </summary>
        bookmark = 1,

        /// <summary>
        /// Najčešći slučaj
        /// </summary>
        navigation = 2,

        /// <summary>
        /// Omogućava pribavljanje multimedijalnog sadržaja ili slike
        /// </summary>
        media = 4,

        /// <summary>
        /// odnosi se na: stilove, skripte, favicon, i slično
        /// </summary>
        technical = 8,

        /// <summary>
        /// IFrame i uvoženje skripti
        /// </summary>
        externalService = 16,

        /// <summary>
        /// Reč je o mailTo linku
        /// </summary>
        mailTo = 32,

        /// <summary>
        /// Nešto drugo - npr #anchor
        /// </summary>
        other = 64,

        /// <summary>
        /// Svakakva priroda - koristi se za filtere
        /// </summary>
        all = 128,
    }
}