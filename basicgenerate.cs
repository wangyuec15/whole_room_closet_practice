using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicgenerate : MonoBehaviour
{
    public float width = 4500;
    public float height = 3000;
    public float depth = 660;

    public float thickness_riser = 18;
    public float thickness_backplane = 9;
    public float thickness_door = 18;
    public float thickness_apical = 18;

    public float ground_clearance = 60;

    public Vector3 move=Vector3.zero;
    public float rotate;
    public Material mat;

    public enum door_style { swing, sliding };


    public door_style mystyle=door_style.sliding;


    public door_style chosen_style;


    private int n;
    public GameObject equal;
    private GameObject bottom_closet;
    public GameObject[] closet;
    public  GameObject cabin;

    private float each_width;
    private object backplane;

    public GameObject handle;

    public GameObject onetime;


    void Start()
    {

        Camera.main.transform.position = new Vector3(width / 2, height / 2, height + depth);
        chosen_style = mystyle;
        handle = Resources.Load<GameObject>("handle");

    }

    void Update()
    {
        

    }

    public void vectical_split(float w)
    {
        if (chosen_style == door_style.swing)
        {
            int a = (int)(w / 900);
            int b = (int)(w / 1100);
            n = (int)Random.Range(b + 0.99f, a + 0.99f);
            each_width = w / n;
        }
        else if (chosen_style == door_style.sliding)
        {
            int a = (int)(w / 600);
            int b = (int)(w / 1000);
            n = (int)Random.Range(b + 0.99f, a + 0.99f);
            each_width = w / n;
        }
        if (n <= 0)
        {
            n = 1; each_width = w / n;
        }



    }

    public void basic_generate()
    {
        //GameObject cabin;
        cabin = new GameObject("cabin");


        chosen_style = mystyle;
        if (width < 1200)
        {
            chosen_style = door_style.swing;
        }
        vectical_split(width);


        if (height <= 2400&&height>=300)
        {
            bottom_closet = new GameObject("bottomcloset");

            gameObject .GetComponent<bottombox>().single_bottombox(width,each_width,depth,height,n,bottom_closet,move,closet);

        }else if(height>2400){
            float height_0 = 1920;
            bottom_closet = new GameObject("bottomcloset");
            gameObject.GetComponent<bottombox>().single_bottombox(width, each_width, depth,height_0,n,bottom_closet,move,closet);
            gameObject .GetComponent<singlebox>(). single_box(width,each_width,depth, depth, height_0, height,n,move, cabin);
            cabin.transform.position += move;
        }
        chosen_style = mystyle;

        equal = new GameObject("split");
        bottom_closet.transform.parent = equal.transform;
        if (bottom_closet = null) { Destroy(bottom_closet); }
        if (cabin != null)
        {
            cabin.transform.parent = equal.transform;
            //cabin.transform.position += move;
            //cabin = null;
        }
        else{
            Destroy(cabin);
        }
        equal.transform.parent = onetime.transform;
        //equal = new GameObject();
        // Debug.Log(cabin);





        //onetime.transform.Rotate(new Vector3(0, rotate, 0));


    }


    public void getitems(Material mat)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < closet[i].transform.childCount; j++)
            {
                closet[i].transform.GetChild(j).GetComponent<MeshRenderer>().material = mat;
            }
        }
    }


    //专门用来外部调用生上面的单个的柜
    public void hanging_cabin(float its_left, float its_right, float its_depth, float its_bottom, float its_top)
    {
        if(cabin==null){
            cabin = new GameObject("cabin");
        }


        if (its_right - its_left < 1200)
        {
            chosen_style = door_style.swing;
        }
        gameObject.GetComponent<singlebox>().single_box(width, each_width, depth, its_depth, its_bottom, its_top, n, move, cabin);
        cabin.transform.position += new Vector3(its_left,0,0);

        chosen_style = mystyle;

        //onetime.transform.Rotate(new Vector3(0, rotate, 0));

    }
    //public void single_bottombox(float its_height){


    //    bottom_closet = new GameObject("bottomcloset");

    //    if (chosen_style == door_style.swing)
    //    {

    //        closet = new GameObject[n];



    //        for (int i = 0; i < n; i++)
    //        {
    //            closet[i] = new GameObject("closet_" + i);

    //        }


    //        depth -= thickness_door + 2;
    //        for (int i = 0; i < n; i++)
    //        {
    //            single_riser(i * each_width + thickness_riser / 2, its_height, 0, 0, depth, closet[i]);
    //            single_riser((i + 1) * each_width - thickness_riser / 2, its_height, 0, 0, depth, closet[i]);

    //            single_apical(i * each_width, (i + 1) * each_width, 0, depth, ground_clearance - thickness_apical / 2, closet[i]);
    //            single_apical(i * each_width, (i + 1) * each_width, 0, depth, its_height - thickness_apical / 2, closet[i]);

    //            single_plane(i * each_width + thickness_riser, (i + 1) * each_width - thickness_riser, 0, its_height, thickness_backplane, thickness_backplane / 2, closet[i]);
    //            single_plane(i * each_width + thickness_riser, (i + 1) * each_width - thickness_riser, 0, ground_clearance - thickness_apical, thickness_backplane, depth - thickness_backplane / 2, closet[i]);


    //            if (each_width >= 650)
    //            {

    //                single_plane(i * each_width + 1, (i + 0.5f) * each_width - 1, ground_clearance - thickness_apical, its_height, thickness_door, depth + 1 + thickness_door / 2, closet[i]);
    //                single_plane((i + 0.5f) * each_width + 1, (i + 1) * each_width - 1, ground_clearance - thickness_apical, its_height, thickness_door, depth + 1 + thickness_door / 2, closet[i]);


    //                GameObject handle_a = Instantiate(handle, new Vector3(each_width * (i + 0.5f) - 30, 1100, depth), Quaternion.identity);
    //                GameObject handle_b = Instantiate(handle, new Vector3(each_width * (i + 0.5f) + 30, 1100, depth), Quaternion.identity);

    //                handle_a.transform.parent = closet[i].transform;
    //                handle_b.transform.parent = closet[i].transform;



    //                if (its_height <= 1300)
    //                {
    //                    handle_a.transform.position -= new Vector3(0, 1300 - its_height, 0);
    //                    handle_b.transform.position -= new Vector3(0, 1300 - its_height, 0);

    //                }

    //            }else{
    //                single_plane(i * each_width + 1, (i + 1) * each_width - 1, ground_clearance - thickness_apical, its_height, thickness_door, depth + 1 + thickness_door / 2, closet[i]);


    //                GameObject handle_a = Instantiate(handle, new Vector3(each_width * i + 30, 1100, depth), Quaternion.identity);
    //                handle_a.transform.parent = closet[i].transform;
    //                if (its_height <= 1300)
    //                {
    //                    handle_a.transform.position -= new Vector3(0, 1300 - its_height, 0);

    //                }

    //            }



    //        }
    //        depth += thickness_door + 2;


    //    }
    //    else if (chosen_style == door_style.sliding)
    //    {
    //        if (1200 <= width && width <= 2200)
    //        {


    //            n = 2;
    //            each_width = width / 2;

    //            closet = new GameObject[n];


    //        }
    //        for (int i = 0; i < n; i++)
    //        {
    //            closet[i] = new GameObject("closet_" + i);


    //        }
    //        if (n % 2 == 0)
    //        {
    //            for (int i = 0; i < n; i++)
    //            {
    //                single_riser(i * each_width + thickness_riser / 2, its_height - thickness_apical * (i % 2), 0, 0, depth - 40 * (i % 2), closet[i]);
    //                single_riser((i + 1) * each_width - thickness_riser / 2, its_height - thickness_apical * ((i + 1) % 2), 0, 0, depth - 40 * ((i + 1) % 2), closet[i]);

    //                single_apical(i * each_width - thickness_riser * (i % 2), (i + 1) * each_width + thickness_riser * ((i + 1) % 2), 0, depth, its_height - thickness_apical / 2, closet[i]);

    //                single_plane(i * each_width + thickness_riser, (i + 1) * each_width - thickness_riser, 0, its_height, thickness_backplane, thickness_backplane / 2, closet[i]);

    //                single_apical(i * each_width, (i + 1) * each_width, thickness_backplane, depth - 40, ground_clearance - thickness_apical / 2, closet[i]);

    //                single_plane(i * each_width + 1 + thickness_riser - 2 * thickness_riser * (i % 2), (i + 1) * each_width - 1 - thickness_riser + 2 * thickness_riser * ((i + 1) % 2), thickness_apical + 1, its_height - thickness_apical - 1, thickness_door, depth - 30 + i % 2 * 20, closet[i]);
    //                single_apical(i * each_width - thickness_riser * (i % 2), (i + 1) * each_width + thickness_riser * ((i + 1) % 2), depth - 40, depth, thickness_apical / 2, closet[i]);




    //            }
    //        }
    //        else if (n > 2 && n % 2 == 1)
    //        {
    //            for (int i = 0; i < n - 2; i++)
    //            {
    //                single_riser(i * each_width + thickness_riser / 2, its_height - thickness_apical * (i % 2), 0, 0, depth - 40 * (i % 2), closet[i]);
    //                single_riser((i + 1) * each_width - thickness_riser / 2, its_height - thickness_apical * ((i + 1) % 2), 0, 0, depth - 40 * ((i + 1) % 2), closet[i]);

    //                single_apical(i * each_width - thickness_riser * (i % 2), (i + 1) * each_width + thickness_riser * ((i + 1) % 2), 0, depth, its_height - thickness_apical / 2, closet[i]);

    //                single_plane(i * each_width + thickness_riser, (i + 1) * each_width - thickness_riser, 0, its_height, thickness_backplane, thickness_backplane / 2, closet[i]);

    //                single_apical(i * each_width, (i + 1) * each_width, thickness_backplane, depth - 40, ground_clearance - thickness_apical / 2, closet[i]);
    //                single_plane(i * each_width + thickness_riser, (i + 1) * each_width - thickness_riser, 0, ground_clearance - thickness_apical, thickness_backplane, depth - thickness_backplane / 2 - 40, closet[i]);

    //                single_plane(i * each_width + 1 + thickness_riser - 2 * thickness_riser * (i % 2), (i + 1) * each_width - 1 - thickness_riser + 2 * thickness_riser * ((i + 1) % 2), thickness_apical + 1, its_height - thickness_apical - 1, thickness_door, depth - 30 + (i + 1) % 2 * 20, closet[i]);
    //                single_apical(i * each_width - thickness_riser * (i % 2), (i + 1) * each_width + thickness_riser * ((i + 1) % 2), depth - 40, depth, thickness_apical / 2, closet[i]);




    //            }
    //            single_riser((n - 2) * each_width + thickness_riser / 2, its_height - thickness_apical, 0, 0, depth - 40, closet[(n - 2)]);
    //            single_riser(((n - 2) + 1) * each_width - thickness_riser / 2, its_height - thickness_apical, 0, 0, depth - 40, closet[(n - 2)]);

    //            single_apical((n - 2) * each_width - thickness_riser, ((n - 2) + 1) * each_width + thickness_riser, 0, depth, its_height - thickness_apical / 2, closet[(n - 2)]);

    //            single_plane((n - 2) * each_width + thickness_riser, ((n - 2) + 1) * each_width - thickness_riser, 0, its_height, thickness_backplane, thickness_backplane / 2, closet[(n - 2)]);

    //            single_apical((n - 2) * each_width, ((n - 2) + 1) * each_width, thickness_backplane, depth - 40, ground_clearance - thickness_apical / 2, closet[(n - 2)]);
    //            single_plane((n - 2) * each_width + thickness_riser, ((n - 2) + 1) * each_width - thickness_riser, 0, ground_clearance - thickness_apical, thickness_backplane, depth - thickness_backplane / 2 - 40, closet[(n - 2)]);

    //            single_plane((n - 2) * each_width + 1 + thickness_riser - 2 * thickness_riser, ((n - 2) + 1) * each_width - 1 - thickness_riser + 2 * thickness_riser * (((n - 2) + 1) % 2), thickness_apical + 1, its_height - thickness_apical - 1, thickness_door, depth - 30, closet[(n - 2)]);

    //            single_apical((n - 2) * each_width - thickness_riser, ((n - 2) + 1) * each_width + thickness_riser, depth - 40, depth, thickness_apical / 2, closet[(n - 2)]);
    //            //////////
    //            single_riser((n - 1) * each_width + thickness_riser / 2, its_height - thickness_apical * ((n) % 2), 0, 0, depth - 40 * ((n) % 2), closet[(n - 1)]);
    //            single_riser(((n - 1) + 1) * each_width - thickness_riser / 2, its_height - thickness_apical * (((n - 1)) % 2), 0, 0, depth - 40 * (((n - 1)) % 2), closet[(n - 1)]);

    //            single_apical((n - 1) * each_width - thickness_riser * ((n) % 2), ((n - 1) + 1) * each_width + thickness_riser * (((n - 1)) % 2), 0, depth, its_height - thickness_apical / 2, closet[(n - 1)]);

    //            single_plane((n - 1) * each_width + thickness_riser, ((n - 1) + 1) * each_width - thickness_riser, 0, its_height, thickness_backplane, thickness_backplane / 2, closet[(n - 1)]);

    //            single_apical((n - 1) * each_width, ((n - 1) + 1) * each_width, thickness_backplane, depth - 40, ground_clearance - thickness_apical / 2, closet[(n - 1)]);
    //            single_plane((n - 1) * each_width + thickness_riser, ((n - 1) + 1) * each_width - thickness_riser, 0, ground_clearance - thickness_apical, thickness_backplane, depth - thickness_backplane / 2 - 40, closet[(n - 1)]);

    //            single_plane((n - 1) * each_width + 1 + thickness_riser - 2 * thickness_riser * ((n) % 2), ((n - 1) + 1) * each_width - 1 - thickness_riser + 2 * thickness_riser * (((n - 1)) % 2), thickness_apical + 1, its_height - thickness_apical - 1, thickness_door, depth - 30 + 20, closet[(n - 1)]);

    //            single_apical((n - 1) * each_width - thickness_riser * ((n) % 2), ((n - 1) + 1) * each_width + thickness_riser * (((n - 1)) % 2), depth - 40, depth, thickness_apical / 2, closet[(n - 1)]);





    //        }
    //    }
    //    for (int i = 0; i < n; i++)
    //    {
    //        for (int j = 0; j < closet[i].transform.childCount; j++)
    //        {
    //            closet[i].transform.GetChild(j).transform.position+= move;
    //        }
    //    }

    //    for (int i = 0; i < n;i++){

    //        closet[i].transform.parent = bottom_closet.transform;

    //    }





    //}





    //生成上面的单柜
    //public void single_box(float its_left,float its_right,float its_depth,float its_bottom,float its_top,GameObject its_parent){

    //    if (chosen_style == door_style.swing)
    //    {

    //        GameObject[] singlecabin;
    //        singlecabin = new GameObject[n];



    //        for (int i = 0; i < n; i++)
    //        {
    //            singlecabin[i] = new GameObject("cabin_" + i);

    //        }



    //        its_depth -= thickness_door + 2;
    //        for (int i = 0; i < n; i++)
    //        {
    //            single_riser(each_width * i + thickness_riser / 2, its_top, its_bottom, 0, its_depth, singlecabin[i]);
    //            single_riser(each_width * (i + 1) - thickness_riser / 2, its_top, its_bottom, 0, its_depth, singlecabin[i]);

    //            single_apical(each_width * i, each_width * (i + 1), 0, its_depth, its_bottom + thickness_apical / 2, singlecabin[i]);
    //            single_apical(each_width * i, each_width * (i + 1), 0, its_depth, its_top - thickness_apical / 2, singlecabin[i]);

    //            single_plane(each_width * i + thickness_riser, each_width * (i + 1) - thickness_riser, its_bottom, its_top, thickness_backplane, thickness_backplane / 2, singlecabin[i]);

    //            if (each_width > 650)
    //            {

    //                single_plane(each_width * i + 1, (i + 0.5f) * each_width - 1, its_bottom + 1, its_top, thickness_door, its_depth + 1 + thickness_door / 2, singlecabin[i]);
    //                single_plane(each_width * i + 0.5f * each_width + 1, each_width * (i + 1) - 1, its_bottom + 1, its_top, thickness_door, its_depth + 1 + thickness_door / 2, singlecabin[i]);

    //                GameObject handle_a = Instantiate(handle, new Vector3(each_width * (i + 0.5f) - 30, its_bottom + 100, its_depth), Quaternion.identity);
    //                GameObject handle_b = Instantiate(handle, new Vector3(each_width * (i + 0.5f) + 30, its_bottom + 100, its_depth), Quaternion.identity);

    //                handle_a.transform.parent = singlecabin[i].transform;
    //                handle_b.transform.parent = singlecabin[i].transform;


    //            }
    //            else
    //            {
    //                single_plane(i * each_width + 1, (i + 1) * each_width - 1, its_bottom + 1, its_top, thickness_door, its_depth + 1 + thickness_door / 2, singlecabin[i]);


    //                GameObject handle_a = Instantiate(handle, new Vector3(each_width * i + 30, its_bottom + 100, its_depth), Quaternion.identity);

    //                handle_a.transform.parent = singlecabin[i].transform;



    //            }


    //        }
    //        its_depth += thickness_door + 2;

    //    }
    //    else if (chosen_style == door_style.sliding)
    //    {
    //        GameObject[] singlecabin;
    //        if (1200 <= width && width <= 2200)
    //        {



    //            n = 2;
    //            each_width = width / 2;


    //        }
    //        singlecabin = new GameObject[n];

    //        for (int i = 0; i < n; i++)
    //        {
    //            singlecabin[i] = new GameObject("cabin_" + i);
    //            singlecabin[i].transform.parent = cabin.transform;
    //        }
    //        if (n % 2 == 0)
    //        {
    //            for (int i = 0; i < n; i++)
    //            {
    //                single_riser(each_width * i + thickness_riser / 2, its_top - thickness_apical * (i % 2), its_bottom, 0, its_depth - 40 * (i % 2), singlecabin[i]);
    //                single_riser(each_width * (i + 1) - thickness_riser / 2, its_top - thickness_apical * ((i + 1) % 2), its_bottom, 0, its_depth - 40 * ((i + 1) % 2), singlecabin[i]);

    //                single_apical(each_width * i - thickness_riser * (i % 2), each_width * (i + 1) + thickness_riser * ((i + 1) % 2), 0, its_depth, its_top - thickness_apical / 2, singlecabin[i]);

    //                single_plane(each_width * i + thickness_riser, each_width * (i + 1) - thickness_riser, its_bottom, its_top, thickness_backplane, thickness_backplane / 2, singlecabin[i]);

    //                single_apical(each_width * i, each_width * (i + 1), thickness_backplane, its_depth - 40, its_bottom + thickness_apical / 2, singlecabin[i]);

    //                single_apical(each_width * i - thickness_riser * (i % 2), each_width * (i + 1) + thickness_riser * ((i + 1) % 2), its_depth - 40, its_depth, its_bottom + thickness_apical / 2, singlecabin[i]);

    //                single_plane(each_width * i + 1 + thickness_riser - 2 * thickness_riser * (i % 2), each_width * (i + 1) - thickness_riser + 2 * thickness_riser * ((i + 1) % 2), its_bottom + thickness_apical + 1, its_top - thickness_apical - 1, thickness_door, its_depth - 30 + i % 2 * 20, singlecabin[i]);


    //                single_plane(i * each_width + 1 + thickness_riser - 2 * thickness_riser * (i % 2), (i + 1) * each_width - 1 - thickness_riser + 2 * thickness_riser * ((i + 1) % 2), its_bottom + thickness_apical + 1, its_top - thickness_apical - 1, thickness_door, its_depth - 30 + i % 2 * 20, singlecabin[i]);




    //            }
    //        }
    //        else if (n > 2 && n % 2 == 1)
    //        {
    //            for (int i = 0; i < n - 2; i++)
    //            {
    //                single_riser(each_width * i + thickness_riser / 2, its_top - thickness_apical * (i % 2), its_bottom, 0, its_depth - 40 * (i % 2), singlecabin[i]);
    //                single_riser(each_width * (i + 1) - thickness_riser / 2, its_top - thickness_apical * ((i + 1) % 2), its_bottom, 0, its_depth - 40 * ((i + 1) % 2), singlecabin[i]);

    //                single_apical(each_width * i - thickness_riser * (i % 2), each_width * (i + 1) + thickness_riser * ((i + 1) % 2), 0, its_depth, its_top - thickness_apical / 2, singlecabin[i]);


    //                single_apical(each_width * i, each_width * (i + 1), thickness_backplane, its_depth - 40, its_bottom + thickness_apical / 2, singlecabin[i]);
    //                single_plane(each_width * i + thickness_riser, each_width * (i + 1) - thickness_riser, its_bottom + thickness_apical, its_top - thickness_apical, thickness_backplane, thickness_backplane / 2, singlecabin[i]);

    //                single_plane(each_width * i + 1 + thickness_riser - 2 * thickness_riser * (i % 2), each_width * (i + 1) - 1 - thickness_riser + 2 * thickness_riser * ((i + 1) % 2), its_bottom + thickness_apical + 1, its_top - thickness_apical - 1, thickness_door, its_depth - 30 + (i + 1) % 2 * 20, singlecabin[i]);
    //                single_apical(each_width * i - thickness_riser * (i % 2), each_width * (i + 1) + thickness_riser * ((i + 1) % 2), its_depth - 40, its_depth, its_bottom + thickness_apical / 2, singlecabin[i]);




    //            }
    //            single_riser((n - 2) * each_width + thickness_riser / 2, its_top - thickness_apical, its_bottom, 0, its_depth - 40, singlecabin[n - 2]);
    //            single_riser(((n - 2) + 1) * each_width - thickness_riser / 2, its_top - thickness_apical, its_bottom, 0, its_depth - 40, singlecabin[n - 2]);

    //            single_apical((n - 2) * each_width - thickness_riser, ((n - 2) + 1) * each_width + thickness_riser, 0, its_depth, its_top - thickness_apical / 2, singlecabin[n - 2]);

    //            single_plane((n - 2) * each_width + thickness_riser, ((n - 2) + 1) * each_width - thickness_riser, its_bottom, its_top, thickness_backplane, thickness_backplane / 2, singlecabin[n - 2]);

    //            single_apical((n - 2) * each_width, ((n - 2) + 1) * each_width, thickness_backplane, its_depth, its_bottom + thickness_apical / 2, singlecabin[n - 2]);

    //            single_plane((n - 2) * each_width + 1 + thickness_riser - 2 * thickness_riser, ((n - 2) + 1) * each_width - 1 - thickness_riser + 2 * thickness_riser * (((n - 2) + 1) % 2), its_bottom + thickness_apical + 1, its_top - thickness_apical - 1, thickness_door, its_depth - 30, singlecabin[n - 2]);

    //            single_apical((n - 2) * each_width - thickness_riser, ((n - 2) + 1) * each_width + thickness_riser, its_depth - 40, its_depth, its_bottom + thickness_apical / 2, singlecabin[n - 2]);
    //            //////////
    //            single_riser((n - 1) * each_width + thickness_riser / 2, its_top - thickness_apical * ((n) % 2), its_bottom, 0, its_depth - 40 * ((n) % 2), singlecabin[n - 1]);
    //            single_riser(((n - 1) + 1) * each_width - thickness_riser / 2, its_top - thickness_apical * (((n - 1)) % 2), its_bottom, 0, its_depth - 40 * (((n - 1)) % 2), singlecabin[n - 1]);

    //            single_apical((n - 1) * each_width - thickness_riser * ((n) % 2), ((n - 1) + 1) * each_width + thickness_riser * (((n - 1)) % 2), 0, its_depth, its_top - thickness_apical / 2, singlecabin[n - 1]);

    //            single_plane((n - 1) * each_width + thickness_riser, ((n - 1) + 1) * each_width - thickness_riser, its_bottom, its_top, thickness_backplane, thickness_backplane / 2, singlecabin[n - 1]);

    //            single_apical((n - 1) * each_width, ((n - 1) + 1) * each_width, thickness_backplane, its_depth - 40, 2400 + thickness_apical / 2, singlecabin[n - 1]);

    //            single_plane((n - 1) * each_width + 1 + thickness_riser - 2 * thickness_riser * ((n) % 2), ((n - 1) + 1) * each_width - 1 - thickness_riser + 2 * thickness_riser * (((n - 1)) % 2), its_bottom + thickness_apical + 1, its_top - thickness_apical - 1, thickness_door, depth - 30 + 20, singlecabin[n - 1]);

    //            single_apical((n - 1) * each_width - thickness_riser * ((n) % 2), ((n - 1) + 1) * each_width + thickness_riser * (((n - 1)) % 2), its_depth - 40, its_depth, its_bottom + thickness_apical / 2, singlecabin[n - 1]);

    //        }


    //        for (int i = 0; i < n; i++)
    //        {

    //            singlecabin[i].transform.parent = its_parent.transform;
    //        }

    //    }

    //    its_parent.transform.position += new Vector3(its_left, 0, 0);
    //    its_parent.transform.position += move;
    //}




    //基础板件生成

    //public void single_pole(float its_left, float its_right, float its_height, GameObject set_parent)
    //{
    //    GameObject pole = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
    //    pole.transform.Rotate(0, 0, 90);
    //    pole.transform.position = new Vector3((its_right + its_left) / 2, its_height, depth / 2);
    //    pole.transform.parent = set_parent.transform;
    //    pole.GetComponent<Transform>().localScale = new Vector3(2, (its_right - its_left) / 2, 2);
    //}


    //public void single_apical(float its_left, float its_right, float far, float near, float its_height, GameObject parent)
    //{
    //    GameObject apical = GameObject.CreatePrimitive(PrimitiveType.Cube);
    //    apical.transform.position = new Vector3((its_right + its_left) / 2, its_height, near / 2 + far / 2);
    //    apical.GetComponent<Transform>().localScale = new Vector3(its_right - its_left - 2 * thickness_riser, thickness_apical, near - far);
    //    apical.transform.parent = parent.transform;
    //}
    //public void single_riser(float x_pos, float top, float bottom, float far, float near, GameObject parent)
    //{
    //    GameObject riser = GameObject.CreatePrimitive(PrimitiveType.Cube);
    //    riser.transform.position = new Vector3(x_pos, top / 2 + bottom / 2, near / 2 + far / 2);
    //    riser.GetComponent<Transform>().localScale = new Vector3(thickness_riser, top - bottom, near - far);
    //    riser.transform.parent = parent.transform;
    //}

    //public void single_plane(float left, float right, float bottom, float top, float thick, float z, GameObject parent)
    //{
    //    GameObject riser = GameObject.CreatePrimitive(PrimitiveType.Cube);
    //    riser.transform.position = new Vector3((left + right) / 2, (bottom + top) / 2, z);
    //    riser.GetComponent<Transform>().localScale = new Vector3((right - left), (top - bottom), thick);
    //    riser.transform.parent = parent.transform;
    //}
}
