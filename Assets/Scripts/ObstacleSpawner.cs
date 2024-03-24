using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject m_obstacle;

    [SerializeField]
    Transform start, end;

    [SerializeField]
    float speed = 30;

    [SerializeField]
    float despawnTime = 3f;

    public Obstacle Spawn()
    {
        GameObject go = Instantiate(m_obstacle, start.position,start.rotation,start);
        Obstacle obstacle = go.GetComponent<Obstacle>();
        obstacle.speed = speed;
        obstacle.end = end;
        obstacle.despawnTime = despawnTime;
        return obstacle;
    }
}
