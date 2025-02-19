using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFieldSelection : MonoBehaviour
{
    public Camera cam;
    public LayerMask tileLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            Ray r = cam.ScreenPointToRay(Input.mousePosition);
            bool succ = Physics.Raycast(r, out hit);
            Debug.Log(tileLayer == (tileLayer | (1 << hit.collider.gameObject.layer)));
            if (tileLayer == (tileLayer | (1 << hit.collider.gameObject.layer)))
            {
                Debug.Log(hit.collider.gameObject.GetComponent<TileController>().GetPositionXY());
            }
        }
    }
}
