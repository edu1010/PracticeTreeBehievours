using UnityEngine;
using BTs;

[CreateAssetMenu(fileName = "BT_THIEF", menuName = "Behaviour Trees/BT_THIEF", order = 1)]
public class BT_THIEF : BehaviourTree
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
    public BT_THIEF()  { 
        /* Receive BT parameters and set them. Remember all are of type string */
    }
    
    public override void OnConstruction()
    {
        root = new Sequence(
            new ACTION_Arrive("storeEntrance", "4"),//llegar
            new ACTION_Utter("1", "2"),//Gritar
            new RepeatUntilSuccessDecorator(
                new CONDITION_InstanceNear("9", "policeTag")
                ),
            new ACTION_WaitForSeconds("2"),
            new ACTION_Arrive("exitPoint")//irse detenido
            ,new ACTION_DESTROY()

            );
    }
}
