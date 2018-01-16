using System;
using System.Linq;
using System.Collections.Generic;
using imbSCI.DataComplex.tables;
using System.ComponentModel;
using System.Text;
using imbMiningContext.TFModels.core;
using System.Data;
using imbSCI.DataComplex.extensions.data.schema;
using imbSCI.DataComplex.extensions.data.operations;
using imbSCI.DataComplex.extensions.data.modify;
using imbSCI.DataComplex.tables;
using imbSCI.Core.extensions.table;

namespace imbMiningContext.TFModels.WLF_ISF
{

    public static class webLemmaTermExtensions
    {

        /// <summary>
        /// Gets the data table sorted.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="limit">The limit.</param>
        /// <returns></returns>
        public static DataTable GetDataTableSorted(this webLemmaTermTable table, Int32 limit=-1)
        {
            DataTable wlt = table.GetDataTable();
            wlt.DefaultView.Sort = "termFrequency desc";
            var sorted = wlt.DefaultView.ToTable();

            DataTable elt = wlt.GetClonedShema<DataTable>(true);

            elt.CopyRowsFrom(sorted, 0, limit);

            if (limit > 0) elt.AddExtra("The report contains first [" + limit.ToString("D5") + "] rows");
            return elt;
        }


        public static Dictionary<String, webLemmaTerm> GetLemmaDictionary(this IEnumerable<webLemmaTerm> lemmas)
        {
            Dictionary<String, webLemmaTerm> output = new Dictionary<string, webLemmaTerm>();

            foreach (webLemmaTerm term in lemmas)
            {
                if (!output.ContainsKey(term.name))
                {
                    output.Add(term.name, term);
                }
            }

            return output;
        }
    }

}