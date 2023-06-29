using UnityEngine;
using TMPro;

public class FadeOutText : MonoBehaviour
{
    private TMP_Text textMesh;
    private float fadeDuration = 1f;
    private float initialDisplayDuration = 2f;
    private float fadeTimer;
    public GameObject leftFinger;
    public GameObject rightFinger;
    private SpriteRenderer spriteRenderer1;
    private SpriteRenderer spriteRenderer2;
    private Color originalColor;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        spriteRenderer1 = leftFinger.GetComponent<SpriteRenderer>();
        spriteRenderer2 = rightFinger.GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer1.color;
        fadeTimer = initialDisplayDuration + fadeDuration;
    }

    private void Update()
    {
        fadeTimer -= Time.deltaTime;
        if (fadeTimer < initialDisplayDuration)
        {
            fadeTimer -= Time.deltaTime;
            float alpha = fadeTimer / fadeDuration;
            textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, alpha);
            spriteRenderer1.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            spriteRenderer2.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
        }

        if (fadeTimer <= 0)
        {
            Destroy(gameObject);
            Destroy(leftFinger);
            Destroy(rightFinger);
        }
    }
}