using System;

namespace redoc_lesson_2
{
    public class WeatherForecast
    {
        /// <summary>
        /// วันที่
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// อุณหภูมิ องศาเซลเซียส
        /// </summary>
        public int TemperatureC { get; set; }

        /// <summary>
        /// อุณหภูมิ องศาฟาเรนด์ไฮน์
        /// </summary>
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        /// <summary>
        /// ข้อมูลสรุป
        /// </summary>
        public string Summary { get; set; }
    }
}
