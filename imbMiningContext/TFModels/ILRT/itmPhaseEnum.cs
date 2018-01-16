using System;
using System.Linq;
using System.Collections.Generic;
using imbMiningContext.TFModels.core;
using imbSCI.DataComplex.tables;
using System.Text;
using System.ComponentModel;
using imbSCI.Core.attributes;

namespace imbMiningContext.TFModels.ILRT
{

    /// <summary>
    /// Phase at which itm model is now
    /// </summary>
    public enum itmPhaseEnum
    {
        none,
        setup,
        readyToCrawl,
        readyToProcessMC,
        readyToApplicate,
    }

}