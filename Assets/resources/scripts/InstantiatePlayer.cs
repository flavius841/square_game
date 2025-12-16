using UnityEngine;

public class InstantiatePlayer : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject ReferencePlayer;
    //ReferencePlayerScript playerInstance;
    void Start()
    {
        GameObject NewPlayer = Instantiate(Player);
        NewPlayer.transform.SetParent(ReferencePlayer.transform);
        // playerInstance = NewPlayer.GetComponent<ReferencePlayerScript>();

        // ReferencePlayerScript script = NewPlayer.GetComponent<ReferencePlayerScript>();
        // script.CaseYDone = playerInstance;
    }

    void Update()
    {

    }
}
