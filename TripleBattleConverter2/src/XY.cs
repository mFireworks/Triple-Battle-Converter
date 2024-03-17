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

        public override ErrorType verifyFiles(int count, long? size)
        {
            if (size == null || size != 15696)
            {
                return ErrorType.IncorrectFileSize;
            }
            if (count != 785)
            {
                return ErrorType.IncorrectFileCount;
            }
            return ErrorType.None;
        }
    }
}
