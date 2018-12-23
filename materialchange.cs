using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class materialchange : MonoBehaviour {
    public Material mat;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

    void changeM(){
        gameObject.GetComponent<basicgenerate>().getitems(mat);
    }
}
