// --------------------------------------------------------------------------------------------------------------------
// <copyright file="termLemmaBase.cs" company="imbVeles" >
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
using imbSCI.Core.attributes;
using imbSCI.Core.extensions.data;
using imbSCI.Data;
using imbSCI.DataComplex;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace imbMiningContext.TFModels.core
{
    public abstract class termLemmaBase:IWeightTableTerm
    {
        /// <summary> Lemma form of the term </summary>
        
        [imb(imbAttributeName.reporting_hide)]
        public String lemmaForm => nominalForm;

        [Category("Label")]
        [DisplayName("Lemma form")]
        [Description("Lemma form of the entry")]
        public string nominalForm { get; set; } = "";

        [Category("Frequencies")]
        [DisplayName("Abs. frequency")]
        [imb(imbAttributeName.measure_letter, "aTF")]
        [imb(imbAttributeName.measure_setUnit, "n")]
        [Description("Number of lemma forms detected in the set")]
        [imb(imbAttributeName.reporting_columnWidth, "7")]
        public int AFreqPoints { get; set; } = 0;

        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        /// <value>
        /// The weight.
        /// </value>
        [Category("Frequencies")]
        [DisplayName("Weight")]
        [imb(imbAttributeName.measure_letter, "TF-IDF")]
        [imb(imbAttributeName.measure_setUnit, "w")]
        [imb(imbAttributeName.reporting_valueformat, "F5")]
        [imb(imbAttributeName.reporting_columnWidth, "7")]
        [Description("Final weight applied to the term")]
        public double weight { get; set; } = 0;



        public int Count
        {
            get
            {
                return 1 + otherForms.Count;
            }
        }

        [imb(imbAttributeName.reporting_hide)]
        [Category("Lemma")]
        [DisplayName("Nominal form")]
        public string name { get; set; } = "";

        public void Define(string __name, string __nominalForm)
        {
            nominalForm = __nominalForm;
            name = __name;
        }
        
        [imb(imbAttributeName.reporting_hide)]
        [Category("Inflections")]
        [DisplayName("Derived words")]
        public String otherFormsStr
        {
            get
            {
                return otherForms.toCsvInLine();
            }
            set
            {
                otherForms = new List<string>();
                otherForms.AddRange(value.SplitSmart(","));
            }
        }

        [XmlIgnore]
        public List<String> otherForms { get; set; } = new List<string>();

        public List<string> GetAllForms(bool includingNominalForm = true)
        {
            List<String> output = new List<string>();

            output.AddRange(otherForms);

            if (includingNominalForm) output.Add(nominalForm);

            return output;
        }

        public bool isMatch(IWeightTableTerm other)
        {
            if (lemmaForm.Equals(other.name, StringComparison.InvariantCultureIgnoreCase)) return true;

            if (otherForms.ContainsAny(other.GetAllForms(true))) {
                return true;
            }
            return false;
        }

        public void SetOtherForms(IEnumerable<string> instances)
        {
            otherForms.AddRange(instances);
        }
    }
}
