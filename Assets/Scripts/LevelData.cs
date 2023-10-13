using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    #region PinCircle
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
    #endregion

    #region Waveio
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
    #endregion

    #region ZigZag
    [Serializable]
    public class ZigZagDatum
    {
        public int level;
        public float playerSpeed;
    }

    [Serializable]
    public class ZigZagData :ILoader<int, ZigZagDatum>
    {
        public List<ZigZagDatum> levelData = new List<ZigZagDatum>();

        public Dictionary<int, ZigZagDatum> LoadData()
        {
            Dictionary<int, ZigZagDatum> data = new Dictionary<int, ZigZagDatum>();

            foreach (ZigZagDatum datum in levelData)
            {
                data.Add(datum.level, datum);
            }

            return data;
        }
    }
    #endregion
}
