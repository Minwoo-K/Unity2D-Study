using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        foreach ( PinCircleDatum datum in levelData)
        {
            data.Add(datum.level, datum);
        }

        return data;
    }
}

public interface ILoader<Key, Value>
{
    Dictionary<Key, Value> LoadData();
}

public class DataManager : MonoBehaviour
{
    private static DataManager _data;

    public static DataManager Data => _data;

    #region Game Data Collection
    private Dictionary<int, PinCircleDatum> PinCircleLevelData = new Dictionary<int, PinCircleDatum>();

    #endregion

    public Dictionary<int, PinCircleDatum> PinCircle { get { SetUpPinCircle(); return PinCircleLevelData; } }

    public T LoadJson<T, Key, Value>(string path) where T: ILoader<Key, Value>
    {
        TextAsset textAsset = Resources.Load<TextAsset>($"Data/{path}");
        T data = JsonUtility.FromJson<T>(textAsset.text);

        return data;
    }

    private void SetUpPinCircle()
    {
        if ( PinCircleLevelData.Count != 0 ) return;
        
        PinCircleLevelData = LoadJson<PinCircleData, int, PinCircleDatum>("PinCircleLevelData").LoadData();
    }

    public void Clear()
    {

    }
}
