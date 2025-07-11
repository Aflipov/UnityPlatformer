using UnityEngine;

public static class Initializer
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]

    public static void Execute()
    {
        Debug.Log("Loaded by the Presist Objects from the Initializer script");
        Object.DontDestroyOnLoad(Object.Instantiate(Resources.Load("PRESISTOBJECTS")));
    }
}