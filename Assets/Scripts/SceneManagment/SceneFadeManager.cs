using UnityEngine;
using UnityEngine.UI;

public class SceneFadeManager : MonoBehaviour
{
	public static SceneFadeManager instance;

	[SerializeField] private Image _fadeOutImage;
	[Range(0.1f, 10f), SerializeField] private float _fadeOutSpeed;
	[Range(0.1f, 10f), SerializeField] private float _fadeInSpeed;

	[SerializeField] private Color _fadeOutStartColor;

	public bool IsFadingOut { get; private set; }
	public bool IsFadingIn { get; private set; }

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}

		_fadeOutStartColor.a = 0f;
	}

	private void Update()
	{
		if (IsFadingOut)
		{
			if (_fadeOutImage.color.a < 1f)
			{
				_fadeOutStartColor.a += Time.deltaTime * _fadeOutSpeed;
				_fadeOutImage.color = _fadeOutStartColor;
			}
			else
			{
				IsFadingOut = false;
			}
		}
		else
		{

			if (_fadeOutImage.color.a > 0f)
			{
				_fadeOutStartColor.a -= Time.deltaTime * _fadeInSpeed;
				_fadeOutImage.color = _fadeOutStartColor;
			}
			else
			{
				IsFadingIn = false;
			}
		}
	}

	public void StartFadeOut()
    {
        Debug.Log("Начали выцветать");
        _fadeOutImage.color = _fadeOutStartColor;
		IsFadingOut = true;
	}

	public void StartFadeIn()
	{
		if (_fadeOutImage.color.a >= 1f)
		{
			_fadeOutImage.color = _fadeOutStartColor;
			IsFadingIn = true;
		}
	}
}
