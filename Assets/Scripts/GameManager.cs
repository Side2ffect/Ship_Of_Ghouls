using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{


    public static GameManager _instance;


    private KeyCount[] noOfKeys;
    [SerializeField] private int keyCount;
    [SerializeField] private Text KeyText;

    private bool gameOver = false;
    private bool gameWon = false;



    [SerializeField] GameObject[] gameOverObjectsToTurnoff;
    [SerializeField] GameObject[] gameOverObjectsToTurnOn;


    [SerializeField] GameObject[] gameWonObjectsToTurnoff;
    [SerializeField] GameObject[] gameWonObjectsToTurnOn;


    public void SetGameOver()
    {
        gameOver = true;
    }

    public void SetGameWon()
    {
        gameWon = true;
    }

    public int ReturnKeyCount()
    {
        return keyCount;
    }
    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }

        else
        {
            _instance = this;
        }
    }
    void Start()
    {
       noOfKeys = FindObjectsOfType<KeyCount>();

        keyCount = noOfKeys.Length;

        KeyText.text = "Keys Remaining: " + keyCount;


    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            for(int i=0; i < gameOverObjectsToTurnoff.Length; i++)
            {
                gameOverObjectsToTurnoff[i].SetActive(false);
            }

            for (int i = 0; i < gameOverObjectsToTurnOn.Length; i++)
            {
                gameOverObjectsToTurnOn[i].SetActive(true);
            
            }
        }


        if (gameWon)
        {
            //play animation
            for (int i = 0; i < gameWonObjectsToTurnoff.Length; i++)
            {
                gameWonObjectsToTurnoff[i].SetActive(false);
            }

            for (int i = 0; i < gameWonObjectsToTurnOn.Length; i++)
            {
                gameWonObjectsToTurnOn[i].SetActive(true);

            }
        }
    }

    public void ReduceKeyCount()
    {

        keyCount--;
        KeyText.text = "Keys Remaining: " + keyCount;
    }

}
