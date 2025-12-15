using UnityEngine;

public class PlayerCrashScript : MonoBehaviour
{
    public GameObject Player;
    void Start()
    {

    }

    void Update()
    {

    }

    public void PlayerDetector(GameObject Player, float Adjustment2)
    {
        for (int i = 0; i < Player.transform.childCount; i++)
        {
            //print(Vector3.Distance(Sphere.transform.position, Player1.transform.GetChild(i).position) + "   " + Player1.transform.GetChild(i).name);
            if (Vector3.Distance(Sphere.transform.position, Player.transform.GetChild(i).position) < DectectingDistance)
            {
                Z_Rot = 180 - Z_Rot - RotationFactor * int.Parse(Player.transform.GetChild(i).name);

                Sphere.transform.position = new Vector3(Sphere.transform.position.x + Adjustment2, Sphere.transform.position.y,
                 Sphere.transform.position.z);

                Score++;

            }
        }
    }
}
