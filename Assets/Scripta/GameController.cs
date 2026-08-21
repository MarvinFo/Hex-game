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
            int diceRoll = UnityEngine.Random.Range(1, 7) + UnityEngine.Random.Range(1, 7);
            if (diceRoll == 7)
            {

            }
            else
            {
                worldController.GetComponent<WorldController>().RollField(diceRoll);
            }
             
        }  
    }
    /*private IEnumerator GameCycle()
    {

    }*/
    /*private IEnumerator gameAction()
    {
        yield return new WaitUntil();
    }*/

    public void DistributeAssetsToPlayers(int playerID)
    {
        Debug.Log("Yippeeee");
    }

}
