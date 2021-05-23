I've been waiting for you. Glad you're here!
*   what? Why are you waiting for me?
    - I need you to open that door for me. #Event.ShowGreenDoor
    * I'll try but I'm not sure what to do. -> instructions
    * I don't think I want to do that right now. 
      Okay bye! -> END
    
    
== instructions ==
You can open the door from the control panel. #Event.EndShowGreenDoor #Event.ShowControlPanel
    * Why can't you do that?
      I'm too wide..
      * * Okay, I'm on it!
          Thanks! #Event.EndShowControlPanel #Quest.InspectTheControlPanel # -> END 
    
- -> END 