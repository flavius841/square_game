using UnityEngine;

public class PlayerCrashScript : MonoBehaviour
{
    [SerializeField] GameObject Parent;
    [SerializeField] bool Crashed;
    [SerializeField] float DectectingDistance;
    private SpriteRenderer rend;

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
                }
            }
        }

    }
}
