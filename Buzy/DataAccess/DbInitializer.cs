﻿using Buzy.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buzy.DataAccess
{
    public class DbInitializer
    {
        public static void DbInitialize(BusHelperContext db)
        {
            db.Database.EnsureCreated();
            ClearDataBase(db);

            if (db.Veiculo.Any()) return;
            var veiculo = new Veiculo()
            {

                nome = "Informática"
            };
            db.Veiculo.Add(veiculo);

            if (db.Usuarios.Any()) return;
            var usuario = new Usuario()
            {

                nome = "Danielz",
                email = "clemente2099@gmail.com",
                senha = "12345",
                telefone = "11 943243499"
            };
            db.Usuarios.Add(usuario);

            if (db.PontosDeOnibus.Any()) return;
            var ptDeOnibus = new PontoDeOnibus()
            {

                latitude = 123,
                longitude = 321,
                nome = "Augusta"
            };
            db.PontosDeOnibus.Add(ptDeOnibus);


            if (db.Sensores.Any()) return;
            var sensores = new Sensor[]
            {
                new Sensor {valor = 100, acao = AcaoSensor.Saida, CodigoLinha = "8000"},
                new Sensor {valor = 123, acao = AcaoSensor.Entrada, CodigoLinha = "8000"},

            };
            db.Sensores.AddRange(sensores);
           
            if (db.HistoricoSensores.Any()) return;
            var histSensores = new HistoricoSensor[]
            {
                new HistoricoSensor {data = new DateTime(2018, 01, 02), sensor = sensores[1]},
                new HistoricoSensor {data = new DateTime(2018, 01, 02), sensor = sensores[0]}
            };
            db.HistoricoSensores.AddRange(histSensores);

            if (db.Feedbacks.Any()) return;
            var feedback = new Feedback()
            {
                assunto = Assunto.Sugestoes,
                mensagem = "Mudar o Motorista"
            };
            db.Feedbacks.Add(feedback);

            db.SaveChanges();
        }

        public static void ClearDataBase(BusHelperContext db)
        {
            if (db.Veiculo.Any()) db.Veiculo.RemoveRange(db.Veiculo.ToList());

            if (db.Usuarios.Any()) db.Usuarios.RemoveRange(db.Usuarios.ToList());

            if (db.PontosDeOnibus.Any()) db.PontosDeOnibus.RemoveRange(db.PontosDeOnibus.ToList());

            if (db.Sensores.Any()) db.Sensores.RemoveRange(db.Sensores.ToList());

            if (db.HistoricoSensores.Any()) db.HistoricoSensores.RemoveRange(db.HistoricoSensores.ToList());

            if (db.Feedbacks.Any()) db.Feedbacks.RemoveRange(db.Feedbacks.ToList());

            db.SaveChanges();
        }
    }
}
