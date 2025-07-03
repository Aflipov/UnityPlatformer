using UnityEngine;

public class ToTitle : MonoBehaviour
{
    public void ExitToTitle()
    {
        PauseManager.instance.PauseGame();

        SceneSwapManager.SwapScene("MainMenu");
    }
}
