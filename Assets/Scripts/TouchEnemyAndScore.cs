using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TouchEnemyAndScore : MonoBehaviour
{
    //public AudioSource BatKill;
    public Text ScoreText;
    public static int score = 0;

    public Text HighScore;

    void Awake()
    {
        //DontDestroyOnLoad(transform.gameObject); - Used to preserve data and not destroy game object
        ScoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        ScoreText.text = "0";
        ScoreText.text = score.ToString();

    }

    public void Start()
    {
        //BatKill = GetComponent<AudioSource>();
        score = 0; // Initializes the score at restart to 0
        HighScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();

    }

    /// <summary>
    /// this part makes  you touch MORE CODE DESCRIPTION SOON 
    /// </summary>
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint((Input.GetTouch(0).position)), Vector2.zero);
            if (hit.collider.gameObject.tag == "Enemy")
            {
                SoundManagerScript.PlaySound("Batkill");
                //BatKill.Play();
                hit.collider.gameObject.SetActive(false);
                score++;
                ScoreText.text = score.ToString();

                if (score > PlayerPrefs.GetInt("HighScore", 0))
                {
                    PlayerPrefs.SetInt("HighScore", score);
                    HighScore.text = score.ToString();
                }
            }
        }

    }

}

