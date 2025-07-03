using UnityEngine;

public class StartButton : MonoBehaviour
{
    public void StartGame()
    {
        SceneSwapManager.SwapScene("Game");
    }
}
