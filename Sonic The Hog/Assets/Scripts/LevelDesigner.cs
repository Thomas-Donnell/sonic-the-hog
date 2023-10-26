using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class LevelDesigner : MonoBehaviour
{
    public Sprite[] sprites;
    public SpriteRenderer finalSpriteRenderer;
    public int spacing = 0;

    private void Start()
    {
        Merge();
    }

    private void Merge()
    {
        Resources.UnloadUnusedAssets();

        // Determine the width and height of the combined texture with spacing
        int combinedWidth = 0;
        int maxHeight = 0;

        foreach (Sprite sprite in sprites)
        {
            combinedWidth += (int)sprite.rect.width + Mathf.Abs(spacing); // Add absolute spacing between sprites
            maxHeight = Mathf.Max(maxHeight, (int)sprite.rect.height);
        }

        // Create a new texture with the updated dimensions
        var newTex = new Texture2D(combinedWidth, maxHeight);

        for (int x = 0; x < combinedWidth; x++)
        {
            for (int y = 0; y < maxHeight; y++)
            {
                newTex.SetPixel(x, y, new Color(1, 1, 1, 0));
            }
        }

        int xOffset = 0;

        foreach (Sprite sprite in sprites)
        {
            Debug.Log("Processing sprite: " + sprite.name + ", Texture: " + sprite.texture.name);
            int spriteWidth = (int)sprite.rect.width + spacing; // Adjust sprite width based on spacing

            for (int x = 0; x < spriteWidth; x++)
            {
                for (int y = 0; y < (int)sprite.rect.height; y++)
                {
                    int xOffsetInSprite = (spacing >= 0) ? x : x - spacing; // Adjust offset for negative spacing
                    int yOffsetInSprite = y;

                    int xPosInCombinedTexture = xOffset + xOffsetInSprite;
                    int yPosInCombinedTexture = yOffsetInSprite;

                    var color = sprite.texture.GetPixel(xOffsetInSprite, yOffsetInSprite);

                    newTex.SetPixel(xPosInCombinedTexture, yPosInCombinedTexture, color);
                }
            }

            xOffset += spriteWidth;
        }

        newTex.Apply();

        var finalSprite = Sprite.Create(newTex, new Rect(0, 0, combinedWidth, maxHeight), new Vector2(0.5f, 0.5f));
        finalSprite.name = "New Sprite";
        finalSpriteRenderer.sprite = finalSprite;
    }

}
