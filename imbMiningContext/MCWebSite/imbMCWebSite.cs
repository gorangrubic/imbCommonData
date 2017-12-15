// --------------------------------------------------------------------------------------------------------------------
// <copyright file="imbMCWebSite.cs" company="imbVeles" >
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
namespace imbMiningContext.MCWebSite
{
    using System.ComponentModel;
    using System.Xml.Serialization;
    using imbMiningContext.MCWebPage;
    using imbSCI.DataComplex.tables;
    using imbSCI.Core.files.fileDataStructure;
    using imbACE.Network.tools;
    using imbSCI.Core.extensions.io;
    using imbSCI.Core.extensions.data;

    /// <summary>
    /// Repository holding Mining Context corpus for a set of web site
    /// </summary>
    [DisplayName("Web site content repository")]
[Description(@"All crawled pages from a domain, approved for data mining / knowledge extraction, are contained in this repository.
The repository also covers general objects&data about the web site.")]
[fileStructure(nameof(name), fileStructureMode.subdirectory,
    fileDataFilenameMode.propertyValue, fileDataPropertyOptions.textDescription)]
public class imbMCWebSite : fileDataStructure, IFileDataStructure
{

    /// <summary>
    /// Gets or sets the domain information.
    /// </summary>
    /// <value>
    /// The domain information.
    /// </value>
    [XmlIgnore]
    [fileData(fileDataFilenameMode.memberInfoName, fileDataPropertyMode.XML)]
    public domainAnalysis domainInfo { get; set; }

        /// <summary>
        /// Makes the name of the repo directory
        /// </summary>
        /// <param name="domain">The domain.</param>
        /// <returns></returns>
        public static string GetRepoDirectoryName(string domain)
        {
            return domain.getCleanFilePath();
        }


        public imbMCWebSite()
        {

        }

        /// <summary> Mining Content repository name </summary>
        [Category("Label")]
        [DisplayName("name")]
        [Description("Name of Web Site MC repository")] // [imb(imbAttributeName.reporting_escapeoff)]
        public string name { get; set; } = "";


        /// <summary> Information on subset used, content, date of creation and such things </summary>
        [Category("Label")]
        [DisplayName("Description")]
        [Description("Information about Web Site MC repository")] // [imb(imbAttributeName.reporting_escapeoff)]
        public string description { get; set; } = "";


    [XmlIgnore]
        [fileData(fileDataFilenameMode.memberInfoName, fileDataPropertyMode.XML)]
        public imbMCWebSiteEntry entry { get; protected set; } = null;


    [XmlIgnore]
        public objectTable<imbMCWebPageEntry> pageTable {get; set;}

        
        internal void deploy(imbMCWebSiteEntry __entry)
        {
            entry = __entry;

            if (domainInfo == null)
            {
                domainInfo = new domainAnalysis(entry.domainProperUrl);
            }
            
            name = domainInfo.domainRootName;
            if (domainInfo.domainRootName.isNullOrEmpty())
            {

            }
        }
      
        private string pageTablePath
        {
            get
            {
                return folder.pathFor("pageTable.xml");
            }
        }
        public override void OnLoaded()
        {
            pageTable = new objectTable<imbMCWebPageEntry>(pageTablePath, true, nameof(imbMCWebPageEntry.HashCode), "pageTable");
            pageTable.description = "Index datatable with entries for each stored page within this MCWebSite repository";
        }

        public override void OnBeforeSave()
        {
            pageTable.Save();
        }

    }
}
