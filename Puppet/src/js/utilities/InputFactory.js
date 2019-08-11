const InputType = require('./InputType.js');
const MouseInputDwFlag = require('./MouseInputDwFlag.js');
const KeyboardInputDwFlag = require('./KeyboardInputDwFlag.js');
const KeyCode = require('./KeyCode.js');
const Client = require('./SocketClient.js');

/*
 * Simple class used to create data structures
 * that can be send directly to the server's
 * User32 library.
 */
class InputFactory {
    SendMouseInput(dx, dy, dwFlags, mouseData, time, dwExtraInfo) {
        Client.send(
            this.CreateMouseInput(
                dx, dy, dwFlags, mouseData, time, dwExtraInfo));
    }

    CreateMouseInput(dx, dy, dwFlags, mouseData, time, dwExtraInfo) {
        if (dx == null)
            dx = 0;
        if (dy == null)
            dy = 0;
        if (dwFlags == null)
            dwFlags = MouseInputDwFlag.MOUSEEVENTF_MOVE;
        if (mouseData == null)
            mouseData = 0;
        if (time == null)
            time = 0;
        if (dwExtraInfo == null)
            dwExtraInfo = 0;

        // Sanatize the input data
        dx = Math.round(dx);
        dy = Math.round(dy);
        mouseData = Math.round(mouseData);

        return {
            type: InputType.INPUT_MOUSE,
            u: {
                mi: {
                    dx: dx,
                    dy: dy,
                    mouseData: mouseData,
                    dwFlags: dwFlags,
                    time: time,
                    dwExtraInfo: dwExtraInfo
                }
            }
        }
    }

    SendKeyboardInput(wvk, dwFlags, wScan, time, dwExtraInfo) {
        Client.send(
            this.CreateKeyboardInput(
                wvk, dwFlags, wScan, time, dwExtraInfo));
    }

    CreateKeyboardInput(wvk, dwFlags, wScan, time, dwExtraInfo) {
        if (wvk == null)
            wvk = 0;
        if (dwFlags == null)
            dwFlags = 0;
        if (wScan == null)
            wScan = 0;
        if (time == null)
            time = 0;
        if (dwExtraInfo == null)
            dwExtraInfo = 0;

        return {
            type: InputType.INPUT_KEYBOARD,
            u: {
                ki: {
                    wvk: wvk,
                    dwFlags: dwFlags,
                    wScan: wScan,
                    time: time,
                    dwExtraInfo: dwExtraInfo
                }
            }
        }
    }
}

module.exports = new InputFactory();