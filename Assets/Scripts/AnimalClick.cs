using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalClick : MonoBehaviour
{
    
    GameObject gameManager;
    GameObject remainingAnimalCountTextbox;
   
    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        remainingAnimalCountTextbox = GameObject.Find("RemainingAnimalCount");

        gameManager.GetComponent<ObjectClickerManager>().activeAnimals.Add(this.gameObject);
        Debug.Log("Animal added");
        remainingAnimalCountTextbox.GetComponent<RemainingAnimalCount>().UpdateText();
        
    }
    private void OnMouseDown()
    {
        gameManager.GetComponent<ObjectClickerManager>().AnimalClicked(this.gameObject);
    }
}
