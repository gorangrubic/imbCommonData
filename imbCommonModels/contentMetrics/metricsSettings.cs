// --------------------------------------------------------------------------------------------------------------------
// <copyright file="metricsSettings.cs" company="imbVeles" >
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
namespace imbCommonModels.contentMetrics
{
    #region imbVELES USING

    using System.ComponentModel;

    #endregion

    /// <summary>
    /// 2013c: LowLevel resurs
    /// </summary>
    public class metricsSettings 
    {
        #region -----------  doRatios  -------  [Da li da računa odnose]

        /// <summary>
        /// Da li da računa odnose
        /// </summary>
        // [XmlIgnore]
        [Category("Calculate")]
        [DisplayName("doRatios")]
        [Description("Da li da računa odnose")]
        public bool doRatios { get; set; } = true;

        #endregion

        #region -----------  doAverages  -------  [Da li da izračuna prosečne vrednosti]

        /// <summary>
        /// Da li da izračuna prosečne vrednosti
        /// </summary>
        // [XmlIgnore]
        [Category("Calculate")]
        [DisplayName("doAverages")]
        [Description("Da li da izračuna prosečne vrednosti")]
        public bool doAverages { get; set; } = true;

        #endregion

        #region --- flags ------- Bindable property

        /// <summary>
        /// Bindable property
        /// </summary>
        public metricsFlag flags { get; set; } = metricsFlag.none;

        #endregion
    }
}