using UnityEngine;
using System.Collections;

public class DamageFlash : MonoBehaviour
{
    [SerializeField] private float flashDuration = 0.1f;
    [SerializeField] private Color flashColor = Color.white;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private Color _originalColor;

    //Ensure we have a SpriteRenderer and get it.
    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();

        if (_spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer not found on this object!");
            enabled = false; // Disable script if no SpriteRenderer is present
            return;
        }

        _originalColor = _spriteRenderer.color; //Store Original color
    }


    //Call this method to inflict Damage Effect.
    public void Flash()
    {
        StartCoroutine(FlashRoutine()); // Start the coroutine for the flash effect
    }

    private IEnumerator FlashRoutine()
    {
        //1. Set sprite to white color
        _spriteRenderer.color = flashColor;

        //2. Wait for the specified flash duration
        yield return new WaitForSeconds(flashDuration);

        //3. Restore the original color.
        _spriteRenderer.color = _originalColor;

        //Coroutine is done, and exits automatically.
    }
}