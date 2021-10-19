using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainNode : MonoBehaviour
{
    [SerializeField] Transform world;
    [SerializeField] GameObject nodePrefab;
    [SerializeField] float nodeXDistance;
    [SerializeField] float nodeYDistance;
    [SerializeField] int nodeAmount;
    UnityEvent checkConections;
    UnityEvent callGenerationRooms;
    GameObject obj;
    UnityEvent finishGeneration;

    void Awake()
    {
        obj = new GameObject();
        checkConections = new UnityEvent();
        callGenerationRooms = new UnityEvent();
    }

    IEnumerator Start()
    {
        for(int i = 0; i < nodeAmount; i++)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1f);
            INode iNode;
            if(colliders.Length == 0)
            {
                GenerateNode();
            }
            else
                foreach (Collider2D collider in colliders)
                {
                    if(!collider.TryGetComponent<INode>(out iNode))
                    {
                        GenerateNode();
                    }
                }
            //
            switch(Random.Range(1, 5))
            {
                case 1:
                    transform.position -= new Vector3(nodeXDistance, 0f, 0f);
                break;
                case 2:
                    transform.position += new Vector3(nodeXDistance, 0f, 0f);
                break;
                case 3:
                    transform.position -= new Vector3(0f, nodeYDistance, 0f);
                break;
                case 4:
                    transform.position += new Vector3(0f, nodeYDistance, 0f);
                break;
            }
            checkConections?.Invoke();
            yield return new WaitForSeconds(0.2f);
        }
        callGenerationRooms?.Invoke();
        finishGeneration?.Invoke();
    }

    void GenerateNode()
    {
        obj = Instantiate(nodePrefab, transform.position, Quaternion.identity, world);
        MyNode myNode = obj.GetComponent<MyNode>();
        myNode.xCheckPosition = nodeXDistance;
        myNode.yCheckPosition = nodeYDistance;
        checkConections?.AddListener(myNode.CheckNodeConections);
        callGenerationRooms?.AddListener(myNode.GenerateRoom);
    }
}
