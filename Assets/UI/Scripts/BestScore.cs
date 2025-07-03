using System.Threading;
using TMPro;
using UnityEngine;

public class BestScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake()
    {
        DrawScore();
    }

    public void DrawScore()
    {
        float timer = SaveManager.LoadScore();
        int seconds = Mathf.FloorToInt(timer);
        int milliseconds = Mathf.FloorToInt((timer - seconds) * 1000);

        scoreText.text = string.Format("{0:00}:{1:00}", seconds, milliseconds);
    }
}
