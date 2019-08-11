const JoystickSlice = require('./JoystickSlice.js');
const InputFactory = require('./InputFactory.js');
const DwFlag = require('./KeyBoardInputDwFlag.js');

class KeyJoystickSlice extends JoystickSlice {
    handleStart() {
        super.handleStart();

        console.log('Starting Key Press!', this.data);

        InputFactory.SendKeyboardInput(this.data, DwFlag.KEYEVENTF_UNICODE);
    }

    handleEnd() {
        super.handleEnd();

        console.log('Ending Key Press!', this.data);

        InputFactory.SendKeyboardInput(this.data, DwFlag.KEYEVENTF_UNICODE + DwFlag.KEYEVENTF_KEYUP);
    }
}

module.exports = KeyJoystickSlice;