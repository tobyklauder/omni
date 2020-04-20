using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class tutorialtextcontroller : MonoBehaviour
{
    public GameObject siren;
    public GameObject closebutton;
    public Text text;
    public static int current;
    public string first;
    public string second;
    public string third;
    public string fourth;
    public string fifth;
    public string sixth; 
    // Start is called before the first frame update
    void Start()
    {
        closebutton.SetActive(false); 
        siren.SetActive(false); 
        first = "Omni Bot Wants to be a human,\n Sadly, pretty hard for a robot \n to be a human, so we need to stop omni - bot from doing \n human things that could hurt \n it. drinking water for example";
        text.text = first;
        current = 1; 
    }

    // Update is called once per frame
    void Update()
    {
        if (current == 1) {
            first = "Omni Bot Wants to be a human,\n Sadly, pretty hard for a robot \n to be a human, so we need to stop omni - bot from doing \n human things that could hurt \n it. drinking water for example";
            text.text = first;
        }
        if (current == 2) {
            second = "When Omni Bot reaches his target, you will see this alarm and the music will pick up. You'll have 15 seconds to find and stop him.";
            text.text = second;
            siren.SetActive(true); 
        }
        if (current == 3) {
            siren.SetActive(false);
            third = "How do you stop Omni-Bot you might ask? Either you can give him the old shove or you can drag certain items into his path. Omni-Bot is claustrophobic, so make the path narrow to his target.";
            text.text = third;
        }
        if (current == 4) {
            fourth = "Or just block the path entirely, I'm not the boss of you. Block him for 30 seconds and he will get bored and choose a new target.";
            text.text = fourth; 
        }
        if (current == 5) {
            fifth = "You keep Omni-Bot from his targets for two minutes and your today's lucky winner, or at least one of them. Keep an eye out for achievements by clicking on certain items.";
            text.text = fifth; 
        }
        if (current == 6) {
            sixth = "Some items will tell you what they are over-top. Those are targets for the robot, or achievements. There are some super secret unmarked achievements as well.";
            text.text = sixth;
            closebutton.SetActive(true);
        }
    }

    public void ChangeText() {
        current++; 
    }

    public static void resetcurrent() {
        current = 1;
    }
}
