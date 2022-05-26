using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public static Transform spaceShipTransform;
    void Awake()
    {
        spaceShipTransform=this.transform;  
    }

   
}
