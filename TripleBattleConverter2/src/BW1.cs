using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleBattleConverter2.src
{
    internal class BW1 : GameType
    {
        public BW1()
        {
            omitList = [ 0, 53, 54, 55, 59, 60, 61, 64 ]; // omit empty trainer, first rival fights, and first N fight. Same as universial randomizer
            battleOffset = 0x02;
            AIOffset = 0x0C;
        }

        public override string getGameName()
        {
            return "Black/White";
        }

        public override int getExpectedCount()
        {
            return 616;
        }

        public override int getExpectedSize()
        {
            return 12300;
        }
    }
}
