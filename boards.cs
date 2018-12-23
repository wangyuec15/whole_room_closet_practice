using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boards : MonoBehaviour {
    private float depth;
    //private float thickness_riser;
    //private float thickness_apical;

	// Use this for initialization
	void Start () {
        depth = gameObject.GetComponent<basicgenerate>().depth;
        //thickness_riser = gameObject.GetComponent<basicgenerate>().thickness_riser;
        //thickness_apical = gameObject.GetComponent<basicgenerate>().thickness_apical;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void single_pole(float its_left, float its_right, float its_height, GameObject set_parent)
    {
        GameObject pole = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        pole.transform.Rotate(0, 0, 90);
        pole.transform.position = new Vector3((its_right + its_left) / 2, its_height, depth / 2);
        pole.transform.parent = set_parent.transform;
        pole.GetComponent<Transform>().localScale = new Vector3(2, (its_right - its_left) / 2, 2);
    }


    public void single_apical(float its_left, float its_right, float far, float near, float its_height, GameObject parent)
    {
        GameObject apical = GameObject.CreatePrimitive(PrimitiveType.Cube);
        apical.transform.position = new Vector3((its_right + its_left) / 2, its_height, near / 2 + far / 2);
        apical.GetComponent<Transform>().localScale = new Vector3(its_right - its_left - 2 * gameObject.GetComponent<basicgenerate>().thickness_riser,gameObject.GetComponent<basicgenerate>().thickness_apical, near - far);
        apical.transform.parent = parent.transform;
    }
    public void single_riser(float x_pos, float top, float bottom, float far, float near, GameObject parent)
    {
        GameObject riser = GameObject.CreatePrimitive(PrimitiveType.Cube);
        riser.transform.position = new Vector3(x_pos, top / 2 + bottom / 2, near / 2 + far / 2);
        riser.GetComponent<Transform>().localScale = new Vector3(gameObject.GetComponent<basicgenerate>().thickness_riser, top - bottom, near - far);
        riser.transform.parent = parent.transform;
    }

    public void single_plane(float left, float right, float bottom, float top, float thick, float z, GameObject parent)
    {
        GameObject riser = GameObject.CreatePrimitive(PrimitiveType.Cube);
        riser.transform.position = new Vector3((left + right) / 2, (bottom + top) / 2, z);
        riser.GetComponent<Transform>().localScale = new Vector3((right - left), (top - bottom), thick);
        riser.transform.parent = parent.transform;
    }

}
