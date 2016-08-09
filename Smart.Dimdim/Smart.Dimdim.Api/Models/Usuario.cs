using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Smart.Dimdim.Api.Models
{
    
    [Table("USUARIO")]
    public class Usuario:Entidade
    {
        public string Nome { get; set; }
        
        public string Email { get; set; }
        
        public string Apelido { get; set; }
        
        public string Senha { get; set; }


        public static string Crypto(string senha)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(senha);
            byte[] hash = md5.ComputeHash(inputBytes);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}