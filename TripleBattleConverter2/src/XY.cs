using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleBattleConverter2.src
{
    internal class XY : GameType
    {
        public XY()
        {
            omitList = [ 0, 137, 138, 139, 188, 435, 436, 437, 596, 597, 598 ];    // omit trainers similar to PokeRandoZX
            battleOffset = 0x02;
            AIOffset = 0x0C;
        }

        public override string getGameName()
        {
            return "X/Y";
        }

        public override int getExpectedCount()
        {
            return 785;
        }

        public override int getExpectedSize()
        {
            return 15680;
        }
    }
}
