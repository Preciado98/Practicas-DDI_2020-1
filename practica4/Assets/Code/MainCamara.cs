using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamara : MonoBehaviour {

    Transform target;
    float tLx, tLY, bRx, bRY;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(
            Mathf.Clamp(target.position.x,tLx,bRx),
            Mathf.Clamp(target.position.y,bRY, tLY),
            transform.position.z);
	}

    public void SetBound(GameObject map) {
        Tiled2Unity.TiledMap config = map.GetComponent<Tiled2Unity.TiledMap>();
        float cameraSize = Camera.main.orthographicSize;

        tLx = map.transform.position.x + cameraSize;
        tLY = map.transform.position.y - cameraSize;
        bRx = map.transform.position.x + config.NumTilesWide - cameraSize;
        bRY = map.transform.position.y - config.NumTilesHigh + cameraSize;
    }

}
