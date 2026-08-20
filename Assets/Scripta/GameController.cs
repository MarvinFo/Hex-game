using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject[] players;
    [SerializeField] private WorldController worldController;
    private Object roundToken;
    public static int playerNumber = 4;

    // Start is called before the first frame update
    void Start()
    {
        roundToken = new Object();
        foreach(GameObject player in players)
        {
            player.GetComponent<PlayerController>().SetToken(roundToken);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            //worldController.GetComponent<WorldController>().RollField(8); 
        }  
    }
    /*private IEnumerator GameCycle()
    {

    }*/
    /*private IEnumerator gameAction()
    {
        yield return new WaitUntil();
    }*/
}
