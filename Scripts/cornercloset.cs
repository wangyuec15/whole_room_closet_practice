using UnityEngine;
using System.Collections;

public class cornercloset : MonoBehaviour
{
    

    public float w1 = 1000;
    public float d1 = 600;
    public float w2 = 1000;
    public float d2 = 600;

    private float height=2200;
    private float ground_clearance = 60;


    private float thickness_riser = 18;
    private float thickness_backplane = 9;
    private float thickness_door = 18;
    private float thickness_apical = 18;


    private Vector3 move;
    //public Material mat;

    public GameObject corner;

    private GameObject handle;

    void Start()
    {
        //corner = new GameObject("corner_closet");
        //generate();

    }

    // Update is called once per frame
    void Update()
    {
    }


    public void create(Vector3 pos,Vector3 rotate){
        corner = new GameObject("corner_closet");
        generate();
        corner.transform.Translate(pos);
        corner.transform.Rotate(rotate);
    }


    void generate(){

        height = gameObject.GetComponent<basicgenerate>().height;
        ground_clearance = gameObject.GetComponent<basicgenerate>().ground_clearance;

        thickness_riser = gameObject.GetComponent<basicgenerate>().thickness_riser;
        thickness_backplane = gameObject.GetComponent<basicgenerate>().thickness_backplane;
        thickness_door = gameObject.GetComponent<basicgenerate>().thickness_door;
        thickness_apical = gameObject.GetComponent<basicgenerate>().thickness_apical;

        move = Vector3.left * w1;

        handle = gameObject.GetComponent<basicgenerate>().handle;



        d1 -= thickness_door + 2;
        d2 -= thickness_door + 2;

        gameObject.GetComponent<boards>(). single_riser(thickness_riser / 2, height, 0, 0, w2-thickness_riser, corner);
        gameObject.GetComponent<boards>().single_riser(w1 - thickness_riser / 2, height, 0, 0, d1, corner );

        gameObject.GetComponent<boards>().single_apical(thickness_riser, d2+thickness_apical+thickness_door*2, thickness_riser, w2-thickness_riser, height - thickness_apical / 2, corner);
        gameObject.GetComponent<boards>().single_apical(d2+thickness_door, w1-thickness_riser, thickness_riser, d1+thickness_door, height - thickness_apical / 2, corner);

        gameObject.GetComponent<boards>().single_apical(thickness_riser, d2, thickness_riser, w2 - thickness_riser, ground_clearance - thickness_apical / 2, corner);
        gameObject.GetComponent<boards>().single_apical(d2, w1 - thickness_riser, thickness_riser, d1, ground_clearance - thickness_apical / 2, corner);

        gameObject.GetComponent<boards>().single_plane( thickness_riser,  w1 - thickness_riser, 0, height, thickness_riser, thickness_riser / 2, corner);
        gameObject.GetComponent<boards>().single_plane(0, d2 ,0,height, thickness_riser, w2 - thickness_riser / 2, corner);

        gameObject.GetComponent<boards>().single_plane(d2-thickness_riser, w1-thickness_riser, 0, ground_clearance-thickness_apical, thickness_riser, d1 - thickness_riser / 2, corner);
        gameObject.GetComponent<boards>().single_riser(d2 - thickness_riser/2, ground_clearance - thickness_apical, 0, d1, w2 - thickness_riser, corner);



        GameObject handle_a = Instantiate(handle, new Vector3(d2 + 100, 1300, d1), Quaternion.identity, corner.transform);
        GameObject handle_b = Instantiate(handle, new Vector3(d2, 1300, d1 + 100), Quaternion.identity, corner.transform);
        handle_b.transform.Rotate(new Vector3(0, 90, 0));


        d1 += thickness_door + 2;
        d2 += thickness_door + 2;



        gameObject.GetComponent<boards>().single_plane(d2 , w1 ,ground_clearance-thickness_apical, height, thickness_riser, d1 - thickness_riser / 2, corner);
        gameObject.GetComponent<boards>().single_riser(d2 - thickness_riser / 2, height, ground_clearance -thickness_apical, d1, w2 , corner);

        corner.transform.position = move;


    }

    void generate_outside()
    {

        height = gameObject.GetComponent<basicgenerate>().height;
        ground_clearance = gameObject.GetComponent<basicgenerate>().ground_clearance;

        thickness_riser = gameObject.GetComponent<basicgenerate>().thickness_riser;
        thickness_backplane = gameObject.GetComponent<basicgenerate>().thickness_backplane;
        thickness_door = gameObject.GetComponent<basicgenerate>().thickness_door;
        thickness_apical = gameObject.GetComponent<basicgenerate>().thickness_apical;

        move = Vector3.left * w1;

        handle = gameObject.GetComponent<basicgenerate>().handle;



        d1 -= thickness_door + 2;
        d2 -= thickness_door + 2;

        gameObject.GetComponent<boards>().single_riser(thickness_riser / 2, height, 0, 0, w2 - thickness_riser, corner);
        gameObject.GetComponent<boards>().single_riser(w1 - thickness_riser / 2, height, 0, 0, d1, corner);

        gameObject.GetComponent<boards>().single_apical(thickness_riser, d2 + thickness_apical + thickness_door * 2, thickness_riser, w2 - thickness_riser, height - thickness_apical / 2, corner);
        gameObject.GetComponent<boards>().single_apical(d2 + thickness_door, w1 - thickness_riser, thickness_riser, d1 + thickness_door, height - thickness_apical / 2, corner);

        gameObject.GetComponent<boards>().single_apical(thickness_riser, d2, thickness_riser, w2 - thickness_riser, ground_clearance - thickness_apical / 2, corner);
        gameObject.GetComponent<boards>().single_apical(d2, w1 - thickness_riser, thickness_riser, d1, ground_clearance - thickness_apical / 2, corner);

        gameObject.GetComponent<boards>().single_plane(thickness_riser, w1 - thickness_riser, 0, height, thickness_riser, thickness_riser / 2, corner);
        gameObject.GetComponent<boards>().single_plane(0, d2, 0, height, thickness_riser, w2 - thickness_riser / 2, corner);

        gameObject.GetComponent<boards>().single_plane(d2 - thickness_riser, w1 - thickness_riser, 0, ground_clearance - thickness_apical, thickness_riser, d1 - thickness_riser / 2, corner);
        gameObject.GetComponent<boards>().single_riser(d2 - thickness_riser / 2, ground_clearance - thickness_apical, 0, d1, w2 - thickness_riser, corner);



        GameObject handle_a = Instantiate(handle, new Vector3(d2 + 100, 1300, d1), Quaternion.identity, corner.transform);
        GameObject handle_b = Instantiate(handle, new Vector3(d2, 1300, d1 + 100), Quaternion.identity, corner.transform);
        handle_b.transform.Rotate(new Vector3(0, 90, 0));


        d1 += thickness_door + 2;
        d2 += thickness_door + 2;



        gameObject.GetComponent<boards>().single_plane(d2, w1, ground_clearance - thickness_apical, height, thickness_riser, d1 - thickness_riser / 2, corner);
        gameObject.GetComponent<boards>().single_riser(d2 - thickness_riser / 2, height, ground_clearance - thickness_apical, d1, w2, corner);

        corner.transform.position = move;


    }


}
