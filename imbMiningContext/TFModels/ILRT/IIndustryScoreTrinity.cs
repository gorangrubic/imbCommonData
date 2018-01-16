// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IIndustryScoreTrinity.cs" company="imbVeles" >
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
using imbMiningContext.TFModels.core;
using imbSCI.DataComplex.tables;
using System.Text;
using System.ComponentModel;
using imbSCI.Core.attributes;

namespace imbMiningContext.TFModels.ILRT
{


    /// <summary>
    /// Industry Score model tri-score trinity
    /// </summary>
    public interface IIndustryScoreTrinity
    {
        /// <summary> Score of this lemma in relation to particular industry of interest </summary>
        [Category("Ratio")]
        [DisplayName("IndustryScore")]
        [imb(imbAttributeName.measure_letter, "S_i")]
        [imb(imbAttributeName.measure_setUnit, "%")]
        [Description("Score of this lemma in relation to particular industry of interest")] // [imb(imbAttributeName.measure_important)][imb(imbAttributeName.reporting_valueformat, "")][imb(imbAttributeName.reporting_escapeoff)]
        Double IndustryScore { get; set; } 

        /// <summary> Score of this lemma in relation to general business web sites </summary>
        [Category("Ratio")]
        [DisplayName("BusinessScore")]
        [imb(imbAttributeName.measure_letter, "S_b")]
        [imb(imbAttributeName.measure_setUnit, "%")]
        [Description("Score of this lemma in relation to general business web sites")] // [imb(imbAttributeName.measure_important)][imb(imbAttributeName.reporting_valueformat, "")][imb(imbAttributeName.reporting_escapeoff)]
        Double BusinessScore { get; set; } 

        /// <summary> Score of negative relevancy to the industry </summary>
        [Category("Ratio")]
        [DisplayName("NegativeRelevancy")]
        [imb(imbAttributeName.measure_letter, "S_n")]
        [imb(imbAttributeName.measure_setUnit, "%")]
        [Description("Score of negative relevancy to the industry")] // [imb(imbAttributeName.measure_important)][imb(imbAttributeName.reporting_valueformat, "")][imb(imbAttributeName.reporting_escapeoff)]
        Double NegativeRelevancy { get; set; }
    }

}