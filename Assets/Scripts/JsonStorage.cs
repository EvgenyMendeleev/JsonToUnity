using System;
using System.Diagnostics;
using System.IO;
using UnityEngine;

[Serializable]
public class FactoryDataPacket
{
    public float isCompressorEnabled;
    public float saltpeterValvePercent;
    public float celsiusTemperature;

    public override string ToString()
    {
        return $"isCompressorEnabled = {isCompressorEnabled}, saltpeterValvePercent = {saltpeterValvePercent}, celsiusTemperature = {celsiusTemperature}";
    }
}

public class JsonStorage : IFactoryDataStorage
{
    private FileStream jsonFileStorage = null;

    public bool IsConnected { get { return jsonFileStorage != null; } }

    public void ConnectToStorage()
    {
        try 
        {
            jsonFileStorage = new FileStream("Assets/Storage/DataStorage.json", FileMode.Open);
        }
        catch (Exception exp)
        {
            throw exp;
        }
    }

    public FactoryDataPacket GetFactoryData()
    {
        using (StreamReader reader = new StreamReader(jsonFileStorage))
        {
            FactoryDataPacket data = JsonUtility.FromJson<FactoryDataPacket>(reader.ReadToEnd());
            return data;
        }
    }

    public void CloseConnection()
    {
        jsonFileStorage.Close();
        jsonFileStorage = null;
    }
}