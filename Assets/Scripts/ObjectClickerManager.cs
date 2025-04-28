using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClickerManager : MonoBehaviour
{
    private void OnMouseDown()
    {
       this.gameObject.SetActive(false);
    }
}
