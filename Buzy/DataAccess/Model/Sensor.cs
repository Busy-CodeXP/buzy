﻿namespace Buzy.DataAccess.Model
{
    public class Sensor
    {
        public Sensor()
        {
        }

        public int Id { get; set; }
        public int valor { get; set; }
        public AcaoSensor acao { get; set; }
        public int prefixo { get; set; }
        public int codigoLinha { get; set; }
    }
}