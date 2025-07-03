using System.Collections;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwapManager : MonoBehaviour
{
	public static SceneSwapManager Instance;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
	}

	private void OnEnable()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
	}
	private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

	public static void SwapScene(string sceneToLoadName)
	{
		Instance.StartCoroutine(Instance.FadeOutAndChangeScene(sceneToLoadName));
	}

	private IEnumerator FadeOutAndChangeScene(string sceneToLoadName)
	{
		Debug.Log("Корутина есть");
		SceneFadeManager.instance.StartFadeOut();

		while (SceneFadeManager.instance.IsFadingOut)
		{
			yield return null;
		}


        Debug.Log("Выцвел");

        SceneManager.LoadScene(sceneToLoadName);
	}

    public static void ExitApp()
    {
        Instance.StartCoroutine(Instance.FadeOutAndExit());
    }

    private IEnumerator FadeOutAndExit()
    {
        SceneFadeManager.instance.StartFadeOut();

        while (SceneFadeManager.instance.IsFadingOut)
        {
            yield return null;
        }

        Application.Quit();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		SceneFadeManager.instance.StartFadeIn();
	}
}