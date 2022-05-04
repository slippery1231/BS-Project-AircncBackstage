using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aircnc_BackStage.Models.DataModels
{
    [Serializable]
    public class PieDataModel
    {
        public int Ranking { get; set; }
        public  string  Area  { get; set; }
        public float Ratio { get; set; }
    }
}
