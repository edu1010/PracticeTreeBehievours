using UnityEngine;
using BTs;

[CreateAssetMenu(fileName = "BT_POLICE", menuName = "Behaviour Trees/BT_POLICE", order = 1)]
public class BT_POLICE : BehaviourTree
{
     // construtor
    public BT_POLICE()  { 
        /* Receive BT parameters and set them. Remember all are of type string */
    }
    
    public override void OnConstruction()
    {
        root = new Sequence(
           new ACTION_Arrive("thief","8"),
           new ACTION_Utter("0","2"),
           new ACTION_Arrive("exitPoint"),
           new ACTION_DESTROY()
            );
    }
}
