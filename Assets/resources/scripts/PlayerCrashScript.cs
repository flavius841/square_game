using UnityEngine;

public class PlayerCrashScript : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] bool Crashed;
    [SerializeField] float DectectingDistance;

    void Start()
    {

    }

    void Update()
    {

    }

    public void PlayerDetector()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            //print(Vector3.Distance(Sphere.transform.position, Player1.transform.GetChild(i).position) + "   " + Player1.transform.GetChild(i).name);
            if (Vector3.Distance(Player.transform.position, transform.GetChild(i).position) < DectectingDistance)
            {
                Crashed = true;
            }
        }
    }
}
