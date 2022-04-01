using UnityEngine;
using BTs;

public class ACTION_INVOKE_POLICE : Action
{

    /* Declare action parameters here. 
       All public parameters must be of type string. All public parameters must be
       regarded as keys in/for the blackboard context.
       Use prefix "key" for input parameters (information stored in the blackboard that must be retrieved)
       use prefix "keyout" for output parameters (information that must be stored in the blackboard)

       e.g.
       public string keyDistance;
       public string keyoutObject 
     */
    // construtor
    public ACTION_INVOKE_POLICE()  { 
        /* Receive action parameters and set them */
    }
    
    /* Declare private attributes here */

    public override void OnInitialize()
    {
        /* write here the initialization code. Remember that initialization is executed once per ticking cycle */
      
           
    }

    public override Status OnTick ()
    {
        if (GameObject.FindGameObjectWithTag("POLICE") == null)
        {
            GameObject.Instantiate(blackboard.Get<GameObject>("policePrefab"), blackboard.Get<Transform>("policePos").position, Quaternion.identity);
        }
        return Status.SUCCEEDED;
    }

    public override void OnAbort()
    {
        // write here the code to be executed if the action is aborted while running
    }

}
