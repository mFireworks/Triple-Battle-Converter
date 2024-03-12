using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleBattleConverter2.src
{
    internal class RotationBattles : BattleType
    {
        public RotationBattles() {
            battleByte = 0x03;
        }

        public override byte convertTrainerAI(byte currAI)
        {
            return (byte)(currAI & 0x7F); // Retain all bits except for the 8th one, force that 0. Binary = 0111 1111
        }
    }
}
