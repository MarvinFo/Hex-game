using UnityEngine;


[CreateAssetMenu(fileName = "GameRessourceMaterials", menuName = "ScriptableObjects/GameRessourceMaterials")]
public class GameRessourceMaterials : ScriptableObject
{
    public enum MaterialEnum
    {

        Pasture ,
        Mountain,
        Hills,
        Forest,
        Field,
        Desert

    }
}
