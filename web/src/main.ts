import Vue from 'vue'
import router from './router'
import App from './App.vue'
import './registerServiceWorker'
import VModal from 'vue-js-modal'


Vue.config.productionTip = false
Vue.use(VModal, { componentName: "navi-modal", dialog: true })

new Vue({
  router,
  render: h => h(App)
}).$mount('#app')
