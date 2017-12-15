using imbSCI.Core.extensions.text;
using imbSCI.Data.collection.graph;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace imbMiningContext.MCDataPoints
{

    public class imbDPTown:imbDPBase
    {

        public String zipCode { get; set; }

        public String phonePrefixNational { get; set; }

        public String phonePrefixInternational { get; set; }

        public override void DeployDataRow(DataRow dr)
        {
            zipCode = dr[0].toStringSafe();
        }
    }

}