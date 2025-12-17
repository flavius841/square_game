using UnityEngine;

public class PlayerCrashScript : MonoBehaviour
{
    [SerializeField] GameObject Parent;
    [SerializeField] bool Crashed;
    [SerializeField] float DectectingDistance;
    private SpriteRenderer rend;
    [SerializeField] GameObject Life3;
    [SerializeField] GameObject Life2;
    [SerializeField] GameObject Life1;
    [SerializeField] int Lifes = 3;
    [SerializeField] float BlinkTime;
    [SerializeField] float Speed;
    [SerializeField] float MinAlpha = 0.5f;
    [SerializeField] float MaxAlpha = 1f;
    [SerializeField] bool HasMinAlpha;



    void Start()
    {

    }

    void Update()
    {
        PlayerDetector();
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
                    && rend.color == Color.red)
                {
                    Crashed = true;
                    Lifes--;
                }
            }
        }

    }

    public void LifeCrashAnimation()
    {
        // if (lifes == 2 && Crashed)
        // {
        //     BlinkTime += Time.deltaTime * Speed;
        //     if (BlinkTime % 4 == 0)
        //     {

        //     }
        // }

        if (Lifes == 2)
        {
            rend = Life3.GetComponent<SpriteRenderer>();
            Color c = rend.color;
            c.a = MinAlpha;
            rend.color = c;
        }

        if (Lifes == 1)
        {
            Color c = Life2.color;
            c.a = MinAlpha;
            Life2.color = c;
        }

        if (Lifes == 0)
        {
            Color c = Life1.color;
            c.a = MinAlpha;
            Life1.color = c;

            //Invoke("ResetFunction", 0.5f);
        }


    }

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

    public void BlinkFunction(SpriteRenderer sr)
    {
        float alpha = Mathf.PingPong(Time.time * Speed, MaxAlpha - MinAlpha) + MinAlpha;

        Color c = sr.color;
        c.a = alpha;
        sr.color = c;
    }

}
