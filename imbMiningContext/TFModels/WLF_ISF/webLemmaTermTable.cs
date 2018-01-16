// --------------------------------------------------------------------------------------------------------------------
// <copyright file="webLemmaTermTable.cs" company="imbVeles" >
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
using imbMiningContext.TFModels.core;
using imbSCI.Core.extensions.data;
using imbSCI.Core.extensions.io;
using imbSCI.Core.files.folders;
using imbSCI.Core.math;
using imbSCI.Core.reporting;
using imbSCI.Data.enums;
using imbSCI.DataComplex.tables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace imbMiningContext.TFModels.WLF_ISF
{



    /// <summary>
    /// Precompiled web lemma term table, ready for saving and application
    /// </summary>
    /// <seealso cref="imbSCI.DataComplex.tables.objectTable{imbMiningContext.TFModels.WLF_ISF.webLemmaTerm}" />
    public class webLemmaTermTable : objectTable<webLemmaTerm>
    {
        public webLemmaTermTable(String _name) : base(nameof(webLemmaTerm.name), _name)
        {

        }

        public webLemmaTermTable(String __filepath, Boolean autoload, String _name) : base(__filepath, autoload, nameof(webLemmaTerm.name), _name)
        {

        }

        /// <summary>
        /// Gets the only positive term table.
        /// </summary>
        /// <returns></returns>
        public webLemmaTermTable GetOnlyPositiveTermTable()
        {
            webLemmaTermTable output = new webLemmaTermTable(info.FullName, false, name);
            
            
            output.description = description;

            List<webLemmaTerm> lemmas = GetList();

            foreach (webLemmaTerm lemma in lemmas)
            {
                if (lemma.weight > 0.00001)
                {
                    output.AddOrUpdate(lemma);
                }
            }
            return output;
        }

        public List<String> unresolved { get; set; } = new List<string>();


        /// <summary>
        /// Gets lemmas that are common between this and specified <c>tableB</c>
        /// </summary>
        /// <param name="tableB">The table b.</param>
        /// <param name="logger">The logger.</param>
        /// <returns></returns>
        public webLemmaTermPairCollection GetMatchingTerms(webLemmaTermTable tableB, ILogBuilder logger = null)
        {
            webLemmaTermPairCollection output = new webLemmaTermPairCollection();

            List<webLemmaTerm> lemmas = GetList();

            foreach (webLemmaTerm lemma in lemmas)
            {
                webLemmaTerm lemmaB = tableB.ResolveLemmaForTerm(lemma.nominalForm);
                if (lemmaB != null)
                {
                    output.Add(lemma, lemmaB);
                }
            }

            return output;
        }


        public webLemmaTerm ResolveLemmaForTerm(String term, ILogBuilder logger = null)
        {
            if (!index.Any()) prepareForUse(logger);

            if (index.ContainsKey(term))
            {
                return index[term];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Resolves single term - returns weight for lemma of this term
        /// </summary>
        /// <param name="term">The term.</param>
        /// <returns></returns>
        public Double ResolveSingleTerm(String term, ILogBuilder logger = null)
        {
            if (!index.Any()) prepareForUse(logger);

            if (index.ContainsKey(term))
            {
                return index[term].weight;
            } else
            {
                return 0;
            }

            return 0;
        }

        protected Dictionary<String, webLemmaTerm> index = new Dictionary<string, webLemmaTerm>();


        public void prepareForUse(ILogBuilder logger=null)
        {
            List<webLemmaTerm> lemmas = GetList();

            foreach (webLemmaTerm term in lemmas)
            {
                if (!index.ContainsKey(term.nominalForm))
                {
                    index.Add(term.nominalForm, term);
                }

                foreach (String termOther in term.otherForms) {
                    if (!index.ContainsKey(termOther))
                    {
                        index.Add(termOther, term);
                    }
                }
            }
            
        }

        private String unresolvedPath { get; set; } = "";

        public override bool Load(string path = "", bool autoBuildOnFail = true)
        {
            String dr = Path.GetDirectoryName(path);
            String nm = Path.GetFileNameWithoutExtension(path) + ".txt";
            unresolvedPath = dr + Path.DirectorySeparatorChar + nm;

            var fi = unresolvedPath.getWritableFile(getWritableFileMode.overwrite);
            unresolvedPath = fi.FullName;

            if (fi.Exists)
            {
                unresolved.AddRange(File.ReadAllLines(unresolvedPath));
            }

            return base.Load(path, autoBuildOnFail);
        }

        public override Boolean Save(getWritableFileMode mode = getWritableFileMode.newOrExisting)
        {
            Boolean output = base.Save(mode);
            folderNode folder = info.Directory;

            if (!unresolvedPath.isNullOrEmpty())
            {
                var fi = unresolvedPath.getWritableFile(getWritableFileMode.overwrite);

                File.WriteAllLines(fi.FullName, unresolved);

            }
            // var fi = folder.pathFor(unresolvedPath, mode); // .FullName + Path.

            return output;

        }

        public void clearUnder(Double lowerLimit=0.001, ILogBuilder logger=null)
        {
            List<webLemmaTerm> lemmas = GetList();
            Int32 i = 0;
            foreach (webLemmaTerm lemma in lemmas)
            {
                if (lemma.weight < lowerLimit)
                {
                    if (Remove(lemma)) i++;
                }
            }

           if (logger != null) logger.log("WFT [" + name + "] removed [" + i + "] entries under [" + lowerLimit + "] out of TC[" + lemmas.Count() + "]");
        }

       
    }
}
