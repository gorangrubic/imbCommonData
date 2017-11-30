// --------------------------------------------------------------------------------------------------------------------
// <copyright file="reportEntryBase.cs" company="imbVeles" >
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
namespace imbCommonModels.contentMetrics.core
{
    #region imbVELES USING

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Text.RegularExpressions;
    using System.Xml.Serialization;
    using System.Xml.XPath;

    #endregion

    public class reportEntryBase 
    {
        internal static Regex serialSelect = new Regex("\\d.");

        internal static Regex codeName_regex = new Regex(@"([A-Q].*[^\d])(_)([0-9]+)(.*[A-Qa-q].*)");
        internal static Regex codeName_regex_alt = new Regex(@"([A-Q].*[^\d])(\d*)(_)(.*)");
        internal pageReportBase parent = null;
        internal Type valueType;


        public reportEntryBase(pageReportBase __parent, string __codename, reportEntryGroups __group, int __serial)
        {
            codename = __codename;
            group = __group;
            groupName = group.ToString();
            serialNumber = __serial.ToString("D2");
            //    deployEntryCodename(__codename);
        }

        public reportEntryBase(pageReportBase __parent, string __codename)
        {
            deployEntryCodename(__codename);
        }

        public reportEntryBase(pageReportBase __parent)
        {
        }

        public reportEntryBase()
        {
        }

        #region --- groupName ------- Ime grupe

        /// <summary>
        /// Ime grupe
        /// </summary>
        public string groupName { get; set; }

        #endregion

        #region --- group ------- Bindable property

        /// <summary>
        /// Bindable property
        /// </summary>
        public reportEntryGroups group { get; set; } = reportEntryGroups.df;

        #endregion

        #region --- serialNumber ------- redni broj entrija - iz oznake FV23, redni broj je 23

        /// <summary>
        /// redni broj entrija - iz oznake FV23, redni broj je 23
        /// </summary>
        public string serialNumber { get; set; }

        #endregion




        #region -----------  fullname  -------  [puno_ime]
       // private String _fullname; // = new String();
                                    /// <summary>
                                    /// puno_ime
                                    /// </summary>
        // [XmlIgnore]
        [Category("reportEntryBase")]
        [DisplayName("fullname")]
        [Description("puno_ime")]
        public string fullname
        {
            get
            {
                string output = codename;
                if (group != reportEntryGroups.df)
                {
                    output = group.ToString() + serialNumber.ToString() + "_" + codename;
                }
                return output;
            }
            //set
            //{
            //    // Boolean chg = (_fullname != value);
            //    _fullname = value;
            //    // OnPropertyChanged("fullname");
            //    // if (chg) {}
            //}
        }
        #endregion


        #region -----------  codename  -------  [Kodno ime za metriku]

        /// <summary>
        /// Kodno ime za metriku
        /// </summary>
        // [XmlIgnore]
        [Category("reportEntry")]
        [DisplayName("codename")]
        [Description("Kodno ime za metriku")]
        public string codename { get; set; } = "new";

        #endregion

        #region -----------  Value  -------  [key value]

        /// <summary>
        /// key value
        /// </summary>
        [XmlIgnore]
        public object Value { get; set; }

        /// <summary>
        /// selektovani nodovi
        /// </summary>
        public IEnumerable<IXPathNavigable> nodes { get; set; }

        #endregion

        public static string makeCodeName(string __codeName)
        {
            return "not ready";
        }

        internal void deployEntryCodename(string __codename)
        {
            var cn_m = codeName_regex.Match(__codename);
            if (cn_m.Success)
            {
                groupName = cn_m.Groups[1].Value;
                serialNumber = cn_m.Groups[3].Value;
                codename = cn_m.Groups[4].Value;
            }
            else
            {
                var cn_alt = codeName_regex_alt.Match(__codename);
                groupName = cn_alt.Groups[1].Value;
                serialNumber = cn_alt.Groups[2].Value;
                codename = cn_alt.Groups[4].Value;

            }


            if (string.IsNullOrEmpty(codename)) codename = __codename;

            if (string.IsNullOrEmpty(groupName))
            {
                group = reportEntryGroups.df;
            }
            else
            {
                reportEntryGroups g = reportEntryGroups.df;
                if (Enum.TryParse(groupName, true, out g))
                {
                    group = g;
                }
            }

            //shortname = codename;
            //codename = __codename;

            //if (String.IsNullOrEmpty(serialNumber))
            //{
            //    serialNumber = "000";
            //}


            /*
            List<String> parts = __codename.Split("_".ToArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
            if (parts.Count > 1)
            {
                Match m = serialSelect.Match(parts[0]);
                codename = parts.GetRange(1, parts.Count - 1).Join("");
                serialNumber = m.Value;
                if (!String.IsNullOrEmpty(serialNumber))
                {
                    groupName = parts[0].Replace(serialNumber, "");

                }
            } else
            {
                codename = __codename;
                groupName = "DIR";
                group = reportEntryGroups.DIR;
                serialNumber = "000";

            }*/
        }

        #region --- cached cache ------- Bindable property

        //public xPathQueryCache get_cache(IXPathNavigable __source, String __xPath)
        //{
        //    if (_cache == null) _cache = new xPathQueryCache(__xPath, __source);
        //    return _cache;
        //}

        //internal xPathQueryCache _cache;

        ///// <summary>
        ///// cached cache ------- Bindable property  -- ugradjuje se u settings klase
        ///// </summary>
        //public xPathQueryCache get_cache(IXPathNavigable __source, ICollection<String> __keysForXpath = null,
        //                                 Boolean count = false, Boolean extendVariations = false)
        //{
        //    if (_cache == null) _cache = new xPathQueryCache(__source, __keysForXpath, count, extendVariations);
        //    return _cache;
        //}

        #endregion
    }
}