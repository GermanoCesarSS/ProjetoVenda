﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Venda_2023.conexao
{
    internal class ConectaBanco
    {
        SqlConnection con;
        string connectionString = @"Server=DESKTOP-CCP659G\SQLEXPRESS;Database=FUNEC2023_DAII;
                                    Trusted_Connection=True;";

        public SqlConnection conectaSqlServer()
        {
            //cria a conexão com o banco de dados
            con = new SqlConnection(connectionString);

            return con;
        }
    }
}
