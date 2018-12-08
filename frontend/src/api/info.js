import config from '@/packages/config'

export default {
  getInfo () {
    if (config.isLocalApp()) {
      return new Promise((resolve) => { resolve(data) })
    } else {
    }
  }
}

const data = {
  totalUsers: 11,
  totalGifts: 7,
  totalKeys: 39
}
