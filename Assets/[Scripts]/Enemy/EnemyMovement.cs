using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Tile;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private List<Waypoint> _path = new List<Waypoint>();
    [SerializeField] [Range(0, 5)] private float speed = 1f;


    private void OnEnable()
    {
        
        FindPath();
        ReturnStart();
        StartCoroutine(FollowPathIE());
    }
    
    private void FindPath()
    {
        _path.Clear();

        GameObject parent = GameObject.FindGameObjectWithTag("Path");

        foreach (Transform child in parent.transform)
        {
            _path.Add(child.GetComponent<Waypoint>());
        }
    }

    private void ReturnStart()
    {
        transform.position = _path[0].transform.position;
    }
    
    IEnumerator FollowPathIE()
    {
        foreach (var waypoint in _path)
        {
            
            Vector3 startPos = transform.position;
            Vector3 endPos = waypoint.transform.position;
            float travelPercentage = 0f;
            endPos.y = startPos.y;
            transform.DOLookAt(endPos, .2f);
            while (travelPercentage < 1)
            {
                travelPercentage += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPos, endPos, travelPercentage);
                yield return new WaitForEndOfFrame();
            }
        }

        gameObject.SetActive(false);
    }
}