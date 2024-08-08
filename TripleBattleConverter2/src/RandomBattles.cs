using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleBattleConverter2.src
{
    internal class RandomBattles : BattleType
    {
        private BattleType currentType;
        private Random rng;

        public RandomBattles() {
            battleByte = 0x00;
            currentType = new SingleBattles();
            rng = new Random();
        }

        public override byte getBattleByte()
        {
            // getBattleByte is called first, so we'll randomize our battle type here.
            switch (rng.Next(0,4))
            {
                case 0:
                    currentType = new SingleBattles();
                    break;
                case 1:
                    currentType = new DoubleBattles();
                    break;
                case 2:
                    currentType = new TripleBattles();
                    break;
                case 3:
                    currentType = new RotationBattles();
                    break;
                default:
                    break;
            }
            return currentType.getBattleByte();
        }

        public override byte convertTrainerAI(byte currAI)
        {
            return currentType.convertTrainerAI(currAI);
        }
    }
}
