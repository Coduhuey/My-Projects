using System;
using UnityEngine;

[Serializable] //making a class by yourself requires you to make it serializable for it to show up in inspector
public class TankManager //doesn't come with start, fixed update, and all that; must be setup
{
    public Color m_PlayerColor;            
    public Transform m_SpawnPoint;         
    [HideInInspector] public int m_PlayerNumber;             
    [HideInInspector] public string m_ColoredPlayerText;
    [HideInInspector] public GameObject m_Instance; //to turn off/on tank         
    [HideInInspector] public int m_Wins;                     


    private TankMovement m_Movement;       //scripts for tank
    private TankShooting m_Shooting;
    private GameObject m_CanvasGameObject; //and UI


    public void Setup() //public for GameManager
    {
        m_Movement = m_Instance.GetComponent<TankMovement>();
        m_Shooting = m_Instance.GetComponent<TankShooting>();
        m_CanvasGameObject = m_Instance.GetComponentInChildren<Canvas>().gameObject; //finding the canvas then taking the gameobject of it

        m_Movement.m_PlayerNumber = m_PlayerNumber;
        m_Shooting.m_PlayerNumber = m_PlayerNumber;

        m_ColoredPlayerText = "<color=#" + ColorUtility.ToHtmlStringRGB(m_PlayerColor) + ">PLAYER " + m_PlayerNumber + "</color>"; //chooses to change color, function to change color of text, then text inside, then finishing the color deciding html tag

        MeshRenderer[] renderers = m_Instance.GetComponentsInChildren<MeshRenderer>(); //grabs the mesh renderers that make up the take to change their color

        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material.color = m_PlayerColor; //changing the color of the material component for each meshrender
        }
    }


    public void DisableControl()
    {
        m_Movement.enabled = false;
        m_Shooting.enabled = false;

        m_CanvasGameObject.SetActive(false);
    }


    public void EnableControl()
    {
        m_Movement.enabled = true;
        m_Shooting.enabled = true;

        m_CanvasGameObject.SetActive(true);
    }


    public void Reset()
    {
        m_Instance.transform.position = m_SpawnPoint.position;
        m_Instance.transform.rotation = m_SpawnPoint.rotation;

        m_Instance.SetActive(false);
        m_Instance.SetActive(true);
    }
}
