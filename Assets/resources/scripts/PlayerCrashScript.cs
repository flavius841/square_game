using UnityEngine;
using TMPro;
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
    [SerializeField] TextMeshProUGUI LoseText;
    public bool Lost;
    [SerializeField] float TextSpeed;
    [SerializeField] float alphaText;





    void Start()
    {

    }

    void Update()
    {
        PlayerDetector();

        BlinkFunction(Life3, 2);
        BlinkFunction(Life2, 1);
        BlinkFunction(Life1, 0);

        if (Lifes == 0)
        {
            Lost = true;

            alphaText = Mathf.MoveTowards(alphaText, 1, TextSpeed * Time.deltaTime);
            TextMeshProUGUI txt = LoseText;

            Color c = txt.color;
            c.a = alphaText;
            txt.color = c;

            InvokeScene1Load();



        }
    }

    public void PlayerDetector()
    {
        for (int j = 0; j < Parent.transform.childCount; j++)
        {
            rend = Parent.transform.GetChild(j).GetComponent<SpriteRenderer>();

            for (int i = 0; i < Parent.transform.GetChild(j).childCount; i++)
            {
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

    public void Scene1Load()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void InvokeScene1Load()
    {
        Invoke("Scene1Load", 2f);
    }


}
