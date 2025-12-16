using UnityEngine;
using UnityEngine.SceneManagement;

public class canvascont : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("Nivel_1");
        //esto luego lo cambiamos x la cinemática
    }

    public void ExitGame()
    {
        Debug.Log("Has salido del juego :)!");
        Application.Quit();
    }
}
