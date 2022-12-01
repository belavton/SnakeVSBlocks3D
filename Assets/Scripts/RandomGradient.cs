using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGradient : MonoBehaviour
{
    public Block Block;
    Gradient gradient;
    GradientColorKey[] colorKey;
    GradientAlphaKey[] alphaKey;

    void Start()
    {
        Block = gameObject.GetComponent<Block>();
        gradient = new Gradient();

        colorKey = new GradientColorKey[2];

        colorKey[0].color = Color.green;
        colorKey[0].time = 0.0f;
        colorKey[1].color = Color.red;
        colorKey[1].time = 1.0f;

        alphaKey = new GradientAlphaKey[2];

        alphaKey[0].alpha = 1.0f;
        alphaKey[0].time = 0.0f;
        alphaKey[1].alpha = 0.0f;
        alphaKey[1].time = 1.0f;

        gradient.SetKeys(colorKey, alphaKey);
    }

    private void Update()
    {
        var blockRenderer = Block.GetComponent<Renderer>();
        float percent = (float)Block.points / Block.Maxpoints;

        blockRenderer.material.SetColor("_Color", gradient.Evaluate(percent));
    }
}
