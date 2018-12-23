using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singlebox : MonoBehaviour {




    //public int n;
    //public GameObject[] closet;


    private float thickness_riser=18 ;
    private float thickness_backplane ;
    private float thickness_door ;
    private float thickness_apical=18;
    private float ground_clearance ;



	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void single_box(float width, float each_width,float depth, float its_depth, float its_bottom, float its_top,int n,Vector3 move, GameObject its_parent)
    {
        thickness_riser = gameObject.GetComponent<basicgenerate>().thickness_riser;
        thickness_backplane = gameObject.GetComponent<basicgenerate>().thickness_backplane;
        thickness_door = gameObject.GetComponent<basicgenerate>().thickness_door;
        thickness_apical = gameObject.GetComponent<basicgenerate>().thickness_apical;
        ground_clearance = gameObject.GetComponent<basicgenerate>().ground_clearance;

        if (gameObject.GetComponent<basicgenerate>(). chosen_style == basicgenerate.door_style.swing)
        {
            GameObject[] singlecabin;
            singlecabin = new GameObject[n];



            for (int i = 0; i < n; i++)
            {
                singlecabin[i] = new GameObject("cabin_" + i);
                singlecabin[i].transform.parent = gameObject.GetComponent<basicgenerate>().cabin.transform;


            }



            its_depth -=  thickness_door + 2;
            for (int i = 0; i < n; i++)
            {
                gameObject .GetComponent<boards>(). single_riser(each_width * i + thickness_riser / 2, its_top, its_bottom, 0, its_depth, singlecabin[i]);
                gameObject.GetComponent<boards>().single_riser(each_width * (i + 1) - thickness_riser / 2, its_top, its_bottom, 0, its_depth, singlecabin[i]);

                gameObject.GetComponent<boards>().single_apical(each_width * i, each_width * (i + 1), 0, its_depth, its_bottom + thickness_apical / 2, singlecabin[i]);
                gameObject.GetComponent<boards>().single_apical(each_width * i, each_width * (i + 1), 0, its_depth, its_top - thickness_apical / 2, singlecabin[i]);

                gameObject.GetComponent<boards>().single_plane(each_width * i + thickness_riser, each_width * (i + 1) - thickness_riser, its_bottom, its_top, thickness_backplane, thickness_backplane / 2, singlecabin[i]);

                if (each_width > 650)
                {

                    gameObject.GetComponent<boards>().single_plane(each_width * i + 1, (i + 0.5f) * each_width - 1, its_bottom + 1, its_top, thickness_door, its_depth + 1 + thickness_door / 2, singlecabin[i]);
                    gameObject.GetComponent<boards>().single_plane(each_width * i + 0.5f * each_width + 1, each_width * (i + 1) - 1, its_bottom + 1, its_top, thickness_door, its_depth + 1 + thickness_door / 2, singlecabin[i]);

                    GameObject handle_a = Instantiate(gameObject.GetComponent<basicgenerate>(). handle, new Vector3(each_width * (i + 0.5f) - 30, its_bottom + 100, its_depth), Quaternion.identity);
                    GameObject handle_b = Instantiate(gameObject.GetComponent<basicgenerate>().handle, new Vector3(each_width * (i + 0.5f) + 30, its_bottom + 100, its_depth), Quaternion.identity);

                    handle_a.transform.parent = singlecabin[i].transform;
                    handle_b.transform.parent = singlecabin[i].transform;


                }
                else
                {
                    gameObject.GetComponent<boards>().single_plane(i * each_width + 1, (i + 1) * each_width - 1, its_bottom + 1, its_top, thickness_door, its_depth + 1 + thickness_door / 2, singlecabin[i]);


                    GameObject handle_a = Instantiate(gameObject.GetComponent<basicgenerate>().handle, new Vector3(each_width * i + 30, its_bottom + 100, its_depth), Quaternion.identity);

                    handle_a.transform.parent = singlecabin[i].transform;



                }


            }
            its_depth += thickness_door + 2;

        }
        else if (gameObject.GetComponent<basicgenerate>().chosen_style == basicgenerate.door_style.sliding)
        {

            GameObject[] singlecabin;
            if (1200 <= width && width <= 2200)
            {



                n = 2;
                each_width = width / 2;


            }
            singlecabin = new GameObject[n];

            for (int i = 0; i < n; i++)
            {
                singlecabin[i] = new GameObject("cabin_" + i);
                singlecabin[i].transform.parent = its_parent.transform;
            }
            if (n % 2 == 0)
            {
                for (int i = 0; i < n; i++)
                {
                    gameObject.GetComponent<boards>().single_riser(each_width * i + thickness_riser / 2, its_top - thickness_apical * (i % 2), its_bottom, 0, its_depth - 40 * (i % 2), singlecabin[i]);
                    gameObject.GetComponent<boards>().single_riser(each_width * (i + 1) - thickness_riser / 2, its_top - thickness_apical * ((i + 1) % 2), its_bottom, 0, its_depth - 40 * ((i + 1) % 2), singlecabin[i]);

                    gameObject.GetComponent<boards>().single_apical(each_width * i - thickness_riser * (i % 2), each_width * (i + 1) + thickness_riser * ((i + 1) % 2), 0, its_depth, its_top - thickness_apical / 2, singlecabin[i]);

                    gameObject.GetComponent<boards>().single_plane(each_width * i + thickness_riser, each_width * (i + 1) - thickness_riser, its_bottom, its_top, thickness_backplane, thickness_backplane / 2, singlecabin[i]);

                    gameObject.GetComponent<boards>().single_apical(each_width * i, each_width * (i + 1), thickness_backplane, its_depth - 40, its_bottom + thickness_apical / 2, singlecabin[i]);

                    gameObject.GetComponent<boards>().single_apical(each_width * i - thickness_riser * (i % 2), each_width * (i + 1) + thickness_riser * ((i + 1) % 2), its_depth - 40, its_depth, its_bottom + thickness_apical / 2, singlecabin[i]);

                    gameObject.GetComponent<boards>().single_plane(each_width * i + 1 + thickness_riser - 2 * thickness_riser * (i % 2), each_width * (i + 1) - thickness_riser + 2 * thickness_riser * ((i + 1) % 2), its_bottom + thickness_apical + 1, its_top - thickness_apical - 1, thickness_door, its_depth - 30 + i % 2 * 20, singlecabin[i]);


                    gameObject.GetComponent<boards>().single_plane(i * each_width + 1 + thickness_riser - 2 * thickness_riser * (i % 2), (i + 1) * each_width - 1 - thickness_riser + 2 * thickness_riser * ((i + 1) % 2), its_bottom + thickness_apical + 1, its_top - thickness_apical - 1, thickness_door, its_depth - 30 + i % 2 * 20, singlecabin[i]);




                }
            }
            else if (n > 2 && n % 2 == 1)
            {
                for (int i = 0; i < n - 2; i++)
                {
                    gameObject.GetComponent<boards>().single_riser(each_width * i + thickness_riser / 2, its_top - thickness_apical * (i % 2), its_bottom, 0, its_depth - 40 * (i % 2), singlecabin[i]);
                    gameObject.GetComponent<boards>().single_riser(each_width * (i + 1) - thickness_riser / 2, its_top - thickness_apical * ((i + 1) % 2), its_bottom, 0, its_depth - 40 * ((i + 1) % 2), singlecabin[i]);

                    gameObject.GetComponent<boards>().single_apical(each_width * i - thickness_riser * (i % 2), each_width * (i + 1) + thickness_riser * ((i + 1) % 2), 0, its_depth, its_top - thickness_apical / 2, singlecabin[i]);


                    gameObject.GetComponent<boards>().single_apical(each_width * i, each_width * (i + 1), thickness_backplane, its_depth - 40, its_bottom + thickness_apical / 2, singlecabin[i]);
                    gameObject.GetComponent<boards>().single_plane(each_width * i + thickness_riser, each_width * (i + 1) - thickness_riser, its_bottom + thickness_apical, its_top - thickness_apical, thickness_backplane, thickness_backplane / 2, singlecabin[i]);

                    gameObject.GetComponent<boards>().single_plane(each_width * i + 1 + thickness_riser - 2 * thickness_riser * (i % 2), each_width * (i + 1) - 1 - thickness_riser + 2 * thickness_riser * ((i + 1) % 2), its_bottom + thickness_apical + 1, its_top - thickness_apical - 1, thickness_door, its_depth - 30 + (i + 1) % 2 * 20, singlecabin[i]);
                    gameObject.GetComponent<boards>().single_apical(each_width * i - thickness_riser * (i % 2), each_width * (i + 1) + thickness_riser * ((i + 1) % 2), its_depth - 40, its_depth, its_bottom + thickness_apical / 2, singlecabin[i]);




                }
                gameObject.GetComponent<boards>().single_riser((n - 2) * each_width + thickness_riser / 2, its_top - thickness_apical, its_bottom, 0, its_depth - 40, singlecabin[n - 2]);
                gameObject.GetComponent<boards>().single_riser(((n - 2) + 1) * each_width - thickness_riser / 2, its_top - thickness_apical, its_bottom, 0, its_depth - 40, singlecabin[n - 2]);

                gameObject.GetComponent<boards>().single_apical((n - 2) * each_width - thickness_riser, ((n - 2) + 1) * each_width + thickness_riser, 0, its_depth, its_top - thickness_apical / 2, singlecabin[n - 2]);

                gameObject.GetComponent<boards>().single_plane((n - 2) * each_width + thickness_riser, ((n - 2) + 1) * each_width - thickness_riser, its_bottom, its_top, thickness_backplane, thickness_backplane / 2, singlecabin[n - 2]);

                gameObject.GetComponent<boards>().single_apical((n - 2) * each_width, ((n - 2) + 1) * each_width, thickness_backplane, its_depth, its_bottom + thickness_apical / 2, singlecabin[n - 2]);

                gameObject.GetComponent<boards>().single_plane((n - 2) * each_width + 1 + thickness_riser - 2 * thickness_riser, ((n - 2) + 1) * each_width - 1 - thickness_riser + 2 * thickness_riser * (((n - 2) + 1) % 2), its_bottom + thickness_apical + 1, its_top - thickness_apical - 1, thickness_door, its_depth - 30, singlecabin[n - 2]);

                gameObject.GetComponent<boards>().single_apical((n - 2) * each_width - thickness_riser, ((n - 2) + 1) * each_width + thickness_riser, its_depth - 40, its_depth, its_bottom + thickness_apical / 2, singlecabin[n - 2]);
                //////////
                gameObject.GetComponent<boards>().single_riser((n - 1) * each_width + thickness_riser / 2, its_top - thickness_apical * ((n) % 2), its_bottom, 0, its_depth - 40 * ((n) % 2), singlecabin[n - 1]);
                gameObject.GetComponent<boards>().single_riser(((n - 1) + 1) * each_width - thickness_riser / 2, its_top - thickness_apical * (((n - 1)) % 2), its_bottom, 0, its_depth - 40 * (((n - 1)) % 2), singlecabin[n - 1]);

                gameObject.GetComponent<boards>().single_apical((n - 1) * each_width - thickness_riser * ((n) % 2), ((n - 1) + 1) * each_width + thickness_riser * (((n - 1)) % 2), 0, its_depth, its_top - thickness_apical / 2, singlecabin[n - 1]);

                gameObject.GetComponent<boards>().single_plane((n - 1) * each_width + thickness_riser, ((n - 1) + 1) * each_width - thickness_riser, its_bottom, its_top, thickness_backplane, thickness_backplane / 2, singlecabin[n - 1]);

                gameObject.GetComponent<boards>().single_apical((n - 1) * each_width, ((n - 1) + 1) * each_width, thickness_backplane, its_depth - 40, 2400 + thickness_apical / 2, singlecabin[n - 1]);

                gameObject.GetComponent<boards>().single_plane((n - 1) * each_width + 1 + thickness_riser - 2 * thickness_riser * ((n) % 2), ((n - 1) + 1) * each_width - 1 - thickness_riser + 2 * thickness_riser * (((n - 1)) % 2), its_bottom + thickness_apical + 1, its_top - thickness_apical - 1, thickness_door, depth - 30 + 20, singlecabin[n - 1]);

                gameObject.GetComponent<boards>().single_apical((n - 1) * each_width - thickness_riser * ((n) % 2), ((n - 1) + 1) * each_width + thickness_riser * (((n - 1)) % 2), its_depth - 40, its_depth, its_bottom + thickness_apical / 2, singlecabin[n - 1]);

            }


            //for (int i = 0; i < n; i++)
            //{

            //    singlecabin[i].transform.parent = its_parent.transform;

            //    Debug.Log(its_parent);

            //}
            //its_parent.transform.position += move;

        }

        //its_parent.transform.position += new Vector3(its_left, 0, 0);
    }


}
