using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : GameTileController
{
    [SerializeField] private GameObject path;
    [SerializeField] private VillageTileController[] villageTilesNotify = new VillageTileController[6];
    [SerializeField] private LayerMask hexTileLayer;
    [SerializeField] private float lifetime = 2f;
    public (int, int, int) number;
    public int fieldNumber;
    private GameObject[] paths = new GameObject[6];
    public string num;
    private (int, int, int) coordinates;
    public bool isDesert = false;
    private GameRessourceMaterials.MaterialEnum material;
    public GameObject RollIndication;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        num = number.ToString();
    }

    public GameObject[] GenPath()
    {
        Vector3[] directions = new Vector3[] { transform.forward, -transform.forward + transform.right, transform.forward + transform.right };

        RaycastHit hit;
        int i = 0;
        foreach (Vector3 direction in directions)
        {
            if (Physics.Raycast(transform.position, direction, out hit, hexTileLayer))
            {
                paths[i] = Instantiate(path, gameObject.transform.position + (hit.collider.gameObject.transform.position - gameObject.transform.position) / 2, Quaternion.LookRotation(Vector3.Cross(transform.up, hit.normal)));
                if (hit.collider.tag == "ocean" && gameObject.tag == "ocean")
                {
                    paths[i].GetComponent<MeshRenderer>().material = hit.collider.gameObject.GetComponent<MeshRenderer>().material;
                }
            }
            i++;
        }
        return paths;
    }
    public void GenVillageTile()
    {
        foreach (GameObject path in paths)
        {
            if (path == null)
                continue;
            path.GetComponent<pathController>().GenVillageTile();
        }
    }

    public void NotifyPicked()
    {
        foreach (VillageTileController village in villageTilesNotify)
        {
            village.NotifyPicked(material);
        }
    }
    public void SetCoordinates((int, int, int) coord)
    {
        coordinates = coord;
    }
    public (int, int, int) GetPositionXY()
    {
        return coordinates;
    }
    public void IndicateSelected()
    {
        Destroy(Instantiate(RollIndication, gameObject.transform.position, gameObject.transform.rotation), lifetime);
    }
    public void SetNumber(int number)
    {
        transform.Find("numberSpawn").transform.Find("text").GetComponent<TMPro.TextMeshPro>().text = number.ToString();
    }
    public void AddNotify(VillageTileController tile)
    {
        for (int i = 0; i < villageTilesNotify.Length; i++)
        {
            if (villageTilesNotify[i] == null)
            {
                villageTilesNotify[i] = tile;
                return;
            }
        }
    }

    public void SetGameMaterial(GameRessourceMaterials.MaterialEnum material)
    {
        this.material = material;
    }
}
