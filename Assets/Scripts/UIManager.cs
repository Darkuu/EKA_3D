using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image healthGlobe, manaGlobe;

    [SerializeField] private Slider xpSlider;

    [SerializeField] private PlayerHealth health;

    [SerializeField] private TMP_Text levelText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateLevelText(int level)
    {
        levelText.text = level.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        healthGlobe.fillAmount = Mathf.Lerp(health.GetHealthRatio(), healthGlobe.fillAmount, 2 * Time.deltaTime);
    }

    public void UpdateXpSlider(float xpRatio)
    {
        xpSlider.value = xpRatio;
    }
}
