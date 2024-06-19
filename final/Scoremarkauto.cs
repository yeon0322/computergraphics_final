using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoremarkauto : MonoBehaviour
{
    public float destroyDelay = 1.0f; //사라질 지연 시간 
    void Start()
    {
        Destroy(gameObject,destroyDelay);
    }

   
}
