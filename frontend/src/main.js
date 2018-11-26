import Vue from 'vue'
import BootstrapVue from 'bootstrap-vue'
import App from './App'
import router from './router'
import {store} from './store'
import '@/assets/css.css'
import 'bootstrap/dist/css/bootstrap.min.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import AxiosConfig from '@/api/http-config'
import Auth from './packages/auth'

Vue.use(BootstrapVue)
Vue.config.productionTip = false
Vue.$http = AxiosConfig
Vue.use(Auth)

/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  store,
  render: h => h(App)
})
