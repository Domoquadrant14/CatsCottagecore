using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemainingAnimalCount : MonoBehaviour
{

    TMPro.TMP_Text text;
    public int remainingAnimalsCount;
    [SerializeField]
    GameObject gameManager;

    private void Start()
    {
        text = this.GetComponent<TMPro.TMP_Text>();
        int count = gameManager.GetComponent<ObjectClickerManager>().activeAnimals.Count;
        text.text = "Animals Remaining: " + count;
    }

    public void UpdateText()
    {
        text.text = "Animals Remaining: " + gameManager.GetComponent<ObjectClickerManager>().activeAnimals.Count;
    }


}
