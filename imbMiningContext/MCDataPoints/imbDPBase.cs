using imbSCI.Core.extensions.text;
using imbSCI.Data.collection.graph;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace imbMiningContext.MCDataPoints
{

    /// <summary>
    /// Data point is complexier token flag, containing additional data structure, in graph-tree form
    /// </summary>
    public abstract class imbDPBase:graphNodeCustom
    {

        /// <summary>
        /// Deploys the data row.
        /// </summary>
        /// <param name="dr">The dr.</param>
        public abstract void DeployDataRow(DataRow dr);
        


    }

}