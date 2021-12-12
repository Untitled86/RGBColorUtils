# RGBColorUtils
Code to mix RGB colors 100% accurately using the additive method.

I was unable to find code that properly mixed RGB colors using the additive approach.  I found snibbits here and there for distance, linear mixing, etc. then combined them into one simple class that gets the job done.

Example syntax:  

Color mixedColor = mixer.Additive(Color.Red, Color.Green, 0.5f); //Makes Yellow
