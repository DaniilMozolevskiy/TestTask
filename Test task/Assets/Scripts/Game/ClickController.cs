using UnityEngine;

public class ClickController : MonoBehaviour
{
    [SerializeField] private Movement playerMovementScript;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            playerMovementScript.SetNewMovePosition(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }
}
