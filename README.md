# ScreenDoctor
Idea and tool to define and enhance screenshots to be used in a user documentation

An existing GUI test tool is used for GUI testing (not covered here).
In an ideal world a GUI test suite for a software covers the whole UI, especially showing all possible screens and relevant screen states.

On the other hand for user manuals it's often required to take screenshots for illustration purposes.
Changing code may lead to different visual appearances of the system even on screenshots not being the "topic" of a screenshot in the existing user documentation.

ScreenDoctor aims to use existing GUI tests with minor extensions to generate screenshots and augment those with necessary markers.

## How it should work
Let's say we want to generate a screenshot like the following:

![Screenshot Huggle 3, Wikipedia](https://upload.wikimedia.org/wikipedia/commons/a/a9/Huggle_3_-_Screenshot_%28numbred%29.png)
(Screenshot by Josve05a (Huggle software) [LGPL (http://www.gnu.org/licenses/lgpl.html), GFDL (http://www.gnu.org/copyleft/fdl.html) or CC-BY-SA-3.0 (http://creativecommons.org/licenses/by-sa/3.0/)], via Wikimedia Commons)

The underlying picture may be part of our software we are testing/developing.

The planned process should be

### One-time manual work
- determine when within a GUI test the screen shows what should be part of the documentation (if necessary, enhance, change or add a GUI test accordingly).
- Include a GUI test procedure at that place that is parametrized with
 - the area to put into the image (may be a reference to a control, a relative part of another control or the complete screen)
 - a list of marker-areas to measure (as references to ui-elements the test tool can determine with it's usual mechanisms)
 - all necessary information where to store the results

### By the GUI test tool
- Let the GUI test open the view that assembles the underlying screenshot
- As part of the GUI test take a screenshot of a given area (full desktop, full window, part of a window)
- As part of the GUI test write a log file that describes predefined "target areas", later to be used for marker placement or other highlightings

### By ScreenDoctor
- Take the screenshot, the log file and the configuration file
- from the configuration file take what kind of augmentation should be used (borders, numeric markers, text with a line aiming to the position, ...), how it should be used (color, font, ...) and what's the content (text/number of the marker etc)
- from the log file take where these augmentations have to be added
- manipulate the screenshot accordingly and save it (preferred as another file).
