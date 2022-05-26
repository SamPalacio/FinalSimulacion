using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitationalAttraction : MonoBehaviour
{
    [SerializeField] bool canMove;
    Vector3 displacement, diferencia, accelaration, force;
    [SerializeField] Vector3 velocity;
    GravitationalAttraction masaReferencia;
    [SerializeField] Transform referencia;
    [SerializeField] float  mass, maxForce;

    private void Start()
    {
        masaReferencia = referencia.GetComponent<GravitationalAttraction>();
    }
    private void Update()
    {
        diferencia = referencia.position - transform.position;

        force = ((mass * masaReferencia.mass) / (diferencia.magnitude * diferencia.magnitude)) * diferencia.normalized;
        if(force.magnitude > maxForce) force = force.normalized * maxForce;
        ApplyForce(force);

        if (canMove) Move();

        accelaration = Vector3.zero;
    }
    public void Move()
    {
        //accelaration = referencia.position - transform.position;
        velocity = velocity + accelaration * Time.deltaTime;
        displacement = velocity * Time.deltaTime;
        transform.position = transform.position + new Vector3(displacement.x, displacement.y, displacement.z);
    }

    void ApplyForce(Vector3 force) { accelaration += force / mass; }
}
