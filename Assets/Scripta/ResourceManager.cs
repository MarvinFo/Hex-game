using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public GameController GameController;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AwardAssets(int playerID)
    {
        GameController.DistributeAssetsToPlayers(playerID);
    }
}
