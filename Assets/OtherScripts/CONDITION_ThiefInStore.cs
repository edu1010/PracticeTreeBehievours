using UnityEngine;
using BTs;

public class CONDITION_ThiefInStore : Condition
{
    public string parameterThiefOut;
    public CONDITION_ThiefInStore()  {
    }
    public CONDITION_ThiefInStore(string thiefOut)
    {
        parameterThiefOut = thiefOut;
    }
    // optional
    public override void OnInitialize()
    {
    }

    public override bool Check ()
    {
        GameObject thief = SensingUtils.FindInstanceWithinRadius(
              blackboard.Get<GameObject>("theStoreEntrance"), "THIEF", 100
          );
        if (thief != null)
        {
            blackboard.Put(parameterThiefOut, thief);
            return true;
        }
        else
        {
            return false;
        }
    }

}
