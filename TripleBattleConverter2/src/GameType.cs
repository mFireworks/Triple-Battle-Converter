using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleBattleConverter2.src
{
    internal abstract class GameType
    {
        protected int[] omitList = [];
        protected byte positionOffset;

        public byte getPositionOffset() { return positionOffset; }

        public abstract ErrorType verifyFiles(int count, long? size);
        public void omitTrainers(string[] files)
        {
            foreach (int omit in omitList)
                files[omit] = "";
        }
    }
}
