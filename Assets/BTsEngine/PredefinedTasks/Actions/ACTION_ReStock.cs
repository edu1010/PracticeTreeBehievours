using UnityEngine;
using BTs;

public class ACTION_ReStock : Action
{
    //public string keyPeachStock;
    //public string keyAppleStock;
    
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
    public ACTION_ReStock(/*string keyPeachStock, string keyAppleStock*/)
    {       
        //this.keyPeachStock = keyPeachStock;
        //this.keyAppleStock = keyAppleStock;
    }

    /* Declare private attributes here */
    private ANITAs_BLACKBOARD bl;
    public override void OnInitialize()
    {
        /* write here the initialization code. Remember that initialization is executed once per ticking cycle */        
        bl = (ANITAs_BLACKBOARD)blackboard;
        bl.Put("peaches", 2);
        bl.Put("apples", 2);

        bl.UpdateText();
    }

    public override Status OnTick ()
    {
        return Status.SUCCEEDED;
    }

    public override void OnAbort()
    {
        // write here the code to be executed if the action is aborted while running
    }

}
