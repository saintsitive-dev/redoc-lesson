using System;

namespace redoc_lesson_2
{
    public class WeatherForecast
    {
        /// <summary>
        /// วันที่
        /// </summary>
        /// <example>สำหรับ en >> 3/1/2008 7:00:00 AM</example>
        public DateTime Date { get; set; }

        /// <summary>
        /// อุณหภูมิ องศาเซลเซียส
        /// </summary>
        /// <example>36.6</example>
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
