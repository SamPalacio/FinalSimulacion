using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    [SerializeField] Vector3 velocity;
    Vector3 acceleration, displacement;
    [SerializeField] Transform referencia;

    void Update()
    {
        acceleration = referencia.position - transform.position;
        velocity = velocity + acceleration * Time.deltaTime;
        displacement = velocity * Time.deltaTime;
        transform.position = transform.position + new Vector3(displacement.x, 0, displacement.z);
    }
}
