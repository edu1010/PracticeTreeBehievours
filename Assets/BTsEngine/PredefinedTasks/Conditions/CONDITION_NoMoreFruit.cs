using UnityEngine;
using BTs;

public class CONDITION_NoMoreFruit : Condition
{    
    // Constructor
    public CONDITION_NoMoreFruit()  {
        /* Receive function parameters and set them */
    }

    // optional
    public int keyPeachStock;
    public int keyAppleStock;
    public override void OnInitialize()
    {
        /* implement this method for conditions that have state and/or
        for conditions that may be called many times in the same ticking cycle
        (e.g. conditions in dynamic selectors). 
        If in doubt, do not implement it. Do all the work in Check */
        //ANITAs_BLACKBOARD bl = GetComponent<ANITAs_BLACKBOARD>();
       
    }

    public override bool Check ()
    {
        /* Add your code here */
        keyPeachStock = blackboard.Get<int>("peaches");
        keyAppleStock = blackboard.Get<int>("apples");

        bool result;

        if(keyAppleStock <= 0 && keyPeachStock <= 0)
        {
            result = true;
        }
        else
        {
            result = false;
        }

        return result;
    }

}
