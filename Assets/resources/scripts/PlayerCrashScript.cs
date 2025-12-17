using UnityEngine;
using UnityEngine.UI;

public class PlayerCrashScript : MonoBehaviour
{
    [SerializeField] GameObject Parent;
    [SerializeField] bool Crashed;
    [SerializeField] bool Blink;
    [SerializeField] float DectectingDistance;
    private SpriteRenderer rend;
    [SerializeField] GameObject Life3;
    [SerializeField] GameObject Life2;
    [SerializeField] GameObject Life1;
    [SerializeField] int Lifes = 3;
    [SerializeField] float Timer;
    [SerializeField] float Speed;
    [SerializeField] float MinAlpha = 0f;
    [SerializeField] float MaxAlpha = 1f;





    void Start()
    {

    }

    void Update()
    {
        PlayerDetector();

        BlinkFunction(Life3, 2);
        BlinkFunction(Life2, 1);
        BlinkFunction(Life1, 0);
    }

    public void PlayerDetector()
    {
        for (int j = 0; j < Parent.transform.childCount; j++)
        {
            rend = Parent.transform.GetChild(j).GetComponent<SpriteRenderer>();

            for (int i = 0; i < Parent.transform.GetChild(j).childCount; i++)
            {
                //print(Vector3.Distance(Sphere.transform.position, Player1.transform.GetChild(i).position) + "   " + Player1.transform.GetChild(i).name);
                if (Vector3.Distance(transform.position, Parent.transform.GetChild(j).GetChild(i).position) < DectectingDistance
                    && rend.color == Color.red && !Crashed)
                {
                    Crashed = true;
                    Lifes--;
                    Blink = true;
                }
            }
        }

    }

    // public void LifeCrashAnimation()
    // {
    //     // if (lifes == 2 && Crashed)
    //     // {
    //     //     BlinkTime += Time.deltaTime * Speed;
    //     //     if (BlinkTime % 4 == 0)
    //     //     {

    //     //     }
    //     // }

    //     if (Lifes == 2)
    //     {
    //         Timer += Time.deltaTime;
    //         if (Timer <= 2)
    //         {

    //         }

    //         rend = Life3.GetComponent<SpriteRenderer>();
    //         Color c = rend.color;
    //         c.a = MinAlpha;
    //         rend.color = c;
    //     }

    //     if (Lifes == 1)
    //     {
    //         rend = Life2.GetComponent<SpriteRenderer>();
    //         Color c = rend.color;
    //         c.a = MinAlpha;
    //         rend.color = c;
    //     }

    //     if (Lifes == 0)
    //     {
    //         rend = Life1.GetComponent<SpriteRenderer>();
    //         Color c = rend.color;
    //         c.a = MinAlpha;
    //         rend.color = c;

    //         //Invoke("ResetFunction", 0.5f);
    //     }


    // }

    // public void BlinkFunction(GameObject Life)
    // {
    //     BlinkTime += Time.deltaTime * Speed;

    //     if (BlinkTime % 4 == 0 && HasMinAlpha)
    //     {
    //         Color c = Life.color;
    //         c.a = MinAlpha;
    //         Life.color = c;
    //         HasMinAlpha = false;
    //     }

    //     else if (BlinkTime % 4 == 0)
    //     {
    //         Color c = Life.color;
    //         c.a = MaxAlpha;
    //         Life.color = c;
    //     }


    // }

    public void BlinkFunction(GameObject Life, int NrLifes)
    {
        Image img = Life.GetComponent<Image>();

        if (Lifes == NrLifes && Blink)
        {
            Timer += Time.deltaTime;
            if (Timer <= 2)
            {
                float alpha = Mathf.PingPong(Time.time * Speed, MaxAlpha - MinAlpha) + MinAlpha;

                Color c = img.color;
                c.a = alpha;
                img.color = c;
            }

            else
            {
                Timer = 0;
                Blink = false;
                Crashed = false;

                Color c = img.color;
                c.a = MinAlpha;
                img.color = c;


            }
        }

    }

}
