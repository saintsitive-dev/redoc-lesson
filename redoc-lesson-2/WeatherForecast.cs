using System;

namespace redoc_lesson_2
{
    public class WeatherForecast
    {
        /// <summary>
        /// �ѹ���
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// �س����� ͧ��������
        /// </summary>
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
