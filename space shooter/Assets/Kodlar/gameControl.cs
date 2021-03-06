using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameControl : MonoBehaviour
{
    public GameObject asteroid;
    public Vector3 randomPOS;
    int score;
    public Text text;
    public GameObject dead;
    private IEnumerator createEngelGameobject;

    void Start()
    {
        score = 0;
        text.text = "Score:" + score;
        createEngelGameobject = olustur();
        // olustur(); aşşağıda IEnumarator parametresini kullandığımız için artık metodu bu şekilde çağırmıyoruz.
        StartCoroutine(createEngelGameobject); // zamana hükmetmek istedğimiz için yani astreoidin belli bir saniye beklemesini istediğimiz için corountine komutlarını kullandık bu yzden fonksiyonu çalıştırırken startCorountine(olustur()) diye çağırdık
    }
    void Update()
    {

    }
    IEnumerator olustur()       // bekletmek için yield return komudu kullandığımız için IEnumerator ile fonksiyon oluşturduk ve startın içinde startcorountine diye çağırdık.
    {
        yield return new WaitForSeconds(2);     // belli bir saniye beklemesini sağlıyor.
        while(true) // while true dersem sonsuza kadar döner.
        {
            for (int i = 0; i < 10; i++)
            {
                Vector3 vec = new Vector3(Random.Range(-randomPOS.x, randomPOS.x), 0, randomPOS.z); // Random.range metodu iki sayı arasında random değer üretmeyi sağlar.
                Instantiate(asteroid, vec, Quaternion.identity);
                yield return new WaitForSeconds(0.7f);     // belli bir saniye beklemesini sağlıyor.
            }
            yield return new WaitForSeconds(2);
          
        }
       
    }
    public void ScoreArttir(int gelenScore)
    {
        score += gelenScore;
        text.text = "Score:" + score;
        Debug.Log(score);
    }
    public void GameOver()
    {
        StopCoroutine(createEngelGameobject);
        dead.SetActive(true);
        text.gameObject.SetActive(false);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
