using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uno.Logic;

namespace Test.Uno
{
	[TestClass]
	public class TiradaTest
	{
		[TestMethod]
		public void PuedoTirarConMismoColor()
		{
			var logica = new ProximaTirada();
			var esValida = logica.PuedoTirar(new Carta.ReglasRealesFactory().Create("1", "R"), new Carta.ReglasRealesFactory().Create("4", "R"));
			Assert.IsTrue(esValida);
		}

		[TestMethod]
		public void PuedoCambiarDeColorSiEsMismoSimbolo()
		{
			var logica = new ProximaTirada();
			Assert.IsTrue(logica.PuedoTirar(new Carta.ReglasRealesFactory().Create("9", "R"), new Carta.ReglasRealesFactory().Create("9","V")));
		}

		[TestMethod]
		public void PuedoTirarMas4EnCualquierMomento()
		{
			var logica = new ProximaTirada();
			
			Assert.IsTrue(logica.PuedoTirar(new Carta.ReglasRealesFactory().Create("9","R"), new Carta.ReglasRealesFactory().Create("+4","E")));
		}

		[TestMethod]
		public void PuedoTirarCambiaColorEnCualquierMomento()
		{
			var logica = new ProximaTirada();
			Assert.IsTrue(logica.PuedoTirar(new Carta.ReglasRealesFactory().Create("9","R"), new Carta.ReglasRealesFactory().Create("C","E")));
		}

		[TestMethod]
		public void PuedoTirarMasDos()
		{
			var logica = new ProximaTirada();
			Assert.IsTrue(logica.PuedoTirar(new Carta.ReglasRealesFactory().Create("+2", "R"), new Carta.ReglasRealesFactory().Create("+2", "V")));

		}

		[TestMethod]
		public void SiEsMovimientoIlegalDoyNegativo()
		{
			var logica = new ProximaTirada();
			Assert.IsFalse(logica.PuedoTirar(new Carta.ReglasRealesFactory().Create("9","A"), new Carta.ReglasRealesFactory().Create("8","V")));

		}

		[TestMethod]
		public void PuedoCrearNuevosSetsDeCartas()
		{
			var logica = new ProximaTirada();
			Assert.IsTrue(logica.PuedoTirar(new Carta.ModoJuegoSiempreAceptaFactory().Create("9", "A"), new Carta.ModoJuegoSiempreAceptaFactory().Create("8", "V")));

		}

	}
}
