using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNote : MonoBehaviour
{
    public Note NotePrefeb;
    public void StartCreatNote()
    {
        string cheaboText = GameManager.Instance.Cheabo.text;

        string[] notes = cheaboText.Split('\n');

        foreach(string note in notes)
        {
            string[] infos = note.Split(',');

            NoteInfo info = new NoteInfo();
            info.Line = int.Parse(ParseLine(infos[0]));
            info.MS = int.Parse(ParseLine(infos[2]));
            info.IsLong = infos[3] == "128" ? true : false;

            if (info.IsLong == true)
            {
                string[] colon = infos[5].Split(":");
                info.EndMS = int.Parse(colon[0]);
            }

            Note newNote = Instantiate(NotePrefeb);
            newNote.info = info;

            float xPos = info.Line;
            xPos -= 2;

            newNote.transform.position = new Vector3(xPos, 0);
        }
    }

    private string ParseLine(string line)
    {
        switch (line)
        {
            case "64":
                line = "1";
                break;

            case "192":
                line = "2";
                break;

            case "320":
                line = "3";
                break;

            case "448":
                line = "4";
                break;
        }

        return line;
    }
}
