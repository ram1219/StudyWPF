using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogusMqttWinPubApp
{
    public class SensorInfo
    {
        public string Dev_Id { get; set; }      //거실, 침실, 욕실, 화장실, 식당 id 부여
        public string Curr_Time { get; set; }
        public float Temp { get; set; }
        public float Humid { get; set; }
        public float Press { get; set; }

    }
}
