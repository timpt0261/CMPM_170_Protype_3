using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class Timer : MonoBehaviour
{
    public float timeRemaining = 100f;
    [Range(1, 10)]
    [SerializeField] private int multiplier = 1;
    [SerializeField] Image timeIcon;

    private Color initialImageColor = new Color(0.9529412f, 1f, 0.003921569f);

    void Start()
    {

        timeIcon.color = initialImageColor;
        timeIcon.fillAmount = 1;
    }
 

    void FixedUpdate()
    {

        UpdateTime();
    }

    private void UpdateTime()
    {
        if (timeRemaining <= 0)
        {
            Debug.Log("GameOver");
            SceneManager.LoadScene(1);
        }

        timeRemaining -= Time.deltaTime * multiplier;

        float normalizedTime = timeRemaining / 100f;

        // Invert the normalized health to get a more noticeable color transition
        float invertedNormalizedTime = 1f - normalizedTime;

        // Create a new color with the same RGB values as initialImageColor but with alpha set to 1
        Color targetColor = new Color(initialImageColor.r, initialImageColor.g, initialImageColor.b, 1f);

        timeIcon.color = Color.Lerp(targetColor, Color.red, invertedNormalizedTime);
        timeIcon.fillAmount = normalizedTime;
    }


}
