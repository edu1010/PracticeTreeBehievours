using UnityEngine;
using BTs;

[CreateAssetMenu(fileName = "BT_ANITA", menuName = "Behaviour Trees/BT_ANITA", order = 1)]
public class BT_ANITA : BehaviourTree
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
    public BT_ANITA()
    {
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
        root = new DynamicSelector();
        //Extra for police and thief behaviour
        root.AddChild(
            new CONDITION_ThiefInStore("theThief"),
            new Sequence(
                new ACTION_Deactivate("theNotes"),
                new ACTION_Utter("0", "2"),
                new ACTION_INVOKE_POLICE()
                )
            );
        root.AddChild(
            new CONDITION_CustomerInStore("theCustomer"),
            new Sequence(
                new ACTION_Deactivate("theBroom"),
                new ACTION_Deactivate("theNotes"),
                new ACTION_Utter("10"),
                new ACTION_Arrive("theFrontOfDesk"),
                new BT_SeeToCustomer()
                )
            );
        root.AddChild(
         new CONDITION_NoMoreFruit(),
         new Sequence(
             //new CONDITION_CheckExistences("apples"),
             new ACTION_ClearUtterance(),
             new ACTION_Arrive("theRestockPoint", "20"),
             new ACTION_ReStock(),
             new ACTION_DebugLog("saliendo?")
             )
         );
        root.AddChild(
            new CONDITION_AlwaysTrue(),
            new BT_SweepAndSing()
            );
       

    }
}
public class BT_SeeToCustomer : BehaviourTree
{
    public BT_SeeToCustomer()
    {

    }
    public override void OnConstruction()
    {
        root = new Sequence(
            new ACTION_EngageInDialog("theCustomer"),
            new ACTION_AskEngaged("11", "2", "theAnswer"),//revisar si los parametros que hay que pasar son estos<====================================================
            new Selector(
                new Sequence(
                    new ACTION_ParseAnswer("theAnswer", "theProduct"),//revisar, creo que es esto ???=================================
                    new ACTION_TellEngaged("13", "2"),
                    new BT_SELL_PRODUCT()
                    ),
                new ACTION_TellEngaged("12", "2")//Apologize
                ),
            new ACTION_DisengageFromDialog(), 
            new ACTION_ClearUtterance()
            );

    }

}
public class BT_SweepAndSing : BehaviourTree
{
    public BT_SweepAndSing()
    {

    }
    public override void OnConstruction()
    {
        root = new Sequence(
            new ACTION_ClearUtterance(),
            new ACTION_Activate("theBroom"),
            new ACTION_Activate("theNotes"),
            new ACTION_WanderAround("theSweepingPoint", "0.5")//REVISAR QUE PUNTO Y QUE PESO SE DEBE PONER <==================================================================
            );
    }

}

public class BT_SELL_PRODUCT : BehaviourTree
{
    public BT_SELL_PRODUCT() { }
    public override void OnConstruction()
    {
        root = new Selector(
            new Sequence(
                new CONDITION_CheckExistences("theProduct"),
                new ACTION_Sell("theProduct"),
                new ACTION_TellEngaged("14", "2")//here you have                
                ),
             new ACTION_TellEngaged("12", "2")//Apologize           

            );
    }
}