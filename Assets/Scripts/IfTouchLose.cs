using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IfTouchLose : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Enemy")
        {
         
            
            transform.position = new Vector2(0, 100);
            target.gameObject.SetActive(false);
            SceneManager.LoadScene("EndGame");
            //StartCoroutine(RestartGame());
        }

        if (target.tag == "Skeleton")
        {
            
            transform.position = new Vector2(0, 100);
            target.gameObject.SetActive(false);
            SceneManager.LoadScene("EndGame");
            //StartCoroutine(RestartGame());
        }
    }
}
/*
    IEnumerator RestartGame()
    {
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
} */