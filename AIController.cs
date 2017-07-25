using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AIController : MonoBehaviour
{
    NavMeshAgent agent;
    PlayerCharacter character;
    Transform targetTrans;
    public Transform line;
    private LineRenderer _lineRenderer;
    void Start()
    {
        _lineRenderer = line.GetComponent<LineRenderer>();

        character = GetComponent<PlayerCharacter>();
        agent = GetComponent<NavMeshAgent>();

        targetTrans = GameObject.FindGameObjectWithTag("Player").transform;

        InvokeRepeating("FireControl", 1, 2);
    }

    void FireControl()
    {
        character.Fire();
    }

    void Update()
    {
        agent.destination = targetTrans.position;

        Vector3[] _path = agent.path.corners;//储存路径

        _lineRenderer.SetVertexCount(_path.Length);//设置线段数
        
        for (int i = 0; i < _path.Length; i++)
        {
             _lineRenderer.SetPosition(i, _path[i]);//设置线段顶点坐标
        }

        transform.LookAt(targetTrans);
    }
}
