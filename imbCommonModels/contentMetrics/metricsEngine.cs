// --------------------------------------------------------------------------------------------------------------------
// <copyright file="metricsEngine.cs" company="imbVeles" >
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

    using System;
    using System.Linq;
    using System.Xml;
    using System.Xml.XPath;
    using imbCommonModels.contentMetrics.core;
    using imbCommonModels.contentMetrics.reports;
    using imbCommonModels.enums;
    using imbCommonModels.pageAnalytics.core;
    using imbCommonModels.structure;
    using imbSCI.Core.reporting;


    //using imbAPI;

    #endregion

    /// <summary>
    /// Mehanizam metrike
    /// </summary>
    public static class metricsEngine
    {


        /// <summary>
        /// Vraca vrednost attributa
        /// </summary>
        /// <param name="source"></param>
        /// <param name="attributeName"></param>
        /// <returns></returns>
        public static string getAttributeValue(this XmlNode source, string attributeName)
        {
            try
            {
                return source.CreateNavigator().getAttributeValue(attributeName);
            }
            catch //Exception ex)
            {
                return "";
            }
        }

        /// <summary>
        /// Vraca vrednost attributa
        /// </summary>
        /// <param name="source"></param>
        /// <param name="attributeName"></param>
        /// <returns></returns>
        public static string getAttributeValue(this XPathNavigator source, string attributeName)
        {
            try
            {
                if (source.HasAttributes)
                {
                    var val = source.GetAttribute(attributeName, source.NamespaceURI);
                    if (val == null)
                    {
                        return "";
                    }
                    else
                    {
                        return val;
                    }
                }
                //XmlAttribute tmpAtt = source.Attributes[attributeName];
                //if (tmpAtt == null) return "";
                //return tmpAtt.Value;
            }
            catch //Exception ex)
            {
                return "";
            }
            return "";
        }

        /// <summary>
        /// Pravi report sa ne-standardnim meta informacijama a standardne smesta u page objekat. Poziva se automatski iz crawlerAgentContextOperations
        /// </summary>
        /// <param name="page"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public static metricsReport getMetaReport(this crawledPage page, metricsReport output = null)
        {
            if (output == null) output = new metricsReport(page.result.HtmlDocument as IXPathNavigable);
            var rt = output.report("META_metanodes", htmlDefinitions.HTMLTags_metaTags);


            // var _allMetaTags = page.xmlDocument.queryXPath(imbXmlXPathTools.makeXPathForAllNodes(htmlDefinitions.HTMLTags_metaTags));
            //  XmlNode old = null;
            string _name = "";
            foreach (IXPathNavigable Ixn in rt.nodes)
            {
                XPathNavigator xn;
                if (Ixn is XPathNavigator)
                {
                    xn = Ixn as XPathNavigator;
                }
                else
                {
                    xn = Ixn.CreateNavigator();
                }


                switch (xn.Name.ToLower())
                {
                    case "title":
                        page.pageCaption = xn.Value;
                        
                        output.report("title", page.pageCaption, reportEntryGroups.META);
                        break;
                    case "meta":

                        _name = xn.getAttributeValue("name").ToLower();
                        switch (_name)
                        {
                            case "application-name":
                            case "generator":
                            case "author":
                            case "google-site-verification":
                            default:
                                if (!string.IsNullOrEmpty(_name))
                                {
                                    output.report(_name, xn.getAttributeValue("content"), reportEntryGroups.META);
                                }
                                break;
                            case "keywords":
                                page.pageKeywords =
                                    Enumerable.ToList<string>(xn.getAttributeValue("content").Split(htmlDefinitions.HTMLMeta_keywordsSepparators,
                                        StringSplitOptions.RemoveEmptyEntries));
                                break;
                            case "description":
                                page.pageDescription = xn.getAttributeValue("content");
                                break;
                        }
                        break;
                }
            }
            return output;
        }


        /// <summary>
        /// Basic HTML Metrics
        /// </summary>
        /// <param name="page"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public static metricsReport getHtmlMetrics(crawledPage page, metricsSettings settings,
                                                   metricsReport output = null)
        {
            if (output == null) output = new metricsReport(page.result.HtmlDocument as IXPathNavigable);


            getMetaReport(page, output);

            int linkInner = page.links.byScope[linkScope.inner].Count;



            output.report("FV01_linkOuter", page.links.byScope[linkScope.outer].Count);
            output.report("FV02_linkInner", linkInner);

            output.report("FV31_cListStructures", htmlDefinitions.HTMLTags_listStructureTags, true);

            output.report("FV31_cListStructures", htmlDefinitions.HTMLTags_listStructureTags, true);
            output.report("FV32_cTableStructures", htmlDefinitions.HTMLTags_tableStructureTags, true);

            output.report("FV41_cHeadingTags", htmlDefinitions.HTMLTags_headingTags, true);
            output.report("FV42_cStructureTags", htmlDefinitions.HTMLTags_allStructureTags, true);


            reportEntryBase _entry = output.report("FV43_cMultiMediaTags", htmlDefinitions.HTMLTags_multimediaTags, true);
            if (settings.flags.HasFlag(metricsFlag.downloadPluginLinkAsMultimediaTag))
            {
                var c = (int) _entry.Value;
                foreach (link l in page.links.byScope[linkScope.outer])
                {
                    if (l.domain == "www.adobe.com")
                    {
                        c = c + 1;
                    }
                }
                _entry.Value = c;
            }

            //Int32 cMultiMediaTags = output["FV43_cMultiMediaTags"].Value.imbToNumber(typeof (Int32));


            output.report("FV44_cImageTags", htmlDefinitions.HTMLTags_multimediaTags, true);


            return output;
        }


    }
}