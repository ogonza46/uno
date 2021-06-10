using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Uno.Logic
{

    public abstract class Carta
    {
        private string simbolo;
        private string color;

        public abstract bool PuedoTirar(Carta cartaActual);
        protected Carta(string simbolo, string color)
        {
            this.simbolo = simbolo ?? throw new ArgumentNullException(nameof(simbolo));
            this.color = color ?? throw new ArgumentNullException(nameof(color));
        }

        public string Simbolo
        {
            get { return simbolo;  }
            set { simbolo = value; }
        }

        public string Color
        {
            get { return color;  }
            set { color = value; }
        }
      

        public class ReglasRealesFactory : IFactory<string, string, Carta>
        {
            public Carta Create(string simbolo, string color)
            {
                // Lista de colores posibles.
                // "V" -> Verde
                // "A" -> Azul
                // "R" -> Rojo
                // "O" -> amarillO
                List<String> colors = new List<string>(); //["V", "A", "R", "O"];
                Regex regex = new Regex("^[0-9]+$");
                if (simbolo.Equals("+2"))
                {
                    return new MasDos(simbolo, color);
                }

                if (simbolo.Equals("+4"))
                {
                    return new MasCuatro(simbolo, color);
                }

                if (simbolo.Equals("C") && color.Equals("E")){
                    return new CambioColor(simbolo, color);
                }

                if (simbolo.Equals("C") && colors.Contains(color)){

                }

                if (colors.Contains(color) || regex.IsMatch(simbolo))
                {
                    return new Normal(simbolo, color);
                }

                throw new ArgumentException($"Argument {nameof(simbolo)} with value ${simbolo} has not impld class"); 
            }
        }

        public class ModoJuegoSiempreAceptaFactory : IFactory<string, string, Carta>
        {
            public ModoJuegoSiempreAceptaFactory()
            {
            }

            public Carta Create(string simbolo, string color)
            {
                return new AceptaTodosColores(simbolo, color);
            }
        }
    }

    public class CambioColor : Carta
    {
        public CambioColor(string simbolo, string color) : base(simbolo, color)
        {
        }

        public override bool PuedoTirar(Carta cartaActual)
        {
            return (cartaActual.Simbolo.Equals("+4") || cartaActual.Simbolo.Equals("C"));
        }
    }

    public class MasDos : Carta
    {
        public MasDos(string simbolo, string color) : base(simbolo, color)
        {
        }

        public override bool PuedoTirar(Carta cartaActual)
        {
            return (cartaActual.Simbolo.Equals("+4") || Simbolo.Equals(cartaActual.Simbolo));
        }
    }

    public class MasCuatro : Carta
    {
        public MasCuatro(string simbolo, string color) : base(simbolo, color)
        {
        }

        public override bool PuedoTirar(Carta cartaActual)
        {
            return cartaActual.Simbolo.Equals("+4");
        }
    }

    public class Normal : Carta
    {
        public Normal(string simbolo, string color) : base(simbolo, color)
        {
        }

        public override bool PuedoTirar(Carta cartaActual)
        {
            return ( (cartaActual.Simbolo.Equals("+4") || cartaActual.Color.Equals("E") || (Color.Equals(cartaActual.Color) || Simbolo.Equals(cartaActual.Simbolo))) );
        }
    }

    public class CambiaSentido : Carta
    {
        public CambiaSentido(string simbolo, string color) : base(simbolo, color)
        {
        }

        public override bool PuedoTirar(Carta cartaActual)
        {
            return (cartaActual.Simbolo.Equals("+4") || cartaActual.Color.Equals("E") || Simbolo.Equals(cartaActual.Simbolo));
        }
    }

    public class AceptaTodosColores : Carta
    {
        public AceptaTodosColores(string simbolo, string color) : base(simbolo, color)
        {
        }

        public override bool PuedoTirar(Carta cartaActual)
        {
            return true;
        }
    }
}
