# ScreenDoctor
Idea and tool to define and enhance screenshots to be used in a user documentation

An existing GUI test tool is used for GUI testing (not covered here).
In an ideal world a GUI test suite for a software covers the whole UI, especially showing all possible screens and relevant screen states.

On the other hand for user manuals it's often required to take screenshots for illustration purposes.
Changing code may lead to different visual appearances of the system even on screenshots not being the "topic" of a screenshot in the existing user documentation.

ScreenDoctor aims to use existing GUI tests with minor extensions to generate screenshots and augment those with necessary markers.

## How it should work

Let's say we want to generate a screenshot like the following:

<a href="https://commons.wikimedia.org/wiki/File%3AHuggle_3_-_Screenshot_(numbred).png"><img width="512" alt="Huggle 3 - Screenshot (numbred)" src="https://upload.wikimedia.org/wikipedia/commons/thumb/a/a9/Huggle_3_-_Screenshot_%28numbred%29.png/512px-Huggle_3_-_Screenshot_%28numbred%29.png"/></a><br/>
(Uploaded by Josve05a (Huggle software) [LGPL (http://www.gnu.org/licenses/lgpl.html), GFDL (http://www.gnu.org/copyleft/fdl.html) or CC-BY-SA-3.0 (http://creativecommons.org/licenses/by-sa/3.0/)], via Wikimedia Commons)

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

## Format Specification

### Configuration file (to be read by the GUI test tool)

A single screenshot is defined in one single file.
The file is a text file X.txt.

1. The first line must contain the target file name without an extension.
2. The second line must be a way that allows the GUI test tool to identify the necessary screenshot target area. How this is defined may be different for different test tools and UI technology.
3. The third line must not be empty and defines the delimiting string for the augmentation requests (may be a single character or more, but must not be part of the output)
3. The third line is an empty line
4. Starting at this line every line requests an augmentation request in the following format
    2. a name to identify this request in the output file
    3. the split string
    2. an identification for the area to be measured, dependent on the UI test tool used.
    3. the split string
    3. type of highlight to be created by ScreenDoctor later (for allowed values see below)
    4. the split string
    3. a label text to be used within the label

### Metadata file (to be written by the GUI test tool and read by ScreenDoctor)

The GUI test tool should take the configuration file as specified above and produce the following output

1. An image file with the name specified in line 1 of the configuration file, followed by the extension .png
2. A measurement file with one line per augmentation request from the configuration file. Each line is a list of values delimited by the same delimiting character specified in the configuration file (see above). The lines have the following format:
    3. the identifying name from the config file
    4. the split string
    5. the highlight type from the config file
    6. the split string
    7. the pixel coordinates of the measured area as left,top,right,bottom in pixels without units
    8. the split string
    7. the label text from the config file

### Highlighting formats
Highlighings are specified by one of the following string values.

1. Circle
2. Square
3. Diamond
4. CircleWithLine
5. SquareWithLine
6. DiamondWithLine
3. PureText

