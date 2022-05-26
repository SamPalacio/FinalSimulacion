using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    private void Update()
    {
        float distance = Mathf.Sqrt(Mathf.Pow((Spaceship.spaceShipTransform.position.x - this.transform.position.x), 2) + Mathf.Pow((Spaceship.spaceShipTransform.position.z - this.transform.position.z), 2));
        Debug.Log(distance);
        if (distance <= 8f){
            Spaceship.spaceShipTransform.GetComponent<TweenMovement>().StopSpaceShip();
            this.enabled = false;
        }
       
    }

}
