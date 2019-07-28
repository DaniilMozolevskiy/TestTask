using System.Collections.Generic;
using UnityEngine;

public class SaveLoadRecords : MonoBehaviour
{
    public RecordsList recordsList;

    public void AddRecord(int _score, string _name)
    {
        LoadRecords();
        if (recordsList == null)
        {
            recordsList = new RecordsList();
            recordsList.records = new List<Record>();
        }
        recordsList.records.Add(new Record(_score,_name));
        SaveRecords();
    }

    public List<Record> GetRecords()
    {
        LoadRecords();
        return recordsList.records;
    }

    private void SaveRecords()
    {
        string _jsonString = JsonUtility.ToJson(recordsList);
        PlayerPrefs.SetString("RecordsSaveString", _jsonString);
    }

    public void LoadRecords()
    {
        recordsList = JsonUtility.FromJson<RecordsList>(PlayerPrefs.GetString("RecordsSaveString"));
    }
}

[System.Serializable]
public class RecordsList
{
    public List<Record> records;
}

[System.Serializable]
public class Record
{
    public int score;
    public string name;

    public Record(int _score, string _name)
    {
        score = _score;
        name = _name;
    }
}
