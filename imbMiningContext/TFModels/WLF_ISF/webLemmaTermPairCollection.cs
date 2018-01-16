using System;
using System.Linq;
using System.Collections.Generic;
using imbMiningContext.TFModels.core;
using imbSCI.Core.files.folders;
using imbSCI.Core.math;
using imbSCI.Core.reporting;
using imbSCI.Data.enums;
using imbSCI.DataComplex.tables;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Data;
using imbSCI.DataComplex.extensions.data.schema;
using imbSCI.DataComplex.extensions.data.modify;
using imbSCI.DataComplex.tables.extensions;
using imbSCI.Core.extensions.table;

namespace imbMiningContext.TFModels.WLF_ISF
{

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Collections.Generic.List{imbMiningContext.TFModels.WLF_ISF.webLemmaTermPair}" />
    public class webLemmaTermPairCollection:List<webLemmaTermPair>
    {

        /// <summary>
        /// Gets the data table with complete pair collection
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable()
        {
            DataTable output = new DataTable("MatchedTerms");

            output.Add("Wqi", "Term weight at case/query", "W_qi", typeof(Double), imbSCI.Core.enums.dataPointImportance.normal, "F5", "Term W_qi");
            output.Add("Wci", "Term weight at class/document", "W_ci", typeof(Double), imbSCI.Core.enums.dataPointImportance.normal, "F5", "Term W_ci");
            output.Add("Pw", "Term pair weight-factor", "P_w", typeof(Double), imbSCI.Core.enums.dataPointImportance.normal, "F5", "Pair W");

            foreach (webLemmaTermPair pair in this)
            {
                var dr = output.NewRow();
                dr["Wqi"] = pair.entryA.weight;
                dr["Wci"] = pair.entryB.weight;
                dr["Pw"] = pair.factor;
                output.Rows.Add(dr);
            }

            output.AddExtra("Total pairs: " + this.Count);

            return output;
        }


        public void Add(webLemmaTerm entryA, webLemmaTerm entryB)
        {
            Add(new webLemmaTermPair(entryA, entryB));
        }

        public webLemmaTermPair GetPair(String nominalForm)
        {
            foreach (webLemmaTermPair pair in this)
            {
                if (pair.entryA.nominalForm == nominalForm)
                {
                    return pair;
                }
            }
            return null;
        }

        public void DeployFactors(List<webLemmaTermPairCollection> otherCrossSections)
        {
            foreach (webLemmaTermPair pair in this)
            {
                Int32 divisor = 1;

                foreach (webLemmaTermPairCollection crossSection in otherCrossSections)
                {
                    var p = crossSection.GetPair(pair.entryA.nominalForm);
                    if (p != null)
                    {
                        divisor++;
                    }
                }

                pair.factor = pair.factor / divisor;
                if (divisor == 2)
                {

                }
                if (divisor == 1)
                {

                }

            }
        }

        /// <summary>
        /// Gets the cosine similarity for contained pairs collection
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <returns></returns>
        public double GetCosineSimilarity(ILogBuilder logger = null)
        {

            Double upper = 0;
            Double lowerA = 0;
            Double lowerB = 0;

            foreach (webLemmaTermPair pair in this)
            {
                upper += pair.entryA.weight * pair.entryB.weight * pair.factor;
                lowerA += pair.entryA.weight * pair.entryA.weight * pair.factor;
                lowerB += pair.entryB.weight * pair.entryB.weight * pair.factor;
            }

            Double output = upper.GetRatio(Math.Sqrt(lowerA * lowerB));

            if (output == 0)
            {
                logger.log("Cosine similarity returned 0 score!");
            }

            return output;

        }
    }

}