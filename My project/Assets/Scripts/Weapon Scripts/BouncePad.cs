using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    public float bounce;
    private void OnCollisionEnter(Collision collision)
    {
        GameObject bouncePad = collision.gameObject;
        Rigidbody rb = bouncePad.GetComponent<Rigidbody>();
        Vector3 bouncedirection = Quaternion.Euler(90,0,0) * transform.forward;
        rb.AddForce(bouncedirection * bounce);

    }
}
