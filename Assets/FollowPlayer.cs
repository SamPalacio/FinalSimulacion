using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private void Update()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(Spaceship.spaceShipTransform.position.x, this.transform.position.y, Spaceship.spaceShipTransform.position.z), 0.04f);
    }

}
