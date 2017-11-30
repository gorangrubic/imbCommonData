// --------------------------------------------------------------------------------------------------------------------
// <copyright file="linkTools.cs" company="imbVeles" >
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
namespace imbCommonModels.pageAnalytics
{
    #region imbVELES USING

    #endregion

    public static class linkTools
    {
        public static string[] externalIndicators = new string[] {"http", "www", "//"};

        /*
        public static Boolean linkNatureCheck(linkNature nature, webLink link)
        {
            if (link.nature == nature) return true;
            if (nature == linkNature.all) return true;

            if (nature == linkNature.none) return false;
            return false;
        }
        */

        /*
        /// <summary>
        /// Na osnovu prosledjenog XmlNode-a pravi webLink
        /// </summary>
        /// <param name="nd">XmlNode koji treba da postane link</param>
        /// <param name="siteDomain">Adresa sajta koji se analizira - root</param>
        /// <param name="pageUrl">Adresa trenutne stranice koja sadrzi link</param>
        /// <returns>Formiran webLink objekat</returns>
        public static webLink nodeToLink(XPathNavigator nd, String siteDomain, String pageUrl)
        {
            IXPathNavigable _xn = nd;
            
            webLink tmpLink = new webLink();
            tmpLink.tag = nd.Name.ToLower();

            tmpLink.linkCaption = nd.Value.Trim();

            String[] atts = Enum.GetNames(typeof (linkAttribute));

            String tmpVal = "";
            String sto = "";
            foreach (String st in atts)
            {
                tmpVal = nd.GetAttribute(st, "");
                if (!String.IsNullOrEmpty(tmpVal))
                {
                    sto = st;
                    break;
                }
            }
            
            if (String.IsNullOrEmpty(sto))
            {
                tmpLink.features.Add(linkFeature.invalidUrl);
                tmpLink.nature = linkNature.other;
                tmpLink.scope = linkScope.onPage;
                return tmpLink;
            }

            tmpLink.attribute = (linkAttribute)Enum.Parse(typeof(linkAttribute), sto);


           // String hostUrl = "";
            Uri tmpUri = null;
            

            try
            {
                tmpUri = new Uri(tmpVal);

               // hostUrl = tmpUri.Host;

                tmpLink.urlPrefix = tmpUri.GetLeftPart(UriPartial.Authority);
                tmpLink.urlPath = tmpUri.GetLeftPart(UriPartial.Path).Replace(tmpLink.urlPrefix, "");
                tmpLink.urlFolderPath = tmpUri.LocalPath.getPathVersion(1);
                tmpLink.urlQuery = tmpUri.Query;

                tmpLink.queryPairs = imbUrlOps.getQueryPairs(tmpLink.urlQuery);

                if (!String.IsNullOrEmpty(tmpLink.urlQuery))
                {
                    tmpLink.features.Add(linkFeature.hasParams);
                }

                tmpLink.urlHost = tmpUri.DnsSafeHost;

                if (tmpLink.urlHost != siteDomain)
                {
                    tmpLink.scope = linkScope.outer;
                }
            }
            catch
            {
                tmpLink.features.Add(linkFeature.invalidUrl);
                tmpLink.nature = linkNature.other;
                tmpLink.scope = linkScope.onPage;
                return tmpLink;
            }

            if (tmpLink.scope == linkScope.unknown)
            {
                if (tmpVal.imbStartWidth(externalIndicators, true, false))
                {
                    if (tmpVal.Contains(siteDomain))
                    {
                        tmpLink.features.Add(linkFeature.localLinkWithFullPath);
                        tmpLink.scope = linkScope.inner;

                    }
                    else
                    {
                        tmpLink.scope = linkScope.outer;
                    }
                }
                else
                {
                    if (String.IsNullOrEmpty(tmpLink.urlPath))
                    {
                        tmpLink.scope = linkScope.onPage;
                    }
                    else
                    {
                        tmpLink.scope = linkScope.inner;
                    }
                }
            }

            tmpLink.url = tmpVal;
            tmpLink.nature = linkNature.other;

            if (tmpVal.Contains("#")) tmpLink.features.Add(linkFeature.hasSharpArchor);


            switch (tmpLink.tag)
            {
                case "a":
                    if (tmpVal.StartsWith("mailto"))
                    {
                        tmpLink.nature = linkNature.mailTo;
                        tmpLink.url = tmpVal.Replace("mailto:", "");
                    }
                    else
                    {
                        tmpLink.nature = linkNature.navigation;
                    }
                    break;
                case "link":
                    tmpLink.nature = linkNature.technical;
                    break;
                case "script":
                    if (tmpLink.scope == linkScope.outer)
                    {
                        tmpLink.nature = linkNature.externalService;
                    }
                    else
                    {
                        tmpLink.nature = linkNature.technical;
                    }
                    break;
                case "iframe":
                    if (tmpLink.scope == linkScope.outer)
                    {
                        tmpLink.nature = linkNature.externalService;
                    }
                    else
                    {
                        tmpLink.nature = linkNature.media;
                    }
                    break;
                case "img":
                    tmpLink.nature = linkNature.media;
                    break;
                case "param":
                    tmpLink.nature = linkNature.media;
                    break;
            }

            return tmpLink;
        }
         * */
    }
}