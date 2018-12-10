using Projeto01_ApiChamadas.Enumeracoes;
using Projeto01_ApiChamadas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto01_ApiChamadas.Dados
{
    public class ClientesDao
    {
        public IEnumerable<ClienteS> BuscarTodos()
        {
            using (var ctx = new DB_CHAMADOSEntities())
            {
                //return ctx.tb_Chamados.ToList();
            }
        }

        public RespostaCliente ResponderClienteS(ClienteS cliente)
        {
            using (var ctx = new DB_CHAMADOSEntities())
            {
                //verificar se o cliente foi respondido
                var resposta = ctx.tb_Chamados.FirstOrDefault(c => c.Descricao.Equals(cliente.Descricao));
                if(resposta!= null)
                {
                    return RespostaCliente.RESPOSTA_OK;
                }

                //não permite fazer a exclusao depois de uma resposta
                var excluir = ctx.tb_Chamados.FirstOrDefault(c => c.Descricao.Equals(cliente.Descricao));
                if(resposta != null)
                {
                    return RespostaCliente.EXCLUSAO_INVALIDA;
                }

            }
        }

    }
}