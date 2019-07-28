using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GeneralData data;
    [SerializeField] private BonusController bonusControllerScript;
    [HideInInspector] public bool isArmorBonus = false;

    private void Start()
    {
        GetComponent<Movement>().Speed = data.PlayerSpeed;
        GetComponent<SpriteRenderer>().sprite = data.PlayerSprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            CollisionEnemy(collision);
        if (collision.gameObject.tag == "Bonus")
            bonusControllerScript.GetBonus(collision.gameObject);
    }

    private void CollisionEnemy(Collider2D collision)
    {
        if (isArmorBonus)
        {
            GameObject.Find("Scene Controller").GetComponent<SpawnController>().SetObjectInDisable(collision.gameObject);
        }
        else
        {
            SceneManager.LoadScene(2);
        }
    }
}
