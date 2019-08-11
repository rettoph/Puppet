/// <summary>
/// If dwFlags contains MOUSEEVENTF_WHEEL, then mouseData specifies the amount of wheel movement. 
/// A positive value indicates that the wheel was rotated forward, away from the user; a negative 
/// value indicates that the wheel was rotated backward, toward the user. One wheel click is defined 
/// as WHEEL_DELTA, which is 120.
/// 
/// Windows Vista: If dwFlags contains MOUSEEVENTF_HWHEEL, then dwData specifies the amount of wheel 
/// movement.A positive value indicates that the wheel was rotated to the right; a negative value 
/// indicates that the wheel was rotated to the left.One wheel click is defined as WHEEL_DELTA, which is 120.
/// 
/// If dwFlags does not contain MOUSEEVENTF_WHEEL, MOUSEEVENTF_XDOWN, or MOUSEEVENTF_XUP, then 
/// mouseData should be zero.
/// 
/// If dwFlags contains MOUSEEVENTF_XDOWN or MOUSEEVENTF_XUP, then mouseData specifies which X 
/// buttons were pressed or released. This value may be any combination of the following flags.
/// 
/// https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-mouseinput
/// </summary>
module.exports = {
    /// <summary>
    /// Set if the first X button is pressed or released.
    /// </summary>
    XBUTTON1: 0x0001,

    /// <summary>
    /// Set if the second X button is pressed or released.
    /// </summary>
    XBUTTON2: 0x0002
}