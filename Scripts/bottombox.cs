using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottombox : MonoBehaviour {

    //public GameObject bottom_closet;
    //public enum door_style { swing, sliding };
    //public door_style chosen_style;


    //public int n;
    public GameObject[] closet;


    private float thickness_riser = 18;
    private float thickness_backplane = 9;
    private float thickness_door = 18;
    private float thickness_apical = 18;
    private float ground_clearance = 60;

    //public float width;
    //public float depth;
    //public float each_width;
    private GameObject handle;
    //public Vector3 move;




	// Use this for initialization
	void Start () {
        closet = gameObject.GetComponent<basicgenerate>().closet;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void single_bottombox(float width,float each_width,float depth, float its_height,int n,GameObject itsparent,Vector3 move,GameObject[] closet)
    {
        Debug.Log("n");
        Debug.Log(n);

        //GameObject bottom_closet;
        //bottom_closet = new GameObject("bottomcloset");
        //itsparent = new GameObject(itsparent.ToString());

        if (gameObject.GetComponent<basicgenerate>().chosen_style == basicgenerate.door_style.swing)
        {

            closet = new GameObject[n];



            for (int i = 0; i < n; i++)
            {
                closet[i] = new GameObject("closet_" + i);

            }


            depth -= thickness_door + 2;
            for (int i = 0; i < n; i++)
            {
                gameObject .GetComponent<boards>().single_riser(i * each_width + thickness_riser / 2, its_height, 0, 0, depth, closet[i]);
                gameObject.GetComponent<boards>().single_riser((i + 1) * each_width - thickness_riser / 2, its_height, 0, 0, depth, closet[i]);

                gameObject.GetComponent<boards>().single_apical(i * each_width, (i + 1) * each_width, 0, depth, ground_clearance - thickness_apical / 2, closet[i]);
                gameObject.GetComponent<boards>().single_apical(i * each_width, (i + 1) * each_width, 0, depth, its_height - thickness_apical / 2, closet[i]);

                gameObject.GetComponent<boards>().single_plane(i * each_width + thickness_riser, (i + 1) * each_width - thickness_riser, 0, its_height, thickness_backplane, thickness_backplane / 2, closet[i]);
                gameObject.GetComponent<boards>().single_plane(i * each_width + thickness_riser, (i + 1) * each_width - thickness_riser, 0, ground_clearance - thickness_apical, thickness_backplane, depth - thickness_backplane / 2, closet[i]);


                if (each_width >= 650)
                {

                    gameObject.GetComponent<boards>().single_plane(i * each_width + 1, (i + 0.5f) * each_width - 1, ground_clearance - thickness_apical, its_height, thickness_door, depth + 1 + thickness_door / 2, closet[i]);
                    gameObject.GetComponent<boards>().single_plane((i + 0.5f) * each_width + 1, (i + 1) * each_width - 1, ground_clearance - thickness_apical, its_height, thickness_door, depth + 1 + thickness_door / 2, closet[i]);


                    GameObject handle_a = Instantiate(gameObject.GetComponent<basicgenerate>(). handle, new Vector3(each_width * (i + 0.5f) - 30, 1100, depth), Quaternion.identity);
                    GameObject handle_b = Instantiate(gameObject.GetComponent<basicgenerate>().handle, new Vector3(each_width * (i + 0.5f) + 30, 1100, depth), Quaternion.identity);

                    handle_a.transform.parent = closet[i].transform;
                    handle_b.transform.parent = closet[i].transform;



                    if (its_height <= 1300)
                    {
                        handle_a.transform.position -= new Vector3(0, 1300 - its_height, 0);
                        handle_b.transform.position -= new Vector3(0, 1300 - its_height, 0);

                    }

                }
                else
                {
                    gameObject.GetComponent<boards>().single_plane(i * each_width + 1, (i + 1) * each_width - 1, ground_clearance - thickness_apical, its_height, thickness_door, depth + 1 + thickness_door / 2, closet[i]);


                    GameObject handle_a = Instantiate(gameObject.GetComponent<basicgenerate>().handle, new Vector3(each_width * i + 30, 1100, depth), Quaternion.identity);
                    handle_a.transform.parent = closet[i].transform;
                    if (its_height <= 1300)
                    {
                        handle_a.transform.position -= new Vector3(0, 1300 - its_height, 0);

                    }

                }



            }
            depth += thickness_door + 2;


        }
        else if (gameObject.GetComponent<basicgenerate>().chosen_style == basicgenerate.door_style.sliding)
        {
            if (1200 <= width && width <= 2200)
            {


                n = 2;
                each_width = width / 2;

                //closet = new GameObject[n];


            }
            closet = new GameObject[n];

            for (int i = 0; i < n; i++)
            {
                closet[i] = new GameObject("closet_" + i);


            }
            if (n % 2 == 0)
            {
                for (int i = 0; i < n; i++)
                {
                    gameObject.GetComponent<boards>().single_riser(i * each_width + thickness_riser / 2, its_height - thickness_apical * (i % 2), 0, 0, depth - 40 * (i % 2), closet[i]);
                    gameObject.GetComponent<boards>().single_riser((i + 1) * each_width - thickness_riser / 2, its_height - thickness_apical * ((i + 1) % 2), 0, 0, depth - 40 * ((i + 1) % 2), closet[i]);

                    gameObject.GetComponent<boards>().single_apical(i * each_width - thickness_riser * (i % 2), (i + 1) * each_width + thickness_riser * ((i + 1) % 2), 0, depth, its_height - thickness_apical / 2, closet[i]);

                    gameObject.GetComponent<boards>().single_plane(i * each_width + thickness_riser, (i + 1) * each_width - thickness_riser, 0, its_height, thickness_backplane, thickness_backplane / 2, closet[i]);

                    gameObject.GetComponent<boards>().single_apical(i * each_width, (i + 1) * each_width, thickness_backplane, depth - 40, ground_clearance - thickness_apical / 2, closet[i]);

                    gameObject.GetComponent<boards>().single_plane(i * each_width + 1 + thickness_riser - 2 * thickness_riser * (i % 2), (i + 1) * each_width - 1 - thickness_riser + 2 * thickness_riser * ((i + 1) % 2), thickness_apical + 1, its_height - thickness_apical - 1, thickness_door, depth - 30 + i % 2 * 20, closet[i]);
                    gameObject.GetComponent<boards>().single_apical(i * each_width - thickness_riser * (i % 2), (i + 1) * each_width + thickness_riser * ((i + 1) % 2), depth - 40, depth, thickness_apical / 2, closet[i]);




                }
            }
            else if (n > 2 && n % 2 == 1)
            {
                for (int i = 0; i < n - 2; i++)
                {
                    gameObject.GetComponent<boards>().single_riser(i * each_width + thickness_riser / 2, its_height - thickness_apical * (i % 2), 0, 0, depth - 40 * (i % 2), closet[i]);
                    gameObject.GetComponent<boards>().single_riser((i + 1) * each_width - thickness_riser / 2, its_height - thickness_apical * ((i + 1) % 2), 0, 0, depth - 40 * ((i + 1) % 2), closet[i]);

                    gameObject.GetComponent<boards>().single_apical(i * each_width - thickness_riser * (i % 2), (i + 1) * each_width + thickness_riser * ((i + 1) % 2), 0, depth, its_height - thickness_apical / 2, closet[i]);

                    gameObject.GetComponent<boards>().single_plane(i * each_width + thickness_riser, (i + 1) * each_width - thickness_riser, 0, its_height, thickness_backplane, thickness_backplane / 2, closet[i]);

                    gameObject.GetComponent<boards>().single_apical(i * each_width, (i + 1) * each_width, thickness_backplane, depth - 40, ground_clearance - thickness_apical / 2, closet[i]);
                    gameObject.GetComponent<boards>().single_plane(i * each_width + thickness_riser, (i + 1) * each_width - thickness_riser, 0, ground_clearance - thickness_apical, thickness_backplane, depth - thickness_backplane / 2 - 40, closet[i]);

                    gameObject.GetComponent<boards>().single_plane(i * each_width + 1 + thickness_riser - 2 * thickness_riser * (i % 2), (i + 1) * each_width - 1 - thickness_riser + 2 * thickness_riser * ((i + 1) % 2), thickness_apical + 1, its_height - thickness_apical - 1, thickness_door, depth - 30 + (i + 1) % 2 * 20, closet[i]);
                    gameObject.GetComponent<boards>().single_apical(i * each_width - thickness_riser * (i % 2), (i + 1) * each_width + thickness_riser * ((i + 1) % 2), depth - 40, depth, thickness_apical / 2, closet[i]);




                }
                gameObject.GetComponent<boards>().single_riser((n - 2) * each_width + thickness_riser / 2, its_height - thickness_apical, 0, 0, depth - 40, closet[(n - 2)]);
                gameObject.GetComponent<boards>().single_riser(((n - 2) + 1) * each_width - thickness_riser / 2, its_height - thickness_apical, 0, 0, depth - 40, closet[(n - 2)]);

                gameObject.GetComponent<boards>().single_apical((n - 2) * each_width - thickness_riser, ((n - 2) + 1) * each_width + thickness_riser, 0, depth, its_height - thickness_apical / 2, closet[(n - 2)]);

                gameObject.GetComponent<boards>().single_plane((n - 2) * each_width + thickness_riser, ((n - 2) + 1) * each_width - thickness_riser, 0, its_height, thickness_backplane, thickness_backplane / 2, closet[(n - 2)]);

                gameObject.GetComponent<boards>().single_apical((n - 2) * each_width, ((n - 2) + 1) * each_width, thickness_backplane, depth - 40, ground_clearance - thickness_apical / 2, closet[(n - 2)]);
                gameObject.GetComponent<boards>().single_plane((n - 2) * each_width + thickness_riser, ((n - 2) + 1) * each_width - thickness_riser, 0, ground_clearance - thickness_apical, thickness_backplane, depth - thickness_backplane / 2 - 40, closet[(n - 2)]);

                gameObject.GetComponent<boards>().single_plane((n - 2) * each_width + 1 + thickness_riser - 2 * thickness_riser, ((n - 2) + 1) * each_width - 1 - thickness_riser + 2 * thickness_riser * (((n - 2) + 1) % 2), thickness_apical + 1, its_height - thickness_apical - 1, thickness_door, depth - 30, closet[(n - 2)]);

                gameObject.GetComponent<boards>().single_apical((n - 2) * each_width - thickness_riser, ((n - 2) + 1) * each_width + thickness_riser, depth - 40, depth, thickness_apical / 2, closet[(n - 2)]);
                //////////
                gameObject.GetComponent<boards>().single_riser((n - 1) * each_width + thickness_riser / 2, its_height - thickness_apical * ((n) % 2), 0, 0, depth - 40 * ((n) % 2), closet[(n - 1)]);
                gameObject.GetComponent<boards>().single_riser(((n - 1) + 1) * each_width - thickness_riser / 2, its_height - thickness_apical * (((n - 1)) % 2), 0, 0, depth - 40 * (((n - 1)) % 2), closet[(n - 1)]);

                gameObject.GetComponent<boards>().single_apical((n - 1) * each_width - thickness_riser * ((n) % 2), ((n - 1) + 1) * each_width + thickness_riser * (((n - 1)) % 2), 0, depth, its_height - thickness_apical / 2, closet[(n - 1)]);

                gameObject.GetComponent<boards>().single_plane((n - 1) * each_width + thickness_riser, ((n - 1) + 1) * each_width - thickness_riser, 0, its_height, thickness_backplane, thickness_backplane / 2, closet[(n - 1)]);

                gameObject.GetComponent<boards>().single_apical((n - 1) * each_width, ((n - 1) + 1) * each_width, thickness_backplane, depth - 40, ground_clearance - thickness_apical / 2, closet[(n - 1)]);
                gameObject.GetComponent<boards>().single_plane((n - 1) * each_width + thickness_riser, ((n - 1) + 1) * each_width - thickness_riser, 0, ground_clearance - thickness_apical, thickness_backplane, depth - thickness_backplane / 2 - 40, closet[(n - 1)]);

                gameObject.GetComponent<boards>().single_plane((n - 1) * each_width + 1 + thickness_riser - 2 * thickness_riser * ((n) % 2), ((n - 1) + 1) * each_width - 1 - thickness_riser + 2 * thickness_riser * (((n - 1)) % 2), thickness_apical + 1, its_height - thickness_apical - 1, thickness_door, depth - 30 + 20, closet[(n - 1)]);

                gameObject.GetComponent<boards>().single_apical((n - 1) * each_width - thickness_riser * ((n) % 2), ((n - 1) + 1) * each_width + thickness_riser * (((n - 1)) % 2), depth - 40, depth, thickness_apical / 2, closet[(n - 1)]);





            }
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < closet[i].transform.childCount; j++)
            {
                closet[i].transform.GetChild(j).transform.position += move;
            }
        }

        for (int i = 0; i < n; i++)
        {

            closet[i].transform.parent = itsparent.transform;

        }


        //bottom_closet.transform.parent = itsparent.transform;


    }

}
