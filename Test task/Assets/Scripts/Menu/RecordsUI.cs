using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RecordsUI : MonoBehaviour
{
    [SerializeField] private GameObject content;
    [SerializeField] private GameObject prefabPanel;
    [SerializeField] private float panelOffset;

    private void OnEnable()
    {
        List<Record> _records = GetComponent<SaveLoadRecords>().GetRecords();
        _records = _records.OrderByDescending(item => item.score).ToList();
        DeletAllChild();

        content.GetComponent<RectTransform>().sizeDelta = 
            new Vector2(0, (_records.Count * prefabPanel.GetComponent<RectTransform>().rect.height + panelOffset * _records.Count));

        for (int i = 0; i < _records.Count; i++)
        {
            GameObject newPanel = Instantiate(prefabPanel, content.transform);
            newPanel.transform.localPosition = new Vector3(prefabPanel.GetComponent<RectTransform>().rect.width/2, -(60 + i*110));
            newPanel.transform.Find("Text (Name)").GetComponent<Text>().text = _records[i].name;
            newPanel.transform.Find("Text (Position in rating)").GetComponent<Text>().text = (i + 1).ToString();
        }
    }

    private void DeletAllChild()
    {
        int _childCount = content.transform.childCount;
        List<GameObject> childs = new List<GameObject>();
        for (int i = 0; i < _childCount; i++)
            childs.Add(content.transform.GetChild(i).gameObject);
        for (int i = 0; i < _childCount; i++)
            Destroy(childs[i]);
    }
}
