const lerp = require('lerp');

/*
 * Simple class used to contain
 * joystick slice data and should have the ability
 * to self render itself on a joystick each frame
 */
class JoystickSlice {
    constructor(data) {
        this.data = data;
    }

    initialize(joystick, radians, theta) {
        this.joystick = joystick;
        this.radians = radians;
        this.theta = this.normalizeAngle(theta);
        this.active = false;
        this.alpha = 0;

        this.thetaStart = this.normalizeAngle(this.theta - (this.radians / 2));
        this.thetaEnd = this.thetaStart + this.radians;

        console.log('JoystickSlice - Initialized');
    }

    update() {
        // Check if the current joystick slice is active
        if (this.joystick.touched && this.joystick.distance > this.joystick.buffer && this.joystick.distance < this.joystick.radius) {
            var oldActive = this.active;
            this.active = (this.thetaStart < this.joystick.theta && this.joystick.theta < this.thetaEnd) ||
                (this.thetaStart < ((Math.PI * 2) + this.joystick.theta) && ((Math.PI * 2) + this.joystick.theta) < this.thetaEnd);

            if (this.active && !oldActive)
                this.handleStart();
            else if (!this.active && oldActive)
                this.handleEnd();
        }
        else if (this.active) {
            this.active = false;
            this.handleEnd();
        }

        this.alpha = lerp(this.alpha, this.active ? 1 : 0, 0.1);
    }

    drawShape() {
        this.joystick.ctx.moveTo(this.joystick.x + this.getX(this.thetaStart, this.joystick.radius), this.joystick.y + this.getY(this.thetaStart, this.joystick.radius));
        this.joystick.ctx.arc(this.joystick.x, this.joystick.y, this.joystick.buffer, this.thetaStart, this.thetaEnd);
        this.joystick.ctx.lineTo(this.joystick.x + this.getX(this.thetaEnd, this.joystick.radius), this.joystick.y + this.getY(this.thetaEnd, this.joystick.radius));
        this.joystick.ctx.arc(this.joystick.x, this.joystick.y, this.joystick.radius, this.thetaEnd, this.thetaStart, true);
        this.joystick.ctx.lineTo(this.joystick.x + this.getX(this.thetaStart, this.joystick.buffer), this.joystick.y + this.getY(this.thetaStart, this.joystick.buffer));
    }
    drawBackground() {
        this.joystick.ctx.globalAlpha = this.alpha;
        this.joystick.ctx.fillStyle = '#70a1ff';
        this.joystick.ctx.beginPath();
        this.drawShape();
        this.joystick.ctx.fill();
    }
    drawForeground() {
        this.joystick.ctx.globalAlpha = 1;
        this.joystick.ctx.strokeStyle = '#57606f';
        this.joystick.ctx.beginPath();
        this.drawShape();
        this.joystick.ctx.stroke();
    }

    getX(theta, radius) {
        return Math.cos(theta) * radius;
    }

    getY(theta, radius) {
        return Math.sin(theta) * radius;
    }

    normalizeAngle(angle) {
        return angle - (Math.PI * 2) * Math.floor((angle + Math.PI) / (Math.PI * 2));
    }  

    handleStart() {
        // 
        window.navigator.vibrate(20);
    }

    handleEnd() {
        // 
        window.navigator.vibrate(10);
    }
}

module.exports = JoystickSlice;