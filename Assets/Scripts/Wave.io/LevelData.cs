using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class WaveioDatum
    {
        public int level;
        public float playerXRange;
        public float playerYSpeed;
    }

    [Serializable]
    public class WaveioData : ILoader<int, WaveioDatum>
    {
        public List<WaveioDatum> levelData = new List<WaveioDatum>();

        public Dictionary<int, WaveioDatum> LoadData()
        {
            Dictionary<int, WaveioDatum> data = new Dictionary<int, WaveioDatum>();

            foreach (WaveioDatum datum in levelData)
            {
                data.Add(datum.level, datum);
            }

            return data;
        }
    }
}
