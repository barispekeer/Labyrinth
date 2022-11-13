using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public TMP_Text time, health,finishTxt;
    public Image finishPnl;
    float timer = 30;
    int hp = 3;
    int speed = 5;
    Rigidbody rigi;
    void Start()
    {
        rigi = GetComponent<Rigidbody>();
    }


    void Update()
    {
        Moving();
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            time.text = (int)timer + "";
        }
        else
        {
            Time.timeScale = 0;
        }
    }
    void Moving()
    {
        float xMove = Input.GetAxis("Horizontal");
        float yMove = Input.GetAxis("Vertical");
        rigi.AddForce(-xMove * speed , 0, -yMove * speed );
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Respawn"))
        {
            hp--;
            health.text = hp.ToString();
            if (hp == 0)
            {
                rigi.isKinematic = true;
                finishPnl.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
        }
        else if (collision.gameObject.tag.Equals("Finish"))
        {
            rigi.isKinematic = true;
            finishPnl.gameObject.SetActive(true);
            finishTxt.text = "KAZANDINIZ !";
            Time.timeScale = 0;
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
