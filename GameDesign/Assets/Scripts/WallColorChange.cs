using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallColorChange : MonoBehaviour
{
    public List<GameObject> walls = new List<GameObject>();
    public float lerpSpeed = 2.0f; // The speed at which the color lerps

    private List<Material> wallMaterials = new List<Material>();
    private Color initialColor; // The initial color for lerping
    private float hue = 0f; // Current hue value (0 to 1)

    private void Start()
    {
        // Initialize the wall materials list
        foreach (GameObject wall in walls)
        {
            Renderer renderer = wall.GetComponent<Renderer>();
            if (renderer != null)
            {
                Material material = renderer.material;
                wallMaterials.Add(material);
            }
        }

        // Initialize the initialColor to the current color
        initialColor = wallMaterials[0].GetColor("_EmissionColor");
    }

    private void Update()
    {
        // Increment the hue value based on time
        hue += Time.deltaTime * lerpSpeed;

        // Wrap the hue value to stay in the range [0, 1]
        if (hue > 1f)
        {
            hue -= 1f;
        }

        // Convert the hue value to a color
        Color lerpedColor = Color.HSVToRGB(hue, 1f, 1f);

        // Update the materials and emission colors
        foreach (Material material in wallMaterials)
        {
            material.SetColor("_EmissionColor", lerpedColor);
            material.color = lerpedColor;
        }
    }
}
