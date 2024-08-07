using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleBattleConverter2.src
{
    internal class BW2 : GameType
    {
        public BW2()
        {
            omitList = [ 0, 161, 162, 163, 342, 347, 356, 360, 361, 362, 363, 364, 365, 374, 375, 376, 377, 797, 798, 799 ];    // omit empty trainer, first rival battle and required multi-battles
            battleOffset = 0x02;
            AIOffset = 0x0C;
        }

        public override string getGameName()
        {
            return "Black 2/White 2";
        }

        public override int getExpectedCount()
        {
            return 814;
        }

        public override int getExpectedSize()
        {
            return 16260;
        }
    }
}
