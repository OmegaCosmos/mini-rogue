using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    private int LayerWalls;
    // Start is called before the first frame update
    void Start()
    {
        LayerWalls = 1 << LayerMask.NameToLayer("Environment");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire(Vector2 origin) {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z += Camera.main.nearClipPlane;
        RaycastHit2D hit = Physics2D.Raycast(origin, pos, Mathf.Infinity);
        Debug.DrawRay(origin, hit.point, Color.red, 10.0f);

        if(hit.collider != null) {
            if(hit.collider.gameObject.tag == "Wall"){
                Debug.Log("Hit wall!");
            }
        }
    }
}
