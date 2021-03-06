﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[RequireComponent(typeof(PathFollower))]
[RequireComponent(typeof(NodeController))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class NumberNode : MonoBehaviour
{
    public PathFollower pathFollower;
    private CircleCollider2D circleCollider;
    public NodeController nodeController;
    private TextMeshPro textMeshPro;
    public NodeState state;

    public int value;
    public const float RADIUS = 1f;
    public bool alive;

    void Awake()
    {
        Init();
    }

    public void Init()
    {
        alive = true;
        pathFollower = GetComponent<PathFollower>();
        circleCollider = GetComponent<CircleCollider2D>();
        nodeController = GetComponent<NodeController>();
        textMeshPro = GetComponentInChildren<TextMeshPro>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        NumberNode otherNode = collision.GetComponent<NumberNode>();
        if (otherNode != null)
        {
            if (! NodeManager.Contains(otherNode))
            {
                NodeManager.InsertAtPlaceOf(NodeManager.GetNodes().Find(this), otherNode);
            }
        }
    }

    public void Kill()
    {
        alive = false;
    }

    public bool IsTouching(NumberNode otherNode)
    {
        if (otherNode != null)
        {
            if (circleCollider.IsTouching(otherNode.circleCollider))
            {
                return true;
            }
        }
        return false;
    }

    public void SetValue(int value)
    {
        this.value = value;
        if (textMeshPro != null)
        {
            textMeshPro.SetText(value.ToString());
        }
    }
    public void SetState(NodeState state)
    {
        this.state = state;
    }

    public override string ToString()
    {
        return value.ToString();
    }
}
