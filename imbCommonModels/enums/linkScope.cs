// --------------------------------------------------------------------------------------------------------------------
// <copyright file="linkScope.cs" company="imbVeles" >
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
    /// Meta linka - domet
    /// </summary>
    [Flags]
    public enum linkScope
    {
        /// <summary>
        /// jos nije detektovan
        /// </summary>
        unknown = 0,

        /// <summary>
        /// Ukazuje na neku drugu stranicu unutar posmartranog sajta
        /// </summary>
        inner = 1,

        /// <summary>
        /// Ukazuje na istu stranicu na kojoj se sada nalazi
        /// </summary>
        onPage = 2,

        /// <summary>
        /// Ukazuje na spoljni domen
        /// </summary>
        outer = 4,

        /// <summary>
        /// specijalan scope> kao sto je javascript funkcija ili mailto: instrukcija
        /// </summary>
        special = 8,
    }
}