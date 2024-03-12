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
            positionOffset = 0x02;
        }

        public override ErrorType verifyFiles(int count, long? size)
        {
            if (size == null || size != 12316)
            {
                return ErrorType.IncorrectFileSize;
            }
            if (count != 616)
            {
                return ErrorType.IncorrectFileCount;
            }
            return ErrorType.None;
        }
    }
}
