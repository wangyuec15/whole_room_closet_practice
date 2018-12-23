using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class drawline : MonoBehaviour
{

    public Vector3[] room_outline;
    public int room_amount;

    public int n;
    private float[] length;
    public float[] closet_length;
    public float[] angel;
    public float[] turn;

    private Vector3[] offset;
    private float w1;
    private float depth;
    private Vector4[] hole;

    // Use this for initialization
    void Start()
    {

    }


    public void eachroom()
    {

        room_amount = gameObject.GetComponent<JsonTest>().room_amount;
        depth = gameObject.GetComponent<basicgenerate>().depth;
        w1 = gameObject.GetComponent<cornercloset>().w1;


        for (int i = 0; i < room_amount; i++)
        {
            set(i);
            setaroom(i);


            findawindow(i);

        //    gameObject.GetComponent<morehole>().holeinfo = wallhole;
        //gameObject.GetComponent<morehole>().holeamount = wallhole.Length;



            set_turn();
            line();
            //sethole();

            int q = 0;

            for (int j = 0; j < n; j++)
            {
                if (length[j] > 10)
                    q += 1;

                Debug.Log(hole[j]);
            }
            if (q == n)
            {

                generate();
            }
        }
    }


    public void set(int i)
    {
        int wallamount = gameObject.GetComponent<JsonTest>().corners[i].Length;
        n = wallamount;
        Debug.Log(n);
        room_outline = new Vector3[n];

        for (int j = 0; j < n; j++)
        {
            room_outline[j] = gameObject.GetComponent<JsonTest>().corners[i][j];
        }
    }

    void setaroom(int i)
    {

        offset = new Vector3[n];
        length = new float[n];
        closet_length = new float[n];
        turn = new float[n];
        angel = new float[n];
        hole = new Vector4[n];
    }


    void findawindow(int i)
    {

        gameObject.GetComponent<JsonTest>().getwindows(i);
        int windowamount = gameObject.GetComponent<JsonTest>().windows_amount;

        Vector2 p1, p2 = new Vector2();


        for (int j = 0; j < windowamount; j++)
        {
            p1 = gameObject.GetComponent<JsonTest>().windows[j][0];
            p2 = gameObject.GetComponent<JsonTest>().windows[j][1];

            float d1=-1;
            float d2=-1;


            int point=-1;


            if (p1.x == p2.x)
            {

                for (int k = 0; k < n - 1; k++)
                {
                    if (k < n - 1 && Mathf.Abs(room_outline[k].x - p1.x) <= 200 && Mathf.Abs(room_outline[k + 1].x - p1.x) <= 200 || k == n - 1 && Mathf.Abs(room_outline[k].x - p1.x) <= 200 && Mathf.Abs(room_outline[0].x - p1.x) <= 200)
                    {
                        point = k;
                        // di k mian qiang shang you zhe ge dong 
                    }
                }

                if (point != -1)
                {

                    d1 = Mathf.Min(Mathf.Abs(room_outline[point].y - p1.y), (Mathf.Abs(room_outline[point].y - p2.y)));
                    d2 = Mathf.Max(Mathf.Abs(room_outline[point].y - p1.y), (Mathf.Abs(room_outline[point].y - p2.y)));
                }
                if (d1 != -1)
                {
                    hole[point] = new Vector4(d1, d2, gameObject.GetComponent<JsonTest>().z[j], gameObject.GetComponent<JsonTest>().w[j]);
                }


            }
            else if (p1.y == p2.y)
            {
                for (int k = 0; k < n - 1; k++)
                {
                    if (k < n - 1 && Mathf.Abs(room_outline[k].y - p1.y) <= 200 && Mathf.Abs(room_outline[k + 1].y - p1.y) <= 200 || k == n - 1 && Mathf.Abs(room_outline[k].y - p1.y) <= 200 && Mathf.Abs(room_outline[0].y - p1.y) <= 200)
                    {
                        point = k;
                    }
                }
                if (point != -1)
                {
                    d1 = Mathf.Min(Mathf.Abs(room_outline[point].x - p1.x), (Mathf.Abs(room_outline[point].x - p2.x)));
                    d2 = Mathf.Max(Mathf.Abs(room_outline[point].x - p1.x), (Mathf.Abs(room_outline[point].x - p2.x)));
                }
                if (d1 != -1)
                {
                    hole[point] = new Vector4(d1, d2, gameObject.GetComponent<JsonTest>().z[j], gameObject.GetComponent<JsonTest>().w[j]);
                }


            }else{
                d1 = 1f;
                d2 = 1f;
            }

                //hole[point] = new Vector4(d1, d2, gameObject.GetComponent<JsonTest>().z[j], gameObject.GetComponent<JsonTest>().w[j]);
            point = -1;
            d1 = -1;
            d2 = -1;

        }
    }





















    // Update is called once per frame
    void Update()
    {

    }
    public void sethole()
    {

        Vector4[] wallhole;
        wallhole = new Vector4[2];
        //wallhole =[new Vector4(2400, 3600, 0, 1900),new Vector4(4400, 4900, 900, 2200)];
        wallhole[0] =new Vector4(2400, 3600, 0, 1900);
        wallhole[1] =new Vector4(4400, 4900, 900, 2200);


        gameObject.GetComponent<morehole>().holeinfo = wallhole;
        gameObject.GetComponent<morehole>().holeamount = wallhole.Length;

    }



    public void SignedAngleBetween(Vector3 a, Vector3 b, Vector3 n, int i)
    {
        float angle = Vector3.Angle(a, b);
        float sign = Mathf.Sign(Vector3.Dot(n, Vector3.Cross(a, b)));
        float signed_angle = angle * sign;
        turn[i] = (signed_angle <= 0) ? 360 + signed_angle : signed_angle;
        //270直角 90优角
    }


    public void set_turn()
    {
        for (int i = 0; i < n; i++)
        {
            if (i == 0)
            {
                SignedAngleBetween(room_outline[i] - room_outline[n - 1], room_outline[i + 1] - room_outline[i], Vector3.up, i);
            }
            else if (i == n - 1)
            {
                SignedAngleBetween(room_outline[i] - room_outline[i - 1], room_outline[0] - room_outline[i], Vector3.up, i);
            }
            else
            {
                SignedAngleBetween(room_outline[i] - room_outline[i - 1], room_outline[i + 1] - room_outline[i], Vector3.up, i);

            }


        }
    }


    public void line()
    {
        for (int i = 0; i < n; i++)
        {
            if (i < n - 1)
            {
                length[i] = Vector3.Distance(room_outline[i], room_outline[i + 1]);
            }
            else
            {
                length[i] = Vector3.Distance(room_outline[i], room_outline[0]);
            }

            Debug.Log(length[i]);

        }
    }




    public void set_closet_length()
    {
        line();
        for (int i = 0; i < n; i++)
        {
            closet_length[i] = length[i];
        }


        for (int i = 0; i < n; i++)
        {
            if (turn[i] - 270 < 1 && turn[i] - 270 > -1)
            {
                offset[i] = new Vector3(w1, 0, 0);
                closet_length[i] -= w1;

                if (i == 0)
                {
                    closet_length[n - 1] -= w1;
                }
                else
                {
                    closet_length[i - 1] -= w1;
                }
            }
            else if (turn[i] - 90 < 1 && 90 - turn[i] < 1)
            {
                offset[i] = new Vector3(0, 0, 0);

                if (i == 0)
                {
                    closet_length[n - 1] += depth;
                }
                else
                {
                    closet_length[i - 1] += depth;
                }


            }
            Debug.Log(turn[i]);

        }
    }


    public void closet_rotate()
    {
        set_closet_length();


        float sum = 0;

        for (int i = 0; i < n; i++)
        {
            sum += turn[i];
            angel[i] = sum;
        }
    }



    public void generate()
    {

        closet_rotate();

        for (int i = 0; i < n; i++)
        {
            if (closet_length[i] > 1)
            {
                gameObject.GetComponent<basicgenerate>().width = closet_length[i];
                gameObject.GetComponent<morehole>().offset = offset[i];
                gameObject.GetComponent<morehole>().make_wall();
                //Vector3 pos = gameObject.GetComponent<basicgenerate>().onetime.transform.position;
                gameObject.GetComponent<basicgenerate>().onetime.transform.Translate(room_outline[i]);
                gameObject.GetComponent<basicgenerate>().onetime.transform.Rotate(new Vector3(0, angel[i]/*+90*/, 0));
            }

        }

        corner();
    }



    public void corner()
    {
        for (int i = 0; i < n; i++)
        {

            if (turn[i] - 270 < 1 && 270 - turn[i] < 1)
            {

                gameObject.GetComponent<cornercloset>().create(room_outline[i] + offset[i], new Vector3(0, angel[i]/*+90*/, 0));

            }

        }

    }
}

      
