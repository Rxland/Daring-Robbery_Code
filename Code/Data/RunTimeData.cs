using System;
using System.Collections.Generic;

namespace _GAME.Code.Data
{
    [Serializable]
    public class RunTimeData
    {
        public int InGameDollarusAmount;
        public int InGameGoldAmount;
        public List<TreasureData> TreasureDataList = new List<TreasureData>();  
    }
}