using Unity.Mathematics;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public static void SaveScore(float score)
    {
        if (LoadScore() == 0.0f)
        {
            PlayerPrefs.SetFloat("Score", score);
            PlayerPrefs.Save();
        }
        else
        {
            PlayerPrefs.SetFloat("Score", Mathf.Min(LoadScore(), score));
            PlayerPrefs.Save();
        }

    }

    public static float LoadScore()
    {
        return PlayerPrefs.GetFloat("Score");
    }

    public static void ResetScore()
    {
        PlayerPrefs.DeleteAll();
    }
}
