// --------------------------------------------------------------------------------------------------------------------
// <copyright file="pageReportBase.cs" company="imbVeles" >
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
    using System.Xml;
    using System.Xml.XPath;
    using imbSCI.Data.collection;
    using imbSCI.Core.reporting.render.builders;
    using imbSCI.Core.math;
    using imbSCI.Core.collection;
    using imbSCI.Core.extensions.text;
    using imbSCI.Core.extensions.typeworks;

    #endregion

    /// <summary>
    /// 2013c: LowLevel resurs
    /// </summary>
    public class pageReportBase : aceDictionaryCollection<reportEntryBase>
    {
        private XPathNavigator _navigator;


        #region Implementation of IxPathQuerySourceProvider

        public XmlNamespaceManager xNm { get; set; }


        public XPathExpression xExp { get; set; }

        public string nsPrefix { get; set; }

        #endregion

        public pageReportBase(IXPathNavigable navSource)
        {
            source = navSource;
        }

        public pageReportBase()
        {
        }

        /// <summary>
        /// Ubacuje u izvestaj tabelu sa svom dobijenom metrikom
        /// </summary>
        /// <param name="sb"></param>
        /// <returns></returns>
        public builderForText makeReport(builderForText sb = null)
        {
            if (sb == null) sb = new builderForText();

            string[] fields = new string[] {"groupName", "codename", "serialNumber", "Value"};

            return sb;
        }

        //public reportEntryBase reportLanguage(String entryName, List<String> toTest, basicLanguage language,
        //                                      Boolean ratio)
        //{
        //    Int32 ok = 0;

        //    language.checkDictFile(false);


        //    foreach (string wl in toTest)
        //    {
        //        if (language.testBoolean(wl, basicLanguageCheck.spellCheck)) ok++;
        //    }
        //    reportEntryBase entry = getEntry(entryName);
        //    Int32 sampleSize = toTest.Count();
        //    if (sampleSize > 0)
        //    {
        //        if (ratio)
        //        {
        //            entry.Value = ok/toTest.Count();
        //        }
        //        else
        //        {
        //            entry.Value = ok;
        //        }
        //    }
        //    else
        //    {
        //        throw new ArgumentOutOfRangeException("toText","Test sampleSize for reportLanguage is 0 :: reportEntry: " + entryName);
        //    }
        //    return entry;
        //}

        public reportEntryBase report(string entryName, object value, reportEntryGroups __group = reportEntryGroups.df,
                                      int __serial = -1)
        {
            if (__serial == -1)
            {
                __serial = Count;
            }
            string __entryName = "";
            if (__group != reportEntryGroups.df)
            {
                __entryName = __group.ToString() + "_";
            }

            if (__serial > -1)
            {
                __entryName += __serial.ToString("D3");
            }

            __entryName += entryName;
            entryName = __entryName;
            reportEntryBase entry = getEntry(entryName);
            entry.Value = value;
            return entry;
        }


        public reportEntryBase reportRatio(string entryName, int whole, int part,
                                           reportEntryGroups __group = reportEntryGroups.df, int __serial = -1)
        {
            return report(entryName, whole.GetRatio(part), __group, __serial);
        }

        /// <summary>
        /// Izvrsava Select upit koji odabira sve nodove iz __keysforXPath
        /// </summary>
        /// <param name="entryName"></param>
        /// <param name="__keysForXpath"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public reportEntryBase report(string entryName, ICollection<string> __keysForXpath, bool count = false)
        {
            reportEntryBase entry = getEntry(entryName);
            throw new NotImplementedException();

            //var query = entry.get_cache(source, __keysForXpath, count, true);

            //if (!count)
            //{
            //    entry.nodes = query.queryXPathToList(source);
            //    entry.Value = "IXPathNavigable : " + entry.nodes.Count();
            //}
            //else
            //{
            //    entry.Value = query.queryXPathCount(source);
            //}
            return entry;
        }


        /// <summary>
        /// brise sve podatke koje je do sada imao ali ostavlja kesirane upite
        /// </summary>
        /// <param name="__source"></param>
        public void connect(IXPathNavigable __source, bool purgeValues = false)
        {
            if (source == __source) return;
            if (__source == null)
            {

                throw new ArgumentNullException("__source", "Can't pass null to the connect method");
                
                return;
            }
            source = __source;
            var navigator = __source.CreateNavigator();

            if (string.IsNullOrEmpty(nsPrefix)) nsPrefix = navigator.Prefix;

            if (nsPrefix != navigator.Prefix)
            {
                purgeCachedExpressions();
            }

            if (purgeValues)
            {
                purgeReportValues();
            }
            //xNm = new XmlNamespaceManager(navigator.NameTable);
        }


        /// <summary>
        /// Copies its data entries into PCE <see cref="imbSCI.Core.collection.PropertyCollectionExtended"/>
        /// </summary>
        /// <param name="useGroup">if set to <c>true</c> [use group].</param>
        /// <param name="useSerial">if set to <c>true</c> [use serial].</param>
        /// <param name="useCodename">if set to <c>true</c> [use codename].</param>
        /// <param name="PCE">The pce.</param>
        /// <returns></returns>
        public PropertyCollectionExtended sendToPCE(bool useGroup, bool useSerial, bool useCodename, PropertyCollectionExtended PCE=null)
        {
            if (PCE==null) PCE = new PropertyCollectionExtended();

            PCE.name = GetType().Name.imbTitleCamelOperation(true);
            PCE.description = "Data report extracted from the web page";
            
            string nn = "";
            int c = 0;
            foreach (reportEntryBase re in Values)
            {
                nn = "";
                if (useGroup) nn += re.group.ToString();
                if (useSerial) nn += re.serialNumber;
                if (useCodename)
                {
                    if (!string.IsNullOrEmpty(nn))
                    {
                        nn += "_";
                    }
                    nn += re.codename;
                }

                PCE.Add(re.codename, re.Value, re.fullname, re.groupName);
                
            }
            return PCE;
        }

        #region Implementation of IxPathQuerySourceProvider




        private object sendToObjectLock = new object();

        /// <summary>
        /// Kopira metriku u prosledjeni objekat
        /// </summary>
        /// <param name="target"></param>
        /// <param name="useGroup"></param>
        /// <param name="useSerial"></param>
        /// <param name="useCodename"></param>
        /// <returns></returns>
        public int sendToObject(object target, bool useGroup, bool useSerial, bool useCodename)
        {
            lock (sendToObjectLock)
            {
                if (target == null)
                {
                    throw new ArgumentNullException("target", "sendToObject has target = null ");
                   
                    return -1;
                }
                //var iTI = target.getTypology();
                //String nn = "";
                //Int32 c = 0;
                //for (int i = 0; i < Count; i++)
                //{
                //    var re = this[i];
                //    nn = "";
                //    if (useGroup) nn += re.group.ToString();
                //    if (useSerial) nn += re.serialNumber;
                //    if (useCodename)
                //    {
                //        if (!String.IsNullOrEmpty(nn))
                //        {
                //            nn += "_";
                //        }
                //        nn += re.codename;
                //    }
                //    if (iTI.allPropertiesByName.ContainsKey(nn))
                //    {
                //        target.imbSetPropertySafe(iTI.allPropertiesByName[nn].propertyInfoSource, re.Value);
                //        c++;
                //    }
                //}
                
                return 0;
            }
        }

       
        #region --- cached queryCache ------- kesiran upit

        /// <summary>
        /// Unistava sve kesirane upite - ostaju podaci i ostala podesavanja na nivou reportEntryBase-a
        /// </summary>
        public void purgeCachedQueries()
        {
            foreach (reportEntryBase reb in Values)
            {
               // reb._cache = null;
            }
        }

        /// <summary>
        /// Prazni sve podatke zapisane u izvestaju ali ostavlja kesirane upite
        /// </summary>
        public void purgeReportValues()
        {
            foreach (reportEntryBase reb in Values)
            {
                reb.Value = null;
                reb.nodes = null;
            }
        }

        internal T getValue<T>(string entryName, reportEntryGroups __group = reportEntryGroups.df,
                                          int __serial = -1)
        {
            object output;

            var ent = getEntry(entryName, __group, __serial);

            return (T) imbTypeExtensions.imbConvertValueSafe(ent.Value, typeof(T));
        }

        internal object getEntryValue(string entryName, reportEntryGroups __group = reportEntryGroups.df,
                                          int __serial = -1)
        {
            object output;

            var ent = getEntry(entryName, __group, __serial);
            return ent.Value;
        }

        /// <summary>
        /// cached queryCache ------- kesiran upit  -- ugradjuje se u settings klase
        /// </summary>
        internal reportEntryBase getEntry(string entryName, reportEntryGroups __group = reportEntryGroups.df,
                                           int __serial = -1)
        {
            reportEntryBase _entry = null;
            if (ContainsKey(entryName))
            {
                _entry = this[entryName];
            }
            else
            {
            }

            if (_entry == null)
            {
                if (__group != reportEntryGroups.df)
                {
                    _entry = new reportEntryBase(this, entryName, __group, __serial);
                }
                else
                {
                    _entry = new reportEntryBase(this, entryName);
                }
                Add(_entry);
            }

            return _entry;
        }

        public void purgeCachedExpressions()
        {
            foreach (reportEntryBase reb in Values)
            {
               // reb._cache.xExp = null;

                //reb._cache = null;
            }
        }

        #endregion

        #region --- source ------- XML izvor koji je predmet izvestavanja

        private IXPathNavigable _source;

        /// <summary>
        /// XML izvor koji je predmet izvestavanja
        /// </summary>
        protected IXPathNavigable source
        {
            get { return _source; }
            set
            {
                _source = value;
                OnPropertyChanged("source");
            }
        }

        #endregion

        #endregion
    }
}