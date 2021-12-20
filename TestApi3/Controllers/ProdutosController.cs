using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestApi3.Models;

namespace TestApi3.Controllers
{
    public class ProdutosController : ApiController
    {
        Entities db = new Entities();
        
        //Post
        public string Post(Produto produto)
        {
            db.Produtos.Add(produto);
            db.SaveChanges();
            return "Número de clientes adicionado com sucesso";
        } 
        //Get
        public IEnumerable <Produto> Get()
        {
            return db.Produtos.ToList();
        }

        //Update
        public string Put (int id, Produto protudo)
        {
            var encontrar_produto = db.Produtos.Find(id);
            encontrar_produto.Cliente = protudo.Cliente;
            encontrar_produto.Quantidade = protudo.Quantidade;
            db.Entry(encontrar_produto).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return "Atualizado com sucesso";
        }


        //Delete
        public string Delete(int id)
        {
            Produto produto = db.Produtos.Find(id);
            db.Produtos.Remove(produto);
            db.SaveChanges();
            return "Deletado com sucesso";
        }

    }
}
