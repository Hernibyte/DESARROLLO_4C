using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBehaviour : MonoBehaviour
{
    [SerializeField] GameObject enemyGenerator;
    [SerializeField] GameObject gatePrefab;
    [SerializeField] float nodeXOffSet;
    [SerializeField] float nodeYOffSet;
    [SerializeField] float gateXOffSet;
    [SerializeField] float gateYOffSet;
    [SerializeField] float halfRound;
    [SerializeField] float quarterRound;
    public bool imFirstRoom;
    [HideInInspector] public MyNode leftNode;
    [HideInInspector] public MyNode rightNode;
    [HideInInspector] public MyNode topNode;
    [HideInInspector] public MyNode downNode;
    [HideInInspector] public List<GateBehaviour> listOfDoors;
    // auxilar parameters
    GameObject obj;
    GateBehaviour gateBehaviour;

    void Start()
    {
        if(imFirstRoom)
            Destroy(enemyGenerator);
    }

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
                    obj = CreateGate(new Vector2(-gateXOffSet, 0f), Quaternion.identity);
                    SetGateParameters(obj, gateBehaviour, leftNode.transform.position.x + nodeXOffSet, leftNode.transform.position.y);
                break;
                case 1:
                    if(rightNode == null)
                        break;
                    //
                    obj = CreateGate(new Vector2(gateXOffSet, 0f), new Quaternion(0f, 0f, halfRound, 0f));
                    SetGateParameters(obj, gateBehaviour, rightNode.transform.position.x - nodeXOffSet, rightNode.transform.position.y);
                break;
                case 2:
                    if(topNode == null)
                        break;
                    //
                    obj = CreateGate(new Vector2(0f, gateYOffSet), new Quaternion(0f, 0f, -quarterRound, quarterRound));
                    SetGateParameters(obj, gateBehaviour,topNode.transform.position.x, topNode.transform.position.y - nodeYOffSet);
                break;
                case 3:
                    if(downNode == null)
                        break;
                    //
                    obj = CreateGate(new Vector2(0f, -gateYOffSet), new Quaternion(0f, 0f, quarterRound, quarterRound));
                    SetGateParameters(obj, gateBehaviour, downNode.transform.position.x, downNode.transform.position.y + nodeYOffSet);
                break;
            }
        }
    }

    GameObject CreateGate(Vector2 offSet, Quaternion gateRotation)
    {
        return Instantiate(gatePrefab, new Vector2(transform.position.x + offSet.x, transform.position.y + offSet.y), gateRotation, transform);
    }

    void SetGateParameters(GameObject obj, GateBehaviour gateBehaviour, float xPosition, float yPosition)
    {
        gateBehaviour = obj.GetComponent<GateBehaviour>();
        listOfDoors.Add(gateBehaviour);
        gateBehaviour.teleportPosition = new Vector2(xPosition, yPosition);
        gateBehaviour.isGateOpen = true;
    }

    public void OpenAndCloseGates()
    {
        foreach(GateBehaviour gate in listOfDoors)
        {
            gate.isGateOpen = !gate.isGateOpen;
        }
    }
}
