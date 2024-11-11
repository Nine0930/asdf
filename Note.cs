using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct NoteInfo
{
    public int Line;
    public int MS;
    public bool IsLong;
    public int EndMS;
}
public class Note : MonoBehaviour
{
    public NoteInfo info;
    private static Transform judgeLine;
    private static float noteSpeed = 0.006f;
    private bool isHit = false;
    private void Start()
    {
        if (judgeLine == null)
        {
            judgeLine = GameManager.Instance.judgeLine;
        }
    }
    private void Update()
    {
        if(isHit == false)
        {
            Vector3 newpos = new Vector3(transform.position.x,
                info.MS - GameManager.Instance.SongTime);

            newpos.y *= noteSpeed;
            newpos.y += judgeLine.transform.position.y;
            transform.position = newpos;
        }
    }
}
