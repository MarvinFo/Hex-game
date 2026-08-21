using UnityEngine;

[CreateAssetMenu(fileName = "StandardWorldGenSO", menuName = "ScriptableObjects/WorldGen/Standard")]
public class StandardWorldGenScriptableObject : ScriptableObject
{
    // Start is called before the first frame update
    public int fieldSize = 7;
    [Header("Offset for tile placement")]
    [SerializeField] public Vector3 q = new Vector3(0.35f, 0, 0);
    [SerializeField] public Vector3 r = new Vector3(-0.5f, 0, -0.5f);
    [SerializeField] public Vector3 s = new Vector3(-0.5f, 0, 0.5f);
    [SerializeField] public int[] fieldNumbers = { 5, 2, 6, 3, 8, 10, 9, 12, 11, 4, 8, 10, 9, 4, 5, 6, 3, 11 };
    [Header("Material list")]
    [SerializeField] public Material[] materials;
    [Header("Material name list")]
    [SerializeField] public GameRessourceMaterials.MaterialEnum[] materialNames;
    [Header("Biom quantity")]
    [SerializeField] public int[] biomes = new int[] { 3, 4, 4, 4, 3, 1 };


}
