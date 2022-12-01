using UnityEngine;



public class Food : MonoBehaviour
{
    public TextMesh _text;
    public int Number {get; private set;}

    
    private int minNumber = 1;
    private int maxNumber = 6;

    private void Start()
    {
        Number = Random.Range(minNumber, maxNumber);
        _text.text = Number.ToString();
    }
}
