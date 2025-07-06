using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    [SerializeField]
    Sprite[] animalSprites;

    private Sprite newSprite;

    private Sprite currentSprite;
    private int currentSpritePos;

    private void Awake()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = animalSprites[0];
    }
    private void OnMouseDown()
    {
        //gets postion of current sprite in sprite sequence
        for(int i = 0; i < animalSprites.Length; i++)
        {
            if(animalSprites[i] == currentSprite)
            {
                currentSpritePos = i;
            }
        }

        //sets sprite to next sprite in sequence
        if(currentSpritePos < animalSprites.Length-1)
        {
            newSprite = animalSprites[currentSpritePos + 1];
        }

        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
       
    }
}
