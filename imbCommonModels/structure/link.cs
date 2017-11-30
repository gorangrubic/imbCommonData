// --------------------------------------------------------------------------------------------------------------------
// <copyright file="link.cs" company="imbVeles" >
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

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Text.RegularExpressions;
    using System.Xml.XPath;
    using HtmlAgilityPack;
    using imbCommonModels.enums;
    using imbSCI.Data;
    using imbSCI.Core.attributes;
    using imbSCI.Core.reporting;
    using imbSCI.Data.enums.reporting;
    using imbSCI.Data.enums;
    using imbSCI.Core.extensions.text;
    using imbSCI.Core.extensions.data;

    #endregion


    /// <summary>
    /// 2014c> Collection item: link, part of linkCollection
    /// </summary>
    [imb(imbAttributeName.collectionPrimaryKey, "name")]
    public class link : INotifyPropertyChanged
    {


        public link()
        {
        }


        public link(string __url)
        {
            _processUrl(__url);
        }


        public link(string __url, linkProcessFlags __flags) 
        {
            nature = linkNature.bookmark;
            tag = linkTag.direct;
            scope = linkScope.special;


            _processUrl(__url);
        }


        /// <summary>
        /// 
        /// </summary>
        public HtmlNode html { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string xPath { get; set; }

        protected string _pathFilename = "";

        public const int NODELINK_LIMIT = 20;

        /// <summary>
        /// Pravi Link objekat na osnovu xPathNavigator objekta i podesavanja
        /// </summary>
        /// <param name="__nav"></param>
        /// <param name="__flags"></param>
        public link(XPathNavigator __nav, linkProcessFlags __flags = linkProcessFlags.standard)
            : base()
        {
            if (string.IsNullOrEmpty(__nav.Name))
            {
            }
            string __tagName = __nav.Name.ToLower();
            linkTag __tag = linkTag.unknown;

            if (Enum.TryParse(__tagName, out __tag))
            {
                tag = __tag;
            }
            string __tmpUrl = "";

            HtmlNodeNavigator nodeNav = __nav as HtmlNodeNavigator;
            html = nodeNav.CurrentNode as HtmlNode;
            xPath = html.XPath;

            switch (tag)
            {
                case linkTag.a:
                    __tmpUrl = __nav.GetAttribute("href", "");
                    attribute = linkAttribute.href;
                    nature = linkNature.navigation;

                    

                    if (__nav.HasChildren)
                    {
                        int i = 0;
                        XPathNodeIterator children = __nav.SelectChildren(XPathNodeType.Text);
                        caption = "";
                        foreach (XPathItem child in children)
                        {
                            caption = caption.add(child.Value);
                            i++;
                            if (i > NODELINK_LIMIT) break;
                        }
                         
                    } else
                    {
                        caption = __nav.Value;
                    }

                    break;
                case linkTag.link:
                    __tmpUrl = __nav.GetAttribute("href", "");
                    attribute = linkAttribute.href;

                    break;
                case linkTag.iframe:
                case linkTag.img:
                case linkTag.script:
                    attribute = linkAttribute.src;

                    __tmpUrl = __nav.GetAttribute("src", "");
                    break;
                default:
                    attribute = linkAttribute.unknown;

                    break;
            }

            switch (tag)
            {
                case linkTag.img:
                    nature = linkNature.media;
                    break;
                case linkTag.link:
                    nature = linkNature.technical;
                    break;
                case linkTag.script:
                    nature = linkNature.technical;
                    break;
            }


            if (string.IsNullOrEmpty(caption))
            {
                caption = "";
                /*
                caption = tag.ToString();
                imbStringReporting.Append(caption, __nav.GetAttribute("rel", ""), " rel:");
                imbStringReporting.Append(caption, __nav.GetAttribute("type", ""), " type:");
                imbStringReporting.Append(caption, __nav.GetAttribute("media", ""), " media:");
                imbStringReporting.Append(caption, __nav.GetAttribute("src", ""), " src:");
                */
            }

            _processUrl(__tmpUrl, __flags);


            if (features.Contains(linkFeatures.mailToLink))
            {
                nature = linkNature.mailTo;
            }
        }

        #region -----------  tag  -------  [vrsta link taga]

        private linkTag _tag; // = new linkTag();

        /// <summary>
        /// vrsta link taga
        /// </summary>
        // [XmlIgnore]
        [Category("link")]
        [DisplayName("tag")]
        [Description("vrsta link taga")]
        public linkTag tag
        {
            get { return _tag; }
            set
            {
                // Boolean chg = (_tag != value);
                _tag = value;
                OnPropertyChanged("tag");
                // if (chg) {}
            }
        }

        #endregion

        #region -----------  attribute  -------  [atribut u koji je upisan link]

        private linkAttribute _attribute; // = new linkAttribute();

        /// <summary>
        /// atribut u koji je upisan link
        /// </summary>
        // [XmlIgnore]
        [Category("link")]
        [DisplayName("attribute")]
        [Description("atribut u koji je upisan link")]
        public linkAttribute attribute
        {
            get { return _attribute; }
            set
            {
                // Boolean chg = (_attribute != value);
                _attribute = value;
                OnPropertyChanged("attribute");
                // if (chg) {}
            }
        }

        #endregion

        #region --- nature ------- Link nature

        private linkNature _nature;

        /// <summary>
        /// Link nature
        /// </summary>
        public linkNature nature
        {
            get { return _nature; }
            set
            {
                _nature = value;
                OnPropertyChanged("nature");
            }
        }

        #endregion

        #region --- scope ------- Link scope

        private linkScope _scope = linkScope.unknown;

        /// <summary>
        /// Link scope
        /// </summary>
        public linkScope scope
        {
            get { return _scope; }
            set
            {
                _scope = value;
                OnPropertyChanged("scope");
            }
        }

        #endregion

        #region -----------  caption  -------  [vidljiv, userfriendly natpis za link]

        private string _caption = ""; // = new String();

        /// <summary>
        /// vidljiv, userfriendly natpis za link
        /// </summary>
        // [XmlIgnore]
        [Category("link")]
        [DisplayName("caption")]
        [Description("vidljiv, userfriendly natpis za link")]
        public string caption
        {
            get { return _caption; }
            set
            {
                // Boolean chg = (_caption != value);
                _caption = value;
                OnPropertyChanged("caption");
                // if (chg) {}
            }
        }

        #endregion

        #region -----------  name  -------  [Naziv ]

        private string _name = ""; // = new String();

        /// <summary>
        /// MATCH za url koji sadrzi domen i shemu
        /// </summary>
        /// <remarks>
        /// za http://stackoverflow.com/questions/80357/match-all-occurrences-of-a-regex?rq=1
        /// vraca group[1]: ://
        /// group[2]: stackoverflow.com
        /// </remarks>
        public static Regex _domain_pattern = new Regex(@"(\w*)(\://)([\w\d\.-]*)[/$\n]*", RegexOptions.None);

        /// <summary>
        /// Ako je MATCH - onda je Group[0]: path bez # ili ?, a ako nije MATCH onda je ceo string path bez # ili ?
        /// </summary>
        public static Regex _prequery_pattern = new Regex(@"([\d\w\./-_]*)[#\?$]", RegexOptions.None);

        public static Regex _test_lettersAndDot = new Regex(@"^([\w\.-]+)$", RegexOptions.None);
        public static Regex _test_letters = new Regex(@"^([\w]+)$", RegexOptions.None);
        public static Regex _test_hasPathMembers = new Regex(@"([\w\.]+)+", RegexOptions.None);
        public static Regex _select_queryPairs = new Regex(@"([#\?]([\d\w\./-=_ ]*)+)", RegexOptions.None);
        public static Regex _select_allBeforeQuery = new Regex(@"^([\d\w\./\-=_ :]+)[#\?$]*", RegexOptions.None);
        public static Regex _select_pathFolders = new Regex(@"([\w\d-/_]+)[/]*", RegexOptions.None);
        public static Regex _select_pathFilename = new Regex(@"([\w\d-_\.]+)$", RegexOptions.None);

        /// <summary>
        /// Selects the anchor at end of an url
        /// </summary>
        public static Regex _select_anchor = new Regex(@"(#[\S]+$)", RegexOptions.None);

        public static string _anchor_symbol = "#";
        public static string _anchor_name = "anchor";
        public static string _mailto_name = "mailto";
        private static List<string> _indexFilenames;
        private string _originalUrl = ""; // = new String();
        private string _url = ""; // = new String();
        private string _query = ""; // = new String();
        private string _path = ""; // = new String();
        private bool _isDefaultHomePage = false;
        private bool _isDefaultFilepath = false;
        private string _pathFolders = "";
        private string _domain = ""; // = new String();
        private urlShema _shema = urlShema.none; // = new urlShema();
        private linkQueryPairs _queryPairs = new linkQueryPairs();
        private linkFeatures _features = linkFeatures.properLink;

        /// <summary>
        /// Naziv itema po kome se vodi key
        /// </summary>
        public string name
        {
            get
            {
                if (string.IsNullOrEmpty(_name))
                {
                    _name = tag + "[" + url + "]";
                }
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("name");
            }
        }

        /// <summary>
        /// kolekcija sa podrazumevanim imenima home page / index fajla
        /// </summary>
        public static List<string> indexFilenames
        {
            get
            {
                if (_indexFilenames == null)
                {
                    _indexFilenames = new List<string>();
                    _indexFilenames.AddRange(new string[]
                                             {
                                                 // "index.php", "index.html", "index.htm", "default.htm", 
                                                 "index.pl",
                                                 "index.html",
                                                 "index.htm",
                                                 "index.shtml",
                                                 "index.php",
                                                 "index.php5",
                                                 "index.php4",
                                                 "index.php3",
                                                 "index.cgi",
                                                 "default.html",
                                                 "default.htm",
                                                 "home.html",
                                                 "home.htm",
                                                 "Index.html",
                                                 "Index.htm",
                                                 "Index.shtml",
                                                 "Index.php",
                                                 "Index.cgi",
                                                 "Default.html",
                                                 "Default.htm",
                                                 "Home.html",
                                                 "Home.htm",
                                                 "placeholder.html",
                                             });
                }
                return _indexFilenames;
            }
        }

        /// <summary>
        /// Izvorni URL - kakav je pronadjen u HTML-u. Razlikuje se od url propertija tek nakon utvrdjivanja scope-a, tj. tada se u url upisuje apsolutna putanja prema stranici
        /// </summary>
        // [XmlIgnore]
        [Category("linkUrl")]
        [DisplayName("originalUrl")]
        [Description(
            "Izvorni URL - kakav je pronadjen u HTML-u. Razlikuje se od url propertija tek nakon utvrdjivanja scope-a, tj. tada se u url upisuje apsolutna putanja prema stranici"
        )]
        public string originalUrl
        {
            get { return _originalUrl; }
            set
            {
                // Boolean chg = (_originalUrl != value);
                _originalUrl = value;
                OnPropertyChanged("originalUrl");
                // if (chg) {}
            }
        }

        /// <summary>
        /// izvorni URL linka - onaj koji je ucitan iz HTML-a
        /// </summary>
        // [XmlIgnore]
        [Category("link")]
        [DisplayName("url")]
        [Description("izvorni URL linka - onaj koji je ucitan iz HTML-a")]
        public string url
        {
            get { return _url; }
            set
            {
                _url = value;
                OnPropertyChanged("url");
            }
        }

        /// <summary>
        /// Query deo URL-a, nakon ? znaka a pre #
        /// </summary>
        // [XmlIgnore]
        [Category("linkUrl")]
        [DisplayName("query")]
        [Description("Query deo URL-a, nakon ? znaka a pre #")]
        public string query
        {
            get { return _query; }
            set
            {
                // Boolean chg = (_query != value);
                _query = value;
                OnPropertyChanged("query");
                // if (chg) {}
            }
        }

        /// <summary>
        /// Path deo Url-a> posle domena sve do queryija ili anchora
        /// </summary>
        // [XmlIgnore]
        [Category("linkUrl")]
        [DisplayName("path")]
        [Description("Path deo Url-a> posle domena sve do queryija ili anchora")]
        public string path
        {
            get { return _path; }
            set
            {
                // Boolean chg = (_path != value);
                _path = value;
                OnPropertyChanged("path");
                // if (chg) {}
            }
        }

        /// <summary>
        /// Da li je putanja linka ustvari podrazumevani home page za dati domen
        /// </summary>
        [Category("Switches")]
        [DisplayName("isDefaultHomePage")]
        [Description("Da li je putanja linka ustvari podrazumevani home page")]
        public bool isDefaultHomePage
        {
            get { return _isDefaultHomePage; }
            set
            {
                _isDefaultHomePage = value;
                OnPropertyChanged("isDefaultHomePage");
            }
        }

        /// <summary>
        /// Da li je filename path ustvari jedan od podrazumevanih index putanja -- TRUE je i ako je filename prazan
        /// </summary>
        [Category("Switches")]
        [DisplayName("isDefaultFilepath")]
        [Description("Da li je filename path ustvari jedan od podrazumevanih index putanja")]
        public bool isDefaultFilepath
        {
            get { return _isDefaultFilepath; }
            set
            {
                _isDefaultFilepath = value;
                OnPropertyChanged("isDefaultFilepath");
            }
        }

        /// <summary>
        /// Path tree element --- nije bukvalno path folder
        /// </summary>
        public string pathFolders
        {
            get { return _pathFolders; }
            set
            {
                _pathFolders = value;
                OnPropertyChanged("pathFolders");
            }
        }

        /// <summary>
        /// Path od kraja domena do fajla
        /// </summary>
        public string pathDirectoryPath { get; set; } = "";

        /// <summary>
        /// ime fajla, sa ekstenzijom
        /// </summary>
        public string pathFilename
        {
            get { return _pathFilename; }
            set
            {
                _pathFilename = value;
                OnPropertyChanged("pathFilename");
            }
        }

        /// <summary>
        /// Anchor part of the url
        /// </summary>
        public string anchor { get; set; } = "";

        /// <summary>
        /// From domain name to the end of URL - including anchor
        /// </summary>
        public string pathAndQuery { get; set; } = "";

        /// <summary>
        /// Domen koji se spominje u URL-u, nakon protokola
        /// </summary>
        // [XmlIgnore]
        [Category("linkUrl")]
        [DisplayName("domain")]
        [Description("Domen koji se spominje u URL-u, nakon protokola")]
        public string domain
        {
            get { return _domain; }
            set
            {
                // Boolean chg = (_domain != value);
                _domain = value;
                OnPropertyChanged("domain");
                // if (chg) {}
            }
        }

        /// <summary>
        /// Shema koja se nalazi na pocetku URL-a
        /// </summary>
        // [XmlIgnore]
        [Category("linkUrl")]
        [DisplayName("shema")]
        [Description("Shema koja se nalazi na pocetku URL-a")]
        public urlShema shema
        {
            get { return _shema; }
            set
            {
                // Boolean chg = (_shema != value);
                _shema = value;
                OnPropertyChanged("shema");
                // if (chg) {}
            }
        }

        /// <summary>
        /// query parovi
        /// </summary>
        public linkQueryPairs queryPairs
        {
            get { return _queryPairs; }
            set
            {
                _queryPairs = value;
                OnPropertyChanged("queryPairs");
            }
        }

        /// <summary>
        /// osobine linka
        /// </summary>
        public linkFeatures features
        {
            get { return _features; }
            set
            {
                _features = value;
                OnPropertyChanged("features");
            }
        }

        #endregion

        public void reportLink(ILogBuilder output)
        {
            output.open(nameof(htmlTagName.div));
            output.AppendPair(tag.ToString(), "[" + nature.ToString() + "] [" + scope.ToString() + "]");
            output.AppendPair("Url:", url + " [original: " + originalUrl + "]");
            output.AppendPair("Shema:", shema.ToString());
            output.AppendPair("Domain:", domain);
            output.AppendPair("Path:", path);
            output.AppendPair("Query:", query);
            output.AppendPair("Query pairs:", queryPairs.Count.ToString());
            output.close();
        }

        public void reportLinkInline(ILogBuilder output)
        {
            output.AppendPair(tag.ToString(),
                              attribute.ToString() + "=" + url + " [" + nature.ToString() + "] [" + scope.ToString() +
                              "]");
            // output.AppendPair(tag.ToString(), attribute.ToString() + "=" + url + " [" + nature.ToString() + "] [" + scope.ToString() + "]");
        }

        public void setFullUrl(string __url)
        {
            originalUrl = url;
            url = __url;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Kreira event koji obaveštava da je promenjen neki parametar
        /// </summary>
        /// <remarks>
        /// Neće biti kreiran event ako nije spremna aplikacija: imbSettingsManager.current.isReady
        /// </remarks>
        /// <param name="name"></param>
        public void OnPropertyChanged(string name)
        {


            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
           
        }

        /// <summary>
        /// Pravi apsolutnu verziju URL-a na osnovu svojih pdoataka i dodeljene parent stranice
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        public string getAbsoluteUrl(link parentNode)
        {
            string output = "";

            

            if (parentNode == null)
            {
                output = output.add(path, "/");

            }  else
            {
                // <------------------------------------------------------------------------- adds shema
                if (parentNode.shema != urlShema.none)
                {
                    output = parentNode.shema.ToString() + ":";
                } else
                {
                    output = "http:";
                }

                // <------------------------------------------------------------------------- adds domain
                //.Trim("/ ".ToCharArray());

                if (path.StartsWith("//"))
                { // <------------------------------------- full absolute path 

                    output = output.add(path, "//");
                }
                else if (path.StartsWith("/"))
                {
                    output = output.add((string) parentNode.domain, "//");
                    output = output.add(path, "/");


                }
                else if (path.StartsWith("../"))
                {
                    path = path.removeStartsWith("../");

                    output = output.add((string) parentNode.domain, "//");
                    string backPath = imbStringPathTools.getPathVersion(parentNode.pathDirectoryPath, 1, "/");
                    output = output.add(backPath, "/");
                    output = output.add(path, "/");

                } else // <--------------------------------------------------------------------- relative path
                {
                    output = output.add((string) parentNode.domain, "//");

                    output = output.add(StringExtensions.EnsureEndsWith(parentNode.pathDirectoryPath, "/"), "/");
                    
                    output = output.add(path, "/");

                    // output += pathFolders.EnsureEndsWith("/");
                }

            }
            
           

            // output = output.Replace("//", "/");

            

            output += queryPairs.getQueryLine("?");
            output = output.Trim();
            output = output.removeEndsWith("#");

            return output;
        }

        protected void _processUrl(string __url, linkProcessFlags __flags = linkProcessFlags.standard)
        {
            if (string.IsNullOrEmpty(__url))
            {
                url = "";
                return;
            }

            MatchCollection mchs = _domain_pattern.Matches(__url);
            // if (__flags == null) __flags = linkProcessFlags.getDefaultFlags();

            url = __url;
            originalUrl = __url;


            Match mch;
            shema = urlShema.unknown;

            if (mchs.Count > 0)
            {
                mch = mchs[0];
                foreach (Group _gr in mch.Groups)
                {
                    string vl = _gr.Value;
                    if (shema == urlShema.unknown)
                    {
                        if (_test_letters.IsMatch(vl))
                        {
                            var __shema = urlShema.unknown;

                            if (Enum.TryParse(vl, true, out __shema))
                            {
                                shema = __shema;
                                continue;
                            }
                        }
                    }

                    if (string.IsNullOrEmpty(domain))
                    {
                        if (_test_lettersAndDot.IsMatch(vl))
                        {
                            domain = vl;
                            continue;
                        }
                    }
                }
            }
            else
            {
                shema = urlShema.none;
                domain = "";
            }

            if (shema == urlShema.unknown)
            {
                shema = urlShema.none;
            }
            else
            {
                __url = __url.removeStartsWith(shema.ToString() + @"://");
            }

            if (!string.IsNullOrEmpty(domain))
            {
                __url = __url.removeStartsWith(domain);
                __url = __url.EnsureStartsWith("/");
            }

            string __query = "";
            if (__flags.Contains(linkProcessFlags.mailtoAsParam))
            {
                __url = __url.Replace(_mailto_name + ":", "?" + _mailto_name + "=");
            }


            query = "";
            if (_select_queryPairs.IsMatch(__url))
            {
                foreach (Match _mch in _select_queryPairs.Matches(__url))
                {
                    query += _mch.Value;
                }
            }


            queryPairs = new linkQueryPairs(query, __flags);

            if (_select_allBeforeQuery.IsMatch(__url))
            {
                mchs = _select_allBeforeQuery.Matches(__url);

                foreach (Match _mch in mchs)
                {
                    Group _gr = _mch.Groups.imbFirstSafe() as Group;
                    if (_gr != null)
                    {
                        path = _gr.Value;
                        break;
                    }
                }
            }

            path = path.Replace("?", "");
            path = path.Replace("#", "");

            if (!string.IsNullOrEmpty(path))
            {
                if (_select_pathFolders.IsMatch(__url))
                {
                    foreach (Match _mch in _select_pathFolders.Matches(path)) // do ovde prolazi
                    {
                        Group _gr = _mch.Groups.imbFirstSafe() as Group;
                        if (_gr != null)
                        {
                            pathFolders = _gr.Value;
                            break;
                        }
                    }
                }

                if (_select_pathFilename.IsMatch(__url))
                {
                    foreach (Match _mch in _select_pathFilename.Matches(path))
                    {
                        Group _gr = _mch.Groups.imbFirstSafe() as Group;
                        if (_gr != null)
                        {
                            pathFilename = _gr.Value;
                            break;
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(pathFilename))
            {
                if (indexFilenames.Contains(pathFilename))
                {
                    isDefaultFilepath = true;
                }
            }
            else
            {
                isDefaultFilepath = true;
            }

            if (isDefaultFilepath && string.IsNullOrEmpty(query))
            {
                if (path == "" || path == "/")
                {
                    isDefaultHomePage = true;
                }
            }

            // mchs = _prequery_pattern.Matches(__url);

            //if (mchs.Count > 0)
            //{
            //    mch = mchs[0];
            //    path = mch.Groups[0].Value;

            //    __query = __url.removeStartsWith(path);

            //    query = __query;


            //} else
            //{
            //    path = __url;
            //}

            if (_select_anchor.IsMatch(url))
            {
                var anchor_match = _select_anchor.Match(url);
                anchor = anchor_match.Value;
            }

            pathDirectoryPath = path.removeEndsWith(pathFilename).Trim('/');

            pathAndQuery = path.add(query, "?").add(anchor, "#");

            // detektovanje osobina
            int c = 0;
            if (queryPairs.ContainsKey(_mailto_name))
            {
                features |= linkFeatures.mailToLink;
                c++;
            }
            if (queryPairs.ContainsKey(_anchor_name))
            {
                features |= linkFeatures.hasSharpArchor;
                c++;
            }

            // da li ima ostale parametre
            if (queryPairs.Count > c) features |= linkFeatures.hasParams;
        }
    }
}