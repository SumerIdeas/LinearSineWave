using System;
using System.IO;

namespace LinearSineWave.Data;

public class AudioFileHandler
{
    public AudioFileHandler()
    {
        
    }


    public void ReadFilesAndFolders()
    {
        string path = "/home/dcrump/Documents/Shares/Music";
            
        DirectoryInfo dir = new(path);

        foreach (DirectoryInfo direct in dir.GetDirectories())
        {
            Console.WriteLine(direct.FullName);
        }
            
        foreach (FileInfo file in dir.GetFiles())
        {
            Console.WriteLine(file.FullName);
        }
    }
}