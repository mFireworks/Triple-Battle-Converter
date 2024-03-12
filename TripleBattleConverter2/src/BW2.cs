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
            positionOffset = 0x02;
        }

        public override ErrorType verifyFiles(int count, long? size)
        {
            if (size == null || size != 16276)
            {
                return ErrorType.IncorrectFileSize;
            }
            if (count != 814)
            {
                return ErrorType.IncorrectFileCount;
            }
            return ErrorType.None;
        }
    }
}
