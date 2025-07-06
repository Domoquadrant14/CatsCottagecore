using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectClickerManager : MonoBehaviour
{
    [SerializeField]
    GameObject textBox;

    int remainingAnimalsCount;

    [SerializeField]
    string animalTag;

    public List<GameObject> activeAnimals;

    private void Awake()
    {
        activeAnimals = new List<GameObject>();
    }

    public void AnimalClicked(GameObject animal)
    {
        if(animal.gameObject.CompareTag(animalTag))
        {
           // animal.gameObject.SetActive(false);
            activeAnimals.Remove(animal);
            textBox.GetComponent<RemainingAnimalCount>().UpdateText();
           // text.text = "Animals Remaining: " + remainingAnimalsCount;

        }
       
    }

   
}
