// --------------------------------------------------------------------------------------------------------------------
// <copyright file="htmlWrapper.cs" company="imbVeles" >
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
namespace imbCommonModels.contentBlock
{
    using System;
    using System.Xml.Serialization;
    using HtmlAgilityPack;
    using imbSCI.Data.interfaces;
    using imbSCI.Data.data;
    using imbSCI.Core.extensions.data;

    /// <summary>
    /// Container for a HTMLNode
    /// </summary>
    /// <seealso cref="aceCommonServices.core.aceBindable" />
    /// <seealso cref="IObjectWithName" />
    public class htmlWrapper : dataBindableBase, IObjectWithName
    {

        public htmlWrapper()
        {

        }
        public htmlWrapper(string __name)
        {
            name = __name;
        }

        public htmlWrapper(HtmlNode __html)
        {
            html = __html;
            HtmlCode = __html.OuterHtml;
            content = __html.InnerText;
            name = html.XPath;
        }

        public static implicit operator htmlWrapper(HtmlNode input)
        {
            return new htmlWrapper(input);
        }

        public static implicit operator HtmlNode(htmlWrapper input)
        {
            return input.html;
        }

        private HtmlNode _html ;
        /// <summary> </summary>
        [XmlIgnore]
        public HtmlNode html
        {
            get
            {
                if (_html == null)
                {
                    if (!HtmlCode.isNullOrEmpty())
                    {
                        _html = new HtmlNode(HtmlNodeType.Element, null, 0);
                    }
                }
                return _html;
            }
            protected set
            {
                _html = value;
                OnPropertyChanged("html");
            }
        }


        public string GetContent(nodeBlockOutputEnum mode)
        {
            switch (mode)
            {
                case nodeBlockOutputEnum.graphPath:

                    break;
                case nodeBlockOutputEnum.htmlInner:

                    return html.InnerHtml;
                    break;
                case nodeBlockOutputEnum.htmlOutter:
                    if (HtmlCode.isNullOrEmpty())
                    {
                        return html.OuterHtml;
                    } else
                    {
                        return HtmlCode;
                    }

                    break;
                case nodeBlockOutputEnum.none:
                    break;
                case nodeBlockOutputEnum.text:
                    return content;
                    
                    break;
                case nodeBlockOutputEnum.xpath:
                    return xPath;
                    
                    break;
                default:
                    throw new ArgumentOutOfRangeException("mode");
                    break;
            }
            return "";
        }


        /// <summary>
        /// Source code of the wrapped node
        /// </summary>
        /// <value>
        /// The HTML code.
        /// </value>
        public string HtmlCode
        {
            get;
            set;
        }


        /// <summary>
        /// 
        /// </summary>
        public int score { get; set; } = 1;


        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; } = "";

        /// <summary>
        /// 
        /// </summary>
        public string content { get; set; } = "";


        /// <summary>
        /// 
        /// </summary>
        public string path { get; set; } = "";


        /// <summary>
        /// Xpath of the HTML node
        /// </summary>
        public string xPath { get; set; } = "";
    }

}