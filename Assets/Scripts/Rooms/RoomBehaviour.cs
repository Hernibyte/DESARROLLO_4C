using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBehaviour : MonoBehaviour
{
    [SerializeField] GameObject gatePrefab;
    [SerializeField] float nodeXOffSet;
    [SerializeField] float nodeYOffSet;
    [SerializeField] float gateXOffSet;
    [SerializeField] float gateYOffSet;
    [SerializeField] float halfRound;
    [SerializeField] float quarterRound;
    [HideInInspector] public MyNode leftNode;
    [HideInInspector] public MyNode rightNode;
    [HideInInspector] public MyNode topNode;
    [HideInInspector] public MyNode downNode;

    public void DefineNodeReferences(MyNode leftNode, MyNode rightNode, MyNode topNode, MyNode downNode)
    {
        if(leftNode != null)
            this.leftNode = leftNode;
        if(rightNode != null)
            this.rightNode = rightNode;
        if(topNode != null)
            this.topNode = topNode;
        if(downNode != null)
            this.downNode = downNode;
    }

    public void GenerateGates()
    {
        for(int i = 0; i < 4; i++)
        {
            switch(i)
            {
                case 0:
                    if(leftNode == null)
                        break;
                    //
                    CreateGate(new Vector2(-gateXOffSet, 0f), Quaternion.identity);
                break;
                case 1:
                    if(rightNode == null)
                        break;
                    //
                    CreateGate(new Vector2(gateXOffSet, 0f), new Quaternion(0f, 0f, halfRound, 0f));
                break;
                case 2:
                    if(topNode == null)
                        break;
                    //
                    CreateGate(new Vector2(0f, gateYOffSet), new Quaternion(0f, 0f, -quarterRound, quarterRound));
                break;
                case 3:
                    if(downNode == null)
                        break;
                    //
                    CreateGate(new Vector2(0f, -gateYOffSet), new Quaternion(0f, 0f, quarterRound, quarterRound));
                break;
            }
        }
    }

    void CreateGate(Vector2 offSet, Quaternion gateRotation)
    {
        Instantiate(gatePrefab, new Vector2(transform.position.x + offSet.x, transform.position.y + offSet.y), gateRotation, transform);
    }
}
