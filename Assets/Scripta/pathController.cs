using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathController : GameTileController
{
    public LayerMask villageLayer;
    public GameObject villageTile;
    public bool hasVillageOnEnd = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void GenVillageTile()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, villageLayer))
        {
            if (villageLayer == (villageLayer | (1 << hit.collider.gameObject.layer)))
                Instantiate(villageTile, (hit.point - transform.position)*9/10 + transform.position, Quaternion.identity);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void CalculateStreetLength(pathController start)
    {

    }
}
