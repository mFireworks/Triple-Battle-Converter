using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleBattleConverter2.src
{
    internal class TripleBattles : BattleType
    {
        public TripleBattles() {
            battleByte = 0x02;
        }

        public override byte convertTrainerAI(byte currAI)
        {
            return (byte)(currAI | 0x80);
        }
    }
}
