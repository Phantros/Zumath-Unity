﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeDestroyer : MonoBehaviour
{

    public void DestroyDeadNodes()
    {
        List<NumberNode> nodesToDestroy = new List<NumberNode>();

        foreach (NumberNode node in NodeManager.GetNodes())
        {
            if (! node.alive)
            {
                nodesToDestroy.Add(node);
            }
        }

        foreach (NumberNode node in nodesToDestroy)
        {
            NodeManager.RemoveNode(node);
            Destroy(node.gameObject);
        }
    }
}
