// --------------------------------------------------------------------------------------------------------------------
// <copyright file="indexPage.cs" company="imbVeles" >
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
namespace imbCommonModels.webPage
{
    using imbSCI.Core.attributes;
    using imbSCI.Core.extensions.data;
    using imbSCI.Core.extensions.enumworks;
    using imbSCI.Core.math;
    using System.ComponentModel;
    using System.Xml.Serialization;

    [XmlInclude(typeof(indexPageRelevancyEnum))]
    [imb(imbAttributeName.reporting_categoryOrder, "IndexData, Information Volume, Language Test")]
    public class indexPage
    {

        public indexPage()
        {

        }

        


        /// <summary> Number of </summary>
        [Category("IndexData")]
        [DisplayName("URL")]
        [imb(imbAttributeName.measure_letter, "url")]
        [imb(imbAttributeName.measure_setUnit, "-")]
        [Description("Resolved form of URL to the page")] // [imb(imbAttributeName.measure_important)][imb(imbAttributeName.reporting_valueformat, "")]	
        public string url { get; set; }


        /// <summary> Domain name of the web site </summary>
        [Category("IndexData")]
        [DisplayName("Domain")]
        [imb(imbAttributeName.measure_letter, "")]
        [imb(imbAttributeName.measure_setUnit, "n")]
        [Description("Domain name of the web site")] // [imb(imbAttributeName.measure_important)][imb(imbAttributeName.reporting_valueformat, "")]	
        public string domain { get; set; }


        /// <summary> Target Semantic Terms - collection of tokens extracted from URL tokens and anchor texts  </summary>
        [Category("Information Volume")]
        [DisplayName("TargetTerms")]
        [imb(imbAttributeName.measure_letter, "TST")]
        [imb(imbAttributeName.measure_setUnit, "word[]")]
        [Description("Target Semantic Terms - collection of tokens extracted from URL tokens and anchor texts ")] // [imb(imbAttributeName.measure_important)][imb(imbAttributeName.reporting_valueformat, "")]	
        public string tst { get; set; }


        /// <summary> Terms that match only one dictionary - considered more certain to be of the primary language </summary>
        [Category("Language Test")]
        [DisplayName("Terms Primary")]
        [imb(imbAttributeName.measure_letter, "W_SLM")]
        [imb(imbAttributeName.measure_setUnit, "word[]")]
        [Description("Terms that match only one dictionary - considered more certain to be of the primary language")] // [imb(imbAttributeName.measure_important)][imb(imbAttributeName.reporting_valueformat, "")]	
        public string singleMatchTokens { get; set; }


        /// <summary> Terms that had more than single dictionary match - considered less reliable for content language evaluation </summary>
        [Category("Language Test")]
        [DisplayName("Terms Secondary")]
        [imb(imbAttributeName.measure_letter, "W_MLM")]
        [imb(imbAttributeName.measure_setUnit, "word[]")]
        [Description("Terms that had more than single dictionary match - considered less reliable for content language evaluation")] // [imb(imbAttributeName.measure_important)][imb(imbAttributeName.reporting_valueformat, "")]	
        public string multiMatchTokens { get; set; }


        /// <summary> Number of distinct words found on the page </summary>
        [Category("Information Volume")]
        [DisplayName("Distinct Terms")]
        [imb(imbAttributeName.measure_letter, "|p_w[]|")]
        [imb(imbAttributeName.measure_setUnit, "word[]")]
        [Description("Number of distinct words found on the page")] // [imb(imbAttributeName.measure_important)][imb(imbAttributeName.reporting_valueformat, "")]	
        public int wordCount { get; set; } = 0;



        /// <summary> Confidence in results of the multi-language evaluation </summary>
        [Category("Language Test")]
        [DisplayName("Test Confidence")]
        [imb(imbAttributeName.measure_letter, "γ(P_w[])")]
        [imb(imbAttributeName.measure_setUnit, "%")]
        [imb(imbAttributeName.reporting_valueformat, "P2")]
        [Description("Confidence in results of the multi-language evaluation")] // [imb(imbAttributeName.measure_important)][imb(imbAttributeName.reporting_valueformat, "")]	
        public double langTestRatio { get; set; } = 0;



        /// <summary> Language designated by the multi-language evaluation done </summary>
        [Category("Language Test")]
        [DisplayName("Content Language")]
        [imb(imbAttributeName.measure_letter, "-")]
        [imb(imbAttributeName.measure_setUnit, "-")]
        [Description("Language designated by the multi-language evaluation done")] // [imb(imbAttributeName.measure_important)][imb(imbAttributeName.reporting_valueformat, "")]	
        public string language { get; set; } = "unknown";


        [Category("Language Test")]
        [DisplayName("Test Conclusion")]
        [imb(imbAttributeName.measure_letter, "-")]
        [imb(imbAttributeName.measure_setUnit, "-")]
        [Description("Language designated by the multi-language evaluation done")]
        public string relevancyText { get; set; }

        private indexPageRelevancyEnum _relevancy = indexPageRelevancyEnum.none;
        [XmlIgnore]

