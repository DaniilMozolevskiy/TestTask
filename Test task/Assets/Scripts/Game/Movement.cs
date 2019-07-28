using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed;

    private Vector3 moveToThisPosition;
    private bool onPlace = true;

    private void Update()
    {
        if (!onPlace)
        {
            if (CheckOnPlace())
                onPlace = true;
            else
            {
                transform.Translate(Speed * Time.deltaTime, 0, 0);
            }
        }
    }

    public void SetNewMovePosition(Vector3 newPosition)
    {
        Vector3 difference = newPosition - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        
        moveToThisPosition = newPosition;
        onPlace = false;
    }

    private bool CheckOnPlace()
    {
        if (Mathf.Abs(transform.position.x - moveToThisPosition.x) < 0.1 && Mathf.Abs(transform.position.y - moveToThisPosition.y) < 0.1)
            return true;
        return false;
    }
}
