// --------------------------------------------------------------------------------------------------------------------
// <copyright file="imbMCManager.cs" company="imbVeles" >
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
namespace imbMiningContext
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using imbACE.Core.operations;
    using imbACE.Services.consolePlugins;
    using imbMiningContext.MCRepository;
    using imbMiningContext.MCWebPage;
    using imbMiningContext.MCWebSite;
    using imbSCI.Core.files.fileDataStructure;
    using imbSCI.Core.files.folders;
    using imbSCI.Data;

    /// <summary>
    /// Manager takes care about MC repositories, loads, creates and provides the instances 
    /// </summary>
    public class imbMCManager: aceConsolePluginBase
    {
        public const string MCRepo_DefaultDirectoryName = "MCRepo";
        public const string MCManagerHelpLine = "Manager plugin takes care about MC repositories, loads, creates and provides the instances.";
        public const string MCManagerName = "MC Manager Plugin";

        /// <summary>
        /// Currently selected folder
        /// </summary>
        /// <value>
        /// The folder.
        /// </value>
        protected folderNode folder { get; set; }

        
        public imbMCManager(IAceOperationSetExecutor __parent=null, string repoRootFolder = "") : base(__parent, MCManagerName, MCManagerHelpLine)
        {
            if (repoRootFolder.isNullOrEmpty())
            {
                repoRootFolder = MCRepo_DefaultDirectoryName;
            }

            folder = new folderNode(repoRootFolder, "MC repositories", "Root directory of a MC Repository Manager");
        }


        /// <summary>
        /// The repository currently selected
        /// </summary>
        /// <value>
        /// The active repository.
        /// </value>
        public imbMCRepository activeRepository { get; protected set; }

        public imbMCWebSite activeWebSite { get; set; }

        public imbMCWebPage activeWebPage { get; set; }


        
        [Display(GroupName = "mc", Name = "Open", ShortName = "", Description = "Opens or creates new MCRepository, starts a MC session. Call this before any other MC operation.")]
        [aceMenuItem(aceMenuItemAttributeRole.ExpandedHelp, "It initiates specified MCRepository and sets it as current/selected.")]
        /// <summary>Opens or creates new MCRepository, starts a MC session. Call this before any other MC operation.</summary> 
        /// <remarks><para>It initiates specified MCRepository and sets it as current/selected.</para></remarks>
        /// <param name="repo">Name of repository to start work with</param>
        /// <param name="log_msg">A message to be written into repository log after it is initiated, e.g. adding new MCWebSites, or running Data Mining procedure XXXX</param>
        /// <param name="debug">If true, it will print out short report on content of the repository (if any)</param>
        /// <seealso cref="aceOperationSetExecutorBase"/>
        public void aceOperation_mcOpen(
            [Description("Name of repository to start working with")] string repo = "word",
            [Description("A message to be written into repository log after it is initiated, e.g. adding new MCWebSites, or running Data Mining procedure XXXX")] string log_msg = "",
            [Description("If true, it will print out short report on content of the repository (if any)")] bool debug = false)
        {
                        
imbMCRepository instance = null;

string path = folder.pathFor("\\" + repo);

if (Directory.Exists(path))
{
    instance = repo.LoadDataStructure<imbMCRepository>(folder, output);
    instance.loger.log("Repository loaded ".add(log_msg, ". "));
} else
{
    string descriptionForNew = "MC Repository created [" + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + "]. " + log_msg;
    instance = new imbMCRepository(repo, descriptionForNew, folder);
    instance.loger.log("Repository created ".add(log_msg, ". "));

}

            if (debug)
            {
                instance.debugReport(output);
            }

            if (instance != null)
            {
                output.log("MC Repository [" + repo + "] initiated");
                activeRepository = instance;
            } else
            {
                output.log("MC Repository [" + repo + "] failed to initiate");
            }
            
        }



        [Display(GroupName = "mc", Name = "Close", ShortName = "", Description = "Saves and unselects the currently selected MC Repository")]
        [aceMenuItem(aceMenuItemAttributeRole.ExpandedHelp, "It will save all muttable variables of the repository and its content ")]
        /// <summary>Saves and unselects the currently selected MC Repository</summary> 
        /// <remarks><para>It will save all muttable variables of the repository and its content</para></remarks>
        /// <param name="log_msg">Log message to write into repository log just before unselecting it, and after saving it</param>
        /// <param name="doReport">if true, it will create report files for complete content of the currently selected repository: spreadsheets, folder content readmes etc.</param>
        /// <param name="debug">If true, it will print out short report on content of the repository (if any)</param>
        /// <seealso cref="aceOperationSetExecutorBase"/>
        public void aceOperation_mcClose(
            [Description("Log message to write into repository log just before unselecting it, and after saving it")] string log_msg = "",
            [Description("if true, it will create report files for complete content of the currently selected repository: spreadsheets, folder content readmes etc.")] bool doReport = true,
            [Description("If true, it will print out short report on content of the repository (if any)")] bool debug = false)
        {

            if (activeRepository == null)
            {
                output.log("There is no active repository. Are you missing the Open call?");
                return;
            }

            if (!log_msg.isNullOrEmpty())
            {
                activeRepository.loger.log(log_msg);
            }

            string filepath = activeRepository.SaveDataStructure(folder, output);

           

            if (debug)
            {
                activeRepository.debugReport(output);
            }

            output.log($"Repository [{activeRepository.name}] saved to {filepath}");
        }






    }
}
