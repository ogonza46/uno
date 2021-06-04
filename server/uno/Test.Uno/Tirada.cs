using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uno.Logic;

namespace Test.Uno
{
	[TestClass]
	public class Tirada
	{
		[TestMethod]
		public void PuedoTirarConMismoColor()
		{
			var logica = new ProximaTirada();
			var esValida = logica.PuedoTirar(new Carta("1", "R"), new Carta("4", "R"));
			Assert.IsTrue(esValida);
		}

		[TestMethod]
		public void PuedoCambiarDeColorSiEsMismoSimbolo()
		{
			var logica = new ProximaTirada();
			Assert.IsTrue(logica.PuedoTirar(new Carta("9", "R"), new Carta("9","V")));
		}

		[TestMethod]
		public void PuedoTirarMas4EnCualquierMomento()
		{
			var logica = new ProximaTirada();

			Assert.IsTrue(logica.PuedoTirar(new Carta("9","R"), new Carta("+","4")));
		}

		[TestMethod]
		public void PuedoTirarCambiaColorEnCualquierMomento()
		{
			var logica = new ProximaTirada();
			Assert.IsTrue(logica.PuedoTirar(new Carta("9","R"), new Carta("C","C")));
		}

		[TestMethod]
		public void SiEsMovimientoIlegalDoyNegativo()
		{
			var logica = new ProximaTirada();
			Assert.IsFalse(logica.PuedoTirar(new Carta("9","A"), new Carta("8","V")));

		}
	}
}
