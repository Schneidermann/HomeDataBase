using System.Data.Entity;


namespace BackEndHome.Models.Contexto
{
	public class MeuContexto : DbContext
	{
		public MeuContexto() : base("strConn")
		{

		}

		public System.Data.Entity.DbSet<BackEndHome.Models.Dados> Dados { get; set; }
	}
}