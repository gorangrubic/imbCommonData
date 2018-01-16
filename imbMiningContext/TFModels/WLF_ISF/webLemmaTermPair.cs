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

namespace imbMiningContext.TFModels.WLF_ISF
{

    /// <summary>
    /// 
    /// </summary>
    public class webLemmaTermPair
    {
        public webLemmaTerm entryA { get; set; }
        public webLemmaTerm entryB { get; set; }

        public Double factor { get; set; } = 1;

        public webLemmaTermPair(webLemmaTerm _entryA, webLemmaTerm _entryB)
        {
            entryA = _entryA;
            entryB = _entryB;
        }

    }

}