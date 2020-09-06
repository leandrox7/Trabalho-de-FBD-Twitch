using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Twitch
{
    public class Data
    {
        MySqlConnection conexao;

        Data()
        {
            conexao = new MySqlConnection("Server=localhost;DataBase=Twitch;Uid=root;Pwd=1234");

        }
        public void Close() 
        { 
             conexao.Close();
        }
        public void Open()
        {
            try
            { 
                conexao.Open();

            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           

           
        }
    }
}



