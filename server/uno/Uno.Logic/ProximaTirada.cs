using System;

namespace Uno.Logic
{
	public class ProximaTirada
	{
		public bool PuedoTirar(Carta cartaAnterior, Carta cartaActual)
		{
			bool rt = false;
			//Mismo color
			if (cartaAnterior.Color.Equals(cartaActual.Color))
            {
				rt = true;
            }
            //Mismo número
            if (cartaAnterior.Simbolo.Equals(cartaActual.Simbolo))
            {
				rt =  true;
            }
			//+4
			if (cartaActual.Simbolo.Equals("+") && cartaActual.Color.Equals("4"))
            {
				rt =  true;
            }
			//Cambio color
			if (cartaActual.Simbolo.Equals("C") && cartaActual.Color.Equals("C"))
            {
				rt = true;
            }

			return rt;
		}
	}
}
