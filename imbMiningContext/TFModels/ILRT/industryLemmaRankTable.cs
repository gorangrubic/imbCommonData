// --------------------------------------------------------------------------------------------------------------------
// <copyright file="industryLemmaRankTable.cs" company="imbVeles" >
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
using imbMiningContext.TFModels.core;
using imbSCI.DataComplex.tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imbMiningContext.TFModels.ILRT
{
    /// <summary>
    /// Table of industry related lemma-terms, having their scores. Precompiled version of table, ready for saving and application
    /// </summary>
    /// <seealso cref="imbSCI.DataComplex.tables.objectTable{imbMiningContext.TFModels.ILRT.industryLemmaTerm}" />
    public class industryLemmaRankTable : objectTable<industryLemmaTerm>
    {
        /// <summary>
        /// New instance of industry rank table 
        /// </summary>
        /// <param name="__filePath">The file path.</param>
        /// <param name="autoLoad">if set to <c>true</c> [automatic load].</param>
        /// <param name="__tableName">Name of the table.</param>
        public industryLemmaRankTable(string __filePath, bool autoLoad, string __tableName = "") : base(__filePath, autoLoad, nameof(termLemmaBase.name), __tableName)
        {
        }
    }
}
