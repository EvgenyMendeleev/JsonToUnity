using System.Collections;
using System.Collections.Generic;

public interface IFactoryDataStorage
{
    void ConnectToStorage();
    FactoryDataPacket GetFactoryData();
    bool IsConnected { get; }
    void CloseConnection();

}
