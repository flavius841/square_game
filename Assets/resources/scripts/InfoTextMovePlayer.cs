using UnityEngine;

public class InfoTextMovePlayer : MonoBehaviour
{
    public InfoTextScript InfoTextStatus;
    public PlayerCrashScript PlayerCrashScript;
    [SerializeField] bool StartMoving;
    [SerializeField] bool Done;
    [SerializeField] float SpeedY;
    [SerializeField] float Limit;

    void Start()
    {

    }

    void Update()
    {
        if (InfoTextStatus.Opened && Done && !PlayerCrashScript.Lost)
        {
            StartMoving = true;
            Done = false;

            Limit = -Limit;
            SpeedY = -SpeedY;
        }

        if (StartMoving)
        {
            Move();
        }

    }


    public void Move()

    {

        transform.position = transform.position + new Vector3(0, SpeedY * Time.deltaTime, 0);

        if ((transform.position.y >= Limit - 0.1f && Limit > 0) || (transform.position.y <= Limit + 0.1f && Limit < 0))
        {
            StartMoving = false;
            Done = true;
        }

    }
}
