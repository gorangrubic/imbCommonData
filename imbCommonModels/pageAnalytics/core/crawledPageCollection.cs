// --------------------------------------------------------------------------------------------------------------------
// <copyright file="crawledPageCollection.cs" company="imbVeles" >
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
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Collection of unique crawled pages
    /// </summary>
    /// <seealso cref="System.Collections.Generic.IEnumerable{imbAnalyticsEngine.pageAnalytics.core.crawledPage}" />
    public class crawledPageCollection:IEnumerable<crawledPage>
    {
        /// <summary>
        /// 
        /// </summary>
        protected crawledPage rootpage { get; private set; }


        /// <summary>
        /// Collection of unique crawled pages - as seen from <c>rootpage</c> perspective
        /// </summary>
        /// <param name="__rootpage">The rootpage.</param>
        public crawledPageCollection(crawledPage __rootpage)
        {
            rootpage = __rootpage;
        }

        /// <summary>
        /// Adds page if it has unique absolute url (against <c>rootpage</c>
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns>Page if it was added. Null if the page was already known</returns>
        public crawledPage Add(crawledPage page)
        {
            string absp = page.getAbsoluteUrl(rootpage);
            if (!pages.ContainsKey(absp))
            {
                pages.Add(absp, page);
                return page;
            }
            return null;
        }

        public crawledPage Get(string url)
        {
            return pages[url];
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<crawledPage> GetEnumerator()
        {
            return pages.Values.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return pages.Values.GetEnumerator();
        }

        /// <summary> </summary>
        protected Dictionary<string, crawledPage> pages { get; set; } = new Dictionary<string, crawledPage>();
    }

}