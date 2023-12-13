using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float currentHealth = 100f;
    [Range(1, 10)]
    [SerializeField] private int multiplier = 1;
    [SerializeField] Image panelImage;
    [SerializeField] Image fillImage;

    private Color initialImageColor = new Color(0.9529412f, 1f, 0.003921569f);

    void Start()
    {
        // Set the initial alpha of the panelImage to 0
        Color panelColor = panelImage.color;
        panelColor.a = 0f;
        panelImage.color = panelColor;

        fillImage.color = initialImageColor;
        fillImage.fillAmount = 1;
    }


    void FixedUpdate()
    {
       
        UpdateHealth();
    }

    public void addHealth(float health) {
        currentHealth = Mathf.Clamp(currentHealth + health, 0, 100);
    }

    public void lose() {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
            Debug.Log("GameOver");
            SceneManager.LoadScene(1);
    }

    private void UpdateHealth()
    {
        if (currentHealth <= 0)
        {
            lose();
        }

        currentHealth -= Time.deltaTime * multiplier;

        float normalizedHealth = currentHealth / 100f;

        // Invert the normalized health to get a more noticeable color transition
        float invertedNormalizedHealth = 1f - normalizedHealth;

        // Update the alpha value of panelImage.color
        Color panelColor = panelImage.color;
        panelColor.a = Mathf.Lerp(0f, 1f, invertedNormalizedHealth);
        panelImage.color = panelColor;

        // Create a new color with the same RGB values as initialImageColor but with alpha set to 1
        Color targetColor = new Color(initialImageColor.r, initialImageColor.g, initialImageColor.b, 1f);

        fillImage.color = Color.Lerp(targetColor, Color.red, invertedNormalizedHealth);
        fillImage.fillAmount = normalizedHealth;
    }
}
