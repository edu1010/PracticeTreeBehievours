using UnityEngine;
using BTs;

[CreateAssetMenu(fileName = "BT_POLICE", menuName = "Behaviour Trees/BT_POLICE", order = 1)]
public class BT_POLICE : BehaviourTree
{
    /* If necessary declare BT parameters here. 
       All public parameters must be of type string. All public parameters must be
       regarded as keys in/for the blackboard context.
       Use prefix "key" for input parameters (information stored in the blackboard that must be retrieved)
       use prefix "keyout" for output parameters (information that must be stored in the blackboard)

       e.g.
       public string keyDistance;
       public string keyoutObject 
     */

     // construtor
    public BT_POLICE()  { 
        /* Receive BT parameters and set them. Remember all are of type string */
    }
    
    public override void OnConstruction()
    {
        /* Write here (method OnConstruction) the code that constructs the Behaviour Tree 
           Remember to set the root attribute to a proper node
           e.g.
            ...
            root = new SEQUENCE();
            ...

          A behaviour tree can use other behaviour trees.  
      */
        root = new Sequence(
           new ACTION_Arrive("thief","8"),
           new ACTION_Utter("0","2"),
           new ACTION_Arrive("exitPoint")
           ,new ACTION_DESTROY()

            );
    }
}
