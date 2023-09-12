using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// An Interface for DATA classes
// All DATA class should inherit from this interface
public interface ILoader<Key, Value>
{
    Dictionary<Key, Value> LoadData();
}

public class DataManager : MonoBehaviour
{
    // Singleton
    private static DataManager _data;
    public static DataManager Data { get { SetUp(); return _data; } }

    // A method to deliver JSON data
    public T LoadJson<T, Key, Value>(string path) where T: ILoader<Key, Value>
    {
        TextAsset textAsset = Resources.Load<TextAsset>($"Data/{path}");
        T data = JsonUtility.FromJson<T>(textAsset.text);

        return data;
    }

    // Set up the Singleton
    public static void SetUp()
    {
        if ( _data == null )
        {
            GameObject dm = GameObject.Find("#DataManager");
            if (dm == null)
            {
                dm = new GameObject() { name = "#DataManager" };
                dm.AddComponent<DataManager>();
            }

            _data = dm.GetComponent<DataManager>();
        }
    }

    // To clear any data that have been loaded
    public void Clear()
    {
        PinCircleLevelData.Clear();
    }

    #region PinCircle
    // The Data Table for PinCircle game
    private Dictionary<int, Data.PinCircleDatum> PinCircleLevelData = new Dictionary<int, Data.PinCircleDatum>();
    // Property for PinCirclelevelData
    public Dictionary<int, Data.PinCircleDatum> PinCircle { get { SetUpPinCircle(); return PinCircleLevelData; } }

    // When using PinCircle Data, the given method must be used to load data
    private void SetUpPinCircle()
    {
        if (PinCircleLevelData.Count != 0) return;

        PinCircleLevelData = LoadJson<Data.PinCircleData, int, Data.PinCircleDatum>("PinCircleLevelData").LoadData();
    }
    #endregion

}
