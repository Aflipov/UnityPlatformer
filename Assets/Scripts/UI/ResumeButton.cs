using UnityEngine;

public class ResumeButton : MonoBehaviour
{
    public void Resume()
    {
        PauseManager.instance.PauseGame();
    }
}
