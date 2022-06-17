using UnityEngine;
using UnityEngine.SceneManagement;


public class UiController : MonoBehaviour
{
    GameManagerOnline gameManagerOnline;
    private bool isOnline = false;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("Game Manager Online"))
        {
            gameManagerOnline = GameObject.Find("Game Manager Online").GetComponent<GameManagerOnline>();
            isOnline = gameManagerOnline is GameManagerOnline;
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string sceneName)
    {
        if (isOnline == false)
            SceneManager.LoadScene(sceneName);
    }

    public void LoadComputerLevel(GameObject aiParameter)
    {
        //aiParameter = Instantiate(this.aiParameter, transform.position, Quaternion.identity).GetComponent<AiParameter>();
        //aiParameter.searchDepth = depthSearch;
        //aiParameter.usingBook = usingBook;
        DontDestroyOnLoad(aiParameter);
        SceneManager.LoadScene("Chess");

    }
}
