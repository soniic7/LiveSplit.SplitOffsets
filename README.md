# Split Offsets

### This component does not work with autosplitters which constantly change the In-Game Time (By using the gameTime block for example). 
### This only works with the In-Game Timer (IGT). RTA is not effected
To enable IGT:
- right click LiveSplit
- find Compare Against
- select Game Time



## About
This component adds a specified IGT offset to the timer at the beginning of the split.  The offset is specified in a tag within the split's name. This was design with LEGO Indiana Jones: The Original Adventures in mind in order to add cutscene offsets to nocut practice splits automatically.

## How to use
1. Install the component
2. Add the component to your LiveSplit layout (Control -> Split Offsets)
3. Add an offset tag to the desired splits' names. Tag examples are shown below.

## Tag syntax examples

Below are some examples of offset tags. These are placed within the name of the split. If the tag is formatted incorrectly, the offset will not be added to the timer.

[45.0] Split name here \
[4.312] Test \
[10:03:41.111] Hours included \
[4:31] Minutes seconds \
One decimal place [15:11.1] \
Two decimal [0:11.22] places \
[131.34] Total seconds 




## Settings
### Enable Split Offsets
When checked, enables the offset addition to the timer.


### Tag Enclosure
Changes the split name tags that determine the offset. \
Options:
- Square Brackets [] 
- Parentheses () 
- Curly Braces {} 
- Angle Brackets <> 







## How to install
1. Navigate to releases
2. Download LiveSplit.SplitOffsets.dll from the latest release
3. Navigate to the Components folder inside your LiveSplit installation directory
4. Place LiveSplit.SplitOffsets.dll in the Components folder

