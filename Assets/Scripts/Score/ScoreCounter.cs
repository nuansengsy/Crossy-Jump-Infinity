using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public TextMeshProUGUI mainMenuBestScore;

    public TextMeshProUGUI currentScore;
    public TextMeshProUGUI scoreOnPanel;
    public TextMeshProUGUI bestScoreOnPanel;


    private int score;
    private int bestScore;
    void Start()
    {
        mainMenuBestScore.text = "BEST SCORE " + PlayerPrefs.GetInt("NewBestScore", 0).ToString();
        Debug.Log("hight score on start = " + PlayerPrefs.GetInt("NewBestScore", 0));
    }

    // Update is called once per frame
    void Update()
    {
        currentScore.text = score.ToString();
        scoreOnPanel.text = "Score " + score.ToString();
        bestScoreOnPanel.text = "Best Score " + PlayerPrefs.GetInt("NewBestScore", 0).ToString();

        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("A pressd");
            PlayerPrefs.SetInt("NewBestScore", 0);
            Debug.Log("hight score = " + PlayerPrefs.GetInt("NewBestScore", 0));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "platform")
        {
            score += 1;
            currentScore.rectTransform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            StartCoroutine(ExampleCoroutine());
            if (score > PlayerPrefs.GetInt("NewBestScore", 0))
            {
                PlayerPrefs.SetInt("NewBestScore", score);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "gem")
        {
            score += 3;
            currentScore.rectTransform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            StartCoroutine(ExampleCoroutine());
            if (score > PlayerPrefs.GetInt("NewBestScore", 0))
            {
                PlayerPrefs.SetInt("NewBestScore", score);
            }
        }
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        currentScore.rectTransform.localScale = new Vector3(1f, 1f, 1f);
    }

}
