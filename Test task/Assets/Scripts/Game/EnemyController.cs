using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GeneralData data;
    private Movement movementScript;
    private GameObject playerTransform;

    private void OnEnable()
    {
        playerTransform = GameObject.Find("Player");
        movementScript = GetComponent<Movement>();
        movementScript.Speed = data.EnemySpeed
            + (data.CoefficientSpeed * GameObject.Find("Scene Controller").GetComponent<TimeScoreController>().timer);
        GetComponent<SpriteRenderer>().sprite = data.EnemySprite;
    }

    private void Update()
    {
        movementScript.SetNewMovePosition(playerTransform.transform.position);
    }
}
