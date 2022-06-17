using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chess.Game;

public class AiParameter : MonoBehaviour
{
    public int searchDepth;
    public bool usingBook;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("GameManager"))
        {
            Debug.Log("Kita benar");
            //Setting The GameManager in the beginning of the Game
            gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            gameManager.aiSettings.depth = searchDepth;
            gameManager.aiSettings.useBook = usingBook;
            
            Destroy(gameObject);
            
        }
    }
}
