using UnityEngine;
using TMPro;

public class Block : MonoBehaviour
{
    public TextMeshPro pointText;
    public ParticleSystem Boom;
    public Audio Audio;
    public int points { get; private set; }
    public int Maxpoints { get { return maxpoints; } }

    [SerializeField]
    private int minpoints;
    [SerializeField]
    private int maxpoints;

    private void Start()
    {
        points = Random.Range(minpoints, maxpoints);
        pointText.text = points.ToString();
    }

    public void ApplyDamage()
    {
        points--;
        pointText.text = points.ToString();

        if (points <= 0)
        {
            Collapse();
        }
    }

    private void Collapse()
    {
        Destroy(gameObject);
        Audio.DestroyBlock();
    }
}
