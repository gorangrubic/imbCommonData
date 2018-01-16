// --------------------------------------------------------------------------------------------------------------------
// <copyright file="imbTextMetricsContext.cs" company="imbVeles" >
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
    /// Low-level context objekat - serijalizuje se u bazu podataka ali ne i u projekat
    /// </summary>
    /// <remarks>
    /// Ovaj low-level Context objekat treba pre svega da sadrži rezultat rada nekog modula. 
    /// Ako sadrži neka privremena podešavanja i vrednosti treba ih označiti sa: [XmlIgnore] // [JsonIgnore]
    /// Ukoliko treba da razmenjuje veliki broj podešavanja sa imbResourceContextualModul-om onda treba napraviti specijalizovanu klasu sa podešavanjima: imbTextMetricsSettings
    /// </remarks>
    public class imbTextMetricsContext 
    {
        #region --- COUNT METRIKA -- koliko je čega u tekstu 

        #region -----------  sentenceCount  -------  [Broj rečenica u tekstu]

        /// <summary>
        /// Broj rečenica u tekstu
        /// </summary>
        // [XmlIgnore]
        [Category("Counters")]
        [DisplayName("sentenceCount")]
        [Description("Broj rečenica u tekstu")]
        public int sentenceCount { get; set; } = 0;

        #endregion

        #region -----------  wordCount  -------  [koliko je reči u tekstu]

        /// <summary>
        /// koliko je reči u tekstu
        /// </summary>
        // [XmlIgnore]
        [Category("Counters")]
        [DisplayName("wordCount")]
        [Description("koliko je reči u tekstu")]
        public int wordCount { get; set; } = 0;

        #endregion

        #region -----------  numeralCount  -------  [koliko je numeričkih karaktera u tekstu]

        /// <summary>
        /// koliko je numeričkih karaktera u tekstu
        /// </summary>
        // [XmlIgnore]
        [Category("Counters")]
        [DisplayName("numeralCount")]
        [Description("koliko je numeričkih karaktera u tekstu")]
        public int numeralCount { get; set; } = 0;

        #endregion

        #region -----------  simbolCount  -------  [Koliko je simboličkih karaktera u tekstu (oni koji nisu ni slovo ni broj)]

        /// <summary>
        /// Koliko je simboličkih karaktera u tekstu (oni koji nisu ni slovo ni broj)
        /// </summary>
        // [XmlIgnore]
        [Category("Counters")]
        [DisplayName("simbolCount")]
        [Description("Koliko je simboličkih karaktera u tekstu (oni koji nisu ni slovo ni broj)")]
        public int simbolCount { get; set; } = 0;

        #endregion

        #region -----------  letterCount  -------  [Koliko je slova u tekstu]

        /// <summary>
        /// Koliko je slova u tekstu
        /// </summary>
        // [XmlIgnore]
        [Category("Counters")]
        [DisplayName("letterCount")]
        [Description("Koliko je slova u tekstu")]
        public int letterCount { get; set; } = 0;

        #endregion

        #region -----------  newlineCount  -------  [Koliko je simbola za novu liniju u tekstu]

        /// <summary>
        /// Koliko je simbola za novu liniju u tekstu
        /// </summary>
        // [XmlIgnore]
        [Category("Counters")]
        [DisplayName("newlineCount")]
        [Description("Koliko je simbola za novu liniju u tekstu")]
        public int newlineCount { get; set; } = 0;

        #endregion

        #endregion

        #region --- AVG METRIKA -- prosečne vrednosti

        #region -----------  charsPerSentence  -------  [Broj karaktera (svih) po rečenici]

        /// <summary>
        /// Broj karaktera (svih) po rečenici
        /// </summary>
        // [XmlIgnore]
        [Category("Average")]
        [DisplayName("charsPerSentence")]
        [Description("Broj karaktera (svih) po rečenici")]
        public double charsPerSentence { get; set; } = 0;

        #endregion

        #region -----------  wordsPerSentence  -------  [Broj reči po rečenici - prosek]

        /// <summary>
        /// Broj reči po rečenici - prosek
        /// </summary>
        // [XmlIgnore]
        [Category("Average")]
        [DisplayName("wordsPerSentence")]
        [Description("Broj reči po rečenici - prosek")]
        public double wordsPerSentence { get; set; } = 0;

        #endregion

        #region -----------  numeralsPerSentence  -------  [Broj numeričkih karaktera po rečenici - prosek]

        /// <summary>
        /// Broj numeričkih karaktera po rečenici - prosek
        /// </summary>
        // [XmlIgnore]
        [Category("Average")]
        [DisplayName("numeralsPerSentence")]
        [Description("Broj numeričkih karaktera po rečenici - prosek")]
        public double numeralsPerSentence { get; set; } = 0;

        #endregion

        #region -----------  newlinePerSentence  -------  [Koliko newline karaktera ide po jednoj rečenici]

        /// <summary>
        /// Koliko newline karaktera ide po jednoj rečenici
        /// </summary>
        // [XmlIgnore]
        [Category("Average")]
        [DisplayName("newlinePerSentence")]
        [Description("Koliko newline karaktera ide po jednoj rečenici")]
        public double newlinePerSentence { get; set; } = 0;

        #endregion

        #endregion

        #region --- RATIO METRIKA -- koliko je čega u odnosu na ono drugo

        #region -----------  numeralLettersRatio  -------  [Odnos numeričkih karaktera prema slovnim karakterima - ratio od 0 do 1]

        /// <summary>
        /// Odnos numeričkih karaktera prema slovnim karakterima - ratio od 0 do 1
        /// </summary>
        // [XmlIgnore]
        [Category("Ratio")]
        [DisplayName("numeralLettersRatio")]
        [Description("Odnos numeričkih karaktera prema slovnim karakterima - ratio od 0 do 1")]
        public double numeralLettersRatio { get; set; } = 0;

        #endregion

        #endregion
    }
}