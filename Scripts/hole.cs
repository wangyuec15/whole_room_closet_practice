using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hole : MonoBehaviour
{
    public float x_left = 1500;
    public float x_right = 3000;
    public float y_bottom = 900;
    public float y_top = 2200;


    private float height;
    private float width;
    private float depth;



    public Vector3 offset = Vector3.zero;

    // Use this for initialization
    void Start()
    {

        //make_wall();
        //isolate_cabin(x_left, x_right, y_top, height);

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void make_wall(){

        height = gameObject.GetComponent<basicgenerate>().height;
        width = gameObject.GetComponent<basicgenerate>().width;
        depth = gameObject.GetComponent<basicgenerate>().depth;


        if (0 <= x_left && x_left < x_right && x_right <= width && 0 <= y_bottom && y_bottom < y_top && y_top <= height)
        {
            if (x_left < 300 && x_left != 0) { isolate_cabin(0, x_left, y_bottom, y_top); x_left = 0; }
            if (width - x_right < 300 && x_right != width) { isolate_cabin(x_right, width, y_bottom, y_top); x_right = width; }



            make_hole();

        }
        else
        {
            gameObject.GetComponent<basicgenerate>().onetime = new GameObject();

            gameObject.GetComponent<basicgenerate>().move = Vector3.zero+offset;

            gameObject.GetComponent<basicgenerate>().basic_generate();
        }




    }




    public void make_hole()
    {
        gameObject.GetComponent<basicgenerate>().onetime = new GameObject();

        if (x_left != 0)
        {
            gameObject.GetComponent<basicgenerate>().move = Vector3.zero+offset;
            gameObject.GetComponent<basicgenerate>().width = x_left;
            gameObject.GetComponent<basicgenerate>().basic_generate();
            gameObject.GetComponent<basicgenerate>().width = width;
        }
        //

        if (y_bottom > 300)
        {
            gameObject.GetComponent<basicgenerate>().move = new Vector3(x_left, 0, 0)+offset;
            gameObject.GetComponent<basicgenerate>().width = x_right - x_left;
            gameObject.GetComponent<basicgenerate>().height = y_bottom;
            gameObject.GetComponent<basicgenerate>().basic_generate();
            gameObject.GetComponent<basicgenerate>().height = height;
            gameObject.GetComponent<basicgenerate>().width = width;
        }else{
            gameObject.GetComponent<basicgenerate>().equal = new GameObject("split");
            gameObject.GetComponent<basicgenerate>().equal.transform.parent = gameObject.GetComponent<basicgenerate>().onetime.transform;
            gameObject.GetComponent<basicgenerate>().cabin = new GameObject("cabin");

        }


        if (y_top <= height - 300)
        {
            isolate_cabin(x_left, x_right, y_top, height);
            gameObject.GetComponent<basicgenerate>().cabin.transform.parent = gameObject.GetComponent<basicgenerate>().equal.transform;
        }
        //





        if (x_right != width)
        {
            gameObject.GetComponent<basicgenerate>().move = new Vector3(x_right, 0, 0)+offset;
            gameObject.GetComponent<basicgenerate>().width = width - x_right;
            gameObject.GetComponent<basicgenerate>().basic_generate();
            gameObject.GetComponent<basicgenerate>().width = width;
        }


    }

    public void isolate_cabin(float l, float r, float b, float t)
    {

        gameObject.GetComponent<basicgenerate>().move = Vector3.zero+offset;
        gameObject.GetComponent<basicgenerate>().width = x_right - x_left;
        gameObject.GetComponent<basicgenerate>().vectical_split(x_right-x_left);

        gameObject.GetComponent<basicgenerate>().hanging_cabin(l, r, depth, b, t);
        gameObject.GetComponent<basicgenerate>().width = width;
    }


}
