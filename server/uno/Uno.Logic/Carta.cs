using System;
using System.Collections.Generic;
using System.Text;

namespace Uno.Logic
{
    public class Carta
    {
        private string simbolo;
        private string color;

        public Carta(string simbolo, string color)
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
    }
}
