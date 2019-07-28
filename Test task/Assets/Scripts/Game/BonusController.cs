using UnityEngine;

public class BonusController : MonoBehaviour
{
    [SerializeField] private GeneralData data;

    public void GetBonus(GameObject _bonusObject)
    {
        switch (_bonusObject.name)
        {
            case "SpeedBonus":
                {
                    GetComponent<Movement>().Speed = data.PlayerSpeed * 2;
                    Invoke("OldSpeed", data.TimeBonus);
                    break;
                }
            case "ScoreBonus":
                {
                    GameObject.Find("Scene Controller").GetComponent<TimeScoreController>().scoreGenerateCount = data.ScoreGenerateCount * 10;
                    Invoke("OldCountScore", data.TimeBonus);
                    break;
                }
            case "ArmorBonus":
                {
                    GetComponent<PlayerController>().isArmorBonus = true;
                    Invoke("OldArmor", data.TimeBonus);
                    break;
                }
        }
        Destroy(_bonusObject);
    }

    private void OldSpeed()
    {
        GetComponent<Movement>().Speed = data.PlayerSpeed;
    }

    private void OldCountScore()
    {
        GameObject.Find("Scene Controller").GetComponent<TimeScoreController>().scoreGenerateCount = data.ScoreGenerateCount;
    }

    private void OldArmor()
    {
        GetComponent<PlayerController>().isArmorBonus = false;
    }
}
