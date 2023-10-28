using System.Collections;
using UnityEngine;

public class FadeInSprites : MonoBehaviour
{
    public SpriteRenderer outlineSprite;  // Объект с контуром
    public SpriteRenderer colorSprite;    // Объект с цветом
    public float duration = 1.0f;     // Длительность анимации в секундах

    void Start()
    {
        // Начальная прозрачность
        SetAlpha(outlineSprite, 0.0f);
        SetAlpha(colorSprite, 0.0f);

        // Запуск корутины для анимации
        StartCoroutine(FadeIn());
    }

    // Установка прозрачности для GameObject с SpriteRenderer
    void SetAlpha(SpriteRenderer sr, float alpha)
    {
        Color c = sr.color;
        c.a = alpha;
        sr.color = c;
    }

    // Корутина для плавного появления
    IEnumerator FadeIn()
    {
        float startTime = Time.time;

        while (Time.time < startTime + duration)
        {
            float t = (Time.time - startTime) / duration;

            SetAlpha(outlineSprite, t);
            yield return null;
        }

        SetAlpha(outlineSprite, 1.0f);

        startTime = Time.time;

        while (Time.time < startTime + duration)
        {
            float t = (Time.time - startTime) / duration;

            SetAlpha(colorSprite, t);
            yield return null;
        }

        SetAlpha(colorSprite, 1.0f);
    }
}