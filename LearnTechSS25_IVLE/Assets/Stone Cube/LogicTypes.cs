using JetBrains.Annotations;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public enum LogicType
{  
    Not,           
    And,          
    Or,            
    Implies,
    EqRelation,    
    ConstTrue,  
    ConstFalse,
    KlammerAuf,
    KlammerZu,
    A,
    E,
    NotEqual,
    Equal,
    X,
    Y,
    Frage
}

public class LogicBlock : MonoBehaviour
{

    public bool Interactables;
    public bool Blank;
    public bool correct;    

    public LogicType type;
    public LogicType[] additionalTypes;

    public Material Not;
    public Material And;
    public Material Or;
    public Material Implies;
    public Material EqRelation;
    public Material ConstTrue;
    public Material ConstFalse;
    public Material KlammerAuf;
    public Material KlammerZu;
    public Material E; 
    public Material A;
    public Material Equal;
    public Material NotEqual;
    public Material Invisible;
    public Material X;
    public Material Y;
    public Material Frage;

    private Renderer renderer;

    private Rigidbody rigidbody;
    private XRBaseInteractable grabinteractable;
    private CheckSelected cs;
    private SnapCubeHere snap;
    private HelpAudio helpAudio;
    


    private void Start()
    {
        correct = false;
        renderer = GetComponent<Renderer>();
        rigidbody = GetComponent<Rigidbody>();
        grabinteractable = GetComponent<XRBaseInteractable>();
        cs = GetComponent<CheckSelected>();
        snap = GetComponent<SnapCubeHere>();
        rigidbody.isKinematic = true;


        UpdateMaterial();

        if (Interactables){
            grabinteractable.enabled = true;
            cs.enabled = true;
        }

        if (Blank) {
            
            snap.enabled = true;

            if(type == LogicType.Frage)
            {
                renderer.material = Frage; 
            }else
            {
                renderer.material = Invisible; 
            }
            
        }

    }


    private void UpdateMaterial()
    {
        switch (type)
        {
            case LogicType.Not:
                renderer.material = Not;
                break;
            case LogicType.And:
                renderer.material = And;
                break;
            case LogicType.Or:
                renderer.material = Or;
                break;
            case LogicType.Implies:
                renderer.material = Implies;
                break;
            case LogicType.EqRelation:
                renderer.material = EqRelation;
                break;
            case LogicType.ConstTrue:
                renderer.material = ConstTrue;
                break;
            case LogicType.ConstFalse:
                renderer.material = ConstFalse;
                break;
            case LogicType.Equal:
                renderer.material = Equal;
                break;        
            case LogicType.NotEqual:
                renderer.material = NotEqual;
                break;     
            case LogicType.KlammerAuf:
                renderer.material = KlammerAuf;
                break;            
            case LogicType.KlammerZu:
                renderer.material = KlammerZu;
                break;            
            case LogicType.E:
                renderer.material = E;
                break;            
            case LogicType.A:
                renderer.material = A;
                break;
            case LogicType.X:
                renderer.material = X;
                break;
            case LogicType.Y:
                renderer.material = Y;
                break;
            case LogicType.Frage:
                renderer.material = Frage;
                break;
            
        }
    }


    public bool CheckSolution(LogicType SolutionType) {
        if (type == SolutionType)
        {
            // In parentObject:
            // set blankCubeCounter += 1 
            // set variable for this cube to true (right block set)
            // TODO BUG
            correct = true;
            Debug.Log("right");
        }
        else if (!(additionalTypes.Length == 0))
        {
            foreach (LogicType adType in additionalTypes) { 
                if(type == adType)
                {
                    correct = true;
                    break;
                }
            }
        }

        if (type == LogicType.Frage)
        {
            if (SolutionType != LogicType.Frage)
            {
                HelpAudio helpAudio = GetComponent<HelpAudio>();
                helpAudio.PlayAudioForType(SolutionType);
                return true;
            }
            else
            {
                // In parentObject:
                // set blankCubeCounter += 1 
                // set variable for this cube to false (right block set)
                correct = false;
                Debug.Log("wrong");
                
            }
        }
        return false;
    }
}
