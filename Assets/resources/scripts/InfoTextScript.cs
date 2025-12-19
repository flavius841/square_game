using UnityEngine;
using UnityEngine.InputSystem;


public class InfoTextScript : MonoBehaviour
{
    [SerializeField] GameObject InfoLabel;
    public bool Opened;

    void Start()
    {


    }

    void Update()
    {
        if (Keyboard.current.cKey.wasPressedThisFrame && !Opened)
        {
            InfoLabel.SetActive(true);
            Opened = !Opened;
        }

        else if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            InfoLabel.SetActive(false);
            Opened = !Opened;
        }

    }
}
