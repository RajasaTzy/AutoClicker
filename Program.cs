using System.Runtime.InteropServices;





// Imports

[DllImport("user32.dll")]
static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, IntPtr DwExtraInfo);

[DllImport("user32.dll")]
static extern short GetAsyncKeyState(int vKey); // hotkey



// class variables

const uint LEFTDOWN = 0x02;
const uint LEFTUP = 0x04;
const int HOTKEY = 0x23;

bool enableClicker = false; // set it to false before we click the hotkey
int clickInterval = 5;

// main loop for autoclicker

while (true)
{
    if (GetAsyncKeyState(HOTKEY)<0) // if hotkey is down
    {
        enableClicker = !enableClicker; // enable or disable depending on the bool value
        Thread.Sleep(300); // a little delay between hotkey usage
    }

    if (enableClicker) // click if enabled :]
    {
        MouseClick();
    }
    Thread.Sleep(clickInterval);
}



// create mouse click

void MouseClick()
{
    mouse_event(LEFTDOWN, 0, 0, 0, IntPtr.Zero); // we dont need anymore information than the leftdown constant

    mouse_event(LEFTUP, 0, 0, 0, IntPtr.Zero); // press down then up
}