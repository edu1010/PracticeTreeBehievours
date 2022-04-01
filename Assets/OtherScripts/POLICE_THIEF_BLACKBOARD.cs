using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class POLICE_THIEF_BLACKBOARD : Blackboard, IDialogSystem
{
    private TextMeshPro utteranceLine;
    private GameObject utteranceBubble;
    private IDialogSystem partner;
    public GameObject police;
    public string policeTag = "POLICE"; 
    public GameObject thief;
    public GameObject exitPoint;
    public GameObject storeEntrance;
    public string[] utterances =
       {
        "YOU ARE UNDER ARREST", // POLICE
        "GIVE ME ALL YOUR MONEY DUMMMY!",//THIEF
        "unused utterance",  // 2
    };
    private void Start()
    {
        utteranceBubble = gameObject.transform.GetChild(0).gameObject;
        utteranceLine = utteranceBubble.transform.GetChild(0).GetComponent<TextMeshPro>();
        police = GameObject.FindGameObjectWithTag("POLICE");
        thief = GameObject.FindGameObjectWithTag("THIEF");
        exitPoint = GameObject.FindGameObjectWithTag("EXIT_POINT");
        storeEntrance = GameObject.FindGameObjectWithTag("STORE_ENTRANCE");
    }

    public void SetUtterance(int index)
    {
        utteranceLine.text = utterances[index];
        utteranceBubble.SetActive(true);
    }

    public void ClearUtterance()
    {
        utteranceLine.text = "";
        utteranceBubble.SetActive(false);
    }

    public string BeAsked(string question)
    {
        // Anita is not suposed to receive direct questions
        return "??";
    }

    public bool EngageInDialog(IDialogSystem partner)
    {
        // you want to engage with someone? Use this method
        if (partner.BeEngagedInDialog(this))
        {
            this.partner = partner;
            return true;
        }
        return false; // returning false means partner has refused.
    }

    public bool BeEngagedInDialog(IDialogSystem partner)
    {
        // Anita is not supposed to be asked to engage. She'll take initiative.
        throw new System.NotImplementedException();
    }

    public void BeDisengagedFromDialog()
    {
        // Anita is not supposed to be asked to disengage. She'll take initiative.
        throw new System.NotImplementedException();
    }

    public void DisengageFromDialog()
    {
        if (partner != null)
            partner.BeDisengagedFromDialog();
        partner = null;
    }

    public bool IsEngagedInDialog()
    {
        // Anita does not need this. By the time being
        throw new System.NotImplementedException();
    }



    public string Ask(int index, bool utter)
    {
        if (partner == null)
        {
            Debug.Log("Cannot ask since no partner known");
            return null;
        }
        else
        {
            if (utter) SetUtterance(index);
            return partner.BeAsked(utterances[index]);
        }
    }

    public bool Tell(int index, bool utter)
    {
        if (partner == null)
        {
            Debug.Log("Cannot ask since no partner known");
            return false;
        }
        else
        {
            if (utter) SetUtterance(index);
            partner.BeTold(utterances[index]);
            return true;
        }

    }

    public void BeTold(string sentence)
    {
        throw new System.NotImplementedException();
    }
}


