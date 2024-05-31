using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Image actorImage;
    public TextMeshProUGUI actorName;
    public TextMeshProUGUI messageText;
    public RectTransform backgroundBox;

    public float typingSpeed = 0.05f;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;
    public static bool isActive = false;

    private bool isTyping = false;
    private bool skipTyping = false;

    public PlayableDirector playableDirector;
    public Image timelineImage;

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive = true;

        Debug.Log("Started conversation! Loaded messages: " + messages.Length);
        DisplayMessage();
    }
    void DisplayMessage()
    {
        StopAllCoroutines();
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;

        // Start the typing effect
        StartCoroutine(TypeScentence(messageToDisplay.message));
    }
    public void NextMessage()
    {
        if (isTyping)
        {
            skipTyping = true;
        }
        else
        {
            activeMessage++;
            if (activeMessage < currentMessages.Length)
            {
                DisplayMessage();
            }
            else
            {
                Debug.Log("Conversation Ended!");
                isActive = false;

                playableDirector.Play();

                StartCoroutine(WaitAndLoadScene());
            }
        }
    }
    void Start()
    {
        // Subscribe to the PlayableDirector played event
        playableDirector.played += OnPlayableDirectorPlayed;
        timelineImage.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) && isActive == true)
        {
            NextMessage();
        }
    }
    IEnumerator TypeScentence(string sentence)
    {
        messageText.text = "";
        isTyping = true;
        skipTyping = false;

        foreach (char letter in sentence.ToCharArray())
        {
            if (skipTyping)
            {
                messageText.text = sentence;
                break;
            }

            messageText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }
    void OnPlayableDirectorPlayed(PlayableDirector director)
    {
        if (director == playableDirector)
        {
            // Enable the image when the timeline starts playing
            timelineImage.enabled = true;
        }
    }
    IEnumerator WaitAndLoadScene()
    {
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene("SampleScene");
    }
}
