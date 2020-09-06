using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Twitch.Models;

namespace Twitch.Controllers
{
    public class ConsultasController : Controller
    {
        MySqlConnection conexao;
        MySqlCommand comando;
        DataTable tabela;
        public ConsultasController()
        {
            conexao = new MySqlConnection("Server=localhost;DataBase=Twitch;Uid=root;Pwd=1234");
            comando = new MySqlCommand();
            comando.Connection = conexao;
            tabela = new DataTable();
          
            try
            {
                conexao.Open();


            }

            catch (Exception ex)
            {

            }
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Consulta1()
        {

            List<Consulta1> listConsulta = new List<Consulta1>();

            comando.CommandText = @"select nome, count(recebido) as itens_reivindicados  from canalstreamer
                                  natural join prime
                                  natural join recompensa
                                  group by cod_usuario
                                  having count(recebido) = 0;" ;

            MySqlDataReader dr = comando.ExecuteReader();


            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Consulta1 consulta = new Consulta1(dr[0].ToString(), dr.GetInt32(1));
                    listConsulta.Add(consulta);
                }

            }

            dr.Close();
            conexao.Close();


            ViewData["lista"] = listConsulta;

            return View();
        }



        public IActionResult Consulta2()
        {
            //   -- contar quantos inscritos tem em cada canal

            List<Consulta2> listConsulta = new List<Consulta2>();

            comando.CommandText = @"select nome_streamer, count(cod_inscrito) as total_inscritos
                                    from inscritosdocanal
                                    group by nome_streamer;";

            MySqlDataReader dr = comando.ExecuteReader();


            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Consulta2 consulta = new Consulta2(dr[0].ToString(), dr.GetInt32(1));
                    listConsulta.Add(consulta);
                }

            }

            dr.Close();
            conexao.Close();


            ViewData["lista"] = listConsulta;

            return View();
        }



        public IActionResult Consulta3()
        {
            //   -- contar quantos inscritos tem em cada canal

            List<Consulta3> listConsulta = new List<Consulta3>();

            comando.CommandText = @"select nome_streamer,nome as nome_espectador 
                                    from canalstreamer
                                    natural join recomendacoes
                                    join (select nome as nome_streamer, cod_usuario as cod_canal
                                    	  from canalstreamer) as streamer
                                    using (cod_canal)
                                    where (cod_canal,cod_usuario) not in
                                    	(select cod_streamer,cod_usuario 
                                         from gravacao
                                    	 natural join participacao);";
                                    

            MySqlDataReader dr = comando.ExecuteReader();


            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Consulta3 consulta = new Consulta3(dr[0].ToString(), dr[0].ToString());
                    listConsulta.Add(consulta);
                }

            }

            dr.Close();
            conexao.Close();


            ViewData["lista"] = listConsulta;

            return View();
        }

        public IActionResult Consulta4()
        {
            //   -- contar quantos inscritos tem em cada canal

            List<Consulta4> listConsulta = new List<Consulta4>();

            comando.CommandText = @"select nome as nome_streamer, total_visualizacoes
                                    from gravacao
                                    natural join categorizados
                                    join canalstreamer on (cod_streamer = cod_usuario)
                                    where total_visualizacoes > 20000 and
                                    	cod_categoria in (select cod_categoria
                                    					  from categorias
                                                          where nome = 'CSGO');";
                                    

            MySqlDataReader dr = comando.ExecuteReader();


            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Consulta4 consulta = new Consulta4(dr[0].ToString(), dr.GetInt32(1));
                    listConsulta.Add(consulta);
                }

            }

            dr.Close();
            conexao.Close();


            ViewData["lista"] = listConsulta;

            return View();
        }


        public IActionResult Consulta5()
        {
            //   -- contar quantos inscritos tem em cada canal

            List<Consulta5> listConsulta = new List<Consulta5>();

            comando.CommandText = @"select nome as nome_streamer, total_visualizacoes
                                    from gravacao
                                    natural join categorizados
                                    join canalstreamer on (cod_streamer = cod_usuario)
                                    where total_visualizacoes > 20000 and
                                    	cod_categoria in (select cod_categoria
                                    					  from categorias
                                                          where nome = 'CSGO');";


            MySqlDataReader dr = comando.ExecuteReader();


            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Consulta5 consulta = new Consulta5(dr[0].ToString());
                    listConsulta.Add(consulta);
                }

            }

            dr.Close();
            conexao.Close();


            ViewData["lista"] = listConsulta;

            return View();
        }

    }
}
