using UnityEngine;

using UnityEngine.InputSystem;

using TMPro;



public enum Axis

{

    X,

    Y

}



public class Test : MonoBehaviour

{

    [SerializeField] bool StartMoving;

    [SerializeField] bool Done;



    [SerializeField] float SpeedX;

    [SerializeField] float SpeedY;

    [SerializeField] float Limit;

    [SerializeField] float AdditionalLimit;

    [SerializeField] Axis axis;
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] int Score;
    [SerializeField] bool ConfigDone;
    public PlayerCrashScript PlayerCrashScript;
    public InfoTextScript InfoTextStatus;


    public Test CaseYDone;

    void Start()

    {




    }



    void Update()

    {
        if (InfoTextStatus.Opened && !StartMoving && !ConfigDone)
        {
            Limit = -Limit / 10;

            SpeedY = -SpeedY;

            ConfigDone = true;

            StartMoving = true;

        }

        if (InfoTextStatus.Opened && !StartMoving && ConfigDone && StartMoving)
        {
            Move();
        }





        if (Keyboard.current.spaceKey.wasPressedThisFrame && (Done || CaseYDone.Done) && !PlayerCrashScript.Lost && !InfoTextStatus.Opened)

        {

            StartMoving = true;

            Done = false;



            switch (axis)

            {

                case Axis.X:

                    Limit += AdditionalLimit;

                    Score++;

                    ScoreText.text = "Score " + Score.ToString();

                    break;



                case Axis.Y:

                    Limit = -Limit;


                    SpeedY = -SpeedY;


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





                if (transform.position.x >= Limit - 0.1f)

                {

                    StartMoving = false;


                    Done = true;

                }

                break;



            case Axis.Y:





                if ((transform.position.y >= Limit - 0.1f && Limit > 0) || (transform.position.y <= Limit + 0.1f && Limit < 0))

                {

                    StartMoving = false;

                    Done = true;

                }




                break;



        }



    }

}