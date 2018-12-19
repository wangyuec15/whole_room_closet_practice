using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class drawline : MonoBehaviour
{

    public Vector3[] room_outline;
    public int n = 9;
    public float[] length;
    public float[] angel;

    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        offset = new Vector3(gameObject.GetComponent<cornercloset>().w1, 0, 0);
        room_outline = new Vector3[n];
        length = new float[n];
        angel = new float[n];
        for (int i = 0; i < n;i++){
            room_outline[i] = new Vector3();
        }
        set();
        line();
        corner();

        generlize();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void set()
    {

        room_outline[0] = new Vector3(0, 0, 0);
        room_outline[1] = new Vector3(6000, 0, 0);
        room_outline[2] = new Vector3(6000, 0, 4000);
        room_outline[3] = new Vector3(8000, 0, 4000);
        room_outline[4] = new Vector3(8000, 0, 12000);
        room_outline[5] = new Vector3(2000, 0, 12000);
        room_outline[6] = new Vector3(2000, 0, 8000);
        room_outline[7] = new Vector3(0, 0, 8000);
    }


    public void line()
    {
        for (int i = 0; i < n; i++)
        {
            //int x, y;
            //if (i == 0)
            //{
            //    length[i] = Vector3.Distance(room_outline[i], room_outline[i + 1]);
            //    angel[i] = Vector3.Angle(room_outline[0] - room_outline[n-1],Vector3.right  /*room_outline[i] - room_outline[n - 1]*/);
            //}
            //else
                if (i < n-1 )
            {
                length[i] = Vector3.Distance(room_outline[i], room_outline[i + 1])-2*offset.x ;//-gameObject.GetComponent<basicgenerate>().depth;
                angel[i] = Vector3.Angle(room_outline[i ] - room_outline[i+1],Vector3.forward/*, room_outline[i] - room_outline[i - 1]*/);

                if (room_outline[i].x - room_outline[i + 1].x < 0)
                {
                    angel[i] = -90f;
                    //length[i] += gameObject.GetComponent<basicgenerate>().depth;
                }


            if (angel[i]==0 && angel[i + 1]==90)
                {
                    length[i] += gameObject.GetComponent<basicgenerate>().depth;
                }



                //if (room_outline[i].x*room_outline[i+1].x+room_outline[i].y * room_outline[i + 1].y+room_outline[i].z * room_outline[i + 1].z<0) { angel[i] -= 180f; }
            }
            else
            {
                length[i] = Vector3.Distance(room_outline[i], room_outline[0])-2*offset.x;//gameObject.GetComponent<basicgenerate>().depth-
                angel[i] = Vector3.Angle(room_outline[i] - room_outline[0],Vector3.forward/* room_outline[i] - room_outline[i - 1]*/);
               // if (room_outline[i].x * room_outline[0].x + room_outline[i].y * room_outline[0].y + room_outline[i].z * room_outline[0].z < 0) { angel[i] -= 180f; }
            
                if (room_outline[i].x - room_outline[0].x < 0) angel[i] = -90f;



            if (angel[i] ==0 && angel[0] ==90)
                {
                    length[i] += gameObject.GetComponent<basicgenerate>().depth;
                }
            
            }


        }

    }



    public void generlize()
    {
        for (int i = 0; i < n; i++)
        {

            if (i > 0)
            {
                if (angel[i] - angel[i - 1] == 90f || angel[i] - angel[i - 1] == -270)
                {
                    gameObject.GetComponent<hole>().offset = Vector3.zero;
                    length[i] += gameObject.GetComponent<cornercloset>().w1;
                }
                else
                {
                    gameObject.GetComponent<hole>().offset = new Vector3(gameObject.GetComponent<cornercloset>().w1, 0, 0);
                }
            }
            else if (i == 0)
            {
                if (angel[0] - angel[n - 1] == 90f || angel[0] - angel[n - 1] == -270)
                {
                    gameObject.GetComponent<hole>().offset = Vector3.zero;
                    length[i] += gameObject.GetComponent<cornercloset>().w1;
                }
                else
                {
                    gameObject.GetComponent<hole>().offset = new Vector3(gameObject.GetComponent<cornercloset>().w1, 0, 0);
                }

            }



            gameObject.GetComponent<basicgenerate>().width = length[i];

            gameObject.GetComponent<hole>().make_wall();

            Vector3 pos = gameObject.GetComponent<basicgenerate>().onetime.transform.position;
            gameObject.GetComponent<basicgenerate>().onetime.transform.Translate(room_outline[i]);
            gameObject.GetComponent<basicgenerate>().onetime.transform.Rotate(new Vector3(0, angel[i]+90, 0));


        }


    }
    public void corner()
    {
        for (int i = 0; i < n; i++)
        {
            if (i > 0)
            {
                if (angel[i] - angel[i - 1] == 90f || angel[i] - angel[i - 1] == -270)
                {
                    length[i - 1] += offset.x +gameObject.GetComponent<basicgenerate>().depth;

                    //gameObject.GetComponent<cornercloset>().create(room_outline[i] + offset, new Vector3(0, angel[i] + 180, 0));
                }else{
                    gameObject.GetComponent<cornercloset>().create(room_outline[i] + offset, new Vector3(0, angel[i] + 90, 0));

                }
            }else if(i==0){
                if (angel[0] - angel[n - 1] == 90f || angel[0] - angel[n - 1] == -270)
                {
                    
                    length[n - 1] += offset.x + gameObject.GetComponent<basicgenerate>().depth;


                    //gameObject.GetComponent<cornercloset>().create(room_outline[i] + offset, new Vector3(0, angel[i] + 180, 0));
                }
                else{
                    gameObject.GetComponent<cornercloset>().create(room_outline[i] + offset, new Vector3(0, angel[i] + 90, 0));

                }
            }
        }
    }

}
