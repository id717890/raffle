import config from '@/packages/config'
import Vue from 'vue'

export default {
  getInfo () {
    if (config.isLocalApp()) {
      return new Promise((resolve) => { resolve(data) })
    } else {
      return Vue.$http.get('api/info/totalinfo').then((x) => {
        return x
      }).catch(error => {
        return error
      })
    }
  }
}

const data = {
  totalUsers: 11,
  totalGifts: 7,
  totalKeys: 39
}
