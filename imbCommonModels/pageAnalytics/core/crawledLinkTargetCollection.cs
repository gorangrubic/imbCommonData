namespace imbCommonModels.pageAnalytics.core
{
    using System;
    using aceCommonTypes.extensions.data;

    /// <summary>
    /// Crawler link collection with ranking mechanism 
    /// </summary>
    /// <seealso cref="crawledPageCollection" />
    public class crawledLinkTargetCollection: linkRootedList
    {


        //private crawledPageCollection _pages;

        ///// <summary>
        ///// 
        ///// </summary>
        //public crawledPageCollection pages
        //{
        //    get { return _pages; }
        //    set { _pages = value; }
        //}


        private Int32 _low;
        /// <summary>
        /// 
        /// </summary>
        public Int32 low
        {
            get { return _low; }
            set { _low = value; }
        }


        private Int32 _max;
        /// <summary>
        /// 
        /// </summary>
        public Int32 max
        {
            get { return _max; }
            set { _max = value; }
        }


        private Int32 _iLimit;
        /// <summary>
        /// 
        /// </summary>
        public Int32 iLimit
        {
            get { return _iLimit; }
            set { _iLimit = value; }
        }


        private Int32 _CountAll;
        /// <summary>
        /// 
        /// </summary>
        public Int32 CountAll
        {
            get {
                return this.Count();
            }
            set { _CountAll = value; }
        }

        public Int32 CountToTarget
        {
            get
            {
                return max - primary.Count();
            }
        }




        private linkList _primary = new linkList();
        /// <summary>
        /// 
        /// </summary>
        public linkList primary
        {
            get { return _primary; }
            set { _primary = value; }
        }



        private linkList _secondary = new linkList();
        /// <summary> </summary>
        public linkList secondary
        {
            get
            {
                return _secondary;
            }
            set
            {
                _secondary = value;
                
            }
        }


        private Boolean _isLinkCollectingDone = false;
        /// <summary>
        /// 
        /// </summary>
        public Boolean isLinkCollectingDone
        {
            get { return _isLinkCollectingDone; }
            set { _isLinkCollectingDone = value; }
        }

        public linkList getResult()
        {
            linkList output = new linkList();


            collectionExtensions.AddMulti(output, primary.take(max));
            Int32 cc = max - output.Count();

            if (output.Count < low+1)
            {
                collectionExtensions.AddMulti(output, secondary.take(cc));
            }
            return output;
        }


        /// <summary>
        /// Processes the specified page.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        public linkList process(crawledPage page, Boolean isLinkStackEmpty)
        {

            
            linkList output = new linkList();
            linkList secOutput = new linkList();

           // pages.Add(page);

            if (page == null)
            {
                isLinkCollectingDone = true;
                return null; //getResult();
            }

            if (CountToTarget < 1)
            {
                isLinkCollectingDone = true;
                return null; //getResult();
            }

            if (iLimit < 0)
            {
                isLinkCollectingDone = true;
                return null; //getResult();
            }

            htmlContentPage hContent = page.tokenizedContent as htmlContentPage;
            if (hContent != null)
            {
                htmlLinkNodeCollection linkNodes = new htmlLinkNodeCollection(hContent.tokens);


                var lnk = linkNodes.getSorted();
                foreach (htmlLinkNode ln in lnk)
                {
                    link crawledLink = null;
                    if (page.links.byUrl.ContainsKey(ln.url))
                    {
                        crawledLink = page.links.byUrl[ln.url];
                    }

                    var cwl = Add(crawledLink);
                    if (cwl != null)
                    {
                        if (ln.isPrimary)
                        {
                            primary.Add(crawledLink);
                            output.Add(cwl);
                        }
                        else
                        {
                            secondary.Add(crawledLink);
                            secOutput.Add(crawledLink);
                        }
                    }
                }
            } else
            {
                
            }

           // Int32 cc = CountToTarget - output.Count();


            if (!output.Any())
            {
                if (isLinkStackEmpty) collectionExtensions.AddMulti(output, secondary);
            }

            iLimit--;

            //if (output.Count() == 0)
            //{
            //    isLinkCollectingDone = true;
            //    return getResult();
            //}

            return output;
        }


        public crawledLinkTargetCollection(crawledPage __rootpage, Int32 __low=7, Int32 __max=10, Int32 __iLimit=7):base(__rootpage)
        {
            low = __low;
            max = __max;
            iLimit = __iLimit;
            primary = new linkList();
           //pages = new crawledPageCollection(__rootpage);
        }
    }

}