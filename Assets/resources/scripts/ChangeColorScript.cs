using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class ChangeColorScript : MonoBehaviour
{
    [SerializeField] Color color1;
    [SerializeField] Color color2;
    [SerializeField] Color color3;
    [SerializeField] Color color4;
    [SerializeField] Color color5;
    [SerializeField] Color color6;
    [SerializeField] Color color7;
    [SerializeField] Color color8;
    [SerializeField] Color color9;
    [SerializeField] Color color10;
    [SerializeField] int i = 1;
    private SpriteRenderer rend;
    [SerializeField] List<Color> colors;
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();

        // List<Color> colors = new List<Color>();

        colors.Add(color1);
        colors.Add(color2);
        colors.Add(color3);
        colors.Add(color4);
        colors.Add(color5);
        colors.Add(color6);
        colors.Add(color7);
        colors.Add(color8);
        colors.Add(color9);
        colors.Add(color10);

    }

    void Update()
    {
        if (Keyboard.current.shiftKey.wasPressedThisFrame)
        {
            rend.color = colors[i];
            i++;

            if (i == 10)
            {
                i = 0;
            }


        }

    }
}
