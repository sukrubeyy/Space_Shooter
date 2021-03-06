using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fxKontrol : MonoBehaviour
{
    Rigidbody fizik;
    float kursunHiz = 10f;
    void Start()
    {
        fizik = GetComponent<Rigidbody>();
        fizik.velocity = transform.forward * kursunHiz;
    }
}
