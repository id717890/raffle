import Vue from 'vue'
import axios from 'axios'

// console.log(Vue.prototype.$auth.getToken());

const Axios = axios.create({
  baseURL: 'https://localhost:44379',
  // baseURL: 'http://localhost/enw/backend/public/',
  headers: {
    // Accept: 'application/json',
    // 'Content-Type': 'application/json',
    // 'X-Requested-With': 'XMLHttpRequest',
  }
})

Axios.interceptors.request.use((config) => {
  config.headers.Authorization = 'Bearer ' + Vue.auth.getToken()
  return config
})

export default Axios
