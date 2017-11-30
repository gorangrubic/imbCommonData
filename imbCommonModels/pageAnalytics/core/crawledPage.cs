// --------------------------------------------------------------------------------------------------------------------
// <copyright file="crawledPage.cs" company="imbVeles" >
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
namespace imbCommonModels.pageAnalytics.core
{
    #region imbVELES USING

    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using imbCommonModels.enums;
    using imbCommonModels.pageAnalytics.enums;
    using imbCommonModels.structure;
    using imbSCI.Data.interfaces;
    using imbSCI.Core.extensions.io;
    using imbACE.Network.extensions;

    //      using Newtonsoft.Json;

    #endregion



    /// <summary>
    /// Privremeni objekat za skladištenje rezultata crawler analize - ne serijalizovati!
    /// </summary>
    // [JsonObject(MemberSerialization.OptIn)]
    public class crawledPage : node, IObjectWithNameAndDescription
    {
        /// <summary>
        /// Name for this instance
        /// </summary>
        public string name { get; set; } = "webpage";

        /// <summary>
        /// Human-readable description of object instance
        /// </summary>
        public string description { get; set; } = "web page of a web site";


        /// <summary>
        /// Parameterless konstruktor za serijalizaciju
        /// </summary>
        public crawledPage()
        {
        }

     


        //public crawledPage(webResult __result, Int32 __depth = 0):this((webResponse) __result?.response, __depth)
        ////: base(result.response.responseUrl, __depth)
        //{
        //    result = __result;
            
        //}

       
        /// <summary>
        /// Vrši pripremu informacija o stranici
        /// </summary>
        public crawledPage(string urlToLoad, int __depth = 0)
            : base(urlToLoad, __depth)
        {
            name = urlToLoad.getCleanFilePath();

            

            caption = urlToLoad.getDomainNameFromUrl(true);
            domain = urlToLoad.getDomainNameFromUrl(false);
            description = "Starting point for spider operation - external pseudo web page";
            pageCaption = "External starting point";
           
            pageDescription = "Pseudo web page [" + urlToLoad + "] created just to have initial `spiderLink` instance with unique hash-id";
            isCrawled = false;
            scope = linkScope.special;
            nature = linkNature.navigation;
            
            _processUrl(urlToLoad);
            status = pageStatus.scheduled;
        }

        ///// <summary>
        ///// Stranica koja je pronadjena ili vec ucitana
        ///// </summary>
        ///// <param name="urlToLoad"></param>
        ///// <param name="__depth"></param>
        ///// <param name="inputLink"></param>
        //public crawledPage(link inputLink, Int32 __depth)
        //    : base(inputLink.url, __depth)
        //{
        //    caption = inputLink.caption;
        //}

        //#region --- tokenizedContent ------- sadrzaj nakon inicjalne tokenizacije

        //private IContentPage _tokenizedContent;

        ///// <summary>
        ///// sadrzaj nakon inicjalne tokenizacije
        ///// </summary>
        //[XmlIgnore]
        //public IContentPage tokenizedContent
        //{
        //    get { return _tokenizedContent; }
        //    set
        //    {
        //        _tokenizedContent = value;
        //        OnPropertyChanged("tokenizedContent");
        //    }
        //}

        //#endregion

      //  #region -----------  xpathStruktura  -------  [XPath string opis strukture]

       // private List<String> _xpathStruktura = new List<string>();

       // /// <summary>
       // /// XPath string opis strukture
       // /// </summary>
       // /// [XmlIgnore]
       //// [JsonProperty]
       // [Category("Content")]
       // [DisplayName("xpathStruktura")]
       // [Description("XPath string opis strukture")]
       // public List<String> xpathStruktura
       // {
       //     get { return _xpathStruktura; }
       //     set
       //     {
       //         _xpathStruktura = value;
       //         OnPropertyChanged("xpathStruktura");
       //     }
       // }

        
        private pageStatus _status = pageStatus.unknown;

        /// <summary>
        /// Status stranice
        /// </summary>
        // [XmlIgnore]
        [Category("Page")]
        [DisplayName("status")]
        [Description("Status stranice")]
       // [JsonProperty]
        public pageStatus status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged("status");
            }
        }

        

        #region -----------  pageCaption  -------  [Naslov koji je ucitan iz sadrzaja]

        private string _pageCaption;

        /// <summary>
        /// Naslov koji je ucitan iz sadrzaja
        /// </summary>
        // [XmlIgnore]
        [Category("Page")]
        [DisplayName("pageCaption")]
        [Description("Naslov koji je ucitan iz sadrzaja")]
       // [JsonProperty]
        public string pageCaption
        {
            get { return _pageCaption; }
            set
            {
                _pageCaption = value;
                OnPropertyChanged("pageCaption");
            }
        }

        #endregion

        #region -----------  pageDescription  -------  [Meta opis stranice]

        private string _pageDescription; // = new String();

        /// <summary>
        /// Meta opis stranice
        /// </summary>
        // [XmlIgnore]
        [Category("crawledPage")]
        [DisplayName("pageDescription")]
        [Description("Meta opis stranice")]
        public string pageDescription
        {
            get { return _pageDescription; }
            set
            {
                // Boolean chg = (_pageDescription != value);
                _pageDescription = value;
                OnPropertyChanged("pageDescription");
                // if (chg) {}
            }
        }

        #endregion

        #region -----------  pageKeywords  -------  [Meta keywords stranice]

        private List<string> _pageKeywords = new List<string>();

        /// <summary>
        /// Meta keywords stranice
        /// </summary>
        // [XmlIgnore]
        [Category("crawledPage")]
        [DisplayName("pageKeywords")]
        [Description("Meta keywords stranice")]
        public List<string> pageKeywords
        {
            get { return _pageKeywords; }
            set
            {
                // Boolean chg = (_pageKeywords != value);
                _pageKeywords = value;
                OnPropertyChanged("pageKeywords");
                // if (chg) {}
            }
        }

        #endregion

        #region -----------  isCrawled  -------  [Da li je ova stranica već bila obrađena]

        private bool _isCrawled;

        /// <summary>
        /// Da li je ova stranica već bila obrađena
        /// </summary>
        public bool isCrawled
        {
            get { return _isCrawled; }
            set
            {
                _isCrawled = value;
                OnPropertyChanged("isCrawled");
            }
        }

        #endregion

        #region --- result ------- rezultat ucitavanja url-a

        private IWebResult _result;

        /// <summary>
        /// rezultat ucitavanja url-a
        /// </summary>
        [XmlIgnore]
        public IWebResult result
        {
            get { return _result; }
            set
            {
                _result = value;
                OnPropertyChanged("result");
            }
        }

        #endregion
    }
}