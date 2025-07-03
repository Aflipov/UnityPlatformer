using UnityEngine;

public class ResetScore : MonoBehaviour
{
    [SerializeField] private BestScore bestScoreButton;

    public void OnScoreResetClick()
    {
        SaveManager.ResetScore();

        bestScoreButton.DrawScore();
    }
}
