using BackRestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace BackRestApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HomeController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            //Model1 conexao = new Model1();

            //List<Equipamento> equipamentos = conexao.Equipamento.ToList<Equipamento>();
            //Random rando = new Random();
            //while (true)
            //{
            //    foreach (Equipamento equipamento in equipamentos)
            //    {
            //        Evento evento = new Evento();
            //        evento.Equipamento = equipamento;
            //        evento.PecasBoas = rando.Next(0, 10);
            //        evento.PecasRuins = rando.Next(0, 10);
            //        evento.TempoParada = rando.Next(0, 60).ToString();
            //        evento.TempoProducao = (60 - Convert.ToInt16(evento.TempoParada)).ToString();

            //        conexao.Evento.Add(evento);
            //        conexao.SaveChanges();
            //    }
            //}

            return View();
        }

        public ActionResult maquinas()
        {
            
            Model1 conexao = new Model1();
            conexao.Configuration.ProxyCreationEnabled = false;
            List<Equipamento> equipamentos = conexao.Equipamento.ToList<Equipamento>();
            List<Maquina> maquinas = new List<Maquina>();
            foreach (Equipamento equip in equipamentos)
            {
                Maquina maquina = new Maquina();
                maquina.Nome = equip.NomeEquipamento;
                maquina.Id = equip.Id;
                maquina.PecasBoas = conexao.Evento.Where(e => e.Equipamento.Id == equip.Id).Sum(e => e.PecasBoas).Value;
                maquina.PecasRuins = conexao.Evento.Where(e => e.Equipamento.Id == equip.Id).Sum(e => e.PecasRuins).Value;
                if (maquina.PecasBoas != 0 && maquina.PecasRuins != 0)
                {
                    maquina.Taxa = (maquina.PecasRuins * 100) / maquina.PecasBoas;
                }
                maquinas.Add(maquina);
            }
            
            return Json(maquinas, JsonRequestBehavior.AllowGet);
        }

        // GET: Obter Equipamentos
        public ActionResult equipamento()
        {
            Model1 conexao = new Model1();
            conexao.Configuration.ProxyCreationEnabled = false;
            List<Equipamento> equipamentos = conexao.Equipamento.ToList<Equipamento>();

            return Json(equipamentos, JsonRequestBehavior.AllowGet);
        }

        // GET: Obter Equipamentos
        public ActionResult equipamentoById(int id)
        {
            Model1 conexao = new Model1();
            conexao.Configuration.ProxyCreationEnabled = false;
            List<Equipamento> equipamentos = conexao.Equipamento.Where(a => a.Id == id).ToList<Equipamento>();

            return Json(equipamentos, JsonRequestBehavior.AllowGet);
        }


        // GET: Obter Eventos Todos Equipamentos
        public ActionResult evento()
        {
            Model1 conexao = new Model1();
            conexao.Configuration.ProxyCreationEnabled = false;

            List<Evento> eventos = conexao.Evento.ToList<Evento>();

            return Json(eventos, JsonRequestBehavior.AllowGet);
        }

        // GET: Obter Eventos Todos Equipamentos
        public ActionResult eventoById(int id)
        {
            Model1 conexao = new Model1();
            conexao.Configuration.ProxyCreationEnabled = false;

            List<Evento> eventos = conexao.Evento.Where(a => a.Id == id).ToList<Evento>();

            return Json(eventos, JsonRequestBehavior.AllowGet);
        }


        // GET: Obter Eventos Equipamentos por Equipamento
        public ActionResult eventoequipamento(int idEquipamento)
        {
            Model1 conexao = new Model1();
            conexao.Configuration.ProxyCreationEnabled = false;

            List<Evento> eventos = conexao.Evento.Where(a => a.Equipamento.Id == idEquipamento).ToList<Evento>();

            return Json(eventos, JsonRequestBehavior.AllowGet);
        }


        // GET: Obter Eventos Equipamentos por Equipamento
        public ActionResult alarmeById(int id)
        {
            Model1 conexao = new Model1();
            conexao.Configuration.ProxyCreationEnabled = false;

            List<Alarme> alarmes = conexao.Alarme.Where(a => a.Equipamento.Id == id).ToList<Alarme>();

            return Json(alarmes, JsonRequestBehavior.AllowGet);
        }

        // GET: Obter Eventos Equipamentos por Equipamento
        public ActionResult alarme()
        {
            Model1 conexao = new Model1();
            conexao.Configuration.ProxyCreationEnabled = false;

            List<Alarme> alarmes = conexao.Alarme.ToList<Alarme>();

            return Json(alarmes, JsonRequestBehavior.AllowGet);
        }

    }
}