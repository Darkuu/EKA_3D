using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;


public class FadeTrigger : MonoBehaviour
{
    [SerializeField] private Image fadeImage;
    [SerializeField] private TMP_Text messageText;
    [SerializeField] private float fadeDuration = 1.5f;
    [SerializeField] private string message = "LEVEL COMPLETE";

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered) return;
        if (other.CompareTag("Player"))
        {
            hasTriggered = true;
            StartCoroutine(FadeToBlack());
        }
    }

    private IEnumerator FadeToBlack()
    {
        float elapsed = 0f;
        Color fadeColor = fadeImage.color;
        Color textColor = messageText.color;

        fadeImage.gameObject.SetActive(true);
        messageText.text = message;
        messageText.gameObject.SetActive(true);

        while (elapsed < fadeDuration)
        {
            float alpha = elapsed / fadeDuration;
            fadeImage.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha);
            messageText.color = new Color(textColor.r, textColor.g, textColor.b, alpha);
            elapsed += Time.deltaTime;
            yield return null;
        }

        fadeImage.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, 1f);
        messageText.color = new Color(textColor.r, textColor.g, textColor.b, 1f);
    }
}
