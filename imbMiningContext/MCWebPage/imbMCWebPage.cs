// --------------------------------------------------------------------------------------------------------------------
// <copyright file="imbMCWebPage.cs" company="imbVeles" >
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
// Project: imbMiningContext
// Author: Goran Grubic
// ------------------------------------------------------------------------------------------------------------------
// Project web site: http://blog.veles.rs
// GitHub: http://github.com/gorangrubic
// Mendeley profile: http://www.mendeley.com/profiles/goran-grubi2/
// ORCID ID: http://orcid.org/0000-0003-2673-9471
// Email: hardy@veles.rs
// </summary>
// ------------------------------------------------------------------------------------------------------------------
namespace imbMiningContext.MCWebPage
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using imbCommonModels.contentBlock;
    using imbCommonModels.webPage;
    using imbSCI.Core.files.fileDataStructure;
    using imbSCI.DataComplex;
    using imbSCI.Data.enums;

    [DisplayName("Page repository")]
    [Description(@"
        web sites retrieved in a single or multiple crawls.")]
    [fileStructure("entry.HashCode", fileStructureMode.subdirectory,
    fileDataFilenameMode.propertyValue, fileDataPropertyOptions.textDescription)]
    public class imbMCWebPage:fileDataStructure, IFileDataStructure
    {
        public imbMCWebPage()
        {

        }
        
        [XmlIgnore]
        public imbMCWebPageEntry entry { get; set; }

        [XmlIgnore]
        [fileData(fileDataFilenameMode.memberInfoName, fileDataPropertyMode.XML)]
        [DisplayName("Index entry")]
        [Description("Entry, about this page, in the index database")] // [imb(imbAttributeName.reporting_escapeoff)]
        public indexPage indexEntry { get; set; }


        /// <summary> Extracted text content - without navigation block </summary>
        [Category("Label")]
        [DisplayName("TextContent")]
        [Description("Extracted text content - without navigation block")] // [imb(imbAttributeName.reporting_escapeoff)]
        [fileData(fileDataFilenameMode.memberInfoName, fileDataPropertyMode.text)]
        [XmlIgnore]
        public string TextContent { get; set; } = default(string);

        
        /// <summary> navigation block text extract, each link in new line </summary>
        [Category("Label")]
        [DisplayName("LinkContent")]
        [Description("navigation block text extract, each link in new line")] // [imb(imbAttributeName.reporting_escapeoff)]
        [XmlIgnore]
        [fileData(fileDataFilenameMode.memberInfoName, fileDataPropertyMode.text)]
        public List<string> LinkContent { get; set; } = new List<string>();

        
        /// <summary> Normalized and sanitized HTML/XML source code of the page </summary>
        [Category("Source")]
        [DisplayName("HtmlSourceCode")]
        [Description("Normalized and sanitized HTML/XML source code of the page")] // [imb(imbAttributeName.reporting_escapeoff)]
        [fileData(fileDataFilenameMode.memberInfoName, fileDataPropertyMode.text)]
        [XmlIgnore]
        public string HtmlSourceCode { get; set; } = default(string);

        [Category("Source")]
        [DisplayName("XmlSourceCode")]
        [Description("HTML source code of the page")] // [imb(imbAttributeName.reporting_escapeoff)]
        [fileData(fileDataFilenameMode.memberInfoName, fileDataPropertyMode.text)]
        [XmlIgnore]
        public string XmlSourceCode { get; set; } = default(string);

        [Category("Label")]
        [DisplayName("name")]
        [Description("Name associated with the crawled web page")] // [imb(imbAttributeName.reporting_escapeoff)]
        public string name { get; set; } = "webpage";


        /// <summary> Information on subset used, content, date of creation and such things </summary>
        [Category("Label")]
        [DisplayName("description")]
        [Description("Information on subset used, content, date of creation and such things")] // [imb(imbAttributeName.reporting_escapeoff)]
        public string description { get; set; } = "Default repository instance";


        /// <summary> Page content blocks </summary>
        [Category("Content")]
        [DisplayName("Blocks")]
        [Description("Page content blocks")]
        [fileData("block", fileDataPropertyMode.XML, fileDataPropertyOptions.itemAsFile)]
        [XmlIgnore]
        public List<nodeBlock> Blocks { get; set; } =  new List<nodeBlock>();

        /// <summary>
        /// Precompiled TF-IDF table for this page
        /// </summary>
        /// <value>
        /// The term table.
        /// </value>
        [XmlIgnore]
        public weightTableCompiled TermTable { get; set; }


        public void deploy(imbMCWebPageEntry __entry)
        {
            entry = __entry;
            
        }
        
        private string TermTablePath
        {
            get
            {
                return folder.pathFor(nameof(TermTable) + ".xml");
            }
        }
        public override void OnLoaded()
        {
            TermTable = new weightTableCompiled(TermTablePath, true, nameof(TermTable));

        }

        public override void OnBeforeSave()
        {
            TermTable.description = "TF-IDF table, of page[" + name + "], constructed during crawl session.";
            TermTable.SaveAs(TermTablePath,getWritableFileMode.newOrExisting);
           // throw new NotImplementedException();
        }
    }
}
