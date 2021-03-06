﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="imbMCBlock.cs" company="imbVeles" >
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
using HtmlAgilityPack;
using imbCommonModels.contentBlock;
using imbSCI.Data.collection.graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imbMiningContext.MCDocumentStructure
{

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="imbMiningContext.MCDocumentStructure.imbMCDocumentElement" />
    public class imbMCBlock: imbMCDocumentElement
    {
        public imbMCBlock()
        {

        }
        public nodeBlock blockModel { get; set; }

        /// <summary>
        /// Extracted text content from the block
        /// </summary>
        /// <value>
        /// The content of the text.
        /// </value>
        public String textContent { get; set; }
    }


}
