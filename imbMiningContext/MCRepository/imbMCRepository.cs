// --------------------------------------------------------------------------------------------------------------------
// <copyright file="imbMCRepository.cs" company="imbVeles" >
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
namespace imbMiningContext.MCRepository
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Xml.Serialization;
    using imbACE.Core.core;
    using imbACE.Network.tools;
    using imbCommonModels.webStructure;
    using imbMiningContext.MCWebPage;
    using imbMiningContext.MCWebSite;
    using imbSCI.Core.attributes;
    using imbSCI.Core.extensions.data;
    using imbSCI.Core.files.fileDataStructure;
    using imbSCI.Core.files.folders;
    using imbSCI.Core.reporting;
    using imbSCI.Data;
    using imbSCI.DataComplex.tables;
    using imbSCI.Core.math;
    using imbSCI.Data.enums;

    //public abstract class imbMCRepositoryBase:fileDataStructure


    /// <summary>
    /// Repository holding Mining Context corpus for a set of web site
    /// </summary>
    /// <seealso cref="aceCommonTypes.files.fileDataStructure.IFileDataStructure" />
    [DisplayName("Minig Content Repository")]
    [Description(@"MCRepository contains structured, semi-structured and raw crawled content data on a set of
        web sites retrieved in a single or multiple crawls.")]
    [fileStructure(nameof(name), fileStructureMode.subdirectory,
        fileDataFilenameMode.propertyValue, fileDataPropertyOptions.textDescription)]
    public class imbMCRepository: fileDataStructure, IFileDataStructure
    {

        internal folderNode parentFolder = null;

        public imbMCRepository()
        {
            
        }

        public imbMCRepository(string __name, string __description, folderNode __parentFolder)
        {
            name = __name;
            description = __description;
            parentFolder = __parentFolder;
            folder = __parentFolder.createDirectory(name, description, false);
            OnLoaded();
            
        }
        
        /// <summary> Mining Content repository name </summary>
        [Category("Label")]
        [DisplayName("name")]
        [Description("Mining Content repository name")] // [imb(imbAttributeName.reporting_escapeoff)]
        public string name { get; set; } = "repo01";


        /// <summary> Information on subset used, content, date of creation and such things </summary>
        [Category("Label")]
        [DisplayName("description")]
        [Description("Information on subset used, content, date of creation and such things")] // [imb(imbAttributeName.reporting_escapeoff)]
        public string description { get; set; } = "Default repository instance";



        /// <summary> If <c>true</c> it will skip a crawled page that was found to have duplicate content, during MCWebSite repository construction </summary>
        [Category("Flag")]
        [DisplayName("doExcludeDuplicatePages")]
        [imb(imbAttributeName.measure_letter, "")]
        [Description("If <c>true</c> it will skip a crawled page that was found to have duplicate content, during MCWebSite repository construction")]
        public bool doExcludeDuplicatePages { get; set; } = true;


        /// <summary> If <c>true</c> it will skip a crawled page that was evaluated as irrelevant, during MCWebSite repository construction </summary>
        [Category("Flag")]
        [DisplayName("doExcludeIrrelevantPages")]
        [imb(imbAttributeName.measure_letter, "")]
        [Description("If <c>true</c> it will skip a crawled page that was evaluated as irrelevant, during MCWebSite repository construction")]
        public bool doExcludeIrrelevantPages { get; set; } = true;



        /// <summary> Throw if page URL is not the same domain as web site is </summary>
        [Category("Flag")]
        [DisplayName("doThrowOnDomainMismatch")]
        [Description("Throw if page URL is not the same domain as web site is")]
        public bool doThrowOnDomainMismatch { get; set; } = false;







        /// <summary>
        /// print out short report on content of the repository (if any)
        /// </summary>
        /// <param name="loger">The loger.</param>
        public void debugReport(ILogBuilder loger)
        {

        }

        /// <summary>
        /// creates extra files describing the repository content
        /// </summary>
        /// <param name="loger">The loger.</param>
        public void doContentReports(ILogBuilder loger)
        {
            // creates extra files describing the repository content
        }


        /// <summary> Persistant log builder </summary>
        [XmlIgnore]
        public builderForLog loger { get; set; } // 

        /// <summary>
        /// Site page repositories index
        /// </summary>
        /// <value>
        /// The site table.
        /// </value>
        [XmlIgnore]
        public objectTable<imbMCWebSiteEntry> siteTable { get; set; }



        /// <summary>
        /// Determines whether target is proper according to repositorium settings
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns>
        ///   <c>true</c> if [is target proper] [the specified target]; otherwise, <c>false</c>.
        /// </returns>
        public bool isTargetProper(ISpiderTarget target)
        {
            ISpiderTarget t = target;
            if (doExcludeDuplicatePages && target.isDuplicate)
            {
                t = null;
            }
            if (doExcludeIrrelevantPages && !target.IsRelevant)
            {
                t = null;
            }
            if (t != null)
            {
                return true;
            } else
            {
                return false;
            }
        }

        /// <summary>
        /// Builds or updates web site repositorium using crawling information. 
        /// </summary>
        /// <remarks>
        /// This method uses completed DLC information to create <see cref="imbMCWebSite"/> repository and <see cref="imbMCWebPage"/> for all proper targets
        /// </remarks>
        /// <param name="targetCollection">Collection of SpiderTargets, populated by DLC crawl</param>
        /// <param name="domainInfo">DLC domain information</param>
        /// <returns>Reference to created or updated web site repository</returns>
        public imbMCWebSite BuildWebSite(ISpiderTargetCollection targetCollection, domainAnalysis domainInfo, ILogBuilder output = null)
        {
            //Int32 siteCount = siteTable.Count;
            int pageCount = 0;

            imbMCWebSite repo = GetWebSite(domainInfo, true, output);

            

            pageCount = repo.pageTable.Count;

            if (pageCount == 0) loger.log("Web site repository created [" + domainInfo.domainName + "]");

            List<ISpiderTarget> crawledTargets = targetCollection.GetLoaded();

            foreach (ISpiderTarget target in crawledTargets)
            {
                
                if (isTargetProper(target))
                {
                    BuildWebPage(target, repo);
                }
            }

            int nPageCount = repo.pageTable.Count - pageCount;

            if (nPageCount > 0)
            {
                loger.log("Repository [" + domainInfo.domainName + "] expanded for [" + nPageCount + "] new pages, in total [" + (pageCount + nPageCount) + "] pages.");
            }

            siteTable.AddOrUpdate(repo.entry);

            repo.SaveDataStructure(folder, output);

            return repo;
        }


        /// <summary>
        /// Builds the web page repository using <see cref="ISpiderTarget"/> crawl information
        /// </summary>
        /// <param name="target">Target information</param>
        /// <param name="site">The site to build page for</param>
        /// <param name="output">The output for console/log</param>
        /// <returns>Built or updated web page repository</returns>
        public imbMCWebPage BuildWebPage(ISpiderTarget target, imbMCWebSite site, ILogBuilder output = null)
        {
            imbMCWebPage page = GetWebPage(site, target.url, true, output);
            ISpiderPage sPage = target.page;

            page.entry.AnchorTextAll = sPage.captions.toCsvInLine(",");
            page.entry.ClickDepth = sPage.iterationDiscovery;
            page.entry.ResolvedRelativeURL = site.domainInfo.GetURLWithoutDomainName(target.url);

            page.deploy(page.entry);

            page.indexEntry = target.GetIndexPage();

            page.TextContent = target.pageText;
            page.name = target.page.name;

            var htmlDoc = target.GetHtmlDocument();

            if (htmlDoc != null)
            {
                page.HtmlSourceCode = htmlDoc.DocumentNode.OuterHtml; // ; = target.contentBlocks;
            } else
            {

            }

            page.Blocks = new List<imbCommonModels.contentBlock.nodeBlock>();


            page.TermTable = target.tokens.GetCompiledTable(output);

            target.contentBlocks.ForEach(x => page.Blocks.Add(x));

            site.pageTable.AddOrUpdate(page.entry);

            page.SaveDataStructure(site.folder, output);

            return page;
        }


        /// <summary>
        /// Deletes the web site repository entry and its directory
        /// </summary>
        /// <param name="domain">Clean domain name, <see cref="domainAnalysis.domainRootName"/></param>
        /// <param name="output">The log/diagnostic output</param>
        /// <returns>True if entry or directory found and deleted</returns>
        public bool DeleteWebSite(string domain, ILogBuilder output=null)
        {
            bool removed = siteTable.Remove(domain);
            string p = folder.path.add(domain, "\\");
            string msg = "";
            if (removed)
            {
                msg = "siteTable entry removed [ _" + domain + "_ ] ";

                if (Directory.Exists(p))
                {
                    Directory.Delete(p);
                } else
                {
                    msg += " - but directory [ _" + p + "_ ] is not found.";
                }

            } else
            {
                msg = "siteTable entry [ _" + domain + "_ ] is not found ";

                if (Directory.Exists(p))
                {
                    removed = true;
                    Directory.Delete(p);

                    msg += " - but directory [ _" + p + "_ ] is deleted.";
                }

            }
            if (output != null) output.log(msg);

            return removed;
        }


        /// <summary>
        /// Gets web site repositorium by clean domain name, like: "koplas.co.rs" for http://www.koplas.co.rs
        /// </summary>
        /// <param name="domainInfo">The domain information.</param>
        /// <param name="autoCreate">if set to <c>true</c> it will automatically create new entry and new repository</param>
        /// <param name="output">The log/diagnostic output</param>
        /// <returns></returns>
        public imbMCWebSite GetWebSite(domainAnalysis domainInfo, bool autoCreate=false, ILogBuilder output=null)
        {
            if (!autoCreate && (!siteTable.ContainsKey(domainInfo.domainRootName)))
            {
                return null;
            }

            if (output == null) output = aceLog.loger;


            imbMCWebSiteEntry entry = siteTable.GetOrCreate(domainInfo.domainRootName);
            entry.domainProperUrl = domainInfo.urlProper;

            imbMCWebSite repo = entry.domain.LoadDataStructure<imbMCWebSite>(folder, output);
            repo.domainInfo = domainInfo;

            repo.deploy(entry);
            
            entry.domainProperUrl = repo.domainInfo.urlProper;

            siteTable.AddOrUpdate(entry);

            if (repo.folder == null)
            {
                if (output != null) output.log("Warning: folder instance is null in web site repo [" + repo.name + "]");
            }

            return repo;
        }

        /// <summary>
        /// Gets the web page repository by resolved URL
        /// </summary>
        /// <param name="site">The site to query page from</param>
        /// <param name="url">The fully resolved URL.</param>
        /// <param name="autoCreate">if set to <c>true</c> [automatic create].</param>
        /// <param name="output">The output.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Url must be in full and resolved form, and must come from the same root domain name (different TLD is allowed) - url</exception>
        public imbMCWebPage GetWebPage(imbMCWebSite site, string url, bool autoCreate = false, ILogBuilder output = null)
        {
            if (output == null) output = aceLog.loger;


            if (!url.Contains(site.domainInfo.domainRootName))
            {
                if (doThrowOnDomainMismatch)
                {
                    throw new ArgumentException($"Url [{url}] must be in full and resolved form, and must come from the same root domain name [{site.entry.domain}] (different TLD is allowed)", nameof(url));
                }
            }

            string HashCode = md5.GetMd5Hash(url);


            if (!autoCreate && (!site.pageTable.ContainsKey(HashCode)))
            {
                output.log($"Page repository {HashCode} (for: {url}) not found at {site.folder.path}");
                return null;
            }

            var entry = site.pageTable.GetOrCreate(HashCode);

            imbMCWebPage repo = HashCode.LoadDataStructure<imbMCWebPage>(site.folder, output);
            repo.deploy(entry);

            site.pageTable.AddOrUpdate(entry);

            return repo;

        }



        /// <summary>
        /// Returns repository instances for all web sites registered in <see cref="imbMCRepository.siteTable"/>
        /// </summary>
        /// <param name="output">The output.</param>
        /// <returns></returns>
        public List<imbMCWebSite> GetAllWebSites(ILogBuilder output = null)
        {
            if (output == null) output = aceLog.loger;

            List<imbMCWebSiteEntry> all = siteTable.GetList();

            List<imbMCWebSite> sites = new List<imbMCWebSite>();

            foreach (var se in all)
            {
                var repo = se.domain.LoadDataStructure<imbMCWebSite>(folder, output);
                if (repo != null)
                {
                    sites.Add(repo);
                }
            }

            return sites;
        }


        /// <summary>
        /// Gets all web pages registered in the <see cref="imbMCWebSite.pageTable"/>
        /// </summary>
        /// <param name="site">The site to get pages of</param>
        /// <param name="output">Loger to use for messages</param>
        /// <returns>List of all page repositories</returns>
        public List<imbMCWebPage> GetAllWebPages(imbMCWebSite site, ILogBuilder output = null)
        {
            if (output == null) output = aceLog.loger;

            var all = site.pageTable.GetList();
            List<imbMCWebPage> pages = new List<imbMCWebPage>();

            foreach (var pe in all)
            {
                var repo = pe.HashCode.LoadDataStructure<imbMCWebPage>(site.folder, output);
                if (repo != null)
                {
                    pages.Add(repo);
                }
            }

            return pages;
        }


        public override void OnLoaded()
        {
            
            loger = new builderForLog(folder.pathFor("log.txt"), true, getWritableFileMode.appendFile);
            loger.log("Repository [" + name + "] accessed");

            siteTable = new objectTable<imbMCWebSiteEntry>(folder.pathFor("siteTable.xml"), true, nameof(imbMCWebSiteEntry.domain), "siteTable");
            siteTable.description = "Index datatable with all stored MCWebSite repo-entries";

        }

        public override void OnBeforeSave()
        {
            if (folder == null)
            {
                if (parentFolder != null) {
                    folder = parentFolder.createDirectory(name, description, false);
                }
            }

            siteTable.Save();
            loger.save();

        }



        //   public String name { get; set; }


    }
}
