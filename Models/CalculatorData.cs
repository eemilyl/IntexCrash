using Microsoft.ML.OnnxRuntime.Tensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace intex2.Models
{
    public class CalculatorData
    {
        public int long_utm_x { get; set; }
        public int lat_utm_y { get; set; }
        public int hour { get; set; }
        public int month { get; set; }
        public int motorcycle_involved { get; set; }
        public int pedestrian_involved { get; set; }
        public int overturn_rollover { get; set; }
        public int bicyclist_involved { get; set; }
        public int teenage_driver_involved { get; set; }

        public Tensor<int> AsTensor()
        {
            int[] data = new int[]
            {
                long_utm_x, lat_utm_y, hour, month, motorcycle_involved, pedestrian_involved, overturn_rollover, bicyclist_involved, teenage_driver_involved
            };
            int[] dimensions = new int[] { 1, 9 };
            return new DenseTensor<int>(data, dimensions);
        }
    }
}
