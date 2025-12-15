using UnityEngine;
using UnityEngine.InputSystem;

public enum Axis
{
    X,
    Y
}

public class ReferencePlayerScript : MonoBehaviour
{
    [SerializeField] bool StartMoving;
    [SerializeField] bool Done;

    [SerializeField] float SpeedX;
    [SerializeField] float SpeedY;
    [SerializeField] float Limit;
    [SerializeField] float AdditionalLimit;
    [SerializeField] Axis axis;
    void Start()
    {

    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && Done)
        {
            StartMoving = true;
            Done = false;

            switch (axis)
            {
                case Axis.X:
                    Limit += AdditionalLimit;
                    break;

                case Axis.Y:
                    Limit = -Limit;
                    break;

            }
        }

        if (StartMoving)
        {
            Move();

        }


    }

    public void Move()
    {
        transform.position = transform.position + new Vector3(SpeedX * Time.deltaTime, SpeedY * Time.deltaTime, 0);

        switch (axis)
        {
            case Axis.X:
                if (transform.position.x >= Limit)
                {
                    StartMoving = false;
                    Done = true;
                }
                break;

            case Axis.Y:
                if (transform.position.y >= Limit)
                {
                    StartMoving = false;
                    Done = true;
                }
                break;

        }

    }
}
