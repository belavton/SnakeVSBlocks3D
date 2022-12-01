using System.Collections.Generic;
using UnityEngine;


public class Tail : MonoBehaviour
{
    public Transform Head;
    public float CircleDiameter;
    public float CollisionInterval;
    public TextMesh pointText;
    public SnakeMovement Snake;
    public Audio Audio;
    public ParticleSystem ParticleSystem;
    public ParticleSystem Boom;
    public int points { get; private set; }

    private List<Transform> snakeCircles = new List<Transform>();
    private List<Vector3> positions = new List<Vector3>();
    private float collisionTimer = 0;

    void Start()
   {
       positions.Add(Head.position);
        //points = 1;
        int startHitpoints = Lives.SnakeLength != -1 ? Lives.SnakeLength : Lives.InitialSnakeLength;
       for (int i = 0; i < startHitpoints; i++)
       {
            AddCircle();
        }
   }

    void Update()
    {
        collisionTimer -= Time.deltaTime;

        float distance = (Head.position - positions[0]).magnitude;

        if (distance > CircleDiameter)
        {
            Vector3 direction = (Head.position - positions[0]).normalized;

            positions.Insert(0, positions[0] + direction * CircleDiameter);
            positions.RemoveAt(positions.Count - 1);

            distance -= CircleDiameter;
        }

        for (int i = 0; i < snakeCircles.Count; i++)
        {
            snakeCircles[i].position = Vector3.Lerp(positions[i + 1], positions[i], distance / CircleDiameter);
        }
    }

    public void AddCircle()
    {
        points++;
        pointText.text = (points + 1).ToString();
        Transform circle = Instantiate(Head, positions[positions.Count - 1], Quaternion.identity, transform);
        snakeCircles.Add(circle);
        positions.Add(circle.position);
    }

    public void RemoveCircle()
    {
        int lastIndex = snakeCircles.Count - 1;

        if (snakeCircles.Count == 0)
        {
            
            Snake.gameObject.SetActive(false);
            Snake.Die();
        }
        else
        {
            points--;
            pointText.text = (points + 1).ToString();
            Destroy(snakeCircles[lastIndex].gameObject);
            snakeCircles.RemoveAt(lastIndex);
            positions.RemoveAt(lastIndex + 1);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Food food))
        {
            for (int i = 0; i < food.Number; i++)
            {
                AddCircle();
            }

            Lives.SnakeLength = points;
            Destroy(other.gameObject);
           Audio.TakeFoodAudio();
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (collisionTimer <= 0 && other.gameObject.TryGetComponent(out Block block))
        {
            block.ApplyDamage();
            RemoveCircle();
            collisionTimer = CollisionInterval;
            Audio.PlayAudio();
            ParticleSystem.Play();

            Lives.SnakeLength = points;
            if (block.points == 0)
                Boom.Play();
        }    
    }
}
