
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{


public void Restart()
    {
        SceneManager.LoadScene(1);

    }
    public void Exit()
    {
        SceneManager.LoadScene(0);

    }
}