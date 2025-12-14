using UnityEngine;

public class DangerousTileScript : MonoBehaviour
{
    [SerializeField] float randomTimeLimit;
    [SerializeField] float ReppetitiveTime;

    private Color actualColor; 
    [SerializeField] bool Danger = false; 

    private SpriteRenderer rend;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        randomTimeLimit =  Random.Range(1f, 5f);
    }

    void Update()
    {
        if (Danger)
        {
            actualColor = Color.red;
        }

        else
        {
            actualColor = Color.green;
        }

        ReppetitiveTime += Time.deltaTime;
        if (ReppetitiveTime > randomTimeLimit)
        {
            ReppetitiveTime = 0;
            rend.material.color = actualColor;
            Danger = !Danger;

        }
        
    }
}
