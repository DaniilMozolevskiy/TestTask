using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void EventStartGame()
    {
        SceneManager.LoadScene(1);
    }
}
