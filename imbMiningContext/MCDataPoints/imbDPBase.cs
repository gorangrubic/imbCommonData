// --------------------------------------------------------------------------------------------------------------------
// <copyright file="imbDPBase.cs" company="imbVeles" >
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
using imbSCI.Core.extensions.text;
using imbSCI.Data.collection.graph;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace imbMiningContext.MCDataPoints
{

    /// <summary>
    /// Data point is complexier token flag, containing additional data structure, in graph-tree form
    /// </summary>
    public abstract class imbDPBase:graphNodeCustom
    {
        protected override bool doAutorenameOnExisting { get { return true; } }

        protected override bool doAutonameFromTypeName { get { return true; } }

        /// <summary>
        /// Deploys the data row.
        /// </summary>
        /// <param name="dr">The dr.</param>
        public abstract void DeployDataRow(DataRow dr);
        


    }

}