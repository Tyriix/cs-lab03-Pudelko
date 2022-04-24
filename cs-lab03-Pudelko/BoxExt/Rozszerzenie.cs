using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cs_lab03_Pudelko;

namespace Rozszerzenie
{
    public static class Rozszerzenie
    {
        public static Pudelko Kompresuj(this Pudelko pudelko)
        {
            double cubedLength = Math.Pow(pudelko.Objetosc, (1d/3));
            return new Pudelko(cubedLength, cubedLength, cubedLength);
        }
    }
}
