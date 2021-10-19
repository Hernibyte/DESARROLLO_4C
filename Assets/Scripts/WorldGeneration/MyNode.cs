using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyNode : MonoBehaviour, INode
{
    [SerializeField] GameObject roomPrefab;
    [HideInInspector] public float xCheckPosition;
    [HideInInspector] public float yCheckPosition;
    [HideInInspector] public MyNode leftNode;
    [HideInInspector] public MyNode rightNode;
    [HideInInspector] public MyNode topNode;
    [HideInInspector] public MyNode downNode;

    public void CheckNodeConections()
    {
        CheckingConection(1,
            new Vector3(
            transform.position.x - xCheckPosition, 
            transform.position.y, 
            transform.position.z));
        //
        CheckingConection(2,
            new Vector3(
            transform.position.x + xCheckPosition, 
            transform.position.y, 
            transform.position.z));
        //
        CheckingConection(3,
            new Vector3(
            transform.position.x, 
            transform.position.y - yCheckPosition, 
            transform.position.z));
        //
        CheckingConection(4,
            new Vector3(
            transform.position.x, 
            transform.position.y + yCheckPosition, 
            transform.position.z));
    }

    void CheckingConection(int side, Vector3 position)
    {
        MyNode myNode;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, 1f);
        foreach(Collider2D collider in colliders)
        {
            if(collider.TryGetComponent<MyNode>(out myNode))
            {
                switch(side)
                {
                    case 1:
                        leftNode = myNode;
                    break;
                    case 2:
                        rightNode = myNode;
                    break;
                    case 3:
                        downNode = myNode;
                    break;
                    case 4:
                        topNode = myNode;
                    break;
                }
            }
        }
    }

    public void GenerateRoom()
    {
        GameObject roomObj = Instantiate(roomPrefab, transform.position, Quaternion.identity, transform);
        RoomBehaviour roomBehaviour = roomObj.GetComponent<RoomBehaviour>();
        roomBehaviour.DefineNodeReferences(leftNode, rightNode, topNode, downNode);
        roomBehaviour.GenerateGates();
    }
}
