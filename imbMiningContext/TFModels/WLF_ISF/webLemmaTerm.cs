// --------------------------------------------------------------------------------------------------------------------
// <copyright file="webLemmaTerm.cs" company="imbVeles" >
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
using System;
using System.Linq;
using System.Collections.Generic;
using imbSCI.DataComplex.tables;
using System.ComponentModel;
using System.Text;
using imbMiningContext.TFModels.core;
using imbSCI.Core.attributes;

namespace imbMiningContext.TFModels.WLF_ISF
{
    public class webLemmaTerm: termLemmaBase
    {


        /// <summary> Ratio </summary>
        [Category("Frequencies")]
        [DisplayName("Document Set Freq")]
        [imb(imbAttributeName.measure_letter, "DSF")]
        [imb(imbAttributeName.measure_setUnit, "n")]
        [Description("Number of Document Sets (web sites) containing the lemma form")] // [imb(imbAttributeName.measure_important)][imb(imbAttributeName.reporting_valueformat, "")][imb(imbAttributeName.reporting_escapeoff)]
        public double documentSetFrequency { get; set; } = 0;

        [Category("Frequencies")]
        [DisplayName("Document Freq")]
        [imb(imbAttributeName.measure_letter, "DF")]
        [imb(imbAttributeName.measure_setUnit, "n")]
        [Description("Number of Documents (web pages) containing the lemma form")] // [imb(imbAttributeName.measure_important)][imb(imbAttributeName.reporting_valueformat, "")][imb(imbAttributeName.reporting_escapeoff)]
        public double documentFrequency { get; set; } = 0;

        [Category("Frequencies")]
        [DisplayName("Term Frequency")]
        [imb(imbAttributeName.measure_letter, "TF")]
        [imb(imbAttributeName.measure_setUnit, "w")]
        [imb(imbAttributeName.reporting_valueformat, "F5")]
        [Description("Normalized weight of the lemma form")] // [imb(imbAttributeName.measure_important)][imb(imbAttributeName.reporting_escapeoff)]
        public double termFrequency { get; set; } = 0;




        /// <summary>
        /// IDF factor for weight
        /// </summary>
        /// <value>
        /// The factor.
        /// </value>
        [Category("Factors")]
        [DisplayName("IDF factor")]
        [imb(imbAttributeName.measure_letter, "IDF")]
        [imb(imbAttributeName.measure_setUnit, "r")]
        [Description("The IDF factor applied to normalized lemma form frequency")]
        [imb(imbAttributeName.reporting_valueformat, "F5")]
        public double documentFactor { get; set; } = 0;

        public webLemmaTerm()
        {

        }






    }

}