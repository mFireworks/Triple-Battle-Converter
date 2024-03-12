using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleBattleConverter2.src
{
    internal abstract class BattleType
    {
        protected byte battleByte;

        public byte getBattleByte()
        { 
            return battleByte;
        }
        public abstract byte convertTrainerAI(byte currAI);
    }
}
