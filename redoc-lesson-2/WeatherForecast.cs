using System;

namespace redoc_lesson_2
{
    public class WeatherForecast
    {
        /// <summary>
        /// �ѹ���
        /// </summary>
        /// <example>����Ѻ en >> 3/1/2008 7:00:00 AM</example>
        public DateTime Date { get; set; }

        /// <summary>
        /// �س����� ͧ��������
        /// </summary>
        /// <example>36.6</example>
        public int TemperatureC { get; set; }

        /// <summary>
        /// �س����� ͧ�ҿ��ù���ι�
        /// </summary>
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        /// <summary>
        /// ��������ػ
        /// </summary>
        public string Summary { get; set; }
    }
}
