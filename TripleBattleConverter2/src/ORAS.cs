using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleBattleConverter2.src
{
    internal class ORAS : GameType
    {
        public ORAS()
        {
            omitList = [ 0, 1, 2, 3, 4, 5, 6, 668, 669, 670, 671, 672, 673 ]; // Initial Fights & Horde Battles. Need to do Multi-Battles too
            battleOffset = 0x06;
            AIOffset = 0x10;
        }

        public override string getGameName()
        {
            return "ORAS";
        }

        public override int getExpectedSize()
        {
            return 22776;
        }

        public override int getExpectedCount()
        {
            return 950;
        }
    }
}
