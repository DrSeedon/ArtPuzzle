using UnityEngine;

public class SpriteFader : MonoBehaviour
{
    public GameObject outlineSprite; // GameObject for the outline sprite
    public GameObject colorSprite;   // GameObject for the colored sprite
    public Material outlineMaterial; // Material for the outline sprite
    public Material colorMaterial;   // Material for the colored sprite
    public Texture maskTexture;      // The mask texture (circular fade)
    public float speed = 0.01f;      // Speed of the fade effect

    private float fadeValue = 0f;

    void Start()
    {
        // Assign the materials to the SpriteRenderers
        outlineSprite.GetComponent<SpriteRenderer>().material = outlineMaterial;
        colorSprite.GetComponent<SpriteRenderer>().material = colorMaterial;

        // Initial setting of the mask
        outlineMaterial.SetTexture("_Mask", maskTexture);
        colorMaterial.SetTexture("_Mask", maskTexture);
    }

    void Update()
    {
        // Update the fade value
        fadeValue += speed * Time.deltaTime;
        fadeValue = Mathf.Clamp(fadeValue, 0f, 1f);

        // Update the materials
        outlineMaterial.SetFloat("_Fade", fadeValue);
        colorMaterial.SetFloat("_Fade", fadeValue);
    }
}