// --------------------------------------------------------------------------------------------------------------------
// <copyright file="linkCollection.cs" company="imbVeles" >
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
namespace imbCommonModels.structure
{
    #region imbVeles using

    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Xml.Serialization;
    using imbCommonModels.enums;
    using imbSCI.Data.collection.nested;
    using imbSCI.Core.reporting;
    using imbSCI.Data.data.maps.datamap;

    #endregion

    /// <summary>
    /// Skup link objekata koji automatski odrzava recnike i druge izvedene propertije
    /// </summary>
    public class linkCollection : ObservableCollection<link>
    {
        private bool isChanged = true;

        public linkCollection(linkProcessFlags ___flags = linkProcessFlags.standard)
            
        {
            flags = ___flags;

            CollectionChanged += linkCollection_CollectionChanged;
        }


        public linkCollection() 
        {
            CollectionChanged += linkCollection_CollectionChanged;
        }


        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string,link> byUrl { get; set; } = new Dictionary<string, link>();


        /// <summary>
        /// Dopunjava izvestaj sa podacima o sebi
        /// </summary>
        /// <param name="output"></param>
        public void reportCollection(ILogBuilder output)
        {
            //output.AppendPairs(this, "Link collection data", "paramTopScored");
            output.AppendPair("Links: ", Count.ToString());

            output.AppendPair("Scope: ", linkScope.inner.ToString() + " (" + byScope[linkScope.inner].Count + ") ");
            foreach (link l in byScope[linkScope.inner])
            {
                l.reportLink(output);
            }

            output.AppendPair("Scope: ", linkScope.outer.ToString() + " (" + byScope[linkScope.outer].Count + ") ");
            foreach (link l in byScope[linkScope.outer])
            {
                l.reportLink(output);
            }

            output.AppendPair("Scope: ", linkScope.onPage.ToString() + " (" + byScope[linkScope.onPage].Count + ") ");
            foreach (link l in byScope[linkScope.onPage])
            {
                l.reportLink(output);
            }

            output.AppendPair("Scope: ", linkScope.special.ToString() + " (" + byScope[linkScope.special].Count + ") ");
            foreach (link l in byScope[linkScope.special])
            {
                l.reportLink(output);
            }
        }

        /// <summary>
        /// Vrsi kalkulaciju Scope-a i Nature-a, postavlja apsolutnu verziju linka
        /// </summary>
        /// <param name="parentNode"></param>
        public void deployCollection(link parentNode)
        {
                     
            // odredjivanje scope-a linkova
            foreach (link l in this)
            {
                if (l.nature != linkNature.navigation)
                {
                    l.scope = linkScope.special;
                }
                else
                {
                    if (string.IsNullOrEmpty(l.domain))
                    {
                        if (l.path == parentNode.path)
                        {
                            //if (l.queryPairs.ContainsKey(paramTopScored))
                            //{
                            //    if (parentNode.queryPairs.ContainsKey(paramTopScored))
                            //    {
                            //        if (l.queryPairs[paramTopScored] != parentNode.queryPairs[paramTopScored])
                            //        {
                            //            l.scope = linkScope.inner;
                            //        }
                            //        else
                            //        {
                            //            l.scope = linkScope.onPage;
                            //        }
                            //    }
                            //    else
                            //    {
                            //        l.scope = linkScope.inner;
                            //    }
                            //}
                            //else
                            //{
                                l.scope = linkScope.onPage;
                            //}
                        }
                        else
                        {
                            l.scope = linkScope.inner;
                        }
                    }
                    else
                    {
                        if (l.domain.Contains(parentNode.domain))
                        {
                            l.scope = linkScope.inner;
                        }
                        else
                        {
                            l.scope = linkScope.outer;
                        }
                    }
                }

                if (!byUrl.ContainsKey(l.url))
                {
                    byUrl.Add(l.url, l);
                }
                

            }


            updateDictionaries(); // < ------ do ovde stize ---- prolazi

           
        }


        private void linkCollection_CollectionChanged(object sender,
                                                      System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            isChanged = true;
            /*
            if (flags.Contains(linkProcessFlag.liveUpdateDictionaries))
            {
                switch (e.Action)
                {
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                        byNature.AddRange(e.NewItems);
                        break;
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
                        break;
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                        byNature.RemoveList(e.OldItems);
                        break;
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                        byNature.RemoveList(e.OldItems);
                        byNature.AddRange(e.NewItems);
                        break;
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                        break;

                }
            } else
            {
                
            }*/
        }

        public void updateDictionaries()
        {
            isChanged = false;
            _byNature.Clear();
            _byScope.Clear();
            foreach (link l in this)
            {
                _byNature.Add(l.nature, l); // <------------------ ovde puca
                _byScope.Add(l.scope,l);
            }
        }

        #region --- byNature ------- pristup linkovima prema prirodi linka

        private aceDictionarySet<linkNature, link> _byNature = new aceDictionarySet<linkNature, link>();
            //new imbCollectionMetaCategorized<link, linkNature>("name");

        /// <summary>
        /// pristup linkovima prema prirodi linka
        /// </summary>
        [XmlIgnore]
        public aceDictionarySet<linkNature, link> byNature 
        {
            get
            {
                if (isChanged) updateDictionaries();
                return _byNature;
            }
            set
            {
                _byNature = value;
            }
        }

        #endregion

        #region --- byScope ------- pristup linkovima prema scope-u linka 

        private aceDictionarySet<linkScope, link> _byScope = new aceDictionarySet<linkScope, link>();
           // new imbCollectionMetaCategorized<link, linkScope>("name");

        /// <summary>
        /// pristup linkovima prema scope-u linka
        /// </summary>
        public aceDictionarySet<linkScope, link> byScope
        {
            get
            {
                if (isChanged) updateDictionaries();
                return _byScope;
            }
            set
            {
                _byScope = value;
            }
        }

        #endregion

        #region --- flags ------- flagovi koji odredjuju kako kolekcija obradjuje linkove

        /// <summary>
        /// flagovi koji odredjuju kako kolekcija obradjuje linkove
        /// </summary>
        public linkProcessFlags flags { get; set; } = linkProcessFlags.standard;

        #endregion

        #region --- paramTopScored ------- parametar koji je najbolje rangiran

        /// <summary>
        /// parametar koji je najbolje rangiran
        /// </summary>
        public string paramTopScored { get; set; }

        #endregion

        #region --- paramRank ------- Bindable property

        /// <summary>
        /// Bindable property
        /// </summary>
        [XmlIgnore]
        private ValuePairsScore paramRank { get; set; } = new ValuePairsScore();

        #endregion
    }
}