using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject[] players;
    private Object roundToken;
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
        
    }
    /*private IEnumerator GameCycle()
    {

    }*/
    /*private IEnumerator gameAction()
    {
        yield return new WaitUntil();
    }*/
}
