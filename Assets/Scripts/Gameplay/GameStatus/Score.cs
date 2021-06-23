using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour {
    public static int PlayerScore = 0;

    private Text scoreText;
    [SerializeField] private GameObject winText;

    private void Start()
    {
        scoreText = GetComponent<Text>();
    }

    private void Update(){
        scoreText.text = "Score: " + PlayerScore;

        if(PlayerScore == 20)
        {

            winText.SetActive(true);
            Time.timeScale = 0f;
        }
    }


}
