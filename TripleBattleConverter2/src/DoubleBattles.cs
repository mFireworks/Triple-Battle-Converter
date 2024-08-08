using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleBattleConverter2.src
{
    internal class DoubleBattles : BattleType
    {
        public DoubleBattles() {
            battleByte = 0x01;
        }

        public override byte convertTrainerAI(byte currAI)
        {
            return (byte)(currAI | 0x80);
        }
    }
}
