import Vue from 'vue'
import Router from 'vue-router'

Vue.use(Router)

export default new Router({
    routes: [{
        path: '/',
        component: require('./App.vue').default,
    }, {
        path: '/:user',
        component: require('./components/HelloWorld.vue').default,
    }],
    mode: "hash"
})