        public indexPageRelevancyEnum relevancy
        {
            get {
                if (_relevancy == indexPageRelevancyEnum.none)
                {
                    
                   _relevancy = (indexPageRelevancyEnum)typeof(indexPageRelevancyEnum).getEnumByName(relevancyText, indexPageRelevancyEnum.none);
                    
                }
                return _relevancy; }
            set {
                _relevancy = value;
                relevancyText = value.ToString();
            }
        }

        //  public Boolean isRelevant { get; set; }

        /// <summary> Size of the page HTML source code - being loaded and processed by the Loader and Content Processor components </summary>
        [Category("IndexData")]
        [DisplayName("Data Load")]
        [imb(imbAttributeName.measure_letter, "")]
        [imb(imbAttributeName.measure_setUnit, "bytes")]
        [imb(imbAttributeName.measure_setUnit, "-")]
        [Description("Size of the page HTML source code - being loaded and processed by the Loader and Content Processor components")] // [imb(imbAttributeName.measure_important)][imb(imbAttributeName.reporting_valueformat, "")]	
        public int byteSize { get; set; }


        [Category("Information Volume")]
        [DisplayName("Lemmas")]
        [imb(imbAttributeName.measure_letter, "|Lem_p|")]
        [imb(imbAttributeName.measure_setUnit, "n")]
        [Description("Number of distinct lemmas on relevant language, discovered on the page")] // [imb(imbAttributeName.measure_important)][imb(imbAttributeName.reporting_valueformat, "")]
        public int Lemmas { get; set; } = 0;

        

        /// <summary> Total Information Prize available on this web site </summary>
        [Category("Information Volume")]
        [DisplayName("Information Prize")]
        [imb(imbAttributeName.measure_letter, "∑|IP_p|")]
        [imb(imbAttributeName.measure_setUnit, "IP")]
        [Description("Information Prize of the page (sum of all Lemma TF-IDF weights)")] // [imb(imbAttributeName.measure_important)][imb(imbAttributeName.reporting_valueformat, "")][imb(imbAttributeName.reporting_escapeoff)]
        public double InfoPrize { get; set; } = 0;


        /// <summary>  </summary>
        [Category("Information Volume")]
        [DisplayName("Distinct Lemmas")]
        [imb(imbAttributeName.measure_letter, "Lem[]")]
        [imb(imbAttributeName.measure_setUnit, "-")]
        [Description("List of lemmas found to be unique to this page (in scope of this index)")] // [imb(imbAttributeName.reporting_escapeoff)]
        public string DistinctLemmas { get; set; } = "";


        /// <summary>  </summary>
        [Category("Information")]
        [DisplayName("RelevantTerms")]
        [imb(imbAttributeName.measure_letter, "")]
        [imb(imbAttributeName.measure_setUnit, "-")]
        [Description("")] // [imb(imbAttributeName.reporting_escapeoff)]
        public string RelevantTerms { get; set; } = default(string);




        /// <summary> True - if the Index Engine has precompiled TF-IDF for this web site </summary>
        [Category("IndexData")]
        [DisplayName("TF-IDF compiled")]
        [imb(imbAttributeName.measure_letter, "")]
        [imb(imbAttributeName.measure_setUnit, "n")]
        [Description("True - if the Index Engine has precompiled TF-IDF for this page")] // [imb(imbAttributeName.measure_important)][imb(imbAttributeName.reporting_valueformat, "")]
        public bool TFIDFcompiled { get; set; } = false;




        private string _HashCode = "";

        /// <summary> Hash code that pairs this domain to its TF-IDF table stored in the index  </summary>
        [Category("Information Volume")]
        [DisplayName("Hash code")]
        [imb(imbAttributeName.measure_letter, "TF-IDF#")]
        [imb(imbAttributeName.measure_setUnit, "#")]
        [Description("Hash code that pairs this page to its TF-IDF table stored in the index ")] // [imb(imbAttributeName.reporting_escapeoff)]
        [imb(imbAttributeName.collectionPrimaryKey)]
        public string HashCode
        {
            get
            {

                if (_HashCode.isNullOrEmpty()) _HashCode = md5.GetMd5Hash(url);
                return _HashCode;
            }
            set
            {
                _HashCode = value;
            }
        }



        /// <summary> Additional note on this index entry </summary>
        [Category("Info")]
        [DisplayName("Note")]
        [imb(imbAttributeName.measure_letter, "")]
        [imb(imbAttributeName.measure_setUnit, "-")]
        [Description("Additional note on this index entry")] // [imb(imbAttributeName.reporting_escapeoff)]
        public string Note { get; set; } = default(string);



        /// <summary> allwords found in the content </summary>
        [Category("Information Volume")]
        [DisplayName("AllWords")]
        [imb(imbAttributeName.measure_letter, "")]
        [imb(imbAttributeName.measure_setUnit, "-")]
        [Description("")] // [imb(imbAttributeName.reporting_escapeoff)]
        public string AllWords { get; set; } = ""; // allwords found in the content

        /// <summary> allwords found in the content </summary>
        [Category("Information Volume")]
        [DisplayName("AllLemmas")]
        [imb(imbAttributeName.measure_letter, "")]
        [imb(imbAttributeName.measure_setUnit, "-")]
        [Description("")] // [imb(imbAttributeName.reporting_escapeoff)]
        public string AllLemmas { get; set; } = ""; // allwords found in the content

    }
}
