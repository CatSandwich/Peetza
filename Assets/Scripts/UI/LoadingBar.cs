using UnityEngine;

/// <summary>
/// Draws a loading bar whose progress corresponds to Value.
/// </summary>
public class LoadingBar : MonoBehaviour
{
    public Color Color;

    public float Value
    {
        get => _value;
        set
        {
            var t = Renderer.transform;
            t.localScale = new Vector2(_value = value, 1f);
            t.localPosition = (1f - t.localScale.x) / 2f * Vector2.left;
        }
    }

    private float _value = 0f;

    [Tooltip("The SpriteRenderer for the placeholder (disabled on start).")]
    public SpriteRenderer EditorBar;
    [Tooltip("The SpriteRenderer for the actual loading bar.")]
    public SpriteRenderer Renderer;

    private void Start()
    {
        EditorBar.enabled = false;
        Value = 0f;
    }

    private void OnValidate() => EditorBar.color = Renderer.color = Color;
}
