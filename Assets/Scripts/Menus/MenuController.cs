using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using StarterAssets;

//Ce script sert à gérer un menu UI
//Il permet de définir les différents types de panneaux, de les ouvrir, de sélectionner des boutons par défaut pour des panneaux
//Il permet aussi d'associer des actions comme le changement de scène ou quitter le jeu


//Enumeration des différents types de panneaux possibles
public enum PanelType
{
    None,
    Main,
    Option,
    Astuces,
    Parametres,
    Commandes,
    Fail,
    Success

}

public class MenuController : MonoBehaviour
{

    [Header("Panels")]
    [SerializeField] private List<MenuPanel> panelsList = new List<MenuPanel>();
    private Dictionary<PanelType,MenuPanel> panelsDict = new Dictionary<PanelType,MenuPanel>();
    private GameManager manager;

    [SerializeField] private EventSystem eventController;
    [SerializeField] private GameLoader gameLoader;

    //Fonction qui se lance au lancement
    private void Start()
    {
        //Instancie un GameManager
        manager = GameManager.instance;

        //Ajoute tous les types de panneau au dictionnaire pour savoir quels panneaux font partie du menu
        foreach (var _panel in panelsList)
        {
            if(_panel) 
            {
                panelsDict.Add(_panel.GetPanelType(),_panel);
                _panel.Init(this);
            }
        }

        //Ouvre le panneau principal
        OpenOnePanel(PanelType.Main);
    }

    //Fonction qui ouvre un panneau et qui ferme tous les autres
    //Argument : un type de panneau (qui se trouve dans l'enum)
    public void OpenOnePanel(PanelType _type)
    {
        foreach (var _panel in panelsList) _panel.ChangeState(false);
        if(_type != PanelType.None) panelsDict[_type].ChangeState(true);
    }


    public void OpenPanel(PanelType _type)
    {
        OpenOnePanel(_type);
    }

    //Fonction qui appelle la fonction de changement de scene du GameLoader
    //Argument : nom de la scene
    public void ChangeScene(string _sceneName){
        gameLoader.ChangeScene(_sceneName);
    }

    //Fonction qui permet de fermer et quitter le jeu
    public void Quit()
    {
        manager.Quit();
    }

    //Fonction qui permet de sélectionner un bouton par défaut à l'ouverture d'un panneau
    //Argument : un GameObject button ou slider, etc
    public void SetSelectedGameObject(GameObject _element)
    {
        eventController.SetSelectedGameObject(_element);
    }

    //Fonction qui permet de désélectionner 
    public void SetSelectedGameObject()
    {
        eventController.SetSelectedGameObject(null);
    }
}
