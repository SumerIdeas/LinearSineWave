using System;

namespace LinearSineWave.Data;

public interface ILswDatabase
{
    void ConnectDatabase();
    Exception GetLastException();
    void RefreshCollections();
}