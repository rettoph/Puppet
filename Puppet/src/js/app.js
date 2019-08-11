const client = require('./utilities/SocketClient.js');
const Vue = require('vue');
const VueRouter = require('vue-router').default;

/*
 * Setup Vue
 */
Vue.use(VueRouter);

/*
 * Setup application components
 */
Vue.component('fullscreen', require('./components/FullScreenComponent.vue.html').default);
Vue.component('touch', require('./components/TouchComponent.vue.html').default);
Vue.component('trackpad', require('./components/TrackpadComponent.vue.html').default);
Vue.component('joystick', require('./components/JoystickComponent.vue.html').default);
Vue.component('key-joystick', require('./components/KeyJoystickComponent.vue.html').default);

/*
 * Setup application routes
 */
const routes = [
    { path: '/', component: require('./pages/home.vue.html').default },
];

/*
 * Setup some basic message handlers
 */
client.bind('system', (d) => {
    console.log('System Message:', d);
});


/*
 * Create vue application 
 */
window.router = new VueRouter({
    mode: 'history',
    base: __dirname,
    routes: routes
});
document.addEventListener('DOMContentLoaded', function (e) {
    window.app = new Vue({
        router 
    }).$mount('#app');
});
