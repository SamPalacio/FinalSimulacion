using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRotation : MonoBehaviour
{
    Transform[] m_transforms;
    [SerializeField] float rotationSpeed1 = 1, rotationSpeed2 = 1;
    void Start()
    {
        m_transforms = transform.GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        m_transforms[1].localRotation *= Quaternion.Euler(0, 0, -1 * Time.deltaTime * rotationSpeed1);
        m_transforms[2].localRotation *= Quaternion.Euler(0, 0, -1 * Time.deltaTime * rotationSpeed2);
    }
}
