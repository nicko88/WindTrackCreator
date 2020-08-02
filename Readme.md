# WindTrackCreator
#### Create wind track files for [HTFanControl](https://github.com/nicko88/HTFanControl)

WindTrackCreator is an application meant to help create wind tracks for the [HTFanControl](https://github.com/nicko88/HTFanControl) program.

### Screenshot

<img src="https://user-images.githubusercontent.com/1866075/89132030-cca9ee80-d4d6-11ea-87bb-0f1ca061ba42.png" width="549px" />

### Getting Started

* Open up WindTrackCreator.
* Load the movie you want to work on in your MPC-HC/BE or Kodi media player.
* Enter in the connection information for your media player.
* Seek through the movie and press the OFF, ECO, LOW, MED, and HIGH buttons (or their cooresponding numpad hotkeys) to insert fan commands at that time.
* You can click the Seek button to jump to an existing fan command time.
* Don't forget to save your work when you are done.

The spinup and spindown offset numbers at the bottom are just there to help you format your command times with reasonable timing gaps.  Time code lines will highlight in red if 2 commands are closer than 500ms from each other and lines will highlight in yellow if the spinup (commands following an OFF) or spindown (OFF commands) times when subtracted from the time code would put the time code closer than 500ms to the previous command.

It is recommended to not place 2 time codes closer than 500ms apart or to place spinup and spindown commands closer than their set times plus 500ms.  If this happens, HTFanControl will simply round the next time code to be exactly 500ms after the previous one, so nothing too terrible will happen, just your commands wont be sent to the fans exactly when you expected them to be.

### Wind Track File Format

The Wind Track file format starts with a header in which each header line start with a #.  The header lines are as follows:

**\# Movie Title (Year)**  
**\# Disc Format (Duration)**  
**\# Offset: Disc Format (Offset time amount)**  
**\# Coded by: Username**

Where **Disc Format** is either **"HD Blu-ray"** or **"4K Ultra HD Blu-ray"**

The **# Offset:** line is an optional line which can be used to specify a disc format offset so the wind track can be used with a different version of the disc.

It is sometimes the case where the HD Blu-ray and 4K Ultra HD Blu-ray contain different "studio logo" intro screens before the actual movie starts, and this requires that all the wind track commands be offset by some positive or negative amount.

For example, if you coded your wind track for the 4K Ultra HD Blu-ray, and the HD Blu-ray has an extra 10.5 seconds of logos at the beginning, you would add a line to the header that looks like this:

**\# Offset: HD Blu-ray (00:00:10.500)**  

The offset amount is always relative to the disc format that the track was originally created for.  To add a negative offset simply put a minus sign "-" before the first set of 00.

The easiest way to find this exact offset is to open both copies of the movie in your media player, and seek the movie to the exact the same frame (you can usually use chapter skip to accomplish this) and then subtract the time code of the frame between each disc copy.

If you don't have access to both disc versions then simply leave this line out.

The header is then followed by a blank line and then the time codes and fan speed commands which are in this format:

**HH:MM:SS.MIL,CMD**

HH = Hours  
MM = Minutes  
SS = Seconds  
MIL = Milliseconds

##### CMD List (in order of wind speed):
* OFF
* ECO
* LOW
* MED
* HIGH

#### Example:

**\# Jurassic Park (1993)**  
**\# 4K Ultra HD Blu-ray (02:06:28)**  
**\# Coded by: SOWK**
 
**00:09:40.915,LOW**  
**00:09:43.374,HIGH**  
**...**

### Sharing Your Wind Track Files

I encourage you to post and share the wind track files you make with others over on the community forum.  Someone there will then upload your wind track to the online database on Pastebin [here](https://pastebin.com/u/SOWK).

When your wind track is uploaded to the pastebin database, it will also become available for other users to download directly from their HTFanControl web interface.

### Community

Visit the forum thread for this project and the main HTFanControl project [here](https://www.avsforum.com/forum/28-tweaks-do-yourself/3152346-4d-theater-wind-effect-diy-home-theater-project.html).