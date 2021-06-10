using System;

namespace Uno.Logic
{
	public class ProximaTirada
	{
		public bool PuedoTirar(Carta cartaAnterior, Carta cartaActual)
		{
			return cartaAnterior.PuedoTirar(cartaActual);
		}
	}


}

// SOLID -> O -> OPEN/CLOSED -> OPEN
// KISS
// 12 FACTOR
