using Microsoft.ML.OnnxRuntime.Tensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// model for the Calculator inputs
namespace intex2.Models
{
    public class CalculatorData
    {
        public float long_utm_x { get; set; }
        public float lat_utm_y { get; set; }
        public float hour { get; set; }
        public float month { get; set; }
        public float motorcycle_involved { get; set; }
        public float pedestrian_involved { get; set; }
        public float overturn_rollover { get; set; }
        public float bicyclist_involved { get; set; }
        public float teenage_driver_involved { get; set; }

        public Tensor<float> AsTensor()
        {
            float[] data = new float[]
            {
                long_utm_x, lat_utm_y, hour, month, motorcycle_involved, pedestrian_involved, overturn_rollover, bicyclist_involved, teenage_driver_involved
            };
            int[] dimensions = new int[] { 1, 9 };
            return new DenseTensor<float>(data, dimensions);
        }
    }
}
