using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerKontrol : MonoBehaviour
{
    Rigidbody fizik;
    float horizontal = 0;
    float vertical = 0;
    Vector3 vect;
    public float playerHiz;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    public float egim;
    float atesZamani = 0f;
    float atesGecenSure = 0.1f;
    public GameObject kursunObje;
    public Transform KursunNeredenCiksin;
    AudioSource audio1;
    void Start()
    {
        fizik = GetComponent<Rigidbody>();
        audio1 = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time>atesZamani)
        {
            atesZamani = Time.time + atesGecenSure;
            Instantiate(kursunObje,KursunNeredenCiksin.position,Quaternion.identity);
            audio1.Play();
        }
    }

    void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        Vector3 vect = new Vector3(horizontal, 0, vertical);
        vect = new Vector3(horizontal, 0, vertical);
        fizik.velocity = vect*playerHiz;
        fizik.position = new Vector3(
            Mathf.Clamp(fizik.position.x,minX,maxX),
            0.0f,
            Mathf.Clamp(fizik.position.z,minZ,maxZ)
            );
        fizik.rotation = Quaternion.Euler(0, 0, fizik.velocity.x*-egim);
    }
}
