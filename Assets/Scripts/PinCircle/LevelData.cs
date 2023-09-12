using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class PinCircleDatum
    {
        public int level;
        public int targetSpeed;
        public int numberOfThrowablePins;
        public int numberOfStuckPins;
    }

    [Serializable]
    public class PinCircleData : ILoader<int, PinCircleDatum>
    {
        public List<PinCircleDatum> levelData = new List<PinCircleDatum>();

        public Dictionary<int, PinCircleDatum> LoadData()
        {
            Dictionary<int, PinCircleDatum> data = new Dictionary<int, PinCircleDatum>();

            foreach (PinCircleDatum datum in levelData)
            {
                data.Add(datum.level, datum);
            }

            return data;
        }
    }
}
