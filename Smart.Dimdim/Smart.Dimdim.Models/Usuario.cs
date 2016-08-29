using Smart.Dimdim.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smart.Dimdim.Models
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
            var md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(senha);
            byte[] hash = md5.ComputeHash(inputBytes);
            var sb = new System.Text.StringBuilder();

            foreach (byte bbyte in hash)
            {
                sb.Append(bbyte.ToString("X2"));
            }
            return sb.ToString();
        }
    }
}