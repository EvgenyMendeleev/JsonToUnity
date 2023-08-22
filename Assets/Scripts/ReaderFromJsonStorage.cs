using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaderFromJsonStorage : MonoBehaviour
{
    private IFactoryDataStorage _factoryDataStorage;

    void Start()
    {
        _factoryDataStorage = new JsonStorage();
        _factoryDataStorage.ConnectToStorage();
        FactoryDataPacket data = _factoryDataStorage.GetFactoryData();

        Debug.Log(data.ToString());
    }
}
