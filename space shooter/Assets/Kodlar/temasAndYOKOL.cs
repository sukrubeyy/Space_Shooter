using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temasAndYOKOL : MonoBehaviour
{
    public GameObject patlama;
    public GameObject playerPatlama;
    Rigidbody fizik;
    float asteroidHiz = -8f;
    GameObject OyunKontrol;
    gameControl kontrol;
    void Start()
    {
        fizik = GetComponent<Rigidbody>();
        fizik.velocity = transform.forward * asteroidHiz;
        fizik.angularVelocity = Random.insideUnitSphere;

        OyunKontrol = GameObject.FindGameObjectWithTag("oyunKontrol");
        kontrol = OyunKontrol.GetComponent<gameControl>();
    }
    void OnTriggerEnter(Collider other)
    {
        
        if(other.tag=="Player")
        {
            Instantiate(playerPatlama,other.transform.position,other.transform.rotation);
            GameOver();
            Destroy(other.gameObject);
            Destroy(gameObject);
           
        }
        else
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Instantiate(patlama, transform.position, transform.rotation);
            kontrol.ScoreArttir(10);
        }
    }
   public void GameOver()
    {
        GameObject gameobje = GameObject.FindGameObjectWithTag("oyunKontrol");
        gameobje.GetComponent<gameControl>().GameOver();
    }
}
