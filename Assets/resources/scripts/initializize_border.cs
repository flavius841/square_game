using UnityEngine;

public class initializize_border : MonoBehaviour
{
    [SerializeField] GameObject PositionReference;
    [SerializeField] float AdditionalPositionX;
    [SerializeField] int Lenght;
    [SerializeField] int IdTile;
    [SerializeField] GameObject Border;
    [SerializeField] GameObject Tile;
    [SerializeField] float ScaleX;
    [SerializeField] string Type;


    void Start()
    {
        InstantiateBorderLoop();
    }
 


    public void InstantiateBorderLoop()
    {
        for (int i = 0; i < Lenght; i++)
        {
            AdditionalPositionX += ScaleX;
            IdTile = i + 1;
            InstantiateBorder(Tile, AdditionalPositionX, IdTile);
        }
    }

    public void InstantiateBorder(GameObject BorderTile, float PositionX, int ID)
    {
        GameObject NewSquare = Instantiate(BorderTile);
        NewSquare.transform.position = new Vector3(PositionReference.transform.position.x + PositionX,
          PositionReference.transform.position.y);
        NewSquare.transform.name = ID.ToString() + Type;
        NewSquare.transform.SetParent(Border.transform);



    }
}
