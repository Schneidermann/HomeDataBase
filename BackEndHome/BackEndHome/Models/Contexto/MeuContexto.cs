using System.Data.Entity;


namespace BackEndHome.Models.Contexto
{
	public class MeuContexto : DbContext
	{
		public MeuContexto() : base("strConn")
		{

		}
	}
}