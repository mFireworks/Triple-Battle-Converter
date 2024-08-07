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
        protected byte battleOffset;
        protected byte AIOffset;

        public byte getBattleOffset() { return battleOffset; }
        public byte getAIOffset() {  return AIOffset; }

        // Name of the game
        public abstract string getGameName();
        // Total file size expected within this game's trdata folder (minus 000.bin due to it being unreliable)
        public abstract int getExpectedSize();
        // Number of files expected within this game's trdata folder
        public abstract int getExpectedCount();
        public void omitTrainers(string[] files)
        {
            foreach (int omit in omitList)
                files[omit] = "";
        }
    }
}
