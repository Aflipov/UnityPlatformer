using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void ExitGame()
    {
        SceneSwapManager.ExitApp();

        Application.Quit();
    }
}